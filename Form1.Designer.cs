namespace FleetManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dashboard_MenuItem = new ToolStripMenuItem();
            flotta_MenuItem = new ToolStripMenuItem();
            personale_MenuItem = new ToolStripMenuItem();
            SideBar = new MenuStrip();
            registroEventiToolStripMenuItem = new ToolStripMenuItem();
            statisticheToolStripMenuItem = new ToolStripMenuItem();
            impostazioni_MenuItem = new ToolStripMenuItem();
            pnlContainer = new Panel();
            SideBar.SuspendLayout();
            SuspendLayout();
            // 
            // dashboard_MenuItem
            // 
            dashboard_MenuItem.Name = "dashboard_MenuItem";
            dashboard_MenuItem.Size = new Size(119, 25);
            dashboard_MenuItem.Text = "Dashboard";
            dashboard_MenuItem.Click += dashboardToolStripMenuItem_Click;
            // 
            // flotta_MenuItem
            // 
            flotta_MenuItem.Name = "flotta_MenuItem";
            flotta_MenuItem.Size = new Size(119, 25);
            flotta_MenuItem.Text = "Flotta";
            flotta_MenuItem.Click += flottaToolStripMenuItem_Click;
            // 
            // personale_MenuItem
            // 
            personale_MenuItem.Name = "personale_MenuItem";
            personale_MenuItem.Size = new Size(119, 25);
            personale_MenuItem.Text = "Personale";
            personale_MenuItem.Click += personaleToolStripMenuItem_Click;
            // 
            // SideBar
            // 
            SideBar.Dock = DockStyle.Left;
            SideBar.Font = new Font("Segoe UI", 12F);
            SideBar.Items.AddRange(new ToolStripItem[] { dashboard_MenuItem, flotta_MenuItem, personale_MenuItem, registroEventiToolStripMenuItem, statisticheToolStripMenuItem, impostazioni_MenuItem });
            SideBar.Location = new Point(0, 0);
            SideBar.Name = "SideBar";
            SideBar.RenderMode = ToolStripRenderMode.Professional;
            SideBar.Size = new Size(132, 466);
            SideBar.TabIndex = 0;
            SideBar.Text = "menuStrip1";
            // 
            // registroEventiToolStripMenuItem
            // 
            registroEventiToolStripMenuItem.Name = "registroEventiToolStripMenuItem";
            registroEventiToolStripMenuItem.Size = new Size(119, 25);
            registroEventiToolStripMenuItem.Text = "Registro Eventi";
            // 
            // statisticheToolStripMenuItem
            // 
            statisticheToolStripMenuItem.Name = "statisticheToolStripMenuItem";
            statisticheToolStripMenuItem.Size = new Size(119, 25);
            statisticheToolStripMenuItem.Text = "Statistiche";
            // 
            // impostazioni_MenuItem
            // 
            impostazioni_MenuItem.Name = "impostazioni_MenuItem";
            impostazioni_MenuItem.Size = new Size(119, 25);
            impostazioni_MenuItem.Text = "Impostazioni";
            impostazioni_MenuItem.Click += impostazioniToolStripMenuItem_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.AutoScroll = true;
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(132, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(886, 466);
            pnlContainer.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1018, 466);
            Controls.Add(pnlContainer);
            Controls.Add(SideBar);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = SideBar;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "Form1";
            Text = "Fleet Manager";
            SideBar.ResumeLayout(false);
            SideBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem dashboard_MenuItem;
        private ToolStripMenuItem flotta_MenuItem;
        private ToolStripMenuItem personale_MenuItem;
        private MenuStrip SideBar;
        private ToolStripMenuItem registroEventiToolStripMenuItem;
        private ToolStripMenuItem statisticheToolStripMenuItem;
        private Panel pnlContainer;
        private ToolStripMenuItem impostazioni_MenuItem;
    }
}
