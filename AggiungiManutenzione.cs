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
    public partial class AggiungiManutenzione : Form
    {
        int FK_Veicolo;
        FormDettaglioVeicolo formDettaglioVeicolo;
        public AggiungiManutenzione(int FK_Veicolo)
        {
            InitializeComponent();
            this.FK_Veicolo = FK_Veicolo;
            this.formDettaglioVeicolo = formDettaglioVeicolo;
            this.Text = "Aggiungi Manutenzione per Veicolo ID: " + FK_Veicolo.ToString();
        }

        private void btn_Conferma_Click(object sender, EventArgs e)
        {
            Manutenzione manutenzione = new Manutenzione
            (
                fK_Veicolo : this.FK_Veicolo,
                dataIntervento : dtp_DataIntervento.Value,
                costo : num_CostoIntervento.Value,
                descrizione : txb_Descrizione.Text
            );
            if (MethodsDB.InserisciManutenzione(manutenzione))
            {
                MessageBox.Show("Manutenzione aggiunta con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Errore durante l'aggiunta della manutenzione. Riprova.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
