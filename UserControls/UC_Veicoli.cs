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
using System.Drawing.Drawing2D;


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

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;

            dGw_Veicoli.AutoGenerateColumns = false;
            dGw_Modelli.AutoGenerateColumns = false;

            TabResize();
            RefreshData();
        }

        private void UC_Veicoli_Load(object sender, EventArgs e)
        {
            // Quando il controllo viene effettivamente caricato a schermo, popolo la griglia
            LoadData();
            FormattaGrid(dGw_Veicoli);
            InizializzaStileEstetico();
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
            cmb_AddMarca.Items.Clear();
            cmb_AddMarca.Items.Add("Tutte le marche"); // TODO: Forse nell'inserimento non serve "Tutte"?
            _marche = MethodsDB.GetDistinteMarche().ToArray();
            foreach (string _marca in _marche)
            {
                // Pulisco la stringa prima di inserirla (rimuovo eventuale ID o formattazione)
                _marche[_marche.IndexOf(_marca)] = Clean(_marca);
            }
            cmb_AddMarca.Items.AddRange(_marche);
            cmb_AddMarca.SelectedIndex = 0;

            // Filtro Ricerca Modello
            cmb_FilterModello.Items.Clear();
            cmb_FilterModello.Items.Add("Tutti i modelli");
            cmb_FilterModello.Items.AddRange(MethodsDB.GetDistintiModelli().ToArray());
            cmb_FilterModello.SelectedIndex = 0;

            // Form Inserimento Modello
            string[] _modelli;
            cmb_AddModello.Items.Clear();
            _modelli = MethodsDB.GetDistintiModelli().ToArray();
            foreach (string _modello in _modelli)
            {
                _modelli[_modelli.IndexOf(_modello)] = Clean(_modello);
            }
            cmb_AddModello.Items.AddRange(_modelli);
            cmb_AddModello.SelectedIndex = -1; // Lascio vuoto per obbligare la scelta

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
            if (cb.SelectedIndex <= 0) return null; // Ignora opzioni come "Tutti..."
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
                cmb_AddModello.Items.AddRange(_modelli);
            }
            else
            {
                string[] _modelli = MethodsDB.GetDistintiModelli().ToArray();
                foreach (string _modello in _modelli)
                {
                    _modelli[_modelli.IndexOf(_modello)] = Clean(_modello);
                }
                cmb_AddModello.Items.AddRange(_modelli);
            }
            cmb_AddModello.Text = string.Empty;
            cmb_AddModello.SelectedIndex = -1;
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
                string nuovoStato = dGw_Veicoli.Rows[e.RowIndex].Cells["Stato"].Value.ToString();

                try
                {
                    MethodsDB.AggiornaVeicolo(idVeicolo, km, nuovoStato);
                    Filter(); // Ricarico la schermata
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante l'aggiornamento dello stato: " + ex.Message);
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

        // Palette "Lavagna & Ghiaccio" - Sfondo spento ad alto contrasto
        private readonly Color ColoreSfondo = Color.FromArgb(30, 34, 42);          // Grigio lavagna scurissimo e opaco (sfondo principale)
        private readonly Color ColoreCard = Color.FromArgb(41, 47, 58);            // Antracite leggermente più chiaro per i pannelli
        private readonly Color ColoreTesto = Color.FromArgb(225, 230, 238);        // Grigio ghiaccio chiarissimo (contrasto netto sul fondo scuro)
        private readonly Color ColoreAccento = Color.FromArgb(0, 180, 216);         // Azzurro ciano brillante per bottoni attivi e focus
        private readonly Color ColoreTestoAccento = Color.FromArgb(20, 24, 33);     // Testo scuro da usare sopra i bottoni azzurri/chiari
        private readonly Color ColoreSelezione = Color.FromArgb(61, 72, 92);        // Grigio-blu medio per evidenziare le righe selezionate
        private readonly Color ColoreBordi = Color.FromArgb(52, 61, 75);           // Linee di divisione scure ma nette
        private readonly Color ColoreGrigliaAlternata = Color.FromArgb(36, 41, 51); // Righe della griglia appena sfasate

        private void InizializzaStileEstetico()
        {
            // Sfondo principale dell'UserControl e dei pannelli
            this.BackColor = ColoreSfondo;
            panel1.BackColor = ColoreCard;
            tabPage1.BackColor = ColoreSfondo;
            tabPage2.BackColor = ColoreSfondo;

            // Configurazione TabControl
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            // Ciclo sui controlli per applicare lo stile Flat a pulsanti e scritte
            ApplicaStileControlliRicorsivo(this.Controls);

            // Ottimizzazione Griglie (dGw_Veicoli e dGw_Modelli)
            ConfiguraGraficaGriglia(dGw_Veicoli);
            ConfiguraGraficaGriglia(dGw_Modelli);
        }

        private void ApplicaStileControlliRicorsivo(Control.ControlCollection controlli)
        {
            foreach (Control c in controlli)
            {
                c.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                if (c is Label lbl && lbl.Font.Size < 14)
                {
                    lbl.ForeColor = ColoreTesto;
                }

                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    // Assegnazione colori in base al nome del bottone
                    bool isBottonePrincipale = btn.Name.Contains("Add") || btn.Name.Contains("FilterInfo");
                    btn.BackColor = isBottonePrincipale ? ColoreAccento : ColoreCard;
                    btn.ForeColor = isBottonePrincipale ? ColoreTestoAccento : ColoreTesto;

                    btn.Cursor = Cursors.Hand;

                    btn.Paint -= Bottoni_Paint;
                    btn.Paint += Bottoni_Paint;
                }

                // Se vuoi arrotondare anche i pannelli (le "Card")
                if (c is Panel pnl && pnl.Name == "panel1")
                {
                    pnl.Paint -= Pannelli_Paint;
                    pnl.Paint += Pannelli_Paint;
                }

                if (c is TextBox || c is ComboBox)
                {
                    c.BackColor = ColoreCard;
                    c.ForeColor = ColoreTesto;
                    // Per TextBox e ComboBox l'arrotondamento è complesso in WinForms, 
                    // ma lo stile piatto scuro è già molto moderno.
                }

                if (c.HasChildren)
                {
                    ApplicaStileControlliRicorsivo(c.Controls);
                }
            }
        }
        private void Bottoni_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Raggio di arrotondamento (es. 6 per un arrotondamento leggero, btn.Height/2 per effetto pillola)
            int raggio = 6;
            Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);

            using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRectanglePath(rect, raggio))
            {
                // 1. Taglia gli spigoli visivi del bottone per non far sbordare il colore di sfondo quadrato
                btn.Region = new Region(path);

                // 2. Disegna il bordo arrotondato usando il colore dei bordi della tua palette
                using (Pen pennaBordo = new Pen(ColoreBordi, 1.5f))
                {
                    e.Graphics.DrawPath(pennaBordo, path);
                }
            }
        }

        private void Pannelli_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int raggio = 8; // I pannelli stanno bene con un raggio leggermente più ampio
            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);

            using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRectanglePath(rect, raggio))
            {
                using (Pen pennaBordo = new Pen(ColoreBordi, 1))
                {
                    e.Graphics.DrawPath(pennaBordo, path);
                }
            }
        }

        private void ConfiguraGraficaGriglia(DataGridView dgw)
        {
            dgw.BackgroundColor = ColoreCard;
            dgw.GridColor = ColoreBordi;

            // Stile celle predefinito
            dgw.DefaultCellStyle.BackColor = ColoreCard;
            dgw.DefaultCellStyle.ForeColor = ColoreTesto;
            dgw.DefaultCellStyle.SelectionBackColor = ColoreSelezione;
            dgw.DefaultCellStyle.SelectionForeColor = ColoreTesto;

            // Righe alternate
            dgw.AlternatingRowsDefaultCellStyle.BackColor = ColoreGrigliaAlternata;

            // Intestazioni di colonna
            dgw.ColumnHeadersDefaultCellStyle.BackColor = ColoreSfondo;
            dgw.ColumnHeadersDefaultCellStyle.ForeColor = ColoreTesto;
            dgw.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColoreSfondo;
            dgw.EnableHeadersVisualStyles = false;
        }

        private void ConfiguraStileGriglia(DataGridView dgw)
        {
            // Permette di sovrascrivere lo stile nativo di Windows
            dgw.EnableHeadersVisualStyles = false;

            // Proprietà di Struttura e Bordi (Morbidi, anti-abbagliamento)
            dgw.BackgroundColor = Color.FromArgb(248, 249, 250);
            dgw.GridColor = Color.FromArgb(231, 235, 240);       // Linee di divisione finissime
            dgw.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgw.RowHeadersVisible = false;
            dgw.BorderStyle = BorderStyle.None;

            // Il "Respiro" dell'interfaccia
            dgw.RowTemplate.Height = 40;
            dgw.ColumnHeadersHeight = 42;
            dgw.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Stile dell'Intestazione (Header)
            DataGridViewCellStyle stileHeader = new DataGridViewCellStyle();
            stileHeader.BackColor = ColoreSfondo;
            stileHeader.SelectionBackColor = ColoreSfondo;
            stileHeader.ForeColor = ColoreTesto; // Testo chiaro su fondo scuro
            stileHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            stileHeader.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgw.ColumnHeadersDefaultCellStyle = stileHeader;

            // Stile delle Righe Standard (Default)
            DataGridViewCellStyle stileRighe = new DataGridViewCellStyle();
            stileRighe.BackColor = Color.Gray;
            stileRighe.ForeColor = Color.White;            // Grigio scuro ardesia
            stileRighe.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            // Selezione armoniosa (Grigio-azzurro opaco, addio blu elettrico)
            stileRighe.SelectionBackColor = Color.FromArgb(226, 232, 240); // Slate 200
            stileRighe.SelectionForeColor = Color.FromArgb(15, 23, 42);    // Slate 900
            stileRighe.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgw.DefaultCellStyle = stileRighe;

            // Stile Righe Alterne (Per facilitare la lettura senza appesantire)
            DataGridViewCellStyle stileRigheAlterne = new DataGridViewCellStyle();
            stileRigheAlterne.BackColor = Color.FromArgb(241, 245, 249);   // Slate 50
            stileRigheAlterne.ForeColor = Color.FromArgb(71, 85, 105);
            stileRigheAlterne.SelectionBackColor = Color.FromArgb(226, 232, 240);
            stileRigheAlterne.SelectionForeColor = Color.FromArgb(15, 23, 42);
            stileRigheAlterne.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgw.AlternatingRowsDefaultCellStyle = stileRigheAlterne;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage pagina = tabControl1.TabPages[e.Index];
            Rectangle areaTab = tabControl1.GetTabRect(e.Index);

            bool istabSelezionato = (tabControl1.SelectedIndex == e.Index);

            // Sfondo del singolo Tab
            using (Brush pennelloSfondo = new SolidBrush(istabSelezionato ? ColoreCard : ColoreSfondo))
            {
                g.FillRectangle(pennelloSfondo, areaTab);
            }

            // Linea inferiore di accento se il tab è attivo
            if (istabSelezionato)
            {
                using (Pen pennaAccento = new Pen(ColoreAccento, 2))
                {
                    g.DrawLine(pennaAccento, areaTab.Left + 4, areaTab.Bottom - 1, areaTab.Right - 4, areaTab.Bottom - 1);
                }
            }

            // Disegno del testo centrato
            TextFormatFlags allineamento = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            Color coloreTestoTab = istabSelezionato ? ColoreAccento : ColoreTesto;

            TextRenderer.DrawText(g, pagina.Text, tabControl1.Font, areaTab, coloreTestoTab, allineamento);
        }

        private void dGw_Veicoli_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 1. Gestione delle Intestazioni di Colonna (RowIndex == -1)
            if (e.RowIndex == -1)
            {
                e.PaintBackground(e.CellBounds, true);

                using (Brush pennelloHeader = new SolidBrush(ColoreSfondo))
                {
                    e.Graphics.FillRectangle(pennelloHeader, e.CellBounds);
                }

                using (Pen pennaLinea = new Pen(ColoreBordi, 1))
                {
                    e.Graphics.DrawLine(pennaLinea, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(pennaLinea, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                }

                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            // 2. Gestione delle celle selezionate per rendere il focus morbido
            else if (e.RowIndex >= 0 && (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                e.PaintBackground(e.CellBounds, false);

                using (Brush pennelloSelezione = new SolidBrush(ColoreSelezione))
                {
                    e.Graphics.FillRectangle(pennelloSelezione, e.CellBounds);
                }

                // Disegna solo la linea orizzontale inferiore di divisione cella
                using (Pen pennaGriglia = new Pen(ColoreBordi, 1))
                {
                    e.Graphics.DrawLine(pennaGriglia, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                // Forza il disegno del testo/contenuto sopra il nostro sfondo personalizzato
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Genera geometricamente un tracciato a rettangolo con angoli arrotondati (look a pillola).
        /// </summary>
        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;

            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            if (diameter <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            // 1. Angolo in alto a sinistra
            path.AddArc(arc, 180, 90);

            // 2. Angolo in alto a destra
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // 3. Angolo in basso a destra
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // 4. Angolo in basso a sinistra
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void splitContainer1_Paint(object sender, PaintEventArgs e)
        {
            SplitContainer split = (SplitContainer)sender;
            using (Pen pennaBordo = new Pen(ColoreBordi, 1))
            {
                // Essendo orizzontale, disegna la linea di divisione sulla coordinata del divisore
                e.Graphics.DrawLine(pennaBordo, 0, split.SplitterDistance, split.Width, split.SplitterDistance);
            }
        }
        #endregion
    }
}