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
    public partial class AggiungiIncidente : Form
    {
        int FK_Guidatore;
        public AggiungiIncidente(int idGuidatore)
        {
            InitializeComponent();
            this.FK_Guidatore = idGuidatore;
            this.Text = "Aggiungi Incidente per Guidatore ID: " + idGuidatore.ToString();
            cmb_Veicolo.DataSource = MethodsDB.RicercaVeicoli()
                .Select(v => new { v.ID_Veicolo, Display = $"{v.ID_Veicolo} - {v.Marca} {v.Modello}" })
                .ToList();
            cmb_Veicolo.DisplayMember = "Display";
            cmb_Veicolo.ValueMember = "ID_Veicolo";
        }

        private void btnn_Conferma_Click(object sender, EventArgs e)
        {
            if (cmb_Veicolo.SelectedValue == null)
            {
                MessageBox.Show("Seleziona un veicolo valido.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Incidente incidente = new Incidente
            (
                fK_Guidatore: this.FK_Guidatore,
                fK_Veicolo: (int)cmb_Veicolo.SelectedValue,
                dataIncidente: dtp_DataIncidente.Value,
                descrizioneDanni: txb_DescrizioneDanni.Text
            );
            MethodsDB.InserisciIncidente(incidente);
            MessageBox.Show("Incidente aggiunto con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
