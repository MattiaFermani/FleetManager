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
            dGw_Veicoli = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Targa = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            NomeModello = new DataGridViewTextBoxColumn();
            AnnoProduzione = new DataGridViewTextBoxColumn();
            Chilometraggio = new DataGridViewTextBoxColumn();
            Stato = new DataGridViewComboBoxColumn();
            txb_FilterTarga = new TextBox();
            cmb_Modello = new ComboBox();
            panel1 = new Panel();
            label1 = new Label();
            cmb_FilterModello = new ComboBox();
            cmb_FilterYearProd = new ComboBox();
            cmb_FilterStato = new ComboBox();
            dataGridView1 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewComboBoxColumn1 = new DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dGw_Veicoli).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dGw_Veicoli
            // 
            dGw_Veicoli.AllowUserToAddRows = false;
            dGw_Veicoli.AllowUserToDeleteRows = false;
            dGw_Veicoli.AllowUserToResizeColumns = false;
            dGw_Veicoli.AllowUserToResizeRows = false;
            dGw_Veicoli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGw_Veicoli.BackgroundColor = SystemColors.Control;
            dGw_Veicoli.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dGw_Veicoli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Veicoli.Columns.AddRange(new DataGridViewColumn[] { ID, Targa, Marca, NomeModello, AnnoProduzione, Chilometraggio, Stato });
            dGw_Veicoli.EditMode = DataGridViewEditMode.EditOnEnter;
            dGw_Veicoli.Location = new Point(18, 83);
            dGw_Veicoli.MultiSelect = false;
            dGw_Veicoli.Name = "dGw_Veicoli";
            dGw_Veicoli.RowHeadersVisible = false;
            dGw_Veicoli.ScrollBars = ScrollBars.Vertical;
            dGw_Veicoli.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dGw_Veicoli.Size = new Size(620, 287);
            dGw_Veicoli.TabIndex = 0;
            dGw_Veicoli.CellClick += dGw_Veicoli_CellClick;
            dGw_Veicoli.CellValueChanged += dGw_Veicoli_CellValueChanged;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ID.DataPropertyName = "ID_Veicolo";
            ID.Frozen = true;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // Targa
            // 
            Targa.DataPropertyName = "Targa";
            Targa.HeaderText = "Targa";
            Targa.Name = "Targa";
            Targa.ReadOnly = true;
            // 
            // Marca
            // 
            Marca.DataPropertyName = "Marca";
            Marca.HeaderText = "Marca";
            Marca.Name = "Marca";
            Marca.ReadOnly = true;
            // 
            // NomeModello
            // 
            NomeModello.DataPropertyName = "NomeModello";
            NomeModello.HeaderText = "NomeModello";
            NomeModello.Name = "NomeModello";
            NomeModello.ReadOnly = true;
            // 
            // AnnoProduzione
            // 
            AnnoProduzione.DataPropertyName = "AnnoProduzione";
            AnnoProduzione.HeaderText = "Anno Produzione";
            AnnoProduzione.Name = "AnnoProduzione";
            AnnoProduzione.ReadOnly = true;
            // 
            // Chilometraggio
            // 
            Chilometraggio.DataPropertyName = "Chilometraggio";
            Chilometraggio.HeaderText = "Chilometraggio";
            Chilometraggio.Name = "Chilometraggio";
            // 
            // Stato
            // 
            Stato.DataPropertyName = "Stato";
            Stato.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            Stato.FlatStyle = FlatStyle.Popup;
            Stato.HeaderText = "Stato";
            Stato.Items.AddRange(new object[] { "Disponibile", "Non Disponibile", "In Uso", "In Manutenzione" });
            Stato.MaxDropDownItems = 4;
            Stato.Name = "Stato";
            Stato.ToolTipText = "Gestisci lo stato del veicolo";
            // 
            // txb_FilterTarga
            // 
            txb_FilterTarga.Location = new Point(18, 54);
            txb_FilterTarga.Name = "txb_FilterTarga";
            txb_FilterTarga.Size = new Size(100, 23);
            txb_FilterTarga.TabIndex = 1;
            txb_FilterTarga.TextChanged += txb_FilterTarga_TextChanged;
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
            panel1.Location = new Point(644, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 367);
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
            cmb_FilterModello.Location = new Point(232, 54);
            cmb_FilterModello.Name = "cmb_FilterModello";
            cmb_FilterModello.Size = new Size(121, 23);
            cmb_FilterModello.TabIndex = 2;
            cmb_FilterModello.SelectedIndexChanged += cmb_FilterModello_SelectedIndexChanged;
            // 
            // cmb_FilterYearProd
            // 
            cmb_FilterYearProd.FormattingEnabled = true;
            cmb_FilterYearProd.Location = new Point(124, 54);
            cmb_FilterYearProd.Name = "cmb_FilterYearProd";
            cmb_FilterYearProd.Size = new Size(102, 23);
            cmb_FilterYearProd.TabIndex = 2;
            cmb_FilterYearProd.SelectedIndexChanged += cmb_FilterYearProd_SelectedIndexChanged;
            // 
            // cmb_FilterStato
            // 
            cmb_FilterStato.FormattingEnabled = true;
            cmb_FilterStato.Location = new Point(359, 54);
            cmb_FilterStato.Name = "cmb_FilterStato";
            cmb_FilterStato.Size = new Size(121, 23);
            cmb_FilterStato.TabIndex = 2;
            cmb_FilterStato.SelectedIndexChanged += cmb_FilterStato_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewComboBoxColumn1 });
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.Location = new Point(18, 432);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(620, 250);
            dataGridView1.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewTextBoxColumn1.DataPropertyName = "ID_Veicolo";
            dataGridViewTextBoxColumn1.Frozen = true;
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Targa";
            dataGridViewTextBoxColumn2.HeaderText = "Targa";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Marca";
            dataGridViewTextBoxColumn3.HeaderText = "Marca";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "NomeModello";
            dataGridViewTextBoxColumn4.HeaderText = "NomeModello";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "AnnoProduzione";
            dataGridViewTextBoxColumn5.HeaderText = "Anno Produzione";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "Chilometraggio";
            dataGridViewTextBoxColumn6.HeaderText = "Chilometraggio";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewComboBoxColumn1
            // 
            dataGridViewComboBoxColumn1.DataPropertyName = "Stato";
            dataGridViewComboBoxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dataGridViewComboBoxColumn1.FlatStyle = FlatStyle.Popup;
            dataGridViewComboBoxColumn1.HeaderText = "Stato";
            dataGridViewComboBoxColumn1.Items.AddRange(new object[] { "Disponibile", "Non Disponibile", "In Uso", "In Manutenzione" });
            dataGridViewComboBoxColumn1.MaxDropDownItems = 4;
            dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            dataGridViewComboBoxColumn1.ToolTipText = "Gestisci lo stato del veicolo";
            // 
            // UC_Veicoli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(cmb_FilterYearProd);
            Controls.Add(cmb_FilterStato);
            Controls.Add(cmb_FilterModello);
            Controls.Add(txb_FilterTarga);
            Controls.Add(dGw_Veicoli);
            Name = "UC_Veicoli";
            Size = new Size(877, 685);
            Load += UC_Veicoli_Load;
            ((System.ComponentModel.ISupportInitialize)dGw_Veicoli).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dGw_Veicoli;
        private TextBox txb_FilterTarga;
        private ComboBox cmb_Modello;
        private Panel panel1;
        private Label label1;
        private ComboBox cmb_FilterModello;
        private ComboBox cmb_FilterYearProd;
        private ComboBox cmb_FilterStato;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Targa;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn NomeModello;
        private DataGridViewTextBoxColumn AnnoProduzione;
        private DataGridViewTextBoxColumn Chilometraggio;
        private DataGridViewComboBoxColumn Stato;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
    }
}
