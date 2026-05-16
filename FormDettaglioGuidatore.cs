using FleetManager.DB;
using FleetManager.Entita;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FleetManager
{
    public partial class FormDettaglioGuidatore : Form
    {
        private Guidatore _guidatore;

        public FormDettaglioGuidatore(Guidatore g)
        {
            InitializeComponent();
            _guidatore = g;
            ConfiguraStileGriglia(dGw_Assegnazioni);
            ConfiguraStileGriglia(dgw_Incidenti);
            PopolaCampi();
            CaricaAssegnazioni();
            CaricaIncidenti();
        }

        private void PopolaCampi()
        {
            txb_Nome.Text = _guidatore.Nome;
            txb_Cognome.Text = _guidatore.Cognome;
            txb_CF.Text = _guidatore.CodiceFiscale;
            dtp_Scadenza.Value = _guidatore.ScadenzaPatente;

        }

        private void CaricaAssegnazioni()
        {
            dGw_Assegnazioni.AutoGenerateColumns = false;
            Targa.DataPropertyName = "Targa";
            Marca.DataPropertyName = "Marca";
            Modello.DataPropertyName = "NomeModello";
            DataInizio.DataPropertyName = "DataInizio";
            DataFine.DataPropertyName = "DataFine";

            var dati = MethodsDB.GetDatiTabellaAssegnazioni(this._guidatore.ID_Guidatore);
            dGw_Assegnazioni.DataSource = dati;
        }

        private void CaricaIncidenti()
        {
            dgw_Incidenti.AutoGenerateColumns = false;
            var dati = MethodsDB.GetIncidentiPerGuidatore(this._guidatore.ID_Guidatore);
            dgw_Incidenti.DataSource = dati;
        }

        private void btn_ApplyEdits_Click(object sender, EventArgs e)
        {
            string nome = txb_Nome.Text == string.Empty ? _guidatore.Nome : txb_Nome.Text;
            string cognome = txb_Cognome.Text == string.Empty ? _guidatore.Cognome : txb_Cognome.Text;
            string CF = txb_CF.Text == string.Empty ? _guidatore.CodiceFiscale : txb_CF.Text;
            DateTime scadenzaPatente = dtp_Scadenza.Value <= DateTime.Now.AddDays(-1) ? _guidatore.ScadenzaPatente : dtp_Scadenza.Value;
            Guidatore g = new Guidatore(
                Id_Guidatore: _guidatore.ID_Guidatore,
                Nome: nome,
                Cognome: cognome,
                CodiceFiscale: CF,
                ScadenzaPatente: scadenzaPatente,
                Stato: _guidatore.Stato
            );

            if (MethodsDB.AggiornaInfoGuidatore(g))
            {
                MessageBox.Show("Informazioni aggiornate con successo.");
                this._guidatore = g;
                PopolaCampi();
                CaricaAssegnazioni();
                UC_Guidatori.Instance.RefreshData();
            }
            else
            {
                MessageBox.Show("Errore durante l'aggiornamento delle informazioni.");
            }

        }

        private void ConfiguraStileGriglia(DataGridView dgw)
        {
            // 1. FONDAMENTALE: Permette di sovrascrivere lo stile nativo di Windows per le intestazioni
            dgw.EnableHeadersVisualStyles = false;

            // 2. Proprietà di Struttura e Bordi
            dgw.BackgroundColor = Color.FromArgb(249, 250, 251); // Sfondo grigio chiarissimo (Tailwind Gray 50)
            dgw.GridColor = Color.FromArgb(243, 244, 246);       // Linee di divisione molto tenui (Gray 100)
            dgw.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Solo linee orizzontali, look più pulito
            dgw.RowHeadersVisible = false;                       // Nasconde la colonna vuota a sinistra
            dgw.BorderStyle = BorderStyle.None;

            // 3. Il "Respiro" (Righe più alte = interfaccia moderna)
            dgw.RowTemplate.Height = 40;                         // Diamo spazio alle celle
            dgw.ColumnHeadersHeight = 42;                        // Più spazio per i titoli
            dgw.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // 4. Stile dell'Intestazione (Header) - Stile scuro "Pro"
            DataGridViewCellStyle stileHeader = new DataGridViewCellStyle();
            stileHeader.BackColor = Color.FromArgb(31, 41, 55);            // Antracite scuro (Gray 800)
            stileHeader.SelectionBackColor = Color.FromArgb(31, 41, 55);   // Mantiene lo stesso colore anche in selezione
            stileHeader.ForeColor = Color.White;                           // Testo bianco
            stileHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            stileHeader.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgw.ColumnHeadersDefaultCellStyle = stileHeader;

            // 5. Stile delle Righe Standard (Default)
            DataGridViewCellStyle stileRighe = new DataGridViewCellStyle();
            stileRighe.BackColor = Color.White;
            stileRighe.ForeColor = Color.FromArgb(55, 65, 81);             // Grigio scuro (meno aggressivo del nero puro)
            stileRighe.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            // Colore di selezione armonioso (Azzurro morbido con testo scuro, non il blu elettrico di Windows)
            stileRighe.SelectionBackColor = Color.FromArgb(239, 246, 255); // Blue 50
            stileRighe.SelectionForeColor = Color.FromArgb(29, 78, 216);   // Blue 700
            stileRighe.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgw.DefaultCellStyle = stileRighe;

            // 6. Stile Righe Alterne (Per migliorare la lettura dei dati)
            DataGridViewCellStyle stileRigheAlterne = new DataGridViewCellStyle();
            stileRigheAlterne.BackColor = Color.FromArgb(249, 250, 251);   // Sfondo alternato Gray 50
            stileRigheAlterne.ForeColor = Color.FromArgb(55, 65, 81);
            stileRigheAlterne.SelectionBackColor = Color.FromArgb(239, 246, 255);
            stileRigheAlterne.SelectionForeColor = Color.FromArgb(29, 78, 216);
            stileRigheAlterne.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgw.AlternatingRowsDefaultCellStyle = stileRigheAlterne;
        }

        private void btnn_AggiungiIncidente_Click(object sender, EventArgs e)
        {
            AggiungiIncidente form = new AggiungiIncidente(this._guidatore.ID_Guidatore);
            form.ShowDialog();
            CaricaIncidenti();
        }

        private void btn_CancelEdits_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
