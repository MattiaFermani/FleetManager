using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace EsempioDBconDapper
{
    internal class Database
    {
        public static string ConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FleetMangement;Integrated Security=True;";

        public static IDbConnection Connection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}