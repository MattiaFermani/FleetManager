using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System;
using System.Windows.Forms; // <-- Controlla che ci sia questo!
using System.Drawing;
using System.Drawing.Drawing2D;
using FleetManager.DB;
using System.Collections.Generic;

namespace FleetManager
{
    partial class AggiungiManutenzione
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
            dtp_DataIntervento = new DateTimePicker();
            num_CostoIntervento = new NumericUpDown();
            txb_Descrizione = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_Conferma = new Button();
            ((System.ComponentModel.ISupportInitialize)num_CostoIntervento).BeginInit();
            SuspendLayout();
            // 
            // dtp_DataIntervento
            // 
            dtp_DataIntervento.Location = new Point(12, 28);
            dtp_DataIntervento.Name = "dtp_DataIntervento";
            dtp_DataIntervento.Size = new Size(200, 23);
            dtp_DataIntervento.TabIndex = 0;
            // 
            // num_CostoIntervento
            // 
            num_CostoIntervento.Location = new Point(234, 28);
            num_CostoIntervento.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            num_CostoIntervento.Name = "num_CostoIntervento";
            num_CostoIntervento.Size = new Size(215, 23);
            num_CostoIntervento.TabIndex = 1;
            // 
            // txb_Descrizione
            // 
            txb_Descrizione.Location = new Point(12, 74);
            txb_Descrizione.Multiline = true;
            txb_Descrizione.Name = "txb_Descrizione";
            txb_Descrizione.Size = new Size(437, 77);
            txb_Descrizione.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 3;
            label1.Text = "Data Intervento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(234, 10);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 3;
            label2.Text = "Costo Intervento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 56);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 3;
            label3.Text = "Descrizione Intervento";
            // 
            // btn_Conferma
            // 
            btn_Conferma.Location = new Point(374, 157);
            btn_Conferma.Name = "btn_Conferma";
            btn_Conferma.Size = new Size(75, 23);
            btn_Conferma.TabIndex = 4;
            btn_Conferma.Text = "Conferma";
            btn_Conferma.UseVisualStyleBackColor = true;
            btn_Conferma.Click += btn_Conferma_Click;
            // 
            // AggiungiManutenzione
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 183);
            Controls.Add(btn_Conferma);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txb_Descrizione);
            Controls.Add(num_CostoIntervento);
            Controls.Add(dtp_DataIntervento);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AggiungiManutenzione";
            Text = "AggiungiManutenzione";
            ((System.ComponentModel.ISupportInitialize)num_CostoIntervento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtp_DataIntervento;
        private NumericUpDown num_CostoIntervento;
        private TextBox txb_Descrizione;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_Conferma;
    }
}