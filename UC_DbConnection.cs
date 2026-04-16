using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FleetManager
{
    public partial class UC_DbConnection : UserControl
    {
        public UC_DbConnection()
        {
            InitializeComponent();
            // Valori di default
            cb_cnType.Items.AddRange(new string[] { "LocalDB", "SQL Server" });
            cb_cnType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            // Impostazione Sorgente Dati
            if (cb_cnType.SelectedItem.ToString() == "LocalDB")
                builder.DataSource = @"(localdb)\MSSQLLocalDB";
            else
                builder.DataSource = txb_svAddress.Text;

            // Database
            builder.InitialCatalog = txb_svName.Text;

            // Autenticazione
            if (ck_Auth.Checked)
            {
                builder.IntegratedSecurity = true;
                builder.TrustServerCertificate = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txb_AuthUsername.Text;
                builder.Password = txb_AuthPassword.Text;
                builder.TrustServerCertificate = true;
            }

            // Aggiorna la classe globale
            Database.ConnectionString = builder.ConnectionString;

            // Verifica
            if (TestConnection())
            {
                builder.DataSource = cb_cnType.Text == "LocalDB" ? @"(localdb)\MSSQLLocalDB" : txb_svAddress.Text;
                builder.InitialCatalog = txb_svName.Text;
                builder.IntegratedSecurity = ck_Auth.Checked;
                builder.TrustServerCertificate = true;
            }

            // Salvataggio permanente
            Database.ConnectionString = builder.ConnectionString;

            MessageBox.Show("Configurazione salvata permanentemente!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool TestConnection()
        {
            try
            {
                using (var conn = Database.Connection())
                {
                    conn.Open();
                    MessageBox.Show("Test di connessione riuscita!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Test di connessione fallito. Errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btn_testConnection_Click(object sender, EventArgs e) => TestConnection();

        private void UC_DbConnection_Load(object sender, EventArgs e)
        {
            string currentConn = Database.ConnectionString;
            if (!string.IsNullOrEmpty(currentConn))
            {
                var builder = new SqlConnectionStringBuilder(currentConn);

                ck_Auth.Checked = builder.IntegratedSecurity;
                cb_cnType.SelectedItem = builder.DataSource.Contains("(localdb)") ? "LocalDB" : "SQL Server";
                txb_svAddress.Text = builder.DataSource;
                txb_svName.Text = builder.InitialCatalog;
            }
        }

        private void ck_Auth_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Auth.Checked)
            {
                txb_AuthUsername.Visible = true;
                txb_AuthPassword.Visible = true;
                txb_AuthUsername.Enabled = true;
                txb_AuthPassword.Enabled = true;
            }
            else
            {
                txb_AuthUsername.Visible = false;
                txb_AuthPassword.Visible = false;
                txb_AuthUsername.Enabled = false;
                txb_AuthPassword.Enabled = false;
            }
        }
    }
}
