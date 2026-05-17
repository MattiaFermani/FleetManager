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
    public partial class FormDettaglioVeicolo : Form
    {
        Veicolo veicolo;
        public FormDettaglioVeicolo(Veicolo v)
        {
            InitializeComponent();

            veicolo = v;
            PopolaCampi(veicolo);
            CaricaAssegnazioni();
            CaricaManutenzioni();
            ConfiguraStileGriglia(dGw_Assegnazioni);
            ConfiguraStileGriglia(dGw_Manutenzioni);
        }

        void PopolaCampi(Veicolo v)
        {
            var veicolo = MethodsDB.GetModelloVeicolo().Find(x => x.Targa == v.Targa);
            txb_Targa.Text = veicolo.Targa;
            txb_AnnoProduzione.Text = veicolo.AnnoProduzione.ToString();
            txb_Modello.Text = $"{veicolo.Marca} {veicolo.Modello}";
            numericUpDown1.Value = veicolo.Chilometraggio;
            this.Text += $" - {veicolo.Targa} | {veicolo.Stato}";

        }

        void CaricaAssegnazioni()
        {
            dGw_Assegnazioni.AutoGenerateColumns = false;
            DataInizio.DataPropertyName = "DataInizio";
            DataFine.DataPropertyName = "DataFine";
            Nome.DataPropertyName = "Nome";
            Cognome.DataPropertyName = "Cognome";

            var dati = MethodsDB.GetAssegnazioniPerVeicolo(veicolo.ID_Veicolo);
            dGw_Assegnazioni.DataSource = dati;

            bool haStatoLimitato = veicolo.Stato.Contains("Manutenzione", StringComparison.OrdinalIgnoreCase) ||
                                   veicolo.Stato.Contains("Non Disponibile", StringComparison.OrdinalIgnoreCase) ||
                                   veicolo.Stato.Contains("In Uso", StringComparison.OrdinalIgnoreCase);

            if (haStatoLimitato)
            {
                btn_AssegnnaVeicolo.Enabled = false;
            }

            DataGridViewRow rigaAttivaDaChiudere = null;
            bool presenteAssegnazioneOggi = false;

            foreach (DataGridViewRow row in dGw_Assegnazioni.Rows)
            {
                if (row.IsNewRow) continue;

                var cellaInizio = row.Cells["DataInizio"].Value;
                var cellaFine = row.Cells["DataFine"].Value;

                if (cellaInizio != null && DateTime.TryParse(cellaInizio.ToString(), out DateTime dtInizio))
                {
                    if (dtInizio.Date == DateTime.Today)
                    {
                        presenteAssegnazioneOggi = true;
                    }
                }

                if (cellaFine == null || cellaFine == DBNull.Value || string.IsNullOrWhiteSpace(cellaFine.ToString()))
                {
                    rigaAttivaDaChiudere = row;
                }
            }

            if (rigaAttivaDaChiudere != null && presenteAssegnazioneOggi)
            {
                MethodsDB.TerminaAssegnazione((int)rigaAttivaDaChiudere.Cells["ID_Assegnazione"].Value, DateTime.Today);
            }


            foreach (DataGridViewRow row in dGw_Assegnazioni.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["DataInizio"].Value != null && DateTime.TryParse(row.Cells["DataInizio"].Value.ToString(), out DateTime dataInizio))
                {
                    if (dataInizio.Date > DateTime.Today)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        if (row.Cells["DataFine"].Value == null || string.IsNullOrEmpty(row.Cells["DataFine"].Value.ToString()))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;

                            if (!haStatoLimitato)
                            {
                                btn_TerminaAssegnazione.Enabled = true;
                            }
                        }
                        else if (DateTime.TryParse(row.Cells["DataFine"].Value.ToString(), out DateTime dataFine))
                        {
                            if (dataFine.Date > DateTime.Today && !haStatoLimitato)
                            {
                                btn_TerminaAssegnazione.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        void CaricaManutenzioni()
        {
            dGw_Manutenzioni.AutoGenerateColumns = false;
            ID_Manutenzione.DataPropertyName = "ID_Manutenzione";
            DataIntervento.DataPropertyName = "DataIntervento";
            Costo.DataPropertyName = "Costo";
            Descrizione.DataPropertyName = "Descrizione";
            var dati = MethodsDB.GetManutenzioniPerVeicolo(veicolo.ID_Veicolo);
            dGw_Manutenzioni.DataSource = dati;
        }

        private void btn_AddManutenzione_Click(object sender, EventArgs e)
        {
            AggiungiManutenzione aggiungiManutenzione = new AggiungiManutenzione(veicolo.ID_Veicolo);
            aggiungiManutenzione.ShowDialog();
            CaricaManutenzioni();
        }

        private void btn_TerminaAssegnazione_Click(object sender, EventArgs e)
        {
            List<Assegnazione> assegnazioni = MethodsDB.GetAssegnazioniByVeicolo(veicolo.ID_Veicolo);
            if (assegnazioni.Count > 0)
            {
                var assegnazioneAttiva = assegnazioni.Find(a => a.DataFine == null);
                if (assegnazioneAttiva != null)
                {
                    MethodsDB.TerminaAssegnazione(assegnazioneAttiva.ID_Assegnazione, DateTime.Now);
                    CaricaAssegnazioni();
                }
            }
        }

        private void btn_AssegnnaVeicolo_Click(object sender, EventArgs e)
        {
            AggiungiAssegnazione aggiungiAssegnazione = new AggiungiAssegnazione(veicolo.ID_Veicolo);
            aggiungiAssegnazione.ShowDialog();
            CaricaAssegnazioni();
        }

        private void dGw_Assegnazioni_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dGw_Assegnazioni.Rows[e.RowIndex];

            var valInizio = row.Cells["DataInizio"].Value;
            var valFine = row.Cells["DataFine"].Value;

            DateTime? dataInizio = null;
            DateTime? dataFine = null;

            if (valInizio != null && DateTime.TryParse(valInizio.ToString(), out DateTime dtIniz))
                dataInizio = dtIniz.Date;

            if (valFine != null && DateTime.TryParse(valFine.ToString(), out DateTime dtFine))
                dataFine = dtFine.Date;

            bool esFutura = dataInizio.HasValue && dataInizio.Value > DateTime.Today;

            bool esSenzaDataFine = valFine == null || valFine == DBNull.Value || string.IsNullOrWhiteSpace(valFine.ToString());

            bool esAttivaOggi = dataInizio.HasValue && dataFine.HasValue &&
                                dataInizio.Value <= DateTime.Today && dataFine.Value >= DateTime.Today;

            if (esFutura)
            {
                e.CellStyle.BackColor = Color.LightYellow;
                e.CellStyle.SelectionBackColor = Color.LightYellow;
            }
            else if (esSenzaDataFine || esAttivaOggi)
            {
                e.CellStyle.BackColor = Color.LightGreen;
                e.CellStyle.SelectionBackColor = Color.LightGreen;
            }

            if (dGw_Assegnazioni.Columns[e.ColumnIndex].Name == "DataFine" && esSenzaDataFine)
            {
                e.Value = "Attiva";
                e.FormattingApplied = true;
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
    }
}
