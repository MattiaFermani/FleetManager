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
            Targa.DataPropertyName = "Targa";
            Marca.DataPropertyName = "Marca";
            Modello.DataPropertyName = "NomeModello";
            DataInizio.DataPropertyName = "DataInizio";
            DataFine.DataPropertyName = "DataFine";

            var dati = MethodsDB.GetDatiTabellaAssegnazioni(this._guidatore.ID_Guidatore);
            dGw_Assegnazioni.DataSource = dati;
        }

        private void btn_ApplyEdits_Click(object sender, EventArgs e)
        {
            string nome = txb_Nome.Text == string.Empty ? _guidatore.Nome : txb_Nome.Text;
            string cognome = txb_Cognome.Text == string.Empty ? _guidatore.Cognome : txb_Cognome.Text;
            string CF = txb_CF.Text == string.Empty ? _guidatore.CodiceFiscale : txb_CF.Text;
            DateTime scadenzaPatente = dtp_Scadenza.Value < DateTime.Now? _guidatore.ScadenzaPatente : dtp_Scadenza.Value;

        }
    }
}
