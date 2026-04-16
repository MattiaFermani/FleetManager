using System.Runtime.CompilerServices;

namespace FleetManager
{
    public partial class Form1 : Form
    {

        private Dictionary<PageType, UserControl> _userControls = new Dictionary<PageType, UserControl>();

        public Form1()
        {
            InitializeComponent();
            MenuSelection(PageType.Dashboard, dashboard_MenuItem);
        }

        private void MenuSelection(PageType page, ToolStripMenuItem selectedItem)
        {
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

        // Eventi: ora passiamo l'Enum invece della stringa
        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Dashboard, (ToolStripMenuItem)sender);

        private void flottaToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Flotta, (ToolStripMenuItem)sender);

        private void personaleToolStripMenuItem_Click(object sender, EventArgs e) =>
            MenuSelection(PageType.Personale, (ToolStripMenuItem)sender);
    }

    public enum PageType
    {
        Dashboard,
        Flotta,
        Personale,
        Incidenti,
        Statistiche
    }
}
