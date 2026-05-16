using FleetManager.DB;
using FleetManager.Entita;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FleetManager
{
    public partial class AggiungiAssegnazione : Form
    {
        int FK_Veicolo;
        public AggiungiAssegnazione(int FK_Veicolo)
        {
            InitializeComponent();
            this.FK_Veicolo = FK_Veicolo;
            this.Text = "Aggiungi Assegnazione per Veicolo ID: " + FK_Veicolo.ToString();
            cmb_Guidatore.DataSource = MethodsDB.RicercaGuidatori()
                .Select(g => new { g.ID_Guidatore, Display = $"{g.ID_Guidatore} - {g.Nome} {g.Cognome}" })
                .ToList();
            cmb_Guidatore.DisplayMember = "Display";
            cmb_Guidatore.ValueMember = "ID_Guidatore";
        }

        private void btn_Conferma_Click(object sender, EventArgs e)
        {
            Assegnazione assegnazione = new Assegnazione
            (
                fK_Veicolo: this.FK_Veicolo,
                fK_Guidatore: (int)cmb_Guidatore.SelectedValue,
                dataInizio: dtp_DataInizio.Value,
                dataFine: ckb_DataFine.Checked ? (DateTime?)dtp_DataFine.Value : null
            );
            List<Assegnazione> assegnazioni = MethodsDB.GetAssegnazioniByVeicolo(this.FK_Veicolo);
            if(assegnazioni != null)
            {
                DateTime newStart = dtp_DataInizio.Value.Date;
                DateTime? newEnd = ckb_DataFine.Checked ? dtp_DataFine.Value.Date : (DateTime?)null;

                foreach (Assegnazione a in assegnazioni)
                {
                    DateTime aStart = a.DataInizio.Date;
                    DateTime? aEnd = a.DataFine?.Date;

                    // Se non ho inserito una data fine e è presente una assegnazione con DataInizio > DateTime.Today
                    if (newEnd == null && aStart > DateTime.Today)
                    {
                        MessageBox.Show("Impossibile aggiungere un'assegnazione senza data di fine: esiste già una assegnazione futura per questo veicolo.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Se è presente una assegnazione con DataInizio > DateTime.Today e la data di fine inserita sovrappone
                    if (aStart > DateTime.Today && newEnd != null && newEnd.Value >= aStart)
                    {
                        MessageBox.Show("La data di fine inserita si sovrappone a un'assegnazione futura esistente. Modifica le date prima di procedere.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Se è presente una assegnazione aperta (DataFine == null) iniziata in passato o oggi
                    if (aEnd == null && aStart <= DateTime.Today)
                    {
                        MessageBox.Show("Il veicolo è attualmente assegnato (assegnazione aperta). Termina l'assegnazione precedente prima di aggiungerne una nuova.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            MethodsDB.InserisciAssegnazione(assegnazione);
            this.Close();
        }

        private void ckb_DataFine_CheckedChanged(object sender, EventArgs e)
        {
            dtp_DataFine.Enabled = ckb_DataFine.Checked;
        }
    }
}
