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
        public FormDettaglioVeicolo(Veicolo v)
        {
            InitializeComponent();
            PopolaCampi(v);
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
            DataInizio.DataPropertyName = "DataInizio";
            DataFine.DataPropertyName = "DataFine";
            var dati = MethodsDB.GetAssegnazioniPerVeicolo(MethodsDB.GetModelloVeicolo().Find(x => x.Targa == txb_Targa.Text).Id);
            dGw_Assegnazioni.DataSource = dati;
        }
        void CaricaManutenzioni()
        {
            ID.DataPropertyName = "ID_Manutenzione";
            DataIntervento.DataPropertyName = "DataIntervento";
            Costo.DataPropertyName = "Costo";
            Descrizione.DataPropertyName = "Descrizione";
            var dati = MethodsDB.GetManutenzioniPerVeicolo(MethodsDB.GetModelloVeicolo().Find(x => x.Targa == txb_Targa.Text).Id);
            dGw_Manutenzioni.DataSource = dati;
        }
    }
}
