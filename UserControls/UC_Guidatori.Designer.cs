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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dGw_Guidatori = new DataGridView();
            ID_Guidatore = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Cognome = new DataGridViewTextBoxColumn();
            CodiceFiscale = new DataGridViewTextBoxColumn();
            ScadenzaPatente = new DataGridViewTextBoxColumn();
            Stato = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dGw_Guidatori).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dGw_Guidatori
            // 
            dGw_Guidatori.AllowUserToAddRows = false;
            dGw_Guidatori.AllowUserToDeleteRows = false;
            dGw_Guidatori.AllowUserToResizeColumns = false;
            dGw_Guidatori.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            dGw_Guidatori.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dGw_Guidatori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGw_Guidatori.BackgroundColor = SystemColors.Control;
            dGw_Guidatori.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dGw_Guidatori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Guidatori.Columns.AddRange(new DataGridViewColumn[] { ID_Guidatore, Nome, Cognome, CodiceFiscale, ScadenzaPatente, Stato });
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
            // 
            // ID_Guidatore
            // 
            ID_Guidatore.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ID_Guidatore.DataPropertyName = "ID_Guidatore";
            ID_Guidatore.Frozen = true;
            ID_Guidatore.HeaderText = "ID";
            ID_Guidatore.Name = "ID_Guidatore";
            ID_Guidatore.ReadOnly = true;
            ID_Guidatore.Visible = false;
            // 
            // Nome
            // 
            Nome.DataPropertyName = "Nome";
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            // 
            // Cognome
            // 
            Cognome.DataPropertyName = "Cognome";
            Cognome.HeaderText = "Cognome";
            Cognome.Name = "Cognome";
            Cognome.ReadOnly = true;
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
            tableLayoutPanel1.Controls.Add(textBox1, 0, 2);
            tableLayoutPanel1.Controls.Add(textBox2, 1, 2);
            tableLayoutPanel1.Controls.Add(textBox3, 2, 2);
            tableLayoutPanel1.Controls.Add(textBox4, 3, 2);
            tableLayoutPanel1.Controls.Add(textBox5, 4, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(877, 71);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(166, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(175, 33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(166, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(347, 33);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(166, 23);
            textBox3.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(519, 33);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(166, 23);
            textBox4.TabIndex = 1;
            // 
            // textBox5
            // 
            textBox5.Dock = DockStyle.Fill;
            textBox5.Location = new Point(691, 33);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(166, 23);
            textBox5.TabIndex = 1;
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
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGw_Guidatori;
        private DataGridViewTextBoxColumn ID_Guidatore;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Cognome;
        private DataGridViewTextBoxColumn CodiceFiscale;
        private DataGridViewTextBoxColumn ScadenzaPatente;
        private DataGridViewTextBoxColumn Stato;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
    }
}
