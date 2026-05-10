using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using FleetManager.DB;

namespace FleetManager
{
    public partial class Form1 : Form
    {
        private Dictionary<PageType, UserControl> _userControls = new Dictionary<PageType, UserControl>();

        private PageType _currentPage;

        public Form1()
        {
            InitializeComponent();


            if (string.IsNullOrWhiteSpace(Database.ConnectionString))
            {
                MenuSelection(PageType.Impostazioni, impostazioni_MenuItem);
                SideBar.Enabled = false;
                MessageBox.Show("Per favore, configura prima la connessione al database.", "Configurazione richiesta");
            }
            else
            {
                MenuSelection(PageType.Dashboard, dashboard_MenuItem);
            }


            _ = WatchdogConnessione();
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
            while (!this.IsDisposed)
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

                if (!this.IsDisposed)
                {
                    this.Invoke(new Action(() => AggiornaStatoApplicazione(connessioneValida)));
                    if(_currentPage == PageType.Dashboard && connessioneValida)
                    {
                        if (_userControls.ContainsKey(PageType.Dashboard))
                        {
                            var dashboardControl = _userControls[PageType.Dashboard] as UC_Dashboard;
                            dashboardControl?.AggiornaDati();
                        }
                    }
                }

                await Task.Delay(5000);
            }
        }

        private void AggiornaStatoApplicazione(bool connessioneOk)
        {
            // Aggiorna lo status
            //lblStatusDB.Text = connessioneOk ? "Connesso" : "Disconnesso";
            //lblStatusDB.ForeColor = connessioneOk ? Color.Green : Color.Red;

            if (connessioneOk)
            {
                // Se la connessione torna e la SideBar era bloccata
                if (!SideBar.Enabled)
                {
                    SideBar.Enabled = true;
                    // Opzionale: torna alla Dashboard solo se l'utente era "bloccato" nelle impostazioni
                    if (_currentPage == PageType.Impostazioni)
                        MenuSelection(PageType.Dashboard, dashboard_MenuItem);
                }
            }
            else
            {
                // Se la connessione cade
                if (SideBar.Enabled)
                {
                    SideBar.Enabled = false; // Blocca navigazione
                }

                // Forza il redirect alle impostazioni solo se non ci siamo già
                if (_currentPage != PageType.Impostazioni)
                {
                    MenuSelection(PageType.Impostazioni, impostazioni_MenuItem);
                    MessageBox.Show("Connessione al database assente. Controllare le impostazioni.",
                                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
