using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace FleetManager.DB
{
    internal class Database
    {
        public static string ConnectionString
        {
            get => Properties.Settings.Default.DbConnectionString;
            set
            {
                Properties.Settings.Default.DbConnectionString = value;
                Properties.Settings.Default.Save(); // Salva su disco in AppData/Local
            }
        }

        public static IDbConnection Connection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}