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
    #region Enumeratori
    // Enumeratori per gestire ciclicamente lo stato dei bottoni di ordinamento e filtraggio
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
    #endregion

    public partial class UC_Veicoli : UserControl
    {
        #region Variabili Globali e Stato Filtri
        // Memoria dello stato attuale dei bottoni per i filtri. 
        // Di default non applichiamo nessun ordine, tranne per i KM che partono con "Over" (>)
        KmFilterType KmfilterType = KmFilterType.Over;
        OrderType StatusOrderTyp = OrderType.None;
        OrderType KmOrderType = OrderType.None;
        OrderType AnnoProduzioneOrderType = OrderType.None;
        OrderType ModelloOrderType = OrderType.None;
        OrderType MarcaOrderType = OrderType.None;
        OrderType Modelli_MarcaOrderType = OrderType.None;
        OrderType Modelli_ModelloOrderType = OrderType.None;
        #endregion

        #region Costruttore e Inizializzazione
        public UC_Veicoli()
        {
            InitializeComponent();

            ConfiguraStileGriglia(dGw_Veicoli);
            ConfiguraStileGriglia(dGw_Modelli);

            // Disattivo l'auto-generazione delle colonne
            dGw_Veicoli.AutoGenerateColumns = false;
            dGw_Modelli.AutoGenerateColumns = false;

            // Adatto le schede del TabControl alla larghezza disponibile
            TabResize();

            // Carico i dati nei menu a tendina e nelle griglie
            RefreshData();
        }

        private void UC_Veicoli_Load(object sender, EventArgs e)
        {
            // Quando il controllo viene effettivamente caricato a schermo, popolo la griglia
            LoadData();
            FormattaGrid(dGw_Veicoli);
        }

        /// <summary>
        /// Setup base per rendere la griglia più pulita e reattiva
        /// </summary>
        private void FormattaGrid(DataGridView dgw)
        {
            dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Occupa tutto lo spazio
            dgw.RowHeadersVisible = false; // Nascondo la colonna vuota a sinistra
        }
        #endregion

        #region Caricamento e Aggiornamento Dati (Core)

        /// <summary>
        /// Recupera la lista veicoli senza filtri (usato all'avvio)
        /// </summary>
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

        /// <summary>
        /// Svuota e ricarica le ComboBox dell'interfaccia leggendo i dati dal DB.
        /// Chiamato all'avvio e dopo ogni inserimento/modifica.
        /// </summary>
        private void RefreshData()
        {
            #region Data Veicoli (Tab 1)

            // --- Filtri Ricerca ---
            cmb_FilterMarca.Items.Clear();
            cmb_FilterMarca.Items.Add("Tutte le marche");
            cmb_FilterMarca.Items.AddRange(MethodsDB.GetDistinteMarche().ToArray());
            cmb_FilterMarca.SelectedIndex = 0;

            // --- Form Inserimento Veicolo ---
            string[] _marche;
            string[] _modelli;
            cmb_AddMarca.Items.Clear();
            cmb_AddModello.Items.Clear();
            cmb_AddMarca.Items.Add("Seleziona Marca");
            cmb_AddModello.Items.Add("Seleziona Modello");
            _marche = MethodsDB.GetDistinteMarche().ToArray();
            _modelli = MethodsDB.GetDistintiModelli().ToArray();
            foreach (string _marca in _marche)
            {
                // Pulisco la stringa prima di inserirla (rimuovo eventuale ID o formattazione)
                _marche[_marche.IndexOf(_marca)] = Clean(_marca);
            }
            foreach (string _modello in _modelli)
            {
                // Pulisco la stringa prima di inserirla (rimuovo eventuale ID o formattazione)
                _modelli[_modelli.IndexOf(_modello)] = Clean(_modello);
            }
            cmb_AddMarca.Items.AddRange(_marche);
            cmb_AddModello.Items.AddRange(_modelli);
            cmb_AddMarca.SelectedIndex = 0;
            cmb_AddModello.SelectedIndex = 0;

            // Filtro Ricerca Modello
            cmb_FilterModello.Items.Clear();
            cmb_FilterModello.Items.Add("Tutti i modelli");
            cmb_FilterModello.Items.AddRange(MethodsDB.GetDistintiModelli().ToArray());
            cmb_FilterModello.SelectedIndex = 0;

            // Filtri Anno e Stato
            cmb_FilterYearProd.Items.Clear();
            cmb_FilterYearProd.Items.Add("Tutti gli anni");
            cmb_FilterYearProd.Items.AddRange(MethodsDB.GetDistintiAnni().ToArray());
            cmb_FilterYearProd.SelectedIndex = 0;

            nUd_AddAnnoProd.Maximum = DateTime.Now.Year;
            nUd_AddAnnoProd.Minimum = 1886; // Anno invenzione dell'automobile :)

            cmb_FilterStato.Items.Clear();
            cmb_FilterStato.Items.Add("Tutti gli stati");
            cmb_FilterStato.Items.AddRange(new string[] { "Disponibile", "Non Disponibile", "In Uso", "In Manutenzione" });
            cmb_FilterStato.SelectedIndex = 0;
            #endregion

            #region Data Modelli (Tab 2)

            // Ricarico la griglia dei modelli
            var Modelli = MethodsDB.GetTuttiModelli().ToList();
            dGw_Modelli.DataSource = Modelli;

            // Popolo il form di inserimento nuovo modello
            cmb_NewMarca.Items.Clear();
            cmb_NewMarca.Items.Add("");
            _marche = MethodsDB.GetDistinteMarche().ToArray();
            foreach (string _marca in _marche)
            {
                _marche[_marche.IndexOf(_marca)] = Clean(_marca);
            }
            cmb_NewMarca.Items.AddRange(_marche);
            cmb_NewMarca.SelectedIndex = 0;

            // Filtri per la tabella Modelli
            cmb_Modelli_FilterMarca.Items.Clear();
            cmb_Modelli_FilterMarca.Items.Add("Tutte le marche");
            cmb_Modelli_FilterMarca.Items.AddRange(MethodsDB.GetDistinteMarche().ToArray());
            cmb_Modelli_FilterMarca.SelectedIndex = 0;

            cmb_Modelli_FilterModello.Items.Clear();
            cmb_Modelli_FilterModello.Items.Add("Tutti i modelli");
            cmb_Modelli_FilterModello.Items.AddRange(MethodsDB.GetDistintiModelli().ToArray());
            cmb_Modelli_FilterModello.SelectedIndex = 0;
            #endregion
        }
        #endregion

        #region Motore di Ricerca (Filtri Logici)

        /// <summary>
        /// Pulisce la stringa estratta da una ComboBox, rimuovendo eventuali ID o formattazioni aggiuntive.
        /// </summary>
        /// <param name="cb"></param>
        /// <returns>La stringa pulita senza formattazioni.</returns>
        private string Clean(ComboBox cb)
        {
            if (cb.SelectedIndex <= 0) return null;
            string s = cb.SelectedItem.ToString();
            int pos = s.IndexOf(") ");
            return pos > -1 ? s.Substring(pos + 2) : s;
        }
        /// <summary>
        /// Pulisce la stringa estratta da un campo di testo, rimuovendo eventuali formattazioni aggiuntive.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>La stringa pulita senza formattazioni.</returns>
        private string Clean(string str)
        {
            int pos = str.IndexOf(") ");
            return pos > -1 ? str.Substring(pos + 2) : str;
        }

        /// <summary>
        /// Filtra i veicoli in base ai parametri attivi nei controlli UI.
        /// </summary>
        private void Filter()
        {
            //Raccolta parametri dai controlli UI (gestione dei null per evitare query errate)
            string targa = string.IsNullOrWhiteSpace(txb_FilterTarga.Text) ? null : txb_FilterTarga.Text.Trim();
            string marca = Clean(cmb_FilterMarca);
            string modello = Clean(cmb_FilterModello);
            string annoStr = cmb_FilterYearProd.SelectedIndex <= 0 ? null : cmb_FilterYearProd.SelectedItem.ToString();
            string stato = cmb_FilterStato.SelectedIndex <= 0 ? null : cmb_FilterStato.SelectedItem.ToString();
            int? km = (int)nUd_FilterKm.Value == 0 ? null : (int?)nUd_FilterKm.Value;

            // Chiamata al database passando TUTTI i parametri contemporaneamente
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

            //Refresh dei dati
            dGw_Veicoli.DataSource = null;
            dGw_Veicoli.DataSource = risultati;
        }

        /// <summary>
        /// Filtro per la tab dei modelli
        /// </summary>
        private void FilterModello()
        {
            string marca = Clean(cmb_Modelli_FilterMarca);
            string modello = Clean(cmb_Modelli_FilterModello);

            // Chiamata al database passando TUTTI i parametri contemporaneamente
            var risultati = MethodsDB.RicercaModelli(
                marcaOrder: Modelli_MarcaOrderType,
                marca: marca,
                modelloOrder: Modelli_ModelloOrderType,
                modello: modello
            ).ToList();

            //Refresh dei dati
            dGw_Modelli.DataSource = null;
            dGw_Modelli.DataSource = risultati;
        }
        #endregion

        #region Eventi UI: Trigger dei Filtri
        // Questi eventi si limitano a rilanciare il metodo Filter() appena l'utente tocca qualcosa

        private void txb_FilterTarga_TextChanged(object sender, EventArgs e) => Filter();
        private void cmb_FilterModello_SelectedIndexChanged(object sender, EventArgs e) => Filter();
        private void cmb_FilterYearProd_SelectedIndexChanged(object sender, EventArgs e) => Filter();
        private void nUd_FiltroKm_ValueChanged(object sender, EventArgs e) => Filter();
        private void cmb_FilterStato_SelectedIndexChanged(object sender, EventArgs e) => Filter();
        private void cmb_Modelli_FilterModello_SelectedIndexChanged(object sender, EventArgs e) => FilterModello();

        // Comportamento dinamico: se scelgo una marca, filtro i modelli disponibili nella tendina successiva
        private void cmb_Modelli_FilterMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_Modelli_FilterModello.Items.Clear();
            cmb_Modelli_FilterModello.Items.Add("Tutti i modelli");
            if (cmb_Modelli_FilterMarca.SelectedIndex > 0)
            {
                string marca = Clean(cmb_Modelli_FilterMarca);
                var modelli = MethodsDB.GetDistintiModelli(marca).ToArray();
                cmb_Modelli_FilterModello.Items.AddRange(modelli);
            }
            else
            {
                var modelli = MethodsDB.GetDistintiModelli().ToArray();
                cmb_Modelli_FilterModello.Items.AddRange(modelli);
            }
            FilterModello();
        }

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

        private void cmb_AddMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_AddModello.Items.Clear();
            if (cmb_AddMarca.SelectedIndex > 0)
            {
                string marca = Clean(cmb_AddMarca);
                string[] _modelli = MethodsDB.GetDistintiModelli(marca).ToArray();
                foreach (string _modello in _modelli)
                {
                    _modelli[_modelli.IndexOf(_modello)] = Clean(_modello);
                }
                cmb_AddModello.Items.Add("Seleziona Modello");
                cmb_AddModello.Items.AddRange(_modelli);
            }
            else
            {
                string[] _modelli = MethodsDB.GetDistintiModelli().ToArray();
                foreach (string _modello in _modelli)
                {
                    _modelli[_modelli.IndexOf(_modello)] = Clean(_modello);
                }
                cmb_AddModello.Items.Add("Seleziona Modello");
                cmb_AddModello.Items.AddRange(_modelli);
            }
            cmb_AddModello.Text = string.Empty;
            cmb_AddModello.SelectedIndex = 0;
        }
        #endregion

        #region Eventi UI: Bottoni Ordinamento

        private void btn_FilterUnderOver_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                KmfilterType = KmfilterType == KmFilterType.Over ? KmFilterType.Under : KmFilterType.Over;
                btn_FilterUnderOver.Text = KmfilterType == KmFilterType.Over ? ">" : "<";
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
                btn_FilterStatoOrder.Text = StatusOrderTyp == OrderType.Ascending ? "▲" : "▼";
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
                btn_FilterChilometraggioOrder.Text = KmOrderType == OrderType.Ascending ? "▲" : "▼";
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
                btn_FilterAnnoProduzioneOrder.Text = AnnoProduzioneOrderType == OrderType.Ascending ? "▲" : "▼";
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
                btn_FilterModelloOrder.Text = ModelloOrderType == OrderType.Ascending ? "▲" : "▼";
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
                btn_FilterMarcaOrder.Text = MarcaOrderType == OrderType.Ascending ? "▲" : "▼";
            }
            else
            {
                MarcaOrderType = OrderType.None;
                btn_FilterMarcaOrder.Text = "↹";
            }
            Filter();
        }
        private void btn_Modelli_FilterMarcaOrder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Modelli_MarcaOrderType = Modelli_MarcaOrderType == OrderType.Ascending ? OrderType.Descending : OrderType.Ascending;
                btn_Modelli_FilterMarcaOrder.Text = MarcaOrderType == OrderType.Ascending ? "▲" : "▼";
            }
            else
            {
                Modelli_MarcaOrderType = OrderType.None;
                btn_Modelli_FilterMarcaOrder.Text = "↹";
            }
            FilterModello();
        }

        private void btn_Modelli_FilterModelloOrder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Modelli_ModelloOrderType = Modelli_ModelloOrderType == OrderType.Ascending ? OrderType.Descending : OrderType.Ascending;
                btn_Modelli_FilterModelloOrder.Text = ModelloOrderType == OrderType.Ascending ? "▲" : "▼";
            }
            else
            {
                Modelli_ModelloOrderType = OrderType.None;
                btn_Modelli_FilterModelloOrder.Text = "↹";
            }
            FilterModello();
        }
        #endregion

        #region Interazione Griglia
        // Seleziona l'intera riga col click destro per mostrare il menu
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

        // Se clicco sulla cella "Stato", apre la tendina per la modifica rapida
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

        // Quando il valore di una cella cambia, salva nel DB
        private void dGw_Veicoli_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dGw_Veicoli.Columns[e.ColumnIndex].Name == "Stato")
            {
                int idVeicolo = Convert.ToInt32(dGw_Veicoli.Rows[e.RowIndex].Cells["ID_Veicolo"].Value);
                int km = Convert.ToInt32(dGw_Veicoli.Rows[e.RowIndex].Cells["Chilometraggio"].Value);

                string nuovoStato = dGw_Veicoli.Rows[e.RowIndex].Cells["Stato"].Value?.ToString() ?? string.Empty;

                try
                {
                    MethodsDB.AggiornaVeicolo(idVeicolo, km, nuovoStato);

                    this.BeginInvoke(new Action(() => Filter()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante l'aggiornamento dello stato: " + ex.Message,
                                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Inserimento ed Eliminazione

        // --- INSERIMENTO NUOVO VEICOLO ---
        private void btn_AddVeicolo_Click(object sender, EventArgs e)
        {
            // Controllo validità camp
            if (string.IsNullOrWhiteSpace(txb_AddTarga.Text) || cmb_AddMarca.SelectedIndex <= 0 || cmb_AddModello.SelectedIndex <= 0)
            {
                MessageBox.Show("Devi compilare tutti i campi correttamente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validazione Targa con Regex (Formato: AA123BB)
            string patternTarga = @"^[A-Z]{2}[0-9]{3}[A-Z]{2}$";
            string targaInput = txb_AddTarga.Text.Trim().ToUpper();

            if (!Regex.IsMatch(targaInput, patternTarga))
            {
                MessageBox.Show("Il formato della targa non è valido (Esempio corretto: AA123BB).", "Formato Errato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (targaInput.Length > 7) // controlli extra
            {
                MessageBox.Show("La targa non può superare i 7 caratteri.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Controllo duplicati
            if (MethodsDB.TargaEsistente(targaInput) == true)
            {
                MessageBox.Show("Questa targa è già presente nel database!", "Duplicato", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Recupero ID Modello e preparazione entita
            int idModello = MethodsDB.GetIdModelloPerNome(Clean(cmb_AddModello));

            if (idModello == -1)
            {
                MessageBox.Show("Errore: Modello non trovato nel sistema.");
                return;
            }

            int _annoProd = Convert.ToInt32(nUd_AddAnnoProd.Value);
            int _chilometraggio = Convert.ToInt32(nUd_AddChilometraggio.Value);

            Veicolo v = new Veicolo(targaInput, idModello, _annoProd, _chilometraggio, "Disponibile");

            // Inserimento
            try
            {
                MethodsDB.InserisciVeicolo(v);

                // Reset campi UI
                txb_AddTarga.Text = "";
                cmb_AddMarca.SelectedIndex = 0;
                cmb_AddModello.SelectedIndex = 0;
                nUd_AddAnnoProd.Value = nUd_AddAnnoProd.Minimum;
                nUd_AddChilometraggio.Value = nUd_AddChilometraggio.Minimum;

                MessageBox.Show("Veicolo inserito correttamente!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh UI
                RefreshData();
                Filter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante l'inserimento: " + ex.Message);
            }
        }

        // --- ELIMINAZIONE VEICOLO ---
        private void Fleet_ContextMenu_EliminaVeicolo_Click(object sender, EventArgs e)
        {
            // Scatenato dal menu a tendina (Tasto destro su riga)
            if (dGw_Veicoli.SelectedRows.Count > 0)
            {
                var idVeicolo = dGw_Veicoli.SelectedRows[0].Cells["ID_Veicolo"].Value;
                var targaVeicolo = dGw_Veicoli.SelectedRows[0].Cells["Targa"].Value;

                if (MessageBox.Show($"Eliminare il veicolo con targa {targaVeicolo}?", "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MethodsDB.EliminaVeicolo((int)idVeicolo);
                    MessageBox.Show("Operazione completata: il veicolo è stato rimosso o impostato come Non Disponibile se presentava assegnazioni.");
                    Filter();
                }
            }
        }

        // --- INSERIMENTO NUOVO MODELLO ---
        private void btn_addModello_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_NewModello.Text) || cmb_NewMarca.Text == string.Empty)
            {
                MessageBox.Show("Devi compilare tutti i campi correttamente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string modello = txt_NewModello.Text.Trim();
            string marca = cmb_NewMarca.Text.Trim();

            Modello m = new Modello(modello, marca);

            try
            {
                MethodsDB.InserisciModello(m);
                txt_NewModello.Text = "";
                cmb_NewMarca.SelectedIndex = 0;
                MessageBox.Show("Modello inserito correttamente!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante l'inserimento: " + ex.Message);
            }
        }
        #endregion

        #region Utility UI
        // Adatta dinamicamente le tab del menu in alto per renderle graficamente bilanciate
        private void TabResize()
        {
            if (tabControl1.TabCount > 0)
            {
                int width = (tabControl1.Size.Width / tabControl1.TabCount) - 3;

                tabControl1.SizeMode = TabSizeMode.Fixed;
                tabControl1.ItemSize = new Size(width, 30);
            }
        }

        // Mostra la legenda dei bottoni dei filtri
        private void btn_FilterInfo_Click(object sender, EventArgs e)
        {
            string messaggio =
                "   🔍 MODALITÀ DI FILTRAGGIO 🔍\n" +
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
        #endregion
        #region STILE
        private void ConfiguraStileGriglia(DataGridView dgw)
        {
            // 1. FONDAMENTALE: Permette di sovrascrivere lo stile nativo di Windows per le intestazioni
            dgw.EnableHeadersVisualStyles = false;

            // 2. Proprietà di Struttura e Bordi
            dgw.BackgroundColor = Color.FromArgb(249, 250, 251); // Sfondo grigio chiarissimo (Tailwind Gray 50)
            dgw.GridColor = Color.FromArgb(243, 244, 246);       // Linee di divisione molto tenui (Gray 100)
            dgw.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Solo linee orizzontali, look più pulito
            dgw.RowHeadersVisible = false;                       // Nasconde la colonna vuota a sinistra
            dgw.BorderStyle = BorderStyle.None;

            // 3. Il "Respiro" (Righe più alte = interfaccia moderna)
            dgw.RowTemplate.Height = 40;                         // Diamo spazio alle celle
            dgw.ColumnHeadersHeight = 42;                        // Più spazio per i titoli
            dgw.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // 4. Stile dell'Intestazione (Header) - Stile scuro "Pro"
            DataGridViewCellStyle stileHeader = new DataGridViewCellStyle();
            stileHeader.BackColor = Color.FromArgb(31, 41, 55);            // Antracite scuro (Gray 800)
            stileHeader.SelectionBackColor = Color.FromArgb(31, 41, 55);   // Mantiene lo stesso colore anche in selezione
            stileHeader.ForeColor = Color.White;                           // Testo bianco
            stileHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            stileHeader.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgw.ColumnHeadersDefaultCellStyle = stileHeader;

            // 5. Stile delle Righe Standard (Default)
            DataGridViewCellStyle stileRighe = new DataGridViewCellStyle();
            stileRighe.BackColor = Color.White;
            stileRighe.ForeColor = Color.FromArgb(55, 65, 81);             // Grigio scuro (meno aggressivo del nero puro)
            stileRighe.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            // Colore di selezione armonioso (Azzurro morbido con testo scuro, non il blu elettrico di Windows)
            stileRighe.SelectionBackColor = Color.FromArgb(239, 246, 255); // Blue 50
            stileRighe.SelectionForeColor = Color.FromArgb(29, 78, 216);   // Blue 700
            stileRighe.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgw.DefaultCellStyle = stileRighe;

            // 6. Stile Righe Alterne (Per migliorare la lettura dei dati)
            DataGridViewCellStyle stileRigheAlterne = new DataGridViewCellStyle();
            stileRigheAlterne.BackColor = Color.FromArgb(249, 250, 251);   // Sfondo alternato Gray 50
            stileRigheAlterne.ForeColor = Color.FromArgb(55, 65, 81);
            stileRigheAlterne.SelectionBackColor = Color.FromArgb(239, 246, 255);
            stileRigheAlterne.SelectionForeColor = Color.FromArgb(29, 78, 216);
            stileRigheAlterne.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgw.AlternatingRowsDefaultCellStyle = stileRigheAlterne;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }
        #endregion STILE

        private void dGw_Veicoli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dGw_Veicoli.Rows[e.RowIndex].IsNewRow) return;

            var v = dGw_Veicoli.Rows[e.RowIndex].DataBoundItem as Veicolo;

            if (v != null)
            {
                int id = v.ID_Veicolo;
                string targa = v.Targa;
                int km = v.Chilometraggio;

                string nomeModello = dGw_Veicoli.Rows[e.RowIndex].Cells["NomeModello"].Value?.ToString() ?? string.Empty;
                int fkModello = !string.IsNullOrEmpty(nomeModello) ? MethodsDB.GetIdModelloPerNome(nomeModello) : 0;

                v.FK_Modello = fkModello;

                FormDettaglioVeicolo formDettaglio = new FormDettaglioVeicolo(v);
                formDettaglio.ShowDialog();
                Filter();
            }
        }
    }
}