using FleetManager.DB;
using FleetManager.Entita;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FleetManager
{
    public enum DateFilterType
    {
        Cresc,
        Descr,
        Equal,
        None
    }
    public partial class UC_Guidatori : UserControl
    {
        private static UC_Guidatori _instance;
        private DateFilterType DatefilterType = DateFilterType.None;
        public static UC_Guidatori Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Guidatori();
                return _instance;
            }
        }
        public UC_Guidatori()
        {
            InitializeComponent();

            _instance = this;

            ConfiguraStileGriglia();

            dGw_Guidatori.AutoGenerateColumns = false;

            Cognome.DataPropertyName = "Cognome";
            Nome.DataPropertyName = "Nome";
            CodiceFiscale.DataPropertyName = "CodiceFiscale";
            ScadenzaPatente.DataPropertyName = "ScadenzaPatente";
            Stato.DataPropertyName = "Stato";
            ID_Guidatore.DataPropertyName = "ID_Guidatore";

            ID_Guidatore.Visible = false;

            InizializzaComboBoxStato();

            RefreshData();
        }

        private void InizializzaComboBoxStato()
        {
            cmb_GuidatoreStato.Items.Clear();
            cmb_GuidatoreStato.Items.Add("Tutti Gli Stati");
            cmb_GuidatoreStato.Items.Add("ATTIVO");
            cmb_GuidatoreStato.Items.Add("IN SCADENZA");
            cmb_GuidatoreStato.Items.Add("SOSPESO (Scaduta)");
            cmb_GuidatoreStato.SelectedIndex = 0;
        }

        public void RefreshData()
        {
            // Richiamiamo direttamente il filtro vuoto o la ricerca totale
            var lista = MethodsDB.RicercaGuidatori();
            dGw_Guidatori.DataSource = null;
            dGw_Guidatori.DataSource = lista;
        }

        private readonly Font _fontStatoGrassetto = new Font("Segoe UI", 9, FontStyle.Bold);
        private void dGw_Guidatori_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            //string nomeColonna = dGw_Guidatori.Columns[e.ColumnIndex].Name;

            //// 1. Gestione COLORI SELEZIONE per le colonne normali (Righe Alterne stabili)
            //if (nomeColonna != "Stato")
            //{
            //    if (e.RowIndex % 2 == 0) // Riga Pari
            //    {
            //        e.CellStyle.SelectionBackColor = Color.White;
            //        e.CellStyle.SelectionForeColor = Color.Black;
            //    }
            //    else // Riga Dispari
            //    {
            //        e.CellStyle.SelectionBackColor = Color.LightGray;
            //        e.CellStyle.SelectionForeColor = Color.Black;
            //    }
            //}

            //// 2. Customizzazione Avanzata Colonna STATO
            //if (nomeColonna == "Stato" && e.Value != null)
            //{
            //    string valore = e.Value.ToString();

            //    switch (valore)
            //    {
            //        case "LICENZIATO":
            //            e.CellStyle.ForeColor = Color.White;
            //            e.CellStyle.BackColor = Color.Gray;
            //            e.CellStyle.SelectionBackColor = Color.DarkGray;
            //            e.CellStyle.SelectionForeColor = Color.White;
            //            break;

            //        case "SOSPESO (Scaduta)":
            //            e.CellStyle.ForeColor = Color.White;
            //            e.CellStyle.BackColor = Color.Crimson;
            //            e.CellStyle.SelectionBackColor = Color.DarkRed;
            //            e.CellStyle.SelectionForeColor = Color.White;
            //            break;

            //        case string s when s.StartsWith("IN SCADENZA"):
            //            e.CellStyle.ForeColor = Color.Black;
            //            e.CellStyle.BackColor = Color.Gold;
            //            e.CellStyle.SelectionBackColor = Color.DarkGoldenrod;
            //            e.CellStyle.SelectionForeColor = Color.Black;
            //            break;

            //        case "ATTIVO":
            //            e.CellStyle.ForeColor = Color.DarkGreen;
            //            e.CellStyle.BackColor = Color.White;
            //            e.CellStyle.SelectionBackColor = Color.LightGray;
            //            e.CellStyle.SelectionForeColor = Color.DarkGreen;
            //            break;
            //    }

            //    e.CellStyle.Font = _fontStatoGrassetto;
            //    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    e.CellStyle.WrapMode = DataGridViewTriState.True;
            //}
        }

        private void dGw_Guidatori_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var guidatoreSelezionato = (Guidatore)dGw_Guidatori.Rows[e.RowIndex].DataBoundItem;

                FormDettaglioGuidatore frm = new FormDettaglioGuidatore(guidatoreSelezionato);

                frm.FormClosed += (s, args) => RefreshData();

                frm.Show();
            }
        }
        private void Filter()
        {
            string nome = string.IsNullOrWhiteSpace(txb_GuidatoreNome.Text) ? null : txb_GuidatoreNome.Text.Trim();
            string cognome = string.IsNullOrWhiteSpace(txb_GuidatoreCognome.Text) ? null : txb_GuidatoreCognome.Text.Trim();
            string CF = string.IsNullOrWhiteSpace(txb_GuidatoreCF.Text) ? null : txb_GuidatoreCF.Text.Trim();

            // Semplificato: se non c'è filtro sulla data, passiamo null al DB
            DateTime? ScadenzaPatente = DatefilterType == DateFilterType.None ? null : dtp_GuidatorePatente.Value.Date;

            string Stato = cmb_GuidatoreStato.SelectedItem?.ToString();

            // Cambiato il tipo della lista da dynamic a Guidatore
            List<Guidatore> risultati = MethodsDB.RicercaGuidatori(
                Nome: nome,
                Cognome: cognome,
                CodiceFiscale: CF,
                DatefilterType: DatefilterType,
                ScadenzaPatente: ScadenzaPatente,
                Stato: Stato == "Tutti Gli Stati" ? null : Stato
            );

            dGw_Guidatori.DataSource = null;
            dGw_Guidatori.DataSource = risultati;
        }
        private void txb_GuidatoreNome_TextChanged(object sender, EventArgs e) => Filter();

        private void txb_GuidatoreCognome_TextChanged(object sender, EventArgs e) => Filter();

        private void txb_GuidatoreCF_TextChanged(object sender, EventArgs e) => Filter();

        private void cmb_GuidatoreStato_SelectedIndexChanged(object sender, EventArgs e) => Filter();

        private void btn_GuidatorePatente_CrescDescr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DatefilterType = DatefilterType == DateFilterType.Cresc ? DateFilterType.Descr : DateFilterType.Cresc;
                btn_GuidatorePatente_CrescDescr.Text = DatefilterType == DateFilterType.Cresc ? ">" : "<";
            }
            else
            {
                DatefilterType = DatefilterType == DateFilterType.Equal ? DateFilterType.None : DateFilterType.Equal;
                btn_GuidatorePatente_CrescDescr.Text = DatefilterType == DateFilterType.None ? "↹" : "=";
            }
            Filter();
        }

        private void dtp_GuidatorePatente_ValueChanged(object sender, EventArgs e) => Filter();

        #region STILE 
        private void ConfiguraStileGriglia()
        {
            // 1. FONDAMENTALE: Permette di sovrascrivere lo stile nativo di Windows per le intestazioni
            dGw_Guidatori.EnableHeadersVisualStyles = false;

            // 2. Proprietà di Struttura e Bordi
            dGw_Guidatori.BackgroundColor = Color.FromArgb(249, 250, 251); // Sfondo grigio chiarissimo (Tailwind Gray 50)
            dGw_Guidatori.GridColor = Color.FromArgb(243, 244, 246);       // Linee di divisione molto tenui (Gray 100)
            dGw_Guidatori.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Solo linee orizzontali, look più pulito
            dGw_Guidatori.RowHeadersVisible = false;                       // Nasconde la colonna vuota a sinistra
            dGw_Guidatori.BorderStyle = BorderStyle.None;

            // 3. Il "Respiro" (Righe più alte = interfaccia moderna)
            dGw_Guidatori.RowTemplate.Height = 40;                         // Diamo spazio alle celle
            dGw_Guidatori.ColumnHeadersHeight = 42;                        // Più spazio per i titoli
            dGw_Guidatori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // 4. Stile dell'Intestazione (Header) - Stile scuro "Pro"
            DataGridViewCellStyle stileHeader = new DataGridViewCellStyle();
            stileHeader.BackColor = Color.FromArgb(31, 41, 55);            // Antracite scuro (Gray 800)
            stileHeader.SelectionBackColor = Color.FromArgb(31, 41, 55);   // Mantiene lo stesso colore anche in selezione
            stileHeader.ForeColor = Color.White;                           // Testo bianco
            stileHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            stileHeader.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dGw_Guidatori.ColumnHeadersDefaultCellStyle = stileHeader;

            // 5. Stile delle Righe Standard (Default)
            DataGridViewCellStyle stileRighe = new DataGridViewCellStyle();
            stileRighe.BackColor = Color.White;
            stileRighe.ForeColor = Color.FromArgb(55, 65, 81);             // Grigio scuro (meno aggressivo del nero puro)
            stileRighe.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            // Colore di selezione armonioso (Azzurro morbido con testo scuro, non il blu elettrico di Windows)
            stileRighe.SelectionBackColor = Color.FromArgb(239, 246, 255); // Blue 50
            stileRighe.SelectionForeColor = Color.FromArgb(29, 78, 216);   // Blue 700
            stileRighe.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dGw_Guidatori.DefaultCellStyle = stileRighe;

            // 6. Stile Righe Alterne (Per migliorare la lettura dei dati)
            DataGridViewCellStyle stileRigheAlterne = new DataGridViewCellStyle();
            stileRigheAlterne.BackColor = Color.FromArgb(249, 250, 251);   // Sfondo alternato Gray 50
            stileRigheAlterne.ForeColor = Color.FromArgb(55, 65, 81);
            stileRigheAlterne.SelectionBackColor = Color.FromArgb(239, 246, 255);
            stileRigheAlterne.SelectionForeColor = Color.FromArgb(29, 78, 216);
            stileRigheAlterne.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dGw_Guidatori.AlternatingRowsDefaultCellStyle = stileRigheAlterne;
        }
        private void dGw_Guidatori_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dGw_Guidatori.Columns[e.ColumnIndex].Name == "Stato")
            {
                // 1. Disegna lo sfondo standard della cella (gestisce la selezione della riga nativa)
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentBackground & ~DataGridViewPaintParts.ContentForeground);

                if (e.Value != null)
                {
                    string valore = e.Value.ToString();

                    // Palette colori Premium (Stile Web moderno)
                    Color badgeColor = Color.FromArgb(243, 244, 246);  // Grigio default
                    Color textColor = Color.FromArgb(75, 85, 99);
                    Color borderColor = Color.FromArgb(229, 231, 235);

                    switch (valore)
                    {
                        case "ATTIVO":
                            badgeColor = Color.FromArgb(220, 252, 231);  // Verde soft
                            textColor = Color.FromArgb(21, 128, 61);     // Testo verde scuro
                            borderColor = Color.FromArgb(187, 247, 208); // Bordo verde intermedio
                            break;

                        case "SOSPESO (Scaduta)":
                            badgeColor = Color.FromArgb(254, 226, 226);  // Rosso soft
                            textColor = Color.FromArgb(185, 28, 28);     // Testo rosso scuro
                            borderColor = Color.FromArgb(254, 202, 202); // Bordo rosso intermedio
                            break;

                        case string s when s.StartsWith("IN SCADENZA"):
                            badgeColor = Color.FromArgb(254, 243, 199);  // Giallo/Ambra soft
                            textColor = Color.FromArgb(180, 83, 9);      // Testo ambra scuro
                            borderColor = Color.FromArgb(253, 230, 138); // Bordo ambra intermedio
                            break;

                        case "LICENZIATO":
                            badgeColor = Color.FromArgb(243, 244, 246);  // Slate soft
                            textColor = Color.FromArgb(107, 114, 128);   // Testo ardesia
                            borderColor = Color.FromArgb(209, 213, 219); // Bordo ardesia intermedio
                            break;
                    }

                    // 2. Calcolo dei margini interni per centrare la pillola nella cella
                    int margineOrizzontale = 12;
                    int margineVerticale = 4;
                    Rectangle badgeRect = new Rectangle(
                        e.CellBounds.X + margineOrizzontale,
                        e.CellBounds.Y + margineVerticale,
                        e.CellBounds.Width - (margineOrizzontale * 2),
                        e.CellBounds.Height - (margineVerticale * 2)
                    );

                    // 3. ATTIVAZIONE ANTI-ALIASING (Rende le curve lisce e professionali)
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // 4. Generazione del tracciato con angoli smussati (Raggio 8px per un look bilanciato)
                    int raggioCurvatura = 8;
                    using (GraphicsPath path = GetRoundedRectanglePath(badgeRect, raggioCurvatura))
                    {
                        // Riempimento corpo del Badge
                        using (SolidBrush brush = new SolidBrush(badgeColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }

                        // Disegno del micro-bordo per dare profondità e rifinitura
                        using (Pen pen = new Pen(borderColor, 1f))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    }

                    // 5. Scrittura del testo (Disattiviamo temporaneamente l'antialiasing del testo per preservare la nitidezza del Font ClearType)
                    e.Graphics.SmoothingMode = SmoothingMode.Default;
                    TextRenderer.DrawText(
                        e.Graphics,
                        valore,
                        _fontStatoGrassetto,
                        badgeRect,
                        textColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
                    );
                }

                // Comunica a Windows Forms che il disegno personalizzato è terminato con successo
                e.Handled = true;
            }
        }

        /// <summary>
        /// Genera geometricamente un tracciato a rettangolo con angoli arrotondati.
        /// </summary>
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Previene anomalie se l'utente rimpicciolisce la colonna oltre la dimensione del raggio
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            if (diameter <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            // Angolo in alto a sinistra
            path.AddArc(arc, 180, 90);

            // Angolo in alto a destra
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Angolo in basso a destra
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Angolo in basso a sinistra
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    #endregion
    }
}