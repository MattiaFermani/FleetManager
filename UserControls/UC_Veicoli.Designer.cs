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
            cmb_FilterModello = new ComboBox();
            cmb_FilterYearProd = new ComboBox();
            cmb_FilterStato = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            nUd_FilterKm = new NumericUpDown();
            label6 = new Label();
            btn_FilterUnderOver = new Button();
            label1 = new Label();
            cmb_FilterMarca = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dGw_Veicoli).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUd_FilterKm).BeginInit();
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
            dGw_Veicoli.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dGw_Veicoli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Veicoli.Columns.AddRange(new DataGridViewColumn[] { ID, Targa, Marca, NomeModello, AnnoProduzione, Chilometraggio, Stato });
            dGw_Veicoli.EditMode = DataGridViewEditMode.EditOnEnter;
            dGw_Veicoli.Location = new Point(10, 119);
            dGw_Veicoli.MultiSelect = false;
            dGw_Veicoli.Name = "dGw_Veicoli";
            dGw_Veicoli.RowHeadersVisible = false;
            dGw_Veicoli.ScrollBars = ScrollBars.Vertical;
            dGw_Veicoli.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dGw_Veicoli.Size = new Size(609, 563);
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
            txb_FilterTarga.Location = new Point(10, 31);
            txb_FilterTarga.Name = "txb_FilterTarga";
            txb_FilterTarga.Size = new Size(137, 23);
            txb_FilterTarga.TabIndex = 1;
            txb_FilterTarga.TextChanged += txb_FilterTarga_TextChanged;
            // 
            // cmb_FilterModello
            // 
            cmb_FilterModello.FormattingEnabled = true;
            cmb_FilterModello.Location = new Point(155, 74);
            cmb_FilterModello.Name = "cmb_FilterModello";
            cmb_FilterModello.Size = new Size(135, 23);
            cmb_FilterModello.TabIndex = 2;
            cmb_FilterModello.SelectedIndexChanged += cmb_FilterModello_SelectedIndexChanged;
            // 
            // cmb_FilterYearProd
            // 
            cmb_FilterYearProd.FormattingEnabled = true;
            cmb_FilterYearProd.Location = new Point(155, 30);
            cmb_FilterYearProd.Name = "cmb_FilterYearProd";
            cmb_FilterYearProd.Size = new Size(132, 23);
            cmb_FilterYearProd.TabIndex = 2;
            cmb_FilterYearProd.SelectedIndexChanged += cmb_FilterYearProd_SelectedIndexChanged;
            // 
            // cmb_FilterStato
            // 
            cmb_FilterStato.FormattingEnabled = true;
            cmb_FilterStato.Location = new Point(296, 74);
            cmb_FilterStato.Name = "cmb_FilterStato";
            cmb_FilterStato.Size = new Size(143, 23);
            cmb_FilterStato.TabIndex = 2;
            cmb_FilterStato.SelectedIndexChanged += cmb_FilterStato_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 13);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "Targa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(155, 12);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 4;
            label3.Text = "Anno di Produzione";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(155, 56);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 4;
            label4.Text = "Modello";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(296, 58);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 4;
            label5.Text = "Stato";
            // 
            // nUd_FilterKm
            // 
            nUd_FilterKm.Location = new Point(336, 30);
            nUd_FilterKm.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nUd_FilterKm.Name = "nUd_FilterKm";
            nUd_FilterKm.Size = new Size(103, 23);
            nUd_FilterKm.TabIndex = 5;
            nUd_FilterKm.ValueChanged += nUd_FiltroKm_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(295, 13);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 4;
            label6.Text = "Chilometraggio";
            // 
            // btn_FilterUnderOver
            // 
            btn_FilterUnderOver.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_FilterUnderOver.Location = new Point(295, 30);
            btn_FilterUnderOver.Name = "btn_FilterUnderOver";
            btn_FilterUnderOver.Size = new Size(35, 23);
            btn_FilterUnderOver.TabIndex = 6;
            btn_FilterUnderOver.Text = ">";
            btn_FilterUnderOver.UseVisualStyleBackColor = true;
            btn_FilterUnderOver.MouseDown += btn_FilterUnderOver_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 56);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 4;
            label1.Text = "Marca";
            // 
            // cmb_FilterMarca
            // 
            cmb_FilterMarca.FormattingEnabled = true;
            cmb_FilterMarca.Location = new Point(10, 74);
            cmb_FilterMarca.Name = "cmb_FilterMarca";
            cmb_FilterMarca.Size = new Size(139, 23);
            cmb_FilterMarca.TabIndex = 2;
            cmb_FilterMarca.SelectedIndexChanged += cmb_FilterMarca_SelectedIndexChanged;
            // 
            // UC_Veicoli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            Controls.Add(btn_FilterUnderOver);
            Controls.Add(nUd_FilterKm);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(cmb_FilterYearProd);
            Controls.Add(cmb_FilterStato);
            Controls.Add(cmb_FilterMarca);
            Controls.Add(cmb_FilterModello);
            Controls.Add(txb_FilterTarga);
            Controls.Add(dGw_Veicoli);
            Name = "UC_Veicoli";
            Size = new Size(877, 685);
            Load += UC_Veicoli_Load;
            ((System.ComponentModel.ISupportInitialize)dGw_Veicoli).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUd_FilterKm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dGw_Veicoli;
        private TextBox txb_FilterTarga;
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
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown nUd_FilterKm;
        private Label label6;
        private Button btn_FilterUnderOver;
        private Label label1;
        private ComboBox cmb_FilterMarca;
    }
}
