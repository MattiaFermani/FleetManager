using FastReport.DataVisualization.Charting;

namespace FleetManager
{
    partial class UC_Dashboard
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            ChartArea chartArea1 = new ChartArea();
            ChartArea chartArea2 = new ChartArea();
            panel1 = new Panel();
            lbl_dash_Vehicles = new Label();
            label1 = new Label();
            panel2 = new Panel();
            lbl_dash_AsgAvl = new Label();
            label3 = new Label();
            panel3 = new Panel();
            lbl_scad = new Label();
            label4 = new Label();
            chart2 = new Chart();
            chart1 = new Chart();
            dGw_Man = new DataGridView();
            dGw_Top3Inc = new DataGridView();
            label2 = new Label();
            label5 = new Label();
            lsw_Man = new ListView();
            lsw_TopInc = new ListView();
            label6 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dGw_Man).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dGw_Top3Inc).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSalmon;
            panel1.Controls.Add(lbl_dash_Vehicles);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(14, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 112);
            panel1.TabIndex = 0;
            // 
            // lbl_dash_Vehicles
            // 
            lbl_dash_Vehicles.AutoSize = true;
            lbl_dash_Vehicles.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lbl_dash_Vehicles.Location = new Point(105, 45);
            lbl_dash_Vehicles.Name = "lbl_dash_Vehicles";
            lbl_dash_Vehicles.Size = new Size(33, 37);
            lbl_dash_Vehicles.TabIndex = 1;
            lbl_dash_Vehicles.Text = "0";
            lbl_dash_Vehicles.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(31, 0);
            label1.Name = "label1";
            label1.Size = new Size(182, 37);
            label1.TabIndex = 0;
            label1.Text = "Veicoli Totali";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.YellowGreen;
            panel2.Controls.Add(lbl_dash_AsgAvl);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(299, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 112);
            panel2.TabIndex = 2;
            // 
            // lbl_dash_AsgAvl
            // 
            lbl_dash_AsgAvl.AutoSize = true;
            lbl_dash_AsgAvl.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lbl_dash_AsgAvl.Location = new Point(118, 45);
            lbl_dash_AsgAvl.Name = "lbl_dash_AsgAvl";
            lbl_dash_AsgAvl.Size = new Size(33, 37);
            lbl_dash_AsgAvl.TabIndex = 1;
            lbl_dash_AsgAvl.Text = "0";
            lbl_dash_AsgAvl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label3.Location = new Point(52, 0);
            label3.Name = "label3";
            label3.Size = new Size(156, 37);
            label3.TabIndex = 0;
            label3.Text = "Disponibili";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.MediumSpringGreen;
            panel3.Controls.Add(lbl_scad);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(598, 16);
            panel3.Name = "panel3";
            panel3.Size = new Size(262, 112);
            panel3.TabIndex = 3;
            // 
            // lbl_scad
            // 
            lbl_scad.AutoSize = true;
            lbl_scad.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lbl_scad.Location = new Point(116, 45);
            lbl_scad.Name = "lbl_scad";
            lbl_scad.Size = new Size(33, 37);
            lbl_scad.TabIndex = 1;
            lbl_scad.Text = "0";
            lbl_scad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label4.Location = new Point(69, 0);
            label4.Name = "label4";
            label4.Size = new Size(136, 37);
            label4.TabIndex = 0;
            label4.Text = "Scadenze";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chart2
            // 
            chart2.BackColor = SystemColors.Control;
            chart2.BackGradientStyle = GradientStyle.Center;
            chartArea1.Name = "MainArea2";
            chart2.ChartAreas.Add(chartArea1);
            chart2.Location = new Point(14, 428);
            chart2.Name = "chart2";
            chart2.Palette = ChartColorPalette.Bright;
            chart2.Size = new Size(405, 244);
            chart2.TabIndex = 4;
            chart2.Text = "chart2";
            // 
            // chart1
            // 
            chart1.BackColor = SystemColors.Control;
            chart1.BackGradientStyle = GradientStyle.Center;
            chartArea2.Name = "MainArea1";
            chart1.ChartAreas.Add(chartArea2);
            chart1.Location = new Point(447, 428);
            chart1.Name = "chart1";
            chart1.Size = new Size(405, 244);
            chart1.TabIndex = 5;
            chart1.Text = "chart1";
            // 
            // dGw_Man
            // 
            dGw_Man.BackgroundColor = SystemColors.Control;
            dGw_Man.BorderStyle = BorderStyle.None;
            dGw_Man.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dGw_Man.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Man.Location = new Point(14, 198);
            dGw_Man.Name = "dGw_Man";
            dGw_Man.Size = new Size(225, 177);
            dGw_Man.TabIndex = 6;
            // 
            // dGw_Top3Inc
            // 
            dGw_Top3Inc.BackgroundColor = SystemColors.Control;
            dGw_Top3Inc.BorderStyle = BorderStyle.None;
            dGw_Top3Inc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Top3Inc.Location = new Point(447, 198);
            dGw_Top3Inc.Name = "dGw_Top3Inc";
            dGw_Top3Inc.Size = new Size(413, 177);
            dGw_Top3Inc.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.Location = new Point(77, 158);
            label2.Name = "label2";
            label2.Size = new Size(288, 37);
            label2.TabIndex = 2;
            label2.Text = "Ultime Manutenzioni";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label5.Location = new Point(555, 158);
            label5.Name = "label5";
            label5.Size = new Size(210, 37);
            label5.TabIndex = 2;
            label5.Text = "Top incidentati";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lsw_Man
            // 
            lsw_Man.Activation = ItemActivation.TwoClick;
            lsw_Man.Alignment = ListViewAlignment.Default;
            lsw_Man.AutoArrange = false;
            lsw_Man.BorderStyle = BorderStyle.None;
            lsw_Man.Enabled = false;
            lsw_Man.Font = new Font("Segoe UI", 12F);
            lsw_Man.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsw_Man.HideSelection = true;
            lsw_Man.LabelWrap = false;
            lsw_Man.Location = new Point(14, 198);
            lsw_Man.MultiSelect = false;
            lsw_Man.Name = "lsw_Man";
            lsw_Man.ShowGroups = false;
            lsw_Man.Size = new Size(405, 177);
            lsw_Man.TabIndex = 7;
            lsw_Man.UseCompatibleStateImageBehavior = false;
            lsw_Man.View = View.Details;
            // 
            // lsw_TopInc
            // 
            lsw_TopInc.Alignment = ListViewAlignment.Default;
            lsw_TopInc.BorderStyle = BorderStyle.None;
            lsw_TopInc.Enabled = false;
            lsw_TopInc.Font = new Font("Segoe UI", 12F);
            lsw_TopInc.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsw_TopInc.LabelWrap = false;
            lsw_TopInc.Location = new Point(447, 198);
            lsw_TopInc.MultiSelect = false;
            lsw_TopInc.Name = "lsw_TopInc";
            lsw_TopInc.Size = new Size(405, 177);
            lsw_TopInc.TabIndex = 7;
            lsw_TopInc.UseCompatibleStateImageBehavior = false;
            lsw_TopInc.View = View.Details;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label6.Location = new Point(570, 388);
            label6.Name = "label6";
            label6.Size = new Size(177, 37);
            label6.TabIndex = 2;
            label6.Text = "Stato Veicoli";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label7.Location = new Point(26, 388);
            label7.Name = "label7";
            label7.Size = new Size(382, 37);
            label7.TabIndex = 2;
            label7.Text = "Spese Mensili Manutenzione";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.Control;
            Controls.Add(lsw_TopInc);
            Controls.Add(lsw_Man);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(dGw_Top3Inc);
            Controls.Add(dGw_Man);
            Controls.Add(chart1);
            Controls.Add(chart2);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_Dashboard";
            Size = new Size(877, 685);
            Load += UC_Dashboard_Load;
            Paint += UC_Dashboard_Paint;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dGw_Man).EndInit();
            ((System.ComponentModel.ISupportInitialize)dGw_Top3Inc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label lbl_dash_Vehicles;
        private Panel panel2;
        private Label lbl_dash_AsgAvl;
        private Label label3;
        private Panel panel3;
        private Label lbl_scad;
        private Label label4;
        private FastReport.DataVisualization.Charting.Chart chart2;
        private FastReport.DataVisualization.Charting.Chart chart1;
        private DataGridView dGw_Man;
        private DataGridView dGw_Top3Inc;
        private Label label2;
        private Label label5;
        private ListView lsw_Man;
        private ListView lsw_TopInc;
        private Label label6;
        private Label label7;
    }
}
