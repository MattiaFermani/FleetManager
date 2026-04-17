using Dapper;
using FleetManager.Entita;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FleetManager.DB
{
    public static class MethodsDB
    {
        // --- METODI DI CONTROLLO E INSERIMENTO ---

        public static bool CheckVeicolo(string targa)
        {
            using (var connection = Database.Connection())
            {
                string query = "SELECT COUNT(*) FROM VEICOLI WHERE Targa = @targa";
                return connection.ExecuteScalar<int>(query, new { targa }) > 0;
            }
        }

        public static void InserisciVeicolo(Veicolo v)
        {
            using (var connection = Database.Connection())
            {
                string query = @"INSERT INTO VEICOLI (Targa, FK_Modello, AnnoProduzione, Chilometraggio, Stato) 
                               VALUES (@Targa, @FK_Modello, @AnnoProduzione, @Chilometraggio, @Stato)";
                connection.Execute(query, v);
            }
        }

        // --- METODI PER KPI ---

        public static int GetTotaleVeicoli()
        {
            using (var connection = Database.Connection())
            {
                return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM VEICOLI");
            }
        }

        public static int GetVeicoliDisponibili()
        {
            using (var connection = Database.Connection())
            {
                return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM VEICOLI WHERE Stato = 'Disponibile'");
            }
        }

        public static int GetPatentiInScadenza()
        {
            using (var connection = Database.Connection())
            {
                string query = "SELECT COUNT(*) FROM GUIDATORI WHERE ScadenzaPatente <= DATEADD(day, 30, GETDATE())";
                return connection.ExecuteScalar<int>(query);
            }
        }

        // --- METODI PER GRAFICI ---

        public static IEnumerable<dynamic> GetStatisticheStatoVeicoli()
        {
            using (var connection = Database.Connection())
            {
                // Raggruppiamo per lo stato del veicolo (es. Disponibile, Impegnato, Manutenzione)
                string query = @"SELECT Stato as Descrizione, COUNT(*) as Qta 
                                 FROM VEICOLI 
                                 GROUP BY Stato";
                return connection.Query(query);
            }
        }

        public static IEnumerable<dynamic> GetSpeseManutenzioneMensili()
        {
            using (var connection = Database.Connection())
            {
                // Usiamo DataIntervento come da tua tabella
                string query = @"SELECT 
                            FORMAT(DataIntervento, 'MMM', 'it-IT') as Mese, 
                            SUM(Costo) as Totale 
                         FROM MANUTENZIONI 
                         WHERE DataIntervento > DATEADD(year, -1, GETDATE())
                         GROUP BY MONTH(DataIntervento), FORMAT(DataIntervento, 'MMM', 'it-IT')
                         ORDER BY MONTH(DataIntervento)";
                return connection.Query(query);
            }
        }

        // --- METODI PER TABELLE ---

        public static IEnumerable<dynamic> GetUltimeManutenzioni()
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT TOP 5 V.Targa, M.DataIntervento, M.Costo 
                                 FROM MANUTENZIONI M 
                                 JOIN VEICOLI V ON M.FK_Veicolo = V.ID_Veicolo 
                                 ORDER BY M.DataIntervento DESC";
                return connection.Query(query);
            }
        }

        public static IEnumerable<dynamic> GetTop3Incidentati()
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT TOP 3 G.Cognome, G.Nome, COUNT(I.ID_Incidente) as Conteggio 
                                 FROM GUIDATORI G 
                                 JOIN INCIDENTI I ON G.ID_Guidatore = I.FK_Guidatore 
                                 GROUP BY G.Cognome, G.Nome 
                                 ORDER BY Conteggio DESC";
                return connection.Query(query);
            }
        }
    }
}