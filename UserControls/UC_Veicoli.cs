using Dapper;
using FleetManager.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FleetManager
{
    public partial class UC_Veicoli : UserControl
    {
        public UC_Veicoli()
        {
            InitializeComponent();
            dGw_Veicoli.AutoGenerateColumns = false;

            //// Configura la colonna Stato (deve essere DataGridViewComboBoxColumn nel Designer)
            //var colStato = (DataGridViewComboBoxColumn)dGw_Veicoli.Columns["Stato"];
            //colStato.DataPropertyName = "Stato"; // Lega al campo del DB

            //// Popola le opzioni della tendina
            //colStato.Items.Clear();
            //colStato.Items.AddRange(new string[] { "Disponibile", "In Uso", "In Manutenzione" });

            //// Rendi la tendina subito reattiva
            //dGw_Veicoli.EditMode = DataGridViewEditMode.EditOnEnter;

            // Filtro Anno
            cmb_FilterYearProd.Items.Clear();
            cmb_FilterYearProd.Items.Add("Tutti gli anni");
            cmb_FilterYearProd.Items.AddRange(MethodsDB.GetDistintiAnni().ToArray());
            cmb_FilterYearProd.SelectedIndex = 0;

            // Filtro Modello
            cmb_FilterModello.Items.Clear();
            cmb_FilterModello.Items.Add("Tutti i modelli");
            cmb_FilterModello.Items.AddRange(MethodsDB.GetDistintiModelli().ToArray());
            cmb_FilterModello.SelectedIndex = 0;

            // Filtro Stato (Fisso o dal DB)
            cmb_FilterStato.Items.Clear();
            cmb_FilterStato.Items.Add("Tutti gli stati");
            cmb_FilterStato.Items.AddRange(new string[] { "Disponibile", "In Uso", "In Manutenzione" });
            cmb_FilterStato.SelectedIndex = 0;

        }

        public void LoadData()
        {
            try
            {

                var veicoli = MethodsDB.RicercaVeicoli().ToList();
                dGw_Veicoli.DataSource = veicoli;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei veicoli: " + ex.Message);
            }
        }

        private void UC_Veicoli_Load(object sender, EventArgs e)
        {
            LoadData();
            FormattaGrid(dGw_Veicoli);
        }

        private void FormattaGrid(DataGridView dgw)
        {
            dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw.RowHeadersVisible = false;
        }

        private void dGw_Veicoli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dGw_Veicoli.Columns[e.ColumnIndex].Name == "Stato")
            {
                dGw_Veicoli.CurrentCell = dGw_Veicoli.Rows[e.RowIndex].Cells[e.ColumnIndex];

                dGw_Veicoli.BeginEdit(true);

                if (dGw_Veicoli.EditingControl is ComboBox combo)
                {
                    combo.DroppedDown = true;
                }
            }
        }

        private void dGw_Veicoli_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dGw_Veicoli.Columns[e.ColumnIndex].Name == "Stato")
            {

                int idVeicolo = Convert.ToInt32(dGw_Veicoli.Rows[e.RowIndex].Cells["ID"].Value);
                int km = Convert.ToInt32(dGw_Veicoli.Rows[e.RowIndex].Cells["Chilometraggio"].Value);
                string nuovoStato = dGw_Veicoli.Rows[e.RowIndex].Cells["Stato"].Value.ToString();

                try
                {
                    MethodsDB.AggiornaVeicolo(idVeicolo, km, nuovoStato);
                    Filter();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante l'aggiornamento dello stato: " + ex.Message);
                }
            }
        }

        private void txb_FilterTarga_TextChanged(object sender, EventArgs e) => Filter();
        private void cmb_FilterYearProd_SelectedIndexChanged(object sender, EventArgs e) => Filter();
        private void cmb_FilterModello_SelectedIndexChanged(object sender, EventArgs e) => Filter();
        private void cmb_FilterStato_SelectedIndexChanged(object sender, EventArgs e) => Filter();

        private void Filter()
        {
            string targa = string.IsNullOrWhiteSpace(txb_FilterTarga.Text) ? null : txb_FilterTarga.Text.Trim();
            string modello = cmb_FilterModello.SelectedIndex <= 0 ? null : cmb_FilterModello.SelectedItem.ToString();
            string stato = cmb_FilterStato.SelectedIndex <= 0 ? null : cmb_FilterStato.SelectedItem.ToString();

            string annoStr = cmb_FilterYearProd.SelectedIndex <= 0 ? null : cmb_FilterYearProd.SelectedItem.ToString();

            dGw_Veicoli.DataSource = MethodsDB.RicercaVeicoli(targa: targa, modello: modello, stato: stato, annoProduzione: annoStr).ToList();
        }
    }


}
