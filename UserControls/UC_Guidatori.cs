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
    public partial class UC_Guidatori : UserControl
    {
        public UC_Guidatori()
        {
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            var lista = MethodsDB.GetTuttiGuidatori();
            dGw_Guidatori.DataSource = lista;
        }

        private void dGw_Guidatori_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dGw_Guidatori.Columns[e.ColumnIndex].Name == "Stato")
            {
                string valore = e.Value?.ToString();

                if (valore == "SOSPESO (Scaduta)")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Crimson;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
                else if (valore == "IN SCADENZA")
                {
                    e.CellStyle.BackColor = Color.Gold;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void dGw_Guidatori_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var guidatoreSelezionato = (Guidatore)dGw_Guidatori.Rows[e.RowIndex].DataBoundItem;

                using (FormDettaglioGuidatore frm = new FormDettaglioGuidatore(guidatoreSelezionato))
                {
                    frm.Show();
                    RefreshData();
                }
            }
        }
    }
}
