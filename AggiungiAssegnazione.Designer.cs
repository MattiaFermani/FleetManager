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
    partial class AggiungiAssegnazione
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
            cmb_Guidatore = new ComboBox();
            btn_Conferma = new Button();
            dtp_DataInizio = new DateTimePicker();
            dtp_DataFine = new DateTimePicker();
            ckb_DataFine = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // cmb_Guidatore
            // 
            cmb_Guidatore.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_Guidatore.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb_Guidatore.FormattingEnabled = true;
            cmb_Guidatore.Location = new Point(12, 23);
            cmb_Guidatore.Name = "cmb_Guidatore";
            cmb_Guidatore.Size = new Size(441, 23);
            cmb_Guidatore.TabIndex = 0;
            // 
            // btn_Conferma
            // 
            btn_Conferma.Location = new Point(378, 130);
            btn_Conferma.Name = "btn_Conferma";
            btn_Conferma.Size = new Size(75, 23);
            btn_Conferma.TabIndex = 1;
            btn_Conferma.Text = "Conferma";
            btn_Conferma.UseVisualStyleBackColor = true;
            btn_Conferma.Click += btn_Conferma_Click;
            // 
            // dtp_DataInizio
            // 
            dtp_DataInizio.Location = new Point(12, 74);
            dtp_DataInizio.Name = "dtp_DataInizio";
            dtp_DataInizio.Size = new Size(200, 23);
            dtp_DataInizio.TabIndex = 2;
            // 
            // dtp_DataFine
            // 
            dtp_DataFine.Location = new Point(12, 128);
            dtp_DataFine.Name = "dtp_DataFine";
            dtp_DataFine.Size = new Size(200, 23);
            dtp_DataFine.TabIndex = 3;
            // 
            // ckb_DataFine
            // 
            ckb_DataFine.AutoSize = true;
            ckb_DataFine.Location = new Point(12, 103);
            ckb_DataFine.Name = "ckb_DataFine";
            ckb_DataFine.Size = new Size(77, 19);
            ckb_DataFine.TabIndex = 4;
            ckb_DataFine.Text = "DataFine?";
            ckb_DataFine.UseVisualStyleBackColor = true;
            ckb_DataFine.CheckedChanged += ckb_DataFine_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 5;
            label1.Text = "DataInizio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 5);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 5;
            label2.Text = "Selezione Guidatore";
            // 
            // AggiungiAssegnazione
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 165);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ckb_DataFine);
            Controls.Add(dtp_DataFine);
            Controls.Add(dtp_DataInizio);
            Controls.Add(btn_Conferma);
            Controls.Add(cmb_Guidatore);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AggiungiAssegnazione";
            Text = "AggiungiAssegnazione";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmb_Guidatore;
        private Button btn_Conferma;
        private DateTimePicker dtp_DataInizio;
        private DateTimePicker dtp_DataFine;
        private CheckBox ckb_DataFine;
        private Label label1;
        private Label label2;
    }
}