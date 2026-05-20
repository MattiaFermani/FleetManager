using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System;
using System.Windows.Forms; // <-- Controlla che ci sia questo!
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using FleetManager.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManager
{
    public partial class Form1 : Form
    {
        private Dictionary<PageType, UserControl> _userControls = new Dictionary<PageType, UserControl>();

        private PageType _currentPage;

        private static Form1 _instance;

        public static Form1 Instance
        {
            get
            {
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
            _instance = this;

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            this.Text = $"FleetManager - v{version.Major}.{version.Minor}.{version.Build}";

            pnlContainer.Dock = DockStyle.Fill;
            this.Padding = new Padding(0, 12, 12, 12); // 12px di spazio sopra, a destra e sotto. 0 a sinistra (attaccato alla SideBar)

            pnlContainer.Padding = new Padding(16);

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
            _currentPage = page;

            ResetMenuColors();

            // Applica lo stile moderno e coordinato all'elemento selezionato
            selectedItem.BackColor = ColoreMenuSelezionato;
            selectedItem.ForeColor = ColoreTestoSelezionato;

            if (!_userControls.ContainsKey(page))
            {
                _userControls[page] = CreateControl(page);
            }

            ShowControl(_userControls[page]);
        }

        private void ResetMenuColors()
        {
            foreach (ToolStripItem item in SideBar.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.FromArgb(55, 65, 81); // Stesso grigio (Gray 600) dei dati in griglia
            }
        }

        private UserControl CreateControl(PageType page)
        {
            switch (page)
            {
                case PageType.Dashboard: return new UC_Dashboard();
                case PageType.Flotta: return new UC_Veicoli();
                case PageType.Personale: return new UC_Guidatori();
                case PageType.Impostazioni: return new UC_DbConnection();
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


        // Gestori eventi (Assicurati che i nomi corrispondano a quelli del Designer)
        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Dashboard, (ToolStripMenuItem)sender);

        private void flottaToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Flotta, (ToolStripMenuItem)sender);

        private void personaleToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Personale, (ToolStripMenuItem)sender);

        private void impostazioniToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Impostazioni, (ToolStripMenuItem)sender);

        public static async Task WatchdogConnessione()
        {
            while (!Form1.Instance.IsDisposed)
            {
                bool connessioneValida = await Task.Run(() =>
                {
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

                if (!Form1.Instance.IsDisposed)
                {
                    Form1.Instance.Invoke(new Action(() => Form1.Instance.AggiornaStatoApplicazione(connessioneValida)));
                    if (Form1.Instance._currentPage == PageType.Dashboard && connessioneValida)
                    {
                        if (Form1.Instance._userControls.ContainsKey(PageType.Dashboard))
                        {
                            var dashboardControl = Form1.Instance._userControls[PageType.Dashboard] as UC_Dashboard;
                            dashboardControl?.AggiornaDati();
                        }
                    }
                }

                await Task.Delay(3000);
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

    #region STILE
    // Palette coerente con ConfiguraStileGriglia (Stile Tailwind)
    private readonly Color ColoreSfondoForm = Color.FromArgb(243, 244, 246);   // Gray 100 (Spento ma pulito)
    private readonly Color ColoreSeparatore = Color.FromArgb(229, 231, 235);   // Gray 200 (Linea sottile discreta)
    private readonly Color ColoreMenuSelezionato = Color.FromArgb(239, 246, 255); // Blue 50 (In linea con la griglia)
    private readonly Color ColoreTestoSelezionato = Color.FromArgb(29, 78, 216);  // Blue 700

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // 1. Uniformiamo lo sfondo del Form
        using (Brush pennelloSfondo = new SolidBrush(ColoreSfondoForm))
        {
            g.FillRectangle(pennelloSfondo, this.ClientRectangle);
        }

        // 2. ELEVAZIONE GRAFICA: Sostituiamo la linea netta con un'ombra morbida (Soft Shadow Effect)
        if (SideBar != null && SideBar.Visible)
        {
            int larghezzaOmbra = 12;
            int inizioOmbraX = SideBar.Right;

            Rectangle areaOmbra = new Rectangle(inizioOmbraX, 0, larghezzaOmbra, this.ClientSize.Height);

            Color coloreOmbraInizio = Color.FromArgb(12, 15, 23, 42); // Ombra ancora più morbida e cinematografica (~5%)
            Color coloreOmbraFine = Color.Transparent;

            using (LinearGradientBrush pennelloGradiente = new LinearGradientBrush(
                areaOmbra,
                coloreOmbraInizio,
                coloreOmbraFine,
                LinearGradientMode.Horizontal))
            {
                g.FillRectangle(pennelloGradiente, areaOmbra);
            }

            using (Pen pennaRifinitura = new Pen(Color.FromArgb(6, 0, 0, 0), 1))
            {
                g.DrawLine(pennaRifinitura, inizioOmbraX, 0, inizioOmbraX, this.ClientSize.Height);
            }
        }
    }

    private void SideBar_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Struttura moderna per la SideBar: Creiamo una fascia di "Branding" o stacco visivo in alto
        // Disegna una linea orizzontale finissima e sfumata per separare un'eventuale intestazione/logo dal menu
        if (SideBar.Height > 60)
        {
            using (Pen pennaSeparatoreMenu = new Pen(Color.FromArgb(40, ColoreSeparatore), 1))
            {
                // Traccia un micro-separatore elegante leggermente rientrato dai bordi
                g.DrawLine(pennaSeparatoreMenu, 15, 55, SideBar.Width - 15, 55);
            }
        }
    }

    private void pnlContainer_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Effetto "Floating Card Canvas" (Contenitore Sospeso Arrotondato)
        // Lasciamo 1 pixel di margine interno per evitare che il disegno del bordo venga clippato
        int raggioArrotondamento = 16; // Angoli morbidi e moderni in stile Windows 11 / macOS
        Rectangle rectCard = new Rectangle(0, 0, pnlContainer.Width - 1, pnlContainer.Height - 1);

        using (GraphicsPath path = GetRoundedRectanglePath(rectCard, raggioArrotondamento))
        {
            // Tagliamo la regione del pannello principale per costringere TUTTI gli UserControl 
            // figli ad ereditare ed essere contenuti dentro gli angoli arrotondati
            pnlContainer.Region = new Region(path);

            // Disegniamo lo sfondo della grande "Card" di lavoro (Bianco puro per far risaltare i dati della griglia)
            using (Brush pennelloCard = new SolidBrush(Color.White))
            {
                g.FillPath(pennelloCard, path);
            }

            // Un bordino millimetrico e texturizzato che profila il pannello dandogli definizione geometrica
            using (Pen pennaBordoCard = new Pen(Color.FromArgb(180, ColoreSeparatore), 1.5f))
            {
                g.DrawPath(pennaBordoCard, path);
            }
        }
    }
        /// <summary>
        /// Genera geometricamente un tracciato a rettangolo con angoli arrotondati.
        /// </summary>
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Previene anomalie se l'utente rimpicciolisce la colonna oltre la dimensione del raggio
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            if (diameter <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            // Angolo in alto a sinistra
            path.AddArc(arc, 180, 90);

            // Angolo in alto a destra
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Angolo in basso a destra
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Angolo in basso a sinistra
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        #endregion STILE
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
