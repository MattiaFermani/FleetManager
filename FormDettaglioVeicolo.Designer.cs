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
            btn_CancelEdits = new Button();
            btn_ApplyEdits = new Button();
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
            ID = new DataGridViewTextBoxColumn();
            DataInizio = new DataGridViewTextBoxColumn();
            DataFine = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Cognome = new DataGridViewTextBoxColumn();
            ID_Guidatore = new DataGridViewTextBoxColumn();
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
            splitContainer1.Location = new Point(3, 508);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btn_CancelEdits);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btn_ApplyEdits);
            splitContainer1.Size = new Size(846, 25);
            splitContainer1.SplitterDistance = 246;
            splitContainer1.TabIndex = 3;
            // 
            // btn_CancelEdits
            // 
            btn_CancelEdits.BackColor = Color.Tomato;
            btn_CancelEdits.Dock = DockStyle.Fill;
            btn_CancelEdits.FlatStyle = FlatStyle.Flat;
            btn_CancelEdits.Location = new Point(0, 0);
            btn_CancelEdits.Name = "btn_CancelEdits";
            btn_CancelEdits.Size = new Size(246, 25);
            btn_CancelEdits.TabIndex = 4;
            btn_CancelEdits.Text = "ANNULLA";
            btn_CancelEdits.UseVisualStyleBackColor = false;
            // 
            // btn_ApplyEdits
            // 
            btn_ApplyEdits.BackColor = Color.PaleGreen;
            btn_ApplyEdits.Dock = DockStyle.Fill;
            btn_ApplyEdits.FlatStyle = FlatStyle.Flat;
            btn_ApplyEdits.Location = new Point(0, 0);
            btn_ApplyEdits.Name = "btn_ApplyEdits";
            btn_ApplyEdits.Size = new Size(596, 25);
            btn_ApplyEdits.TabIndex = 3;
            btn_ApplyEdits.Text = "APPLICA";
            btn_ApplyEdits.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(417, 17);
            label1.TabIndex = 2;
            label1.Text = "Targa";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Location = new Point(426, 0);
            label2.Name = "label2";
            label2.Size = new Size(417, 17);
            label2.TabIndex = 3;
            label2.Text = "Modello";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Location = new Point(3, 43);
            label3.Name = "label3";
            label3.Size = new Size(417, 17);
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
            tableLayoutPanel2.Size = new Size(846, 87);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // txb_Targa
            // 
            txb_Targa.Dock = DockStyle.Fill;
            txb_Targa.Location = new Point(3, 20);
            txb_Targa.Name = "txb_Targa";
            txb_Targa.ReadOnly = true;
            txb_Targa.Size = new Size(417, 23);
            txb_Targa.TabIndex = 0;
            // 
            // txb_Modello
            // 
            txb_Modello.Dock = DockStyle.Fill;
            txb_Modello.Location = new Point(426, 20);
            txb_Modello.Name = "txb_Modello";
            txb_Modello.ReadOnly = true;
            txb_Modello.Size = new Size(417, 23);
            txb_Modello.TabIndex = 0;
            // 
            // txb_AnnoProduzione
            // 
            txb_AnnoProduzione.Dock = DockStyle.Fill;
            txb_AnnoProduzione.Location = new Point(3, 63);
            txb_AnnoProduzione.Name = "txb_AnnoProduzione";
            txb_AnnoProduzione.ReadOnly = true;
            txb_AnnoProduzione.Size = new Size(417, 23);
            txb_AnnoProduzione.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Location = new Point(426, 43);
            label4.Name = "label4";
            label4.Size = new Size(417, 17);
            label4.TabIndex = 5;
            label4.Text = "Chilometraggio";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Fill;
            numericUpDown1.Location = new Point(426, 63);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.ReadOnly = true;
            numericUpDown1.Size = new Size(417, 23);
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
            tableLayoutPanel1.Size = new Size(852, 536);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 96);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dGw_Assegnazioni);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dGw_Manutenzioni);
            splitContainer2.Size = new Size(846, 406);
            splitContainer2.SplitterDistance = 423;
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
            dGw_Assegnazioni.Columns.AddRange(new DataGridViewColumn[] { ID, DataInizio, DataFine, Nome, Cognome, ID_Guidatore });
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
            dGw_Assegnazioni.Size = new Size(423, 406);
            dGw_Assegnazioni.TabIndex = 3;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID_Assegnazione";
            ID.HeaderText = "ID_Assegnazioni";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
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
            ID_Guidatore.HeaderText = "ID Guidatore";
            ID_Guidatore.Name = "ID_Guidatore";
            ID_Guidatore.ReadOnly = true;
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
            dGw_Manutenzioni.Size = new Size(419, 406);
            dGw_Manutenzioni.TabIndex = 4;
            // 
            // ID_Manutenzione
            // 
            ID_Manutenzione.DataPropertyName = "ID_Manutenzione";
            ID_Manutenzione.HeaderText = "ID Manutenzione";
            ID_Manutenzione.Name = "ID_Manutenzione";
            ID_Manutenzione.ReadOnly = true;
            // 
            // DataIntervento
            // 
            DataIntervento.DataPropertyName = "DataIntervento";
            DataIntervento.HeaderText = "Data Intervento";
            DataIntervento.Name = "DataIntervento";
            DataIntervento.ReadOnly = true;
            // 
            // Costo
            // 
            Costo.DataPropertyName = "Costo";
            Costo.HeaderText = "Costo";
            Costo.Name = "Costo";
            Costo.ReadOnly = true;
            // 
            // Descrizione
            // 
            Descrizione.DataPropertyName = "Descrizione";
            Descrizione.HeaderText = "Descrizione";
            Descrizione.Name = "Descrizione";
            Descrizione.ReadOnly = true;
            // 
            // FormDettaglioVeicolo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 536);
            Controls.Add(tableLayoutPanel1);
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
        private Button btn_CancelEdits;
        private Button btn_ApplyEdits;
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
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn DataInizio;
        private DataGridViewTextBoxColumn DataFine;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Cognome;
        private DataGridViewTextBoxColumn ID_Guidatore;
        private DataGridView dGw_Manutenzioni;
        private DataGridViewTextBoxColumn ID_Manutenzione;
        private DataGridViewTextBoxColumn DataIntervento;
        private DataGridViewTextBoxColumn Costo;
        private DataGridViewTextBoxColumn Descrizione;
    }
}