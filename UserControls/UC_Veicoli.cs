using Dapper;
using FleetManager.DB;
using FleetManager.Entita;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            dGw_Modelli.AutoGenerateColumns = false;

            TabResize();

            //// Configura la colonna Stato (deve essere DataGridViewComboBoxColumn nel Designer)
            //var colStato = (DataGridViewComboBoxColumn)dGw_Veicoli.Columns["Stato"];
            //colStato.DataPropertyName = "Stato"; // Lega al campo del DB

            //// Popola le opzioni della tendina
            //colStato.Items.Clear();
            //colStato.Items.AddRange(new string[] { "Disponibile", "In Uso", "In Manutenzione" });

            //// Rendi la tendina subito reattiva
            //dGw_Veicoli.EditMode = DataGridViewEditMode.EditOnEnter;

            RefreshData();

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

        private void RefreshData()
        {
            #region Data Veicoli
            // Filtro Marca
            cmb_FilterMarca.Items.Clear();
            cmb_FilterMarca.Items.Add("Tutte le marche");
            cmb_FilterMarca.Items.AddRange(MethodsDB.GetDistinteMarche().ToArray());
            cmb_FilterMarca.SelectedIndex = 0;

            // Aggiungi Veicolo Marca
            string[] _marche;
            cmb_AddMarca.Items.Clear();
            cmb_AddMarca.Items.Add("Tutte le marche");
            _marche = MethodsDB.GetDistinteMarche().ToArray();
            foreach (string _marca in _marche)
            {
                _marche[_marche.IndexOf(_marca)] = Clean(_marca);
            }
            cmb_AddMarca.Items.AddRange(_marche);
            cmb_AddMarca.SelectedIndex = 0;

            // Filtro Modello
            cmb_FilterModello.Items.Clear();
            cmb_FilterModello.Items.Add("Tutti i modelli");
            cmb_FilterModello.Items.AddRange(MethodsDB.GetDistintiModelli().ToArray());
            cmb_FilterModello.SelectedIndex = 0;

            // Aggiungi Veicolo Modello
            string[] _modelli;
            cmb_AddModello.Items.Clear();
            _modelli = MethodsDB.GetDistintiModelli().ToArray();
            foreach (string _modello in _modelli)
            {
                _modelli[_modelli.IndexOf(_modello)] = Clean(_modello);
            }
            cmb_AddModello.Items.AddRange(_modelli);
            cmb_AddModello.SelectedIndex = -1;

            // Filtro Anno
            cmb_FilterYearProd.Items.Clear();
            cmb_FilterYearProd.Items.Add("Tutti gli anni");
            cmb_FilterYearProd.Items.AddRange(MethodsDB.GetDistintiAnni().ToArray());
            cmb_FilterYearProd.SelectedIndex = 0;

            // Aggiungi Veicolo Anno
            nUd_AddAnnoProd.Maximum = DateTime.Now.Year;
            nUd_AddAnnoProd.Minimum = 1886;

            // Filtro Stato
            cmb_FilterStato.Items.Clear();
            cmb_FilterStato.Items.Add("Tutti gli stati");
            cmb_FilterStato.Items.AddRange(new string[] { "Disponibile", "Non Disponibile", "In Uso", "In Manutenzione" });
            cmb_FilterStato.SelectedIndex = 0;

            #endregion Data Veicoli

            #region Data Modelli

            var Modelli = MethodsDB.GetTuttiModelli().ToList();
            dGw_Modelli.DataSource = Modelli;

            #endregion Data Modelli
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
        private string Clean(string str)
        {
            int pos = str.IndexOf(") ");
            return pos > -1 ? str.Substring(pos + 2) : str;
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

        private void btn_AddVeicolo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_AddTarga.Text) ||
                cmb_AddMarca.SelectedIndex <= 0 ||
                cmb_AddModello.SelectedIndex <= 0)
            {
                MessageBox.Show("Devi compilare tutti i campi correttamente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string _targa_ = txb_AddTarga.Text.Trim().ToUpper();

            // Definizione del pattern Regex per le targhe italiane
            // ^[A-Z]{2} -> Inizia con 2 lettere
            // [0-9]{3}  -> Seguono 3 numeri
            // [A-Z]{2}$ -> Finisce con 2 lettere (escludendo I, O, Q, U per precisione estrema servirebbe un pattern più complesso, ma questo è lo standard)
            string patternTarga = @"^[A-Z]{2}[0-9]{3}[A-Z]{2}$";

            string targaInput = txb_AddTarga.Text.Trim().ToUpper();

            if (!Regex.IsMatch(targaInput, patternTarga))
            {
                MessageBox.Show("Il formato della targa non è valido (Esempio corretto: AA123BB).",
                                "Formato Errato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se il formato è corretto, controlliamo se esiste già nel DB
            if (MethodsDB.TargaEsistente(targaInput) == true)
            {
                MessageBox.Show("Questa targa è già presente nel database!",
                                "Duplicato", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Se passa entrambi i controlli, procede con linserimento

            if (_targa_.Length > 7)
            {
                MessageBox.Show("La targa non può superare i 7 caratteri.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idModello = MethodsDB.GetIdModelloPerNome(Clean(cmb_AddModello));

            if (idModello == -1)
            {
                MessageBox.Show("Errore: Modello non trovato nel sistema.");
                return;
            }

            string _targa = txb_AddTarga.Text.Trim().ToUpper();
            int _annoProd = Convert.ToInt32(nUd_AddAnnoProd.Value);
            int _chilometraggio = Convert.ToInt32(nUd_AddChilometraggio.Value);

            Veicolo v = new Veicolo(_targa, idModello, _annoProd, _chilometraggio, "Disponibile");

            // prova a inserire il veicolo nel database e gestisce eventuali errori
            try
            {
                MethodsDB.InserisciVeicolo(v);

                txb_AddTarga.Text = "";
                cmb_AddMarca.SelectedIndex = 0;
                cmb_AddModello.SelectedIndex = 0;
                nUd_AddAnnoProd.Value = nUd_AddAnnoProd.Minimum;
                nUd_AddChilometraggio.Value = nUd_AddChilometraggio.Minimum;

                MessageBox.Show("Veicolo inserito correttamente!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Dopo l'inserimento, aggiorna i filtri e la visualizzazione
                RefreshData();
                Filter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante l'inserimento: " + ex.Message);
            }
        }

        private void cmb_AddMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_AddModello.Items.Clear();
            if (cmb_AddMarca.SelectedIndex > 0)
            {
                string marca = Clean(cmb_AddMarca);
                string[] _modelli;
                _modelli = MethodsDB.GetDistintiModelli(marca).ToArray();
                foreach (string _modello in _modelli)
                {
                    _modelli[_modelli.IndexOf(_modello)] = Clean(_modello);
                }
                cmb_AddModello.Items.AddRange(_modelli);
            }
            else
            {
                string[] _modelli;
                _modelli = MethodsDB.GetDistintiModelli().ToArray();
                foreach (string _modello in _modelli)
                {
                    _modelli[_modelli.IndexOf(_modello)] = Clean(_modello);
                }
                cmb_AddModello.Items.AddRange(_modelli);
            }
            cmb_AddModello.Text = string.Empty;
            cmb_AddModello.SelectedIndex = -1;
        }

        private void dGw_Veicoli_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dGw_Veicoli.ClearSelection();
                dGw_Veicoli.Rows[e.RowIndex].Selected = true;

                dGw_Veicoli.CurrentCell = dGw_Veicoli.Rows[e.RowIndex].Cells[e.ColumnIndex];

                Veicoli_ContextMenu.Show(Cursor.Position);
            }
        }

        private void Fleet_ContextMenu_EliminaVeicolo_Click(object sender, EventArgs e)
        {
            if (dGw_Veicoli.SelectedRows.Count > 0)
            {
                var idVeicolo = dGw_Veicoli.SelectedRows[0].Cells["ID_Veicolo"].Value;
                var targaVeicolo = dGw_Veicoli.SelectedRows[0].Cells["Targa"].Value;

                if (MessageBox.Show($"Eliminare il veicolo con targa {targaVeicolo}?", "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MethodsDB.EliminaVeicolo((int)idVeicolo);
                    Filter();
                }
            }
        }

        private void tabControl1_Resize(object sender, EventArgs e)
        {
        }

        private void TabResize()
        {
            if (tabControl1.TabCount > 0)
            {
                int width = (tabControl1.Size.Width / tabControl1.TabCount) - 3;

                tabControl1.SizeMode = TabSizeMode.Fixed;
                tabControl1.ItemSize = new Size(width, 30);
            }
        }

        private void btn_addModello_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_NewModello.Text) || cmb_AddMarca.SelectedIndex <= 0)
            {
                MessageBox.Show("Devi compilare tutti i campi correttamente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string modello = txt_NewModello.Text.Trim();
            string marca = cmb_AddMarca.Text.Trim();

            Modello m = new Modello(modello, marca);

            try
            {
                MethodsDB.InserisciModello(m);
                txt_NewModello.Text = "";
                cmb_AddMarca.SelectedIndex = 0;
                MessageBox.Show("Modello inserito correttamente!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante l'inserimento: " + ex.Message);

            }
        }
    }

}
