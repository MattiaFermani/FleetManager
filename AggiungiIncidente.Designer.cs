namespace FleetManager
{
    partial class AggiungiIncidente
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
            cmb_Veicolo = new ComboBox();
            label1 = new Label();
            dtp_DataIncidente = new DateTimePicker();
            txb_DescrizioneDanni = new TextBox();
            label2 = new Label();
            btnn_Conferma = new Button();
            SuspendLayout();
            // 
            // cmb_Veicolo
            // 
            cmb_Veicolo.FormattingEnabled = true;
            cmb_Veicolo.Location = new Point(12, 26);
            cmb_Veicolo.Name = "cmb_Veicolo";
            cmb_Veicolo.Size = new Size(449, 23);
            cmb_Veicolo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 61);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 1;
            label1.Text = "Data Incidente";
            // 
            // dtp_DataIncidente
            // 
            dtp_DataIncidente.Location = new Point(12, 79);
            dtp_DataIncidente.Name = "dtp_DataIncidente";
            dtp_DataIncidente.Size = new Size(200, 23);
            dtp_DataIncidente.TabIndex = 2;
            // 
            // txb_DescrizioneDanni
            // 
            txb_DescrizioneDanni.Location = new Point(12, 130);
            txb_DescrizioneDanni.Multiline = true;
            txb_DescrizioneDanni.Name = "txb_DescrizioneDanni";
            txb_DescrizioneDanni.Size = new Size(449, 91);
            txb_DescrizioneDanni.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 112);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 1;
            label2.Text = "Descrizione Danni";
            // 
            // btnn_Conferma
            // 
            btnn_Conferma.Location = new Point(386, 234);
            btnn_Conferma.Name = "btnn_Conferma";
            btnn_Conferma.Size = new Size(75, 23);
            btnn_Conferma.TabIndex = 4;
            btnn_Conferma.Text = "Conferma";
            btnn_Conferma.UseVisualStyleBackColor = true;
            btnn_Conferma.Click += btnn_Conferma_Click;
            // 
            // AggiungiIncidente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 269);
            Controls.Add(btnn_Conferma);
            Controls.Add(txb_DescrizioneDanni);
            Controls.Add(dtp_DataIncidente);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmb_Veicolo);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AggiungiIncidente";
            Text = "AggiungiIncidente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmb_Veicolo;
        private Label label1;
        private DateTimePicker dtp_DataIncidente;
        private TextBox txb_DescrizioneDanni;
        private Label label2;
        private Button btnn_Conferma;
    }
}