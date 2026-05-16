namespace FleetManager
{
    partial class FormDettaglioVeicolo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            btn_TerminaAssegnazione = new Button();
            btn_AssegnnaVeicolo = new Button();
            btn_AddManutenzione = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            txb_Targa = new TextBox();
            txb_Modello = new TextBox();
            txb_AnnoProduzione = new TextBox();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            tableLayoutPanel1 = new TableLayoutPanel();
            splitContainer2 = new SplitContainer();
            dGw_Assegnazioni = new DataGridView();
            ID_Assegnazione = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Cognome = new DataGridViewTextBoxColumn();
            ID_Guidatore = new DataGridViewTextBoxColumn();
            DataInizio = new DataGridViewTextBoxColumn();
            DataFine = new DataGridViewTextBoxColumn();
            dGw_Manutenzioni = new DataGridView();
            ID_Manutenzione = new DataGridViewTextBoxColumn();
            DataIntervento = new DataGridViewTextBoxColumn();
            Costo = new DataGridViewTextBoxColumn();
            Descrizione = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGw_Assegnazioni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dGw_Manutenzioni).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 497);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btn_TerminaAssegnazione);
            splitContainer1.Panel1.Controls.Add(btn_AssegnnaVeicolo);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btn_AddManutenzione);
            splitContainer1.Size = new Size(1329, 25);
            splitContainer1.SplitterDistance = 661;
            splitContainer1.TabIndex = 3;
            // 
            // btn_TerminaAssegnazione
            // 
            btn_TerminaAssegnazione.BackColor = Color.Silver;
            btn_TerminaAssegnazione.Dock = DockStyle.Right;
            btn_TerminaAssegnazione.Enabled = false;
            btn_TerminaAssegnazione.FlatStyle = FlatStyle.Flat;
            btn_TerminaAssegnazione.Location = new Point(328, 0);
            btn_TerminaAssegnazione.Name = "btn_TerminaAssegnazione";
            btn_TerminaAssegnazione.Size = new Size(333, 25);
            btn_TerminaAssegnazione.TabIndex = 5;
            btn_TerminaAssegnazione.Text = "TERMINA ASSEGNAZIONE";
            btn_TerminaAssegnazione.UseVisualStyleBackColor = false;
            btn_TerminaAssegnazione.Click += btn_TerminaAssegnazione_Click;
            // 
            // btn_AssegnnaVeicolo
            // 
            btn_AssegnnaVeicolo.BackColor = Color.Silver;
            btn_AssegnnaVeicolo.Dock = DockStyle.Left;
            btn_AssegnnaVeicolo.FlatStyle = FlatStyle.Flat;
            btn_AssegnnaVeicolo.Location = new Point(0, 0);
            btn_AssegnnaVeicolo.Name = "btn_AssegnnaVeicolo";
            btn_AssegnnaVeicolo.Size = new Size(333, 25);
            btn_AssegnnaVeicolo.TabIndex = 4;
            btn_AssegnnaVeicolo.Text = "ASSEGNA VEICOLO";
            btn_AssegnnaVeicolo.UseVisualStyleBackColor = false;
            btn_AssegnnaVeicolo.Click += btn_AssegnnaVeicolo_Click;
            // 
            // btn_AddManutenzione
            // 
            btn_AddManutenzione.BackColor = Color.Silver;
            btn_AddManutenzione.Dock = DockStyle.Fill;
            btn_AddManutenzione.FlatStyle = FlatStyle.Flat;
            btn_AddManutenzione.Location = new Point(0, 0);
            btn_AddManutenzione.Name = "btn_AddManutenzione";
            btn_AddManutenzione.Size = new Size(664, 25);
            btn_AddManutenzione.TabIndex = 3;
            btn_AddManutenzione.Text = "AGGIUNGI MANUTENZIONE";
            btn_AddManutenzione.UseVisualStyleBackColor = false;
            btn_AddManutenzione.Click += btn_AddManutenzione_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(658, 17);
            label1.TabIndex = 2;
            label1.Text = "Targa";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Location = new Point(667, 0);
            label2.Name = "label2";
            label2.Size = new Size(659, 17);
            label2.TabIndex = 3;
            label2.Text = "Modello";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Location = new Point(3, 42);
            label3.Name = "label3";
            label3.Size = new Size(658, 17);
            label3.TabIndex = 4;
            label3.Text = "Anno di Produzione";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(txb_Targa, 0, 1);
            tableLayoutPanel2.Controls.Add(txb_Modello, 1, 1);
            tableLayoutPanel2.Controls.Add(txb_AnnoProduzione, 0, 3);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(label2, 1, 0);
            tableLayoutPanel2.Controls.Add(label3, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 1, 2);
            tableLayoutPanel2.Controls.Add(numericUpDown1, 1, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Size = new Size(1329, 85);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // txb_Targa
            // 
            txb_Targa.Dock = DockStyle.Fill;
            txb_Targa.Location = new Point(3, 20);
            txb_Targa.Name = "txb_Targa";
            txb_Targa.ReadOnly = true;
            txb_Targa.Size = new Size(658, 23);
            txb_Targa.TabIndex = 0;
            // 
            // txb_Modello
            // 
            txb_Modello.Dock = DockStyle.Fill;
            txb_Modello.Location = new Point(667, 20);
            txb_Modello.Name = "txb_Modello";
            txb_Modello.ReadOnly = true;
            txb_Modello.Size = new Size(659, 23);
            txb_Modello.TabIndex = 0;
            // 
            // txb_AnnoProduzione
            // 
            txb_AnnoProduzione.Dock = DockStyle.Fill;
            txb_AnnoProduzione.Location = new Point(3, 62);
            txb_AnnoProduzione.Name = "txb_AnnoProduzione";
            txb_AnnoProduzione.ReadOnly = true;
            txb_AnnoProduzione.Size = new Size(658, 23);
            txb_AnnoProduzione.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Location = new Point(667, 42);
            label4.Name = "label4";
            label4.Size = new Size(659, 17);
            label4.TabIndex = 5;
            label4.Text = "Chilometraggio";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Fill;
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(667, 62);
            numericUpDown1.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.ReadOnly = true;
            numericUpDown1.Size = new Size(659, 23);
            numericUpDown1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 2);
            tableLayoutPanel1.Controls.Add(splitContainer2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.56F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 81.44F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(1335, 525);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 94);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dGw_Assegnazioni);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dGw_Manutenzioni);
            splitContainer2.Size = new Size(1329, 397);
            splitContainer2.SplitterDistance = 664;
            splitContainer2.TabIndex = 4;
            // 
            // dGw_Assegnazioni
            // 
            dGw_Assegnazioni.AllowUserToAddRows = false;
            dGw_Assegnazioni.AllowUserToDeleteRows = false;
            dGw_Assegnazioni.AllowUserToResizeColumns = false;
            dGw_Assegnazioni.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dGw_Assegnazioni.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dGw_Assegnazioni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGw_Assegnazioni.BackgroundColor = SystemColors.Control;
            dGw_Assegnazioni.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dGw_Assegnazioni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Assegnazioni.Columns.AddRange(new DataGridViewColumn[] { ID_Assegnazione, Nome, Cognome, ID_Guidatore, DataInizio, DataFine });
            dGw_Assegnazioni.Dock = DockStyle.Fill;
            dGw_Assegnazioni.EditMode = DataGridViewEditMode.EditOnEnter;
            dGw_Assegnazioni.Location = new Point(0, 0);
            dGw_Assegnazioni.MultiSelect = false;
            dGw_Assegnazioni.Name = "dGw_Assegnazioni";
            dGw_Assegnazioni.ReadOnly = true;
            dGw_Assegnazioni.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dGw_Assegnazioni.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dGw_Assegnazioni.ScrollBars = ScrollBars.Vertical;
            dGw_Assegnazioni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGw_Assegnazioni.Size = new Size(664, 397);
            dGw_Assegnazioni.TabIndex = 3;
            // 
            // ID_Assegnazione
            // 
            ID_Assegnazione.DataPropertyName = "ID_Assegnazione";
            ID_Assegnazione.HeaderText = "ID_Assegnazione";
            ID_Assegnazione.Name = "ID_Assegnazione";
            ID_Assegnazione.ReadOnly = true;
            ID_Assegnazione.Visible = false;
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
            // ID_Guidatore
            // 
            ID_Guidatore.DataPropertyName = "ID_Guidatore";
            ID_Guidatore.HeaderText = "ID Guidatore";
            ID_Guidatore.Name = "ID_Guidatore";
            ID_Guidatore.ReadOnly = true;
            // 
            // DataInizio
            // 
            DataInizio.DataPropertyName = "DataInizio";
            DataInizio.HeaderText = "Data Inizio";
            DataInizio.Name = "DataInizio";
            DataInizio.ReadOnly = true;
            // 
            // DataFine
            // 
            DataFine.DataPropertyName = "DataFine";
            DataFine.HeaderText = "Data Fine";
            DataFine.Name = "DataFine";
            DataFine.ReadOnly = true;
            // 
            // dGw_Manutenzioni
            // 
            dGw_Manutenzioni.AllowUserToAddRows = false;
            dGw_Manutenzioni.AllowUserToDeleteRows = false;
            dGw_Manutenzioni.AllowUserToResizeColumns = false;
            dGw_Manutenzioni.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(224, 224, 224);
            dGw_Manutenzioni.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dGw_Manutenzioni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGw_Manutenzioni.BackgroundColor = SystemColors.Control;
            dGw_Manutenzioni.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dGw_Manutenzioni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Manutenzioni.Columns.AddRange(new DataGridViewColumn[] { ID_Manutenzione, DataIntervento, Costo, Descrizione });
            dGw_Manutenzioni.Dock = DockStyle.Fill;
            dGw_Manutenzioni.EditMode = DataGridViewEditMode.EditOnEnter;
            dGw_Manutenzioni.Location = new Point(0, 0);
            dGw_Manutenzioni.MultiSelect = false;
            dGw_Manutenzioni.Name = "dGw_Manutenzioni";
            dGw_Manutenzioni.ReadOnly = true;
            dGw_Manutenzioni.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dGw_Manutenzioni.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dGw_Manutenzioni.ScrollBars = ScrollBars.Vertical;
            dGw_Manutenzioni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGw_Manutenzioni.Size = new Size(661, 397);
            dGw_Manutenzioni.TabIndex = 4;
            // 
            // ID_Manutenzione
            // 
            ID_Manutenzione.DataPropertyName = "ID_Manutenzione";
            ID_Manutenzione.FillWeight = 43.3164063F;
            ID_Manutenzione.HeaderText = "ID";
            ID_Manutenzione.Name = "ID_Manutenzione";
            ID_Manutenzione.ReadOnly = true;
            // 
            // DataIntervento
            // 
            DataIntervento.DataPropertyName = "DataIntervento";
            DataIntervento.FillWeight = 43.3164063F;
            DataIntervento.HeaderText = "Data";
            DataIntervento.Name = "DataIntervento";
            DataIntervento.ReadOnly = true;
            // 
            // Costo
            // 
            Costo.DataPropertyName = "Costo";
            Costo.FillWeight = 43.3164063F;
            Costo.HeaderText = "Costo";
            Costo.Name = "Costo";
            Costo.ReadOnly = true;
            // 
            // Descrizione
            // 
            Descrizione.DataPropertyName = "Descrizione";
            Descrizione.FillWeight = 200F;
            Descrizione.HeaderText = "Descrizione";
            Descrizione.Name = "Descrizione";
            Descrizione.ReadOnly = true;
            // 
            // FormDettaglioVeicolo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1335, 525);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(1351, 564);
            Name = "FormDettaglioVeicolo";
            Text = "FormDettaglioVeicolo";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGw_Assegnazioni).EndInit();
            ((System.ComponentModel.ISupportInitialize)dGw_Manutenzioni).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox txb_Targa;
        private TextBox txb_Modello;
        private TextBox txb_AnnoProduzione;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private NumericUpDown numericUpDown1;
        private SplitContainer splitContainer2;
        private DataGridView dGw_Assegnazioni;
        private DataGridView dGw_Manutenzioni;
        private Button btn_AssegnnaVeicolo;
        private Button btn_AddManutenzione;
        private DataGridViewTextBoxColumn ID_Assegnazione;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Cognome;
        private DataGridViewTextBoxColumn ID_Guidatore;
        private DataGridViewTextBoxColumn DataInizio;
        private DataGridViewTextBoxColumn DataFine;
        private DataGridViewTextBoxColumn ID_Manutenzione;
        private DataGridViewTextBoxColumn DataIntervento;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Descrizione;
        private Button btn_TerminaAssegnazione;
    }
}