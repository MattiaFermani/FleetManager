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
            // CHART 1
            chart1.Series.Clear();
            var dsStato = MethodsDB.GetStatisticheStatoVeicoli().ToList();

            if (dsStato.Any())
            {
                chart1.DataSource = dsStato;
                var s1 = chart1.Series.Add("StatoVeicoli");

                // Collega la serie alla ChartArea creata nel designer
                s1.ChartArea = chart1.ChartAreas[0].Name;

                s1.XValueMember = "Descrizione";
                s1.YValueMembers = "Qta";
                s1.ChartType = SeriesChartType.Pie;

                chart1.DataBind();
            }

            // CHART 2
            chart2.Series.Clear();
            var dsSpese = MethodsDB.GetSpeseManutenzioneMensili().ToList();

            if (dsSpese.Any())
            {
                chart2.DataSource = dsSpese;
                var s2 = chart2.Series.Add("Spese");

                if (chart2.ChartAreas.Count > 0)
                    s2.ChartArea = chart2.ChartAreas[0].Name;

                s2.XValueMember = "Mese";
                s2.YValueMembers = "Totale";
                s2.ChartType = SeriesChartType.Column;

                chart2.DataBind();
            }
            else
            {
                // Se arrivi qui, la lista è vuota (non ci sono manutenzioni nell'ultimo anno)
                Console.WriteLine("Nessun dato trovato per le spese di manutenzione.");
            }
        }

        private void CaricaTabelle()
        {
            dGw_Man.DataSource = MethodsDB.GetUltimeManutenzioni().ToList();
            dGw_Top3Inc.DataSource = MethodsDB.GetTop3Incidentati().ToList();

            FormattaGrid(dGw_Man);
            FormattaGrid(dGw_Top3Inc);
        }

        private void FormattaGrid(DataGridView dgw)
        {
            dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgw.ReadOnly = true;
            dgw.RowHeadersVisible = false;
        }

        private void UC_Dashboard_Paint(object sender, PaintEventArgs e)
        {
            AggiornaDati();
        }
    }
}