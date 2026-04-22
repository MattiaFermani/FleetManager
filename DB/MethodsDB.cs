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
                                FORMAT(DataIntervento, 'MMM yyyy', 'us-US') as Mese, 
                                SUM(Costo) as Totale 
                                FROM MANUTENZIONI 
                                WHERE DataIntervento > DATEADD(year, -1, GETDATE())
                                GROUP BY YEAR(DataIntervento), MONTH(DataIntervento), FORMAT(DataIntervento, 'MMM yyyy', 'us-US')
                                ORDER BY YEAR(DataIntervento), MONTH(DataIntervento)";
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
        #region VEICOLI
        public static void InserisciVeicolo(Veicolo v)
        {
            using (var connection = Database.Connection())
            {
                string query = @"INSERT INTO VEICOLI (Targa, FK_Modello, AnnoProduzione, Chilometraggio, Stato) 
                               VALUES (@Targa, @FK_Modello, @AnnoProduzione, @Chilometraggio, @Stato)";
                connection.Execute(query, v);
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
        public static void InserisciModello(Modello m)
        {
            using (var connection = Database.Connection())
            {
                string query = @"INSERT INTO MODELLI (NomeModello, Marca) 
                               VALUES (@NomeModello, @Marca)";
                connection.Execute(query, m);
            }
        }
        #endregion VEICOLI
        #region FILTRI
        public static List<string> GetDistintiAnni()
        {
            using (var connection = Database.Connection())
                return connection.Query<string>("SELECT DISTINCT CAST(AnnoProduzione AS VARCHAR) FROM VEICOLI WHERE AnnoProduzione IS NOT NULL ORDER BY 1").ToList();
        }

        public static List<string> GetDistintiModelli(string marca = null)
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT '(' + CAST(COUNT(*) AS VARCHAR) + ') ' + M.NomeModello 
                         FROM VEICOLI V
                         JOIN MODELLI M ON V.FK_Modello = M.ID_Modello
                         WHERE (@marca IS NULL OR M.Marca = @marca)
                         GROUP BY M.NomeModello
                         ORDER BY M.NomeModello";
                return connection.Query<string>(query, new { marca }).ToList();
            }
        }

        public static List<string> GetDistinteMarche(string modello = null)
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT '(' + CAST(COUNT(*) AS VARCHAR) + ') ' + M.Marca 
                         FROM VEICOLI V
                         JOIN MODELLI M ON V.FK_Modello = M.ID_Modello
                         WHERE (@modello IS NULL OR M.NomeModello = @modello)
                         GROUP BY M.Marca
                         ORDER BY M.Marca";
                return connection.Query<string>(query, new { modello }).ToList();
            }
        }

        public static IEnumerable<dynamic> RicercaVeicoli(string? targa = null, OrderType? annoProduzioneOrder = null, string? annoProduzione = null, OrderType? marcaOrder = null, string? marca = null, OrderType? modelloOrder = null, string? modello = null, OrderType? kmOrder = null, KmFilterType? KmfilterType = null, int? chilometraggio = null, OrderType? statusOrder = null, string? stato = null)
        {
            using (var connection = Database.Connection())
            {
                // 1. Gestione operatore KM
                string operatore = KmfilterType switch
                {
                    KmFilterType.Under => "<",
                    KmFilterType.Over => ">",
                    KmFilterType.Equal => "=",
                    _ => ">"
                };

                List<string> orders = new List<string>();

                if (marcaOrder != OrderType.None && marcaOrder != null)
                    orders.Add($"M.Marca {(marcaOrder == OrderType.Ascending ? "ASC" : "DESC")}");

                if (modelloOrder != OrderType.None && modelloOrder != null)
                    orders.Add($"M.NomeModello {(modelloOrder == OrderType.Ascending ? "ASC" : "DESC")}");

                if (annoProduzioneOrder != OrderType.None && annoProduzioneOrder != null)
                    orders.Add($"V.AnnoProduzione {(annoProduzioneOrder == OrderType.Ascending ? "ASC" : "DESC")}");

                if (kmOrder != OrderType.None && kmOrder != null)
                    orders.Add($"V.Chilometraggio {(kmOrder == OrderType.Ascending ? "ASC" : "DESC")}");

                if (statusOrder != OrderType.None && statusOrder != null)
                    orders.Add($"V.Stato {(statusOrder == OrderType.Ascending ? "ASC" : "DESC")}");

                string orderBy = orders.Count > 0
                    ? "ORDER BY " + string.Join(", ", orders)
                    : "ORDER BY V.Targa ASC"; //Ordine Default

                string query = $@"SELECT V.ID_Veicolo, V.Targa, M.Marca, M.NomeModello, 
                                V.AnnoProduzione, V.Chilometraggio, V.Stato
                         FROM VEICOLI V
                         JOIN MODELLI M ON V.FK_Modello = M.ID_Modello
                         WHERE (@targa IS NULL OR V.Targa LIKE '%' + @targa + '%')
                           AND (@annoProduzione IS NULL OR V.AnnoProduzione = @annoProduzione)
                           AND (@marca IS NULL OR M.Marca LIKE '%' + @marca + '%')
                           AND (@modello IS NULL OR M.NomeModello LIKE '%' + @modello + '%')
                           AND (@chilometraggio IS NULL OR V.Chilometraggio {operatore} @chilometraggio)
                           AND (@stato IS NULL OR V.Stato = @stato)
                         {orderBy}";

                return connection.Query(query, new { targa, annoProduzione, marca, modello, chilometraggio, stato }).ToList();
            }
        }
        #endregion FILTRI
        #endregion FLOTTA
    }
}