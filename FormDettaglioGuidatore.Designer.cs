namespace FleetManager
{
    partial class FormDettaglioGuidatore
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
            txb_Nome = new TextBox();
            txb_Cognome = new TextBox();
            txb_CF = new TextBox();
            dtp_Scadenza = new DateTimePicker();
            dGw_Assegnazioni = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            DataInizio = new DataGridViewTextBoxColumn();
            DataFine = new DataGridViewTextBoxColumn();
            Targa = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            Modello = new DataGridViewTextBoxColumn();
            btn_ApplyEdits = new Button();
            btn_CancelEdits = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)dGw_Assegnazioni).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // txb_Nome
            // 
            txb_Nome.Dock = DockStyle.Fill;
            txb_Nome.Location = new Point(3, 25);
            txb_Nome.Name = "txb_Nome";
            txb_Nome.Size = new Size(223, 23);
            txb_Nome.TabIndex = 0;
            // 
            // txb_Cognome
            // 
            txb_Cognome.Dock = DockStyle.Fill;
            txb_Cognome.Location = new Point(232, 25);
            txb_Cognome.Name = "txb_Cognome";
            txb_Cognome.Size = new Size(224, 23);
            txb_Cognome.TabIndex = 0;
            // 
            // txb_CF
            // 
            txb_CF.Dock = DockStyle.Fill;
            txb_CF.Location = new Point(3, 80);
            txb_CF.Name = "txb_CF";
            txb_CF.Size = new Size(223, 23);
            txb_CF.TabIndex = 0;
            // 
            // dtp_Scadenza
            // 
            dtp_Scadenza.Dock = DockStyle.Fill;
            dtp_Scadenza.Format = DateTimePickerFormat.Short;
            dtp_Scadenza.Location = new Point(232, 80);
            dtp_Scadenza.Name = "dtp_Scadenza";
            dtp_Scadenza.Size = new Size(224, 23);
            dtp_Scadenza.TabIndex = 1;
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
            dGw_Assegnazioni.Columns.AddRange(new DataGridViewColumn[] { ID, DataInizio, DataFine, Targa, Marca, Modello });
            dGw_Assegnazioni.Dock = DockStyle.Fill;
            dGw_Assegnazioni.EditMode = DataGridViewEditMode.EditOnEnter;
            dGw_Assegnazioni.Location = new Point(3, 119);
            dGw_Assegnazioni.MultiSelect = false;
            dGw_Assegnazioni.Name = "dGw_Assegnazioni";
            dGw_Assegnazioni.ReadOnly = true;
            dGw_Assegnazioni.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dGw_Assegnazioni.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dGw_Assegnazioni.ScrollBars = ScrollBars.Vertical;
            dGw_Assegnazioni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGw_Assegnazioni.Size = new Size(459, 503);
            dGw_Assegnazioni.TabIndex = 2;
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
            // Modello
            // 
            Modello.DataPropertyName = "NomeModello";
            Modello.HeaderText = "Modello";
            Modello.Name = "Modello";
            Modello.ReadOnly = true;
            // 
            // btn_ApplyEdits
            // 
            btn_ApplyEdits.BackColor = Color.PaleGreen;
            btn_ApplyEdits.Dock = DockStyle.Fill;
            btn_ApplyEdits.FlatStyle = FlatStyle.Flat;
            btn_ApplyEdits.Location = new Point(0, 0);
            btn_ApplyEdits.Name = "btn_ApplyEdits";
            btn_ApplyEdits.Size = new Size(321, 25);
            btn_ApplyEdits.TabIndex = 3;
            btn_ApplyEdits.Text = "APPLICA";
            btn_ApplyEdits.UseVisualStyleBackColor = false;
            btn_ApplyEdits.Click += btn_ApplyEdits_Click;
            // 
            // btn_CancelEdits
            // 
            btn_CancelEdits.BackColor = Color.Tomato;
            btn_CancelEdits.Dock = DockStyle.Fill;
            btn_CancelEdits.FlatStyle = FlatStyle.Flat;
            btn_CancelEdits.Location = new Point(0, 0);
            btn_CancelEdits.Name = "btn_CancelEdits";
            btn_CancelEdits.Size = new Size(134, 25);
            btn_CancelEdits.TabIndex = 4;
            btn_CancelEdits.Text = "ANNULLA";
            btn_CancelEdits.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(dGw_Assegnazioni, 0, 1);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.56F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 81.44F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(465, 656);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(txb_Nome, 0, 1);
            tableLayoutPanel2.Controls.Add(txb_Cognome, 1, 1);
            tableLayoutPanel2.Controls.Add(txb_CF, 0, 3);
            tableLayoutPanel2.Controls.Add(dtp_Scadenza, 1, 3);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(label2, 1, 0);
            tableLayoutPanel2.Controls.Add(label3, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 1, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Size = new Size(459, 110);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(223, 22);
            label1.TabIndex = 2;
            label1.Text = "Nome";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Location = new Point(232, 0);
            label2.Name = "label2";
            label2.Size = new Size(224, 22);
            label2.TabIndex = 3;
            label2.Text = "Cognome";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Location = new Point(3, 55);
            label3.Name = "label3";
            label3.Size = new Size(223, 22);
            label3.TabIndex = 4;
            label3.Text = "Codice Fiscale";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Location = new Point(232, 55);
            label4.Name = "label4";
            label4.Size = new Size(224, 22);
            label4.TabIndex = 5;
            label4.Text = "Data Scadenza Patente";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 628);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btn_CancelEdits);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btn_ApplyEdits);
            splitContainer1.Size = new Size(459, 25);
            splitContainer1.SplitterDistance = 134;
            splitContainer1.TabIndex = 3;
            // 
            // FormDettaglioGuidatore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 656);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(300, 650);
            Name = "FormDettaglioGuidatore";
            Text = "Info Guidatore";
            ((System.ComponentModel.ISupportInitialize)dGw_Assegnazioni).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txb_Nome;
        private TextBox txb_Cognome;
        private TextBox txb_CF;
        private DateTimePicker dtp_Scadenza;
        private DataGridView dGw_Assegnazioni;
        private Button btn_ApplyEdits;
        private Button btn_CancelEdits;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn DataInizio;
        private DataGridViewTextBoxColumn DataFine;
        private DataGridViewTextBoxColumn Targa;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Modello;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private SplitContainer splitContainer1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}