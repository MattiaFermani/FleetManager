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
        #region DASHBOARD
        #region CONTATORI
        // --- METODI PER COUNTERS ---

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
        #endregion CONTATORI
        #region GRAFICI
        // --- METODI PER I GRAFICI ---

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
        #endregion GRAFICI
        #region TABELLE
        // --- METODI PER LE TABELLE ---

        public static IEnumerable<dynamic> GetUltimeManutenzioni(int top)
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT TOP (@man) V.Targa, M.DataIntervento, M.Costo 
                                 FROM MANUTENZIONI M 
                                 JOIN VEICOLI V ON M.FK_Veicolo = V.ID_Veicolo 
                                 ORDER BY M.DataIntervento DESC";
                return connection.Query(query, new { man = top });
            }
        }

        public static IEnumerable<dynamic> GetTopIncidentati(int top)
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT TOP (@inc) G.Cognome, G.Nome, COUNT(I.ID_Incidente) as Conteggio 
                                 FROM GUIDATORI G 
                                 JOIN INCIDENTI I ON G.ID_Guidatore = I.FK_Guidatore 
                                 GROUP BY G.Cognome, G.Nome 
                                 ORDER BY Conteggio DESC";
                return connection.Query(query, new { inc = top });
            }
        }
        #endregion TABELLE
        #endregion

        #region FLOTTA
        public static IEnumerable<dynamic> GetVeicoliCompleti()
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT V.ID_Veicolo, V.Targa, M.Marca, M.NomeModello, 
                                V.AnnoProduzione, V.Chilometraggio, V.Stato
                         FROM VEICOLI V
                         JOIN MODELLI M ON V.FK_Modello = M.ID_Modello";
                return connection.Query(query);
            }
        }

        public static IEnumerable<Modello> GetListaModelli()
        {
            using (var connection = Database.Connection())
            {
                return connection.Query<Modello>("SELECT * FROM MODELLI ORDER BY Marca, NomeModello");
            }
        }

        public static void AggiornaVeicolo(int id, int km, string stato)
        {
            using (var connection = Database.Connection())
            {
                string query = "UPDATE VEICOLI SET Chilometraggio = @km, Stato = @stato WHERE ID_Veicolo = @id";
                connection.Execute(query, new { id, km, stato });
            }
        }
        public static List<string> GetDistintiAnni()
        {
            using (var connection = Database.Connection())
                return connection.Query<string>("SELECT DISTINCT CAST(AnnoProduzione AS VARCHAR) FROM VEICOLI WHERE AnnoProduzione IS NOT NULL ORDER BY 1").ToList();
        }

        public static List<string> GetDistintiModelli()
        {
            using (var connection = Database.Connection())
                return connection.Query<string>("SELECT DISTINCT M.NomeModello FROM VEICOLI V JOIN MODELLI M ON V.FK_Modello = M.ID_Modello ORDER BY 1").ToList();
        }

        public static IEnumerable<dynamic> RicercaVeicoli(string targa = null,string annoProduzione = null, string marca = null, string modello = null, string stato = null)
        {
            using (var connection = Database.Connection())
            {
                // La query rimane identica, i controlli IS NULL gestiranno i parametri non passati
                string query = @"SELECT V.ID_Veicolo, V.Targa, M.Marca, M.NomeModello, 
                                V.AnnoProduzione, V.Chilometraggio, V.Stato
                         FROM VEICOLI V
                         JOIN MODELLI M ON V.FK_Modello = M.ID_Modello
                         WHERE (@targa IS NULL OR V.Targa LIKE '%' + @targa + '%')
                           AND (@annoProduzione IS NULL OR V.AnnoProduzione = @annoProduzione)
                           AND (@marca IS NULL OR M.Marca LIKE '%' + @marca + '%')
                           AND (@modello IS NULL OR M.NomeModello LIKE '%' + @modello + '%')
                           AND (@stato IS NULL OR V.Stato = @stato)";

                return connection.Query(query, new { targa, annoProduzione, marca, modello, stato }).ToList();

            }
        }
        #endregion FLOTTA
    }
}