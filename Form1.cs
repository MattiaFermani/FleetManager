namespace FleetManager
{
    public partial class Form1 : Form
    {
        private Dictionary<PageType, UserControl> _userControls = new Dictionary<PageType, UserControl>();

        // CORREZIONE 1: Dichiarazione della variabile di stato
        private PageType _currentPage;

        public Form1()
        {
            InitializeComponent();

            // CORREZIONE 2: Avvio del thread di monitoraggio
            _ = WatchdogConnessione();

            if (string.IsNullOrWhiteSpace(Database.ConnectionString))
            {
                // CORREZIONE 3: Verifica il nome corretto del tuo oggetto ToolStripMenuItem (es. impostazioniToolStripMenuItem)
                MenuSelection(PageType.Impostazioni, impostazioni_MenuItem);
                SideBar.Enabled = false;
                MessageBox.Show("Per favore, configura prima la connessione al database.", "Configurazione richiesta");
            }
            else
            {
                MenuSelection(PageType.Dashboard, dashboard_MenuItem);
            }
        }

        private void MenuSelection(PageType page, ToolStripMenuItem selectedItem)
        {
            // Aggiorniamo sempre la pagina corrente per il Watchdog
            _currentPage = page;

            ResetMenuColors();
            selectedItem.BackColor = Color.LightBlue;

            if (!_userControls.ContainsKey(page))
            {
                _userControls[page] = CreateControl(page);
            }

            ShowControl(_userControls[page]);
        }

        private UserControl CreateControl(PageType page)
        {
            switch (page)
            {
                case PageType.Dashboard: return new UC_Dashboard();
                case PageType.Flotta: return new UC_Veicoli();
                case PageType.Personale: return new UC_Guidatori();
                case PageType.Impostazioni: return new UC_DbConnection();
                // Aggiungi i casi mancanti per evitare eccezioni
                case PageType.Incidenti: return new UC_Incidenti();
                case PageType.Statistiche: return new UC_Statistiche();
                default: throw new ArgumentException("Pagina non gestita");
            }
        }

        private void ShowControl(UserControl sonC)
        {
            pnlContainer.SuspendLayout();
            pnlContainer.Controls.Clear();
            sonC.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(sonC);
            pnlContainer.ResumeLayout();
        }

        private void ResetMenuColors()
        {
            // Nota: Se SideBar è un MenuStrip, usa SideBar.Items
            foreach (ToolStripItem item in SideBar.Items)
            {
                item.BackColor = SystemColors.Control;
            }
        }

        // Gestori eventi (Assicurati che i nomi corrispondano a quelli del Designer)
        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Dashboard, (ToolStripMenuItem)sender);

        private void flottaToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Flotta, (ToolStripMenuItem)sender);

        private void personaleToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Personale, (ToolStripMenuItem)sender);

        private void impostazioniToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Impostazioni, (ToolStripMenuItem)sender);


        private async Task WatchdogConnessione()
        {
            while (true)
            {
                bool connessioneValida = await Task.Run(() => {
                    try
                    {
                        using (var conn = Database.Connection())
                        {
                            conn.Open();
                            return true;
                        }
                    }
                    catch { return false; }
                });

                // Sposta l'esecuzione sul thread della UI per modificare i controlli
                this.Invoke(new Action(() => AggiornaStatoApplicazione(connessioneValida)));

                await Task.Delay(5000);
            }
        }

        private void AggiornaStatoApplicazione(bool connessioneOk)
        {
            if (connessioneOk)
            {
                if (!SideBar.Enabled)
                {
                    SideBar.Enabled = true;
                    MenuSelection(PageType.Dashboard, dashboard_MenuItem);
                }
            }
            else
            {
                if (SideBar.Enabled || _currentPage != PageType.Impostazioni)
                {
                    SideBar.Enabled = false;
                    if (_currentPage != PageType.Impostazioni)
                    {
                        MenuSelection(PageType.Impostazioni, impostazioni_MenuItem);
                    }
                }
            }
        }
    }

public enum PageType
    {
        Dashboard,
        Flotta,
        Personale,
        Incidenti,
        Statistiche,
        Impostazioni
    }
}
