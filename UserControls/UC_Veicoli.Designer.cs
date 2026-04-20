namespace FleetManager
{
    partial class UC_Veicoli
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
            dataGridView1 = new DataGridView();
            txb_FilterTarga = new TextBox();
            cmb_Modello = new ComboBox();
            panel1 = new Panel();
            label1 = new Label();
            cmb_FilterModello = new ComboBox();
            cmb_FilterYearProd = new ComboBox();
            cmb_FilterStato = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(620, 150);
            dataGridView1.TabIndex = 0;
            // 
            // txb_FilterTarga
            // 
            txb_FilterTarga.Location = new Point(18, 133);
            txb_FilterTarga.Name = "txb_FilterTarga";
            txb_FilterTarga.Size = new Size(100, 23);
            txb_FilterTarga.TabIndex = 1;
            // 
            // cmb_Modello
            // 
            cmb_Modello.FormattingEnabled = true;
            cmb_Modello.Location = new Point(54, 68);
            cmb_Modello.Name = "cmb_Modello";
            cmb_Modello.Size = new Size(121, 23);
            cmb_Modello.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cmb_Modello);
            panel1.Location = new Point(644, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 312);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(32, 17);
            label1.Name = "label1";
            label1.Size = new Size(173, 28);
            label1.TabIndex = 0;
            label1.Text = "Aggiungi Veicolo";
            // 
            // cmb_FilterModello
            // 
            cmb_FilterModello.FormattingEnabled = true;
            cmb_FilterModello.Location = new Point(232, 133);
            cmb_FilterModello.Name = "cmb_FilterModello";
            cmb_FilterModello.Size = new Size(121, 23);
            cmb_FilterModello.TabIndex = 2;
            // 
            // cmb_FilterYearProd
            // 
            cmb_FilterYearProd.FormattingEnabled = true;
            cmb_FilterYearProd.Location = new Point(124, 133);
            cmb_FilterYearProd.Name = "cmb_FilterYearProd";
            cmb_FilterYearProd.Size = new Size(102, 23);
            cmb_FilterYearProd.TabIndex = 2;
            // 
            // cmb_FilterStato
            // 
            cmb_FilterStato.FormattingEnabled = true;
            cmb_FilterStato.Location = new Point(359, 133);
            cmb_FilterStato.Name = "cmb_FilterStato";
            cmb_FilterStato.Size = new Size(121, 23);
            cmb_FilterStato.TabIndex = 2;
            // 
            // UC_Veicoli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            Controls.Add(panel1);
            Controls.Add(cmb_FilterYearProd);
            Controls.Add(cmb_FilterStato);
            Controls.Add(cmb_FilterModello);
            Controls.Add(txb_FilterTarga);
            Controls.Add(dataGridView1);
            Name = "UC_Veicoli";
            Size = new Size(877, 685);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txb_FilterTarga;
        private ComboBox cmb_Modello;
        private Panel panel1;
        private Label label1;
        private ComboBox cmb_FilterModello;
        private ComboBox cmb_FilterYearProd;
        private ComboBox cmb_FilterStato;
    }
}
