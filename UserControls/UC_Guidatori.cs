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
            RefreshData();
            _instance = this;
        }

        public void RefreshData()
        {
            var lista = MethodsDB.GetTuttiGuidatori();
            dGw_Guidatori.DataSource = lista;
        }

        private void dGw_Guidatori_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dGw_Guidatori.Columns[e.ColumnIndex].Name == "Stato")
            {
                string valore = e.Value?.ToString();
                if (valore == "LICENZIATO")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Gray;
                    e.CellStyle.SelectionBackColor = Color.DarkGray;
                }
                if (valore == "SOSPESO (Scaduta)")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Crimson;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
                else if (valore.StartsWith("IN SCADENZA"))
                {
                    e.CellStyle.BackColor = Color.Gold;
                }
                else if (valore == "ATTIVO")
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                int id = (int)dGw_Guidatori.Rows[e.RowIndex].Cells["ID_Guidatore"].Value;

                MethodsDB.AggiornaStatoGuidatore(id, valore);
            }
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
            string nome = txb_GuidatoreNome.Text;
            string cognome = txb_GuidatoreCognome.Text;
            string codiceFiscale = txb_GuidatoreCF.Text;

        }
        private void txb_GuidatoreNome_TextChanged(object sender, EventArgs e) => Filter();

        private void txb_GuidatoreCognome_TextChanged(object sender, EventArgs e) => Filter();

        private void txb_GuidatoreCF_TextChanged(object sender, EventArgs e) => Filter();

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
    }
}