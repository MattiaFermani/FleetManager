using Dapper;
using FleetManager.Classi;
using FleetManager.Entita;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System;
using System.Windows.Forms; // <-- Controlla che ci sia questo!
using System.Drawing;
using System.Drawing.Drawing2D;
using FleetManager.DB;
using System.Collections.Generic;

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

        public static List<dynamic> GetStatisticheStatoVeicoli()
        {
            using (var connection = Database.Connection())
            {
                // Raggruppiamo per lo stato del veicolo (es. Disponibile, Impegnato, Manutenzione)
                string query = @"SELECT Stato as Descrizione, COUNT(*) as Qta 
                                 FROM VEICOLI 
                                 GROUP BY Stato";
                return connection.Query(query).ToList();
            }
        }

        public static List<dynamic> GetSpeseManutenzioneMensili()
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
                return connection.Query(query).ToList();
            }
        }
        #endregion GRAFICI
        #region TABELLE
        // --- METODI PER LE TABELLE ---

        public static List<dynamic> GetUltimeManutenzioni(int top)
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT TOP (@man) V.Targa, M.DataIntervento, M.Costo 
                                 FROM MANUTENZIONI M 
                                 JOIN VEICOLI V ON M.FK_Veicolo = V.ID_Veicolo 
                                 ORDER BY M.DataIntervento DESC";
                return connection.Query(query, new { man = top }).ToList();
            }
        }

        public static List<dynamic> GetTopIncidentati(int top)
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT TOP (@inc) G.Cognome, G.Nome, COUNT(I.ID_Incidente) as Conteggio 
                                 FROM GUIDATORI G 
                                 JOIN INCIDENTI I ON G.ID_Guidatore = I.FK_Guidatore 
                                 GROUP BY G.Cognome, G.Nome 
                                 ORDER BY Conteggio DESC";
                return connection.Query(query, new { inc = top }).ToList();
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
        public static void AggiornaVeicolo(int id, int? km = null, string? stato = null)
        {
            using (var connection = Database.Connection())
            {
                string query = @"UPDATE VEICOLI SET " +
                               (km != null ? "Chilometraggio = @km" : "") +
                               (km != null && stato != null ? ", " : "") +
                               (stato != null ? "Stato = @stato" : "") +
                               " WHERE ID_Veicolo = @id";
                connection.Execute(query, new { id, km, stato });
            }
        }
        public static void EliminaVeicolo(int id)
        {
            using (var connection = Database.Connection())
            {
                string checkQuery = "SELECT COUNT(1) FROM ASSEGNAZIONI WHERE ID_Veicolo = @id";
                int count = connection.ExecuteScalar<int>(checkQuery, new { id });

                if (count > 0)
                {
                    string updateQuery = "UPDATE VEICOLI SET Stato = 'Non Disponibile' WHERE ID_Veicolo = @id";
                    connection.Execute(updateQuery, new { id });
                }
                else
                {
                    string deleteQuery = "DELETE FROM VEICOLI WHERE ID_Veicolo = @id";
                    connection.Execute(deleteQuery, new { id });
                }
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
        public static int GetIdModelloPerNome(string nomeModello)
        {
            using (var connection = Database.Connection())
            {
                // Cerchiamo l'ID corrispondente al nome pulito
                return connection.ExecuteScalar<int>(
                    "SELECT ID_Modello FROM MODELLI WHERE NomeModello = @nome",
                    new { nome = nomeModello }
                );
            }
        }
        public static bool TargaEsistente(string targa)
        {
            using (var connection = Database.Connection())
            {
                string query = "SELECT COUNT(1) FROM VEICOLI WHERE Targa = @targa";

                int count = connection.ExecuteScalar<int>(query, new { targa });
                return count > 0;
            }
        }
        public static List<dynamic> GetModelloVeicolo()
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT V.ID_Veicolo, V.Targa, M.Marca, M.NomeModello, V.AnnoProduzione, V.Chilometraggio, V.Stato
                                FROM VEICOLI V
                                JOIN MODELLI M ON V.FK_Modello = M.ID_Modello
                                ORDER BY M.Marca, M.NomeModello, V.Targa";
                return connection.Query(query).ToList();
            }
        }
        #endregion VEICOLI
        #region MODELLI

        public static List<dynamic> GetTuttiModelli()
        {
            using (var connection = Database.Connection())
            {
                string query = @"
                SELECT M.ID_Modello, M.NomeModello, M.Marca, COUNT(V.ID_Veicolo) AS NumeroVeicoli
                FROM MODELLI M
                RIGHT JOIN VEICOLI V ON M.ID_Modello = V.FK_Modello
                GROUP BY M.ID_Modello, M.NomeModello, M.Marca
                ORDER BY M.Marca, M.NomeModello";

                return connection.Query(query).ToList();
            }
        }

        #endregion MODELLI
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
                         RIGHT JOIN MODELLI M ON V.FK_Modello = M.ID_Modello
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
                         RIGHT JOIN MODELLI M ON V.FK_Modello = M.ID_Modello
                         WHERE (@modello IS NULL OR M.NomeModello = @modello)
                         GROUP BY M.Marca
                         ORDER BY M.Marca";
                return connection.Query<string>(query, new { modello }).ToList();
            }
        }

        public static List<Veicolo> RicercaVeicoli(string? targa = null, OrderType? annoProduzioneOrder = null, string? annoProduzione = null, OrderType? marcaOrder = null, string? marca = null, OrderType? modelloOrder = null, string? modello = null, OrderType? kmOrder = null, KmFilterType? KmfilterType = null, int? chilometraggio = null, OrderType? statusOrder = null, string? stato = null)
        {
            using (var connection = Database.Connection())
            {
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
                    : "ORDER BY V.Targa ASC";

                string query = $@"SELECT V.ID_Veicolo, V.Targa, M.Marca, M.NomeModello, V.AnnoProduzione, V.Chilometraggio, V.Stato
                                FROM VEICOLI V
                                JOIN MODELLI M ON V.FK_Modello = M.ID_Modello
                                WHERE (@targa IS NULL OR V.Targa LIKE '%' + @targa + '%')
                                AND (@annoProduzione IS NULL OR V.AnnoProduzione = @annoProduzione)
                                AND (@marca IS NULL OR M.Marca LIKE '%' + @marca + '%')
                                AND (@modello IS NULL OR M.NomeModello LIKE '%' + @modello + '%')
                                AND (@chilometraggio IS NULL OR V.Chilometraggio {operatore} @chilometraggio)
                                AND (@stato IS NULL OR V.Stato = @stato)
                                {orderBy}";

                return connection.Query<Veicolo>(query, new { targa, annoProduzione, marca, modello, chilometraggio, stato }).ToList();
            }
        }

        public static List<dynamic> RicercaModelli(OrderType? marcaOrder = null, string? marca = null, OrderType? modelloOrder = null, string? modello = null)
        {
            using (var connection = Database.Connection())
            {

                List<string> orders = new List<string>();

                if (marcaOrder != OrderType.None && marcaOrder != null)
                    orders.Add($"M.Marca {(marcaOrder == OrderType.Ascending ? "ASC" : "DESC")}");

                if (modelloOrder != OrderType.None && modelloOrder != null)
                    orders.Add($"M.NomeModello {(modelloOrder == OrderType.Ascending ? "ASC" : "DESC")}");

                string orderBy = orders.Count > 0
                    ? "ORDER BY " + string.Join(", ", orders)
                    : "ORDER BY M.Marca ASC";

                string query = $@"SELECT  M.Marca, M.NomeModello, COUNT(V.ID_Veicolo) AS NumeroVeicoli
                         FROM MODELLI M
                         LEFT JOIN VEICOLI V ON M.ID_Modello = V.FK_Modello
                         WHERE (@marca IS NULL OR M.Marca LIKE '%' + @marca + '%')
                           AND (@modello IS NULL OR M.NomeModello LIKE '%' + @modello + '%')
                            GROUP BY M.Marca, M.NomeModello
                         {orderBy}";

                return connection.Query(query, new { marca, modello}).ToList();
            }
        }


        #endregion FILTRI
        #endregion FLOTTA

        #region GUIDATORI

        public static List<Guidatore> RicercaGuidatori(string Nome = null, string Cognome = null, string CodiceFiscale = null, DateFilterType? DatefilterType = null, DateTime? ScadenzaPatente = null, string Stato = null)
        {
            using (var connection = Database.Connection())
            {
                string operatore = DatefilterType switch
                {
                    DateFilterType.Cresc => ">",
                    DateFilterType.Descr => "<",
                    DateFilterType.Equal => "=",
                    _ => ">"
                };

                string query = $@"SELECT ID_Guidatore, Nome, Cognome, CodiceFiscale, ScadenzaPatente, Stato 
                        FROM GUIDATORI 
                        WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')
                        AND (@Cognome IS NULL OR Cognome LIKE '%' + @Cognome + '%')
                        AND (@CodiceFiscale IS NULL OR CodiceFiscale LIKE '%' + @CodiceFiscale + '%')
                        AND (@ScadenzaPatente IS NULL OR ScadenzaPatente {operatore} @ScadenzaPatente)
                        AND (@Stato IS NULL OR Stato LIKE '%' + @Stato + '%')
                        ORDER BY Cognome, Nome ASC";

                return connection.Query<Guidatore>(query, new { Nome, Cognome, CodiceFiscale, DatefilterType, ScadenzaPatente, Stato }).ToList();
            }
        }
        public static void AggiornaStatoGuidatore(int id, string nuovoStato)
        {
            using (var connection = Database.Connection())
            {
                string query = "UPDATE GUIDATORI SET Stato = @nuovoStato WHERE ID_Guidatore = @id";
                connection.Execute(query, new { id, nuovoStato });
            }
        }
        public static bool AggiornaInfoGuidatore(Guidatore g)
        {
            using (var connection = Database.Connection())
            {
                string query = @"UPDATE GUIDATORI SET Nome = @Nome, Cognome = @Cognome, CodiceFiscale = @CodiceFiscale, ScadenzaPatente = @ScadenzaPatente WHERE ID_Guidatore = @ID_Guidatore";
                int rowsAffected = connection.Execute(query, new { g.Nome, g.Cognome, g.CodiceFiscale, g.ScadenzaPatente, g.ID_Guidatore });
                return rowsAffected > 0;
            }
        }
        public static List<AssegnazioneTabellaDTO> GetDatiTabellaAssegnazioni(int idGuidatore)
        {
            using (var connection = Database.Connection())
            {
                string query = @"
                SELECT A.ID_Assegnazione, A.DataInizio, A.DataFine, V.Targa, M.Marca, M.NomeModello
                FROM ASSEGNAZIONI A
                JOIN VEICOLI V ON A.FK_Veicolo = V.ID_Veicolo
                JOIN MODELLI M ON V.FK_Modello = M.ID_Modello
                WHERE A.FK_Guidatore = @idGuidatore
                ORDER BY A.DataInizio DESC";

                return connection.Query<AssegnazioneTabellaDTO>(query, new { idGuidatore }).ToList();
            }
        }

        #endregion GUIDATORI

        #region MANUTENZIONI
        public static List<Manutenzione> GetManutenzioniPerVeicolo(int idVeicolo)
        {
            using (var connection = Database.Connection())
            {
                string query = "SELECT ID_Manutenzione, FK_Veicolo, DataIntervento, Costo, Descrizione FROM MANUTENZIONI WHERE FK_Veicolo = @idVeicolo ORDER BY DataIntervento DESC";
                return connection.Query<Manutenzione>(query, new { idVeicolo }).ToList();
            }
        }
        public static bool InserisciManutenzione(Manutenzione m)
        {
            using (var connection = Database.Connection())
            {
                try
                {
                    string query = @"INSERT INTO MANUTENZIONI (FK_Veicolo, DataIntervento, Costo, Descrizione) 
                               VALUES (@FK_Veicolo, @DataIntervento, @Costo, @Descrizione)";
                    connection.Execute(query, m);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante l'inserimento della manutenzione: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
            }
        }
        public static void EliminaManutenzione(int idManutenzione)
        {
            using (var connection = Database.Connection())
            {
                string query = "DELETE FROM MANUTENZIONI WHERE ID_Manutenzione = @idManutenzione";
                connection.Execute(query, new { idManutenzione });
            }
        }
        #endregion MANUTENZIONI

        #region ASSEGNAZIONI
        public static void InserisciAssegnazione(Assegnazione a)
        {
            using (var connection = Database.Connection())
            {
                string query = @"INSERT INTO ASSEGNAZIONI (FK_Veicolo, FK_Guidatore, DataInizio, DataFine) 
                               VALUES (@FK_Veicolo, @FK_Guidatore, @DataInizio, @DataFine)";
                connection.Execute(query, a);
            }
        }
        public static void TerminaAssegnazione(int idAssegnazione, DateTime dataFine)
        {
            using (var connection = Database.Connection())
            {
                string query = "UPDATE ASSEGNAZIONI SET DataFine = @dataFine WHERE ID_Assegnazione = @idAssegnazione";
                connection.Execute(query, new { idAssegnazione, dataFine });
            }
        }
        public static List<dynamic> GetAssegnazioniPerVeicolo(int idVeicolo)
        {
            using (var connection = Database.Connection())
            {
                string query = @"SELECT ID_Assegnazione, G.Nome, G.Cognome, G.ID_Guidatore, DataInizio, DataFine 
                                FROM ASSEGNAZIONI
                                INNER JOIN GUIDATORI G ON ASSEGNAZIONI.FK_Guidatore = G.ID_Guidatore
                                WHERE FK_Veicolo = @idVeicolo 
                                ORDER BY DataInizio DESC";
                return connection.Query<dynamic>(query, new { idVeicolo }).ToList();
            }
        }
        public static List<Assegnazione> GetAssegnazioniByVeicolo(int idVeicolo)
        {
            using (var connection = Database.Connection())
            {
                string query = "SELECT ID_Assegnazione, FK_Veicolo, FK_Guidatore, DataInizio, DataFine FROM ASSEGNAZIONI WHERE FK_Veicolo = @idVeicolo ORDER BY DataInizio DESC";
                return connection.Query<Assegnazione>(query, new { idVeicolo }).ToList();
            }
        }
        #endregion ASSEGNAZIONI

        #region INCIDENTI
        public static List<Incidente> GetIncidentiPerGuidatore(int idGuidatore)
        {
            using (var connection = Database.Connection())
            {
                string query = "SELECT * FROM INCIDENTI WHERE FK_Guidatore = @idGuidatore ORDER BY DataIncidente DESC";
                return connection.Query<Incidente>(query, new { idGuidatore }).ToList();
            }
        }
        public static void InserisciIncidente(Incidente i)
        {
            using (var connection = Database.Connection())
            {
                string query = @"INSERT INTO INCIDENTI (FK_Guidatore, FK_Veicolo, DataIncidente, DescrizioneDanni) 
                               VALUES (@FK_Guidatore, @FK_Veicolo, @DataIncidente, @DescrizioneDanni)";
                connection.Execute(query, i);
            }
        }
        #endregion INCIDENTI
    }
}