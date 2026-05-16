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

            foreach (DataGridViewRow row in dGw_Assegnazioni.Rows)
            {
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
                            row.Cells["DataFine"].Value = "Attiva";
                            btn_TerminaAssegnazione.Enabled = true;
                        }
                        else if (DateTime.TryParse(row.Cells["DataFine"].Value.ToString(), out DateTime dataFine))
                        {
                            if (dataFine.Date > DateTime.Today)
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
    }
}
