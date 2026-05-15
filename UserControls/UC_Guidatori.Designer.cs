namespace FleetManager
{
    partial class UC_Guidatori
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dGw_Guidatori = new DataGridView();
            Cognome = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            CodiceFiscale = new DataGridViewTextBoxColumn();
            ScadenzaPatente = new DataGridViewTextBoxColumn();
            Stato = new DataGridViewTextBoxColumn();
            ID_Guidatore = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            txb_GuidatoreNome = new TextBox();
            txb_GuidatoreCognome = new TextBox();
            txb_GuidatoreCF = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmb_GuidatoreStato = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            dtp_GuidatorePatente = new DateTimePicker();
            btn_GuidatorePatente_CrescDescr = new Button();
            ((System.ComponentModel.ISupportInitialize)dGw_Guidatori).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // dGw_Guidatori
            // 
            dGw_Guidatori.AllowUserToAddRows = false;
            dGw_Guidatori.AllowUserToDeleteRows = false;
            dGw_Guidatori.AllowUserToResizeColumns = false;
            dGw_Guidatori.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dGw_Guidatori.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dGw_Guidatori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGw_Guidatori.BackgroundColor = SystemColors.Control;
            dGw_Guidatori.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dGw_Guidatori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Guidatori.Columns.AddRange(new DataGridViewColumn[] { Cognome, Nome, CodiceFiscale, ScadenzaPatente, Stato, ID_Guidatore });
            dGw_Guidatori.Dock = DockStyle.Fill;
            dGw_Guidatori.EditMode = DataGridViewEditMode.EditOnEnter;
            dGw_Guidatori.Location = new Point(0, 0);
            dGw_Guidatori.MultiSelect = false;
            dGw_Guidatori.Name = "dGw_Guidatori";
            dGw_Guidatori.ReadOnly = true;
            dGw_Guidatori.RowHeadersVisible = false;
            dGw_Guidatori.ScrollBars = ScrollBars.Vertical;
            dGw_Guidatori.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGw_Guidatori.Size = new Size(877, 610);
            dGw_Guidatori.TabIndex = 1;
            dGw_Guidatori.CellDoubleClick += dGw_Guidatori_CellDoubleClick;
            dGw_Guidatori.CellFormatting += dGw_Guidatori_CellFormatting;
            dGw_Guidatori.CellPainting += dGw_Guidatori_CellPainting;
            // 
            // Cognome
            // 
            Cognome.DataPropertyName = "Cognome";
            Cognome.HeaderText = "Cognome";
            Cognome.Name = "Cognome";
            Cognome.ReadOnly = true;
            // 
            // Nome
            // 
            Nome.DataPropertyName = "Nome";
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            // 
            // CodiceFiscale
            // 
            CodiceFiscale.DataPropertyName = "CodiceFiscale";
            CodiceFiscale.HeaderText = "Codice Fiscale";
            CodiceFiscale.Name = "CodiceFiscale";
            CodiceFiscale.ReadOnly = true;
            // 
            // ScadenzaPatente
            // 
            ScadenzaPatente.DataPropertyName = "ScadenzaPatente";
            ScadenzaPatente.HeaderText = "Scadenza Patente";
            ScadenzaPatente.Name = "ScadenzaPatente";
            ScadenzaPatente.ReadOnly = true;
            // 
            // Stato
            // 
            Stato.DataPropertyName = "Stato";
            Stato.HeaderText = "Stato";
            Stato.Name = "Stato";
            Stato.ReadOnly = true;
            // 
            // ID_Guidatore
            // 
            ID_Guidatore.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ID_Guidatore.DataPropertyName = "ID_Guidatore";
            ID_Guidatore.FillWeight = 5F;
            ID_Guidatore.HeaderText = "ID";
            ID_Guidatore.Name = "ID_Guidatore";
            ID_Guidatore.ReadOnly = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dGw_Guidatori);
            splitContainer1.Size = new Size(877, 685);
            splitContainer1.SplitterDistance = 71;
            splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 14F));
            tableLayoutPanel1.Controls.Add(txb_GuidatoreNome, 0, 2);
            tableLayoutPanel1.Controls.Add(txb_GuidatoreCognome, 1, 2);
            tableLayoutPanel1.Controls.Add(txb_GuidatoreCF, 2, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 2, 1);
            tableLayoutPanel1.Controls.Add(label4, 3, 1);
            tableLayoutPanel1.Controls.Add(label5, 4, 1);
            tableLayoutPanel1.Controls.Add(cmb_GuidatoreStato, 4, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 3, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(877, 71);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txb_GuidatoreNome
            // 
            txb_GuidatoreNome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txb_GuidatoreNome.Location = new Point(3, 34);
            txb_GuidatoreNome.Name = "txb_GuidatoreNome";
            txb_GuidatoreNome.Size = new Size(166, 23);
            txb_GuidatoreNome.TabIndex = 0;
            txb_GuidatoreNome.TextChanged += txb_GuidatoreNome_TextChanged;
            // 
            // txb_GuidatoreCognome
            // 
            txb_GuidatoreCognome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txb_GuidatoreCognome.Location = new Point(175, 34);
            txb_GuidatoreCognome.Name = "txb_GuidatoreCognome";
            txb_GuidatoreCognome.Size = new Size(166, 23);
            txb_GuidatoreCognome.TabIndex = 1;
            txb_GuidatoreCognome.TextChanged += txb_GuidatoreCognome_TextChanged;
            // 
            // txb_GuidatoreCF
            // 
            txb_GuidatoreCF.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txb_GuidatoreCF.Location = new Point(347, 34);
            txb_GuidatoreCF.Name = "txb_GuidatoreCF";
            txb_GuidatoreCF.Size = new Size(166, 23);
            txb_GuidatoreCF.TabIndex = 1;
            txb_GuidatoreCF.TextChanged += txb_GuidatoreCF_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(166, 28);
            label1.TabIndex = 2;
            label1.Text = "Nome";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(175, 3);
            label2.Name = "label2";
            label2.Size = new Size(166, 28);
            label2.TabIndex = 3;
            label2.Text = "Cognome";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(347, 3);
            label3.Name = "label3";
            label3.Size = new Size(166, 28);
            label3.TabIndex = 4;
            label3.Text = "Codice Fiscale";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(519, 3);
            label4.Name = "label4";
            label4.Size = new Size(166, 28);
            label4.TabIndex = 5;
            label4.Text = "Scadenza Patente";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(691, 3);
            label5.Name = "label5";
            label5.Size = new Size(166, 28);
            label5.TabIndex = 6;
            label5.Text = "Stato";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // cmb_GuidatoreStato
            // 
            cmb_GuidatoreStato.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmb_GuidatoreStato.FormattingEnabled = true;
            cmb_GuidatoreStato.Items.AddRange(new object[] { "Tutti Gli Stati", "ATTIVO", "IN SCADENZA", "SOSPESO" });
            cmb_GuidatoreStato.Location = new Point(691, 34);
            cmb_GuidatoreStato.Name = "cmb_GuidatoreStato";
            cmb_GuidatoreStato.Size = new Size(166, 23);
            cmb_GuidatoreStato.TabIndex = 8;
            cmb_GuidatoreStato.SelectedIndexChanged += cmb_GuidatoreStato_SelectedIndexChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.57143F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.42857F));
            tableLayoutPanel2.Controls.Add(dtp_GuidatorePatente, 1, 0);
            tableLayoutPanel2.Controls.Add(btn_GuidatorePatente_CrescDescr, 0, 0);
            tableLayoutPanel2.Location = new Point(519, 34);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(166, 21);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // dtp_GuidatorePatente
            // 
            dtp_GuidatorePatente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtp_GuidatorePatente.Format = DateTimePickerFormat.Short;
            dtp_GuidatorePatente.Location = new Point(50, 3);
            dtp_GuidatorePatente.Name = "dtp_GuidatorePatente";
            dtp_GuidatorePatente.Size = new Size(113, 23);
            dtp_GuidatorePatente.TabIndex = 0;
            dtp_GuidatorePatente.ValueChanged += dtp_GuidatorePatente_ValueChanged;
            // 
            // btn_GuidatorePatente_CrescDescr
            // 
            btn_GuidatorePatente_CrescDescr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_GuidatorePatente_CrescDescr.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_GuidatorePatente_CrescDescr.Location = new Point(3, 3);
            btn_GuidatorePatente_CrescDescr.Name = "btn_GuidatorePatente_CrescDescr";
            btn_GuidatorePatente_CrescDescr.Size = new Size(41, 24);
            btn_GuidatorePatente_CrescDescr.TabIndex = 0;
            btn_GuidatorePatente_CrescDescr.Text = "↹";
            btn_GuidatorePatente_CrescDescr.UseVisualStyleBackColor = true;
            btn_GuidatorePatente_CrescDescr.MouseDown += btn_GuidatorePatente_CrescDescr_MouseDown;
            // 
            // UC_Guidatori
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Thistle;
            Controls.Add(splitContainer1);
            Name = "UC_Guidatori";
            Size = new Size(877, 685);
            ((System.ComponentModel.ISupportInitialize)dGw_Guidatori).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGw_Guidatori;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txb_GuidatoreNome;
        private TextBox txb_GuidatoreCognome;
        private TextBox txb_GuidatoreCF;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btn_GuidatorePatente_CrescDescr;
        private DateTimePicker dtp_GuidatorePatente;
        private ComboBox cmb_GuidatoreStato;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridViewTextBoxColumn Cognome;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn CodiceFiscale;
        private DataGridViewTextBoxColumn ScadenzaPatente;
        private DataGridViewTextBoxColumn Stato;
        private DataGridViewTextBoxColumn ID_Guidatore;
    }
}
