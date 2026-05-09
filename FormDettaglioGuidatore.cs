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
            PopolaCampi();
            CaricaAssegnazioni();
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
            var list = MethodsDB.GetAssegnazioniPerGuidatore(_guidatore.ID_Guidatore);
            dGw_Assegnazioni.DataSource = list;

            if (dGw_Assegnazioni.Columns["DataInizio"] != null)
                dGw_Assegnazioni.Columns["DataInizio"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dGw_Assegnazioni.Columns["DataFine"] != null)
                dGw_Assegnazioni.Columns["DataFine"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
    }
}
