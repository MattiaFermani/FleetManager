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
    public enum KmFilterType
    {
        Under,
        Over,
        Equal
    }
    public enum OrderType
    {
        Ascending,
        Descending,
        None
    }

    public partial class UC_Veicoli : UserControl
    {

        KmFilterType KmfilterType = KmFilterType.Over;
        OrderType StatusOrderTyp = OrderType.None;
        OrderType KmOrderType = OrderType.None;
        OrderType AnnoProduzioneOrderType = OrderType.None;
        OrderType ModelloOrderType = OrderType.None;
        OrderType MarcaOrderType = OrderType.None;

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

            // Filtro Marca
            cmb_FilterMarca.Items.Clear();
            cmb_FilterMarca.Items.Add("Tutte le marche");
            cmb_FilterMarca.Items.AddRange(MethodsDB.GetDistinteMarche().ToArray());
            cmb_FilterMarca.SelectedIndex = 0;

            // Filtro Modello
            cmb_FilterModello.Items.Clear();
            cmb_FilterModello.Items.Add("Tutti i modelli");
            cmb_FilterModello.Items.AddRange(MethodsDB.GetDistintiModelli().ToArray());
            cmb_FilterModello.SelectedIndex = 0;

            // Filtro Anno
            cmb_FilterYearProd.Items.Clear();
            cmb_FilterYearProd.Items.Add("Tutti gli anni");
            cmb_FilterYearProd.Items.AddRange(MethodsDB.GetDistintiAnni().ToArray());
            cmb_FilterYearProd.SelectedIndex = 0;

            // Filtro Stato
            cmb_FilterStato.Items.Clear();
            cmb_FilterStato.Items.Add("Tutti gli stati");
            cmb_FilterStato.Items.AddRange(new string[] { "Disponibile", "Non Disponibile", "In Uso", "In Manutenzione" });
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

        //private void LoadFilters(string? marca = null, string? modello = null, string? annoProduzione = null, string? stato = null)
        //{
        //    // Filtro Modello
        //    cmb_FilterModello.Items.Clear();
        //    cmb_FilterModello.Items.Add("Tutti i modelli");
        //    var modelli = MethodsDB.GetDistintiModelli().ToArray();
        //    if (cmb_FilterMarca.SelectedIndex > 0)
        //    {
        //        marca = Clean(cmb_FilterMarca);
        //        modelli = MethodsDB.GetDistintiModelli(marca).ToArray();
        //        cmb_FilterModello.Items.AddRange(modelli);
        //    }else 
        //        cmb_FilterModello.Items.AddRange(modelli);

        //    // Filtro Marca
        //    cmb_FilterMarca.Items.Clear();
        //    cmb_FilterMarca.Items.Add("Tutte le marche");
        //    var marche = MethodsDB.GetDistinteMarche().ToArray();
        //    if (cmb_FilterModello.SelectedIndex > 0)
        //    {
        //        modello = Clean(cmb_FilterModello);
        //        marche = MethodsDB.GetDistinteMarche(modello).ToArray();
        //        cmb_FilterMarca.Items.AddRange(marche);
        //    }
        //    else
        //        cmb_FilterMarca.Items.AddRange(marche);

        //    // Filtro Anno
        //    cmb_FilterYearProd.Items.Clear();
        //    cmb_FilterYearProd.Items.Add("Tutti gli anni");
        //    var anni = MethodsDB.GetDistintiAnni().ToArray();
        //    cmb_FilterYearProd.Items.AddRange(anni);

        //    // Filtro Stato
        //    cmb_FilterStato.Items.Clear();
        //    cmb_FilterStato.Items.Add("Tutti gli stati");
        //    cmb_FilterStato.Items.AddRange(new string[] { "Disponibile", "Non Disponibile", "In Uso", "In Manutenzione" });
        //    cmb_FilterStato.SelectedIndex = 0;

        //}

        private void UC_Veicoli_Load(object sender, EventArgs e)
        {
            LoadData();
            FormattaGrid(dGw_Veicoli);
        }

        private void FormattaGrid(DataGridView dgw)
        {
            dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        private void cmb_FilterMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_FilterModello.Items.Clear();
            cmb_FilterModello.Items.Add("Tutti i modelli");
            if (cmb_FilterMarca.SelectedIndex > 0)
            {
                string marca = Clean(cmb_FilterMarca);
                var modelli = MethodsDB.GetDistintiModelli(marca).ToArray();
                cmb_FilterModello.Items.AddRange(modelli);
            }
            else
            {
                var modelli = MethodsDB.GetDistintiModelli().ToArray();
                cmb_FilterModello.Items.AddRange(modelli);
            }
            Filter();
        }

        private void cmb_FilterModello_SelectedIndexChanged(object sender, EventArgs e) => Filter();
        private void cmb_FilterYearProd_SelectedIndexChanged(object sender, EventArgs e) => Filter();
        private void nUd_FiltroKm_ValueChanged(object sender, EventArgs e) => Filter();
        private void cmb_FilterStato_SelectedIndexChanged(object sender, EventArgs e) => Filter();

        private string Clean(ComboBox cb)
        {
            if (cb.SelectedIndex <= 0) return null;
            string s = cb.SelectedItem.ToString();
            int pos = s.IndexOf(") ");
            return pos > -1 ? s.Substring(pos + 2) : s;
        }

        private void Filter()
        {

            string targa = string.IsNullOrWhiteSpace(txb_FilterTarga.Text) ? null : txb_FilterTarga.Text.Trim();
            string marca = Clean(cmb_FilterMarca);
            string modello = Clean(cmb_FilterModello);
            string annoStr = cmb_FilterYearProd.SelectedIndex <= 0 ? null : cmb_FilterYearProd.SelectedItem.ToString();
            string stato = cmb_FilterStato.SelectedIndex <= 0 ? null : cmb_FilterStato.SelectedItem.ToString();
            int? km = (int)nUd_FilterKm.Value == 0 ? null : (int?)nUd_FilterKm.Value;


            // Esecuzione ricerca
            var risultati = MethodsDB.RicercaVeicoli(
                targa: targa,
                marcaOrder: MarcaOrderType,
                marca: marca,
                modelloOrder: ModelloOrderType,
                modello: modello,
                statusOrder: StatusOrderTyp,
                stato: stato,
                annoProduzioneOrder: AnnoProduzioneOrderType,
                annoProduzione: annoStr,
                kmOrder: KmOrderType,
                KmfilterType: KmfilterType,
                chilometraggio: km
            ).ToList();

            dGw_Veicoli.DataSource = null;
            dGw_Veicoli.DataSource = risultati;
        }

        private void btn_FilterUnderOver_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                KmfilterType = KmfilterType == KmFilterType.Over ? KmFilterType.Under : KmFilterType.Over;

                if (KmfilterType == KmFilterType.Over) btn_FilterUnderOver.Text = ">";
                else btn_FilterUnderOver.Text = "<";
            }
            else
            {
                KmfilterType = KmFilterType.Equal;
                btn_FilterUnderOver.Text = "=";
            }
            Filter();
        }

        private void btn_FilterStatoOrder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StatusOrderTyp = StatusOrderTyp == OrderType.Ascending ? OrderType.Descending : OrderType.Ascending;

                if (StatusOrderTyp == OrderType.Ascending) btn_FilterStatoOrder.Text = "▲";
                else btn_FilterStatoOrder.Text = "▼";
            }
            else
            {
                StatusOrderTyp = OrderType.None;
                btn_FilterStatoOrder.Text = "↹";
            }
            Filter();

        }

        private void btn_FilterChilometraggioOrder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                KmOrderType = KmOrderType == OrderType.Ascending ? OrderType.Descending : OrderType.Ascending;

                if (KmOrderType == OrderType.Ascending) btn_FilterChilometraggioOrder.Text = "▲";
                else btn_FilterChilometraggioOrder.Text = "▼";
            }
            else
            {
                KmOrderType = OrderType.None;
                btn_FilterChilometraggioOrder.Text = "↹";
            }
            Filter();

        }

        private void btn_FilterAnnoProduzioneOrder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AnnoProduzioneOrderType = AnnoProduzioneOrderType == OrderType.Ascending ? OrderType.Descending : OrderType.Ascending;

                if (AnnoProduzioneOrderType == OrderType.Ascending) btn_FilterAnnoProduzioneOrder.Text = "▲";
                else btn_FilterAnnoProduzioneOrder.Text = "▼";
            }
            else
            {
                AnnoProduzioneOrderType = OrderType.None;
                btn_FilterAnnoProduzioneOrder.Text = "↹";
            }
            Filter();

        }

        private void btn_FilterModelloOrder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ModelloOrderType = ModelloOrderType == OrderType.Ascending ? OrderType.Descending : OrderType.Ascending;

                if (ModelloOrderType == OrderType.Ascending) btn_FilterModelloOrder.Text = "▲";
                else btn_FilterModelloOrder.Text = "▼";
            }
            else
            {
                ModelloOrderType = OrderType.None;
                btn_FilterModelloOrder.Text = "↹";
            }
            Filter();

        }

        private void btn_FilterMarcaOrder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MarcaOrderType = MarcaOrderType == OrderType.Ascending ? OrderType.Descending : OrderType.Ascending;

                if (MarcaOrderType == OrderType.Ascending) btn_FilterMarcaOrder.Text = "▲";
                else btn_FilterMarcaOrder.Text = "▼";
            }
            else
            {
                MarcaOrderType = OrderType.None;
                btn_FilterMarcaOrder.Text = "↹";
            }
            Filter();

        }

        private void btn_FilterInfo_Click(object sender, EventArgs e)
        {
            string messaggio =
                "      🔍 MODALITÀ DI FILTRAGGIO 🔍\n" +
                "══════════════════════════════\n\n" +

                "📑 LEGENDA SIMBOLI (Ordinamento)\n" +
                "──────────────────────\n" +
                "   ▲  Ascendente (A-Z, 0-9)\n" +
                "   ▼  Discendente (Z-A, 9-0)\n" +
                "   ↹  Nessun ordine [Tasto Destro 🖱️]\n\n" +

                "🛣️ FILTRO CHILOMETRAGGIO\n" +
                "──────────────────────\n" +
                "   >  Superiore a...\n" +
                "   <  Inferiore a...\n" +
                "   =  Esattamente uguale [Tasto Destro 🖱️]\n\n" +

                "⚙️ LOGICA DI SISTEMA\n" +
                "──────────────────────\n" +
                "• I filtri sono SEMPRE attivi contemporaneamente.\n" +
                "• L'ordinamento segue questa priorità (Gerarchia):\n\n" +
                "   1º  🏷️ Marca\n" +
                "   2º  🚗 Modello\n" +
                "   3º  📅 Anno Produzione\n" +
                "   4º  🛣️ Chilometraggio\n" +
                "   5º  🚥 Stato Veicolo\n\n" +
                "──────────────────────\n" +
                "Se nessun ordinamento viene selezionato, viene automaticamente ordinato per targa Ascendente.\n\n" +
                "══════════════════════════════";

            MessageBox.Show(messaggio, "Funzionamento dei Filtri", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


}
