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
            DataInizio = new DataGridViewTextBoxColumn();
            DataFine = new DataGridViewTextBoxColumn();
            Targa = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            Modello = new DataGridViewTextBoxColumn();
            btn_ApplyEdits = new Button();
            btn_CancelEdits = new Button();
            ((System.ComponentModel.ISupportInitialize)dGw_Assegnazioni).BeginInit();
            SuspendLayout();
            // 
            // txb_Nome
            // 
            txb_Nome.Location = new Point(12, 42);
            txb_Nome.Name = "txb_Nome";
            txb_Nome.Size = new Size(170, 23);
            txb_Nome.TabIndex = 0;
            // 
            // txb_Cognome
            // 
            txb_Cognome.Location = new Point(188, 42);
            txb_Cognome.Name = "txb_Cognome";
            txb_Cognome.Size = new Size(167, 23);
            txb_Cognome.TabIndex = 0;
            // 
            // txb_CF
            // 
            txb_CF.Location = new Point(12, 112);
            txb_CF.Name = "txb_CF";
            txb_CF.Size = new Size(170, 23);
            txb_CF.TabIndex = 0;
            // 
            // dtp_Scadenza
            // 
            dtp_Scadenza.Format = DateTimePickerFormat.Short;
            dtp_Scadenza.Location = new Point(188, 109);
            dtp_Scadenza.Name = "dtp_Scadenza";
            dtp_Scadenza.Size = new Size(167, 23);
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
            dGw_Assegnazioni.Columns.AddRange(new DataGridViewColumn[] { DataInizio, DataFine, Targa, Marca, Modello });
            dGw_Assegnazioni.EditMode = DataGridViewEditMode.EditOnEnter;
            dGw_Assegnazioni.Location = new Point(12, 160);
            dGw_Assegnazioni.MultiSelect = false;
            dGw_Assegnazioni.Name = "dGw_Assegnazioni";
            dGw_Assegnazioni.ReadOnly = true;
            dGw_Assegnazioni.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dGw_Assegnazioni.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dGw_Assegnazioni.ScrollBars = ScrollBars.Vertical;
            dGw_Assegnazioni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGw_Assegnazioni.Size = new Size(343, 459);
            dGw_Assegnazioni.TabIndex = 2;
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
            btn_ApplyEdits.Location = new Point(188, 625);
            btn_ApplyEdits.Name = "btn_ApplyEdits";
            btn_ApplyEdits.Size = new Size(167, 23);
            btn_ApplyEdits.TabIndex = 3;
            btn_ApplyEdits.Text = "Applica Modifiche";
            btn_ApplyEdits.UseVisualStyleBackColor = false;
            // 
            // btn_CancelEdits
            // 
            btn_CancelEdits.BackColor = Color.Tomato;
            btn_CancelEdits.Location = new Point(12, 625);
            btn_CancelEdits.Name = "btn_CancelEdits";
            btn_CancelEdits.Size = new Size(170, 23);
            btn_CancelEdits.TabIndex = 4;
            btn_CancelEdits.Text = "Cancel";
            btn_CancelEdits.UseVisualStyleBackColor = false;
            // 
            // FormDettaglioGuidatore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 656);
            Controls.Add(btn_CancelEdits);
            Controls.Add(btn_ApplyEdits);
            Controls.Add(dGw_Assegnazioni);
            Controls.Add(dtp_Scadenza);
            Controls.Add(txb_Cognome);
            Controls.Add(txb_CF);
            Controls.Add(txb_Nome);
            Name = "FormDettaglioGuidatore";
            Text = "FormDettaglioGuidatore";
            ((System.ComponentModel.ISupportInitialize)dGw_Assegnazioni).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txb_Nome;
        private TextBox txb_Cognome;
        private TextBox txb_CF;
        private DateTimePicker dtp_Scadenza;
        private DataGridView dGw_Assegnazioni;
        private DataGridViewTextBoxColumn DataInizio;
        private DataGridViewTextBoxColumn DataFine;
        private DataGridViewTextBoxColumn Targa;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Modello;
        private Button btn_ApplyEdits;
        private Button btn_CancelEdits;
    }
}