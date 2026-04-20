using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FleetManager.DB;
using FastReport.DataVisualization.Charting;

namespace FleetManager
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            AggiornaDati();
        }

        public void AggiornaDati()
        {
            try
            {
                CaricaKPIs();
                CaricaGrafici();
                CaricaTabelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel refresh Dashboard: " + ex.Message);
            }
        }

        private void CaricaKPIs()
        {
            lbl_dash_Vehicles.Text = MethodsDB.GetTotaleVeicoli().ToString();
            lbl_dash_AsgAvl.Text = MethodsDB.GetVeicoliDisponibili().ToString();
            lbl_scad.Text = MethodsDB.GetPatentiInScadenza().ToString();
        }

        private void CaricaGrafici()
        {
            // --- CHART 1: Stato Veicoli (Torta) ---
            chart1.Series.Clear();
            chart1.Legends.Clear(); 
            var dsStato = MethodsDB.GetStatisticheStatoVeicoli().ToList();

            if (dsStato.Any())
            {
                chart1.DataSource = dsStato;
                var legend1 = chart1.Legends.Add("StatoVeicoliLegend");
                legend1.Docking = Docking.Bottom;

                var s1 = chart1.Series.Add("StatoVeicoli");
                s1.ChartArea = chart1.ChartAreas[0].Name;

                s1.XValueMember = "Descrizione";
                s1.YValueMembers = "Qta";
                s1.ChartType = SeriesChartType.Pie;

                s1.Label = "#PERCENT{P0} (#VALY)";
                s1.LegendText = "#VALX"; 

                chart1.DataBind();
            }

            // --- CHART 2: Spese Manutenzione (Istogramma) ---
            chart2.Series.Clear();
            chart2.Legends.Clear(); 
            var dsSpese = MethodsDB.GetSpeseManutenzioneMensili().ToList();

            if (dsSpese.Any())
            {
                chart2.DataSource = dsSpese;
                var legend2 = chart2.Legends.Add("SpeseManutenzioneLegend");
                legend2.Docking = Docking.Bottom;

                var s2 = chart2.Series.Add("Spese");
                if (chart2.ChartAreas.Count > 0)
                    s2.ChartArea = chart2.ChartAreas[0].Name;

                s2.XValueMember = "Mese";
                s2.YValueMembers = "Totale";
                s2.ChartType = SeriesChartType.Column;

                s2.Label = "#VALY{C2}";

                s2.Palette = ChartColorPalette.SeaGreen;

                chart2.DataBind();
            }
            else
            {
                Console.WriteLine("Nessun dato trovato per le spese di manutenzione.");
            }
        }

        private void CaricaTabelle()
        {
            //dGw_Man.Rows.Clear();
            //dGw_Man.Columns.Clear();
            //dGw_Top3Inc.Rows.Clear();
            //dGw_Top3Inc.Columns.Clear();
            List<dynamic> manutenzioni = MethodsDB.GetUltimeManutenzioni(6).ToList();

            lsw_Man.View = View.Details;
            lsw_Man.MultiSelect = false;
            lsw_Man.FullRowSelect = true;
            lsw_Man.GridLines = false;

            lsw_Man.Clear();

            lsw_Man.Columns.Add("Targa", 100);
            lsw_Man.Columns.Add("Data Intervento", 120);
            lsw_Man.Columns.Add("Costo (€)", 80);

            foreach (var m in manutenzioni)
            {
                ListViewItem item = new ListViewItem(m.Targa?.ToString() ?? "N/D");

                item.SubItems.Add(Convert.ToDateTime(m.DataIntervento).ToShortDateString());
                item.SubItems.Add(string.Format("{0:C2}", m.Costo));

                lsw_Man.Items.Add(item);
            }

            lsw_Man.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            List<dynamic> topIncidenti = MethodsDB.GetTopIncidentati(6).ToList();

            lsw_TopInc.View = View.Details;
            lsw_TopInc.MultiSelect = false;
            lsw_TopInc.FullRowSelect = true;
            lsw_TopInc.GridLines = false;

            lsw_TopInc.Clear();

            lsw_TopInc.Columns.Add("Cognome", 100);
            lsw_TopInc.Columns.Add("Nome", 120);
            lsw_TopInc.Columns.Add("Conteggio", 80);

            foreach (var m in topIncidenti)
            {
                ListViewItem item = new ListViewItem(m.Cognome?.ToString() ?? "N/D");

                item.SubItems.Add(m.Nome?.ToString() ?? "N/D");
                item.SubItems.Add(m.Conteggio?.ToString() ?? "0");

                lsw_TopInc.Items.Add(item);
            }

            lsw_TopInc.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            //dGw_Man.DataSource = MethodsDB.GetUltimeManutenzioni().ToList();
            //dGw_Top3Inc.DataSource = MethodsDB.GetTopIncidentati().ToList();

            //FormattaGrid(dGw_Man);
            //FormattaGrid(dGw_Top3Inc);
        }

        //private void FormattaGrid(DataGridView dgw)
        //{
        //    dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //    dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgw.ReadOnly = true;
        //    dgw.RowHeadersVisible = false;
        //}

        private void UC_Dashboard_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}