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
        string tempConnectionString;
        public UC_DbConnection()
        {
            InitializeComponent();
            // Valori di default
            cb_cnType.Items.AddRange(new string[] { "LocalDB", "SQL Server" });
            cb_cnType.SelectedIndex = 0;
        }

        private void createCnnString()
        {
            if (!ValidaInput())
                return;

            var builder = new SqlConnectionStringBuilder();

            if (cb_cnType.SelectedItem.ToString() == "LocalDB")
                builder.DataSource = @"(localdb)\MSSQLLocalDB";
            else
                builder.DataSource = txb_svAddress.Text.Trim();

            builder.InitialCatalog = txb_svName.Text.Trim();

            if (ck_Auth.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txb_AuthUsername.Text.Trim();
                builder.Password = txb_AuthPassword.Text;
            }

            builder.TrustServerCertificate = true;

            tempConnectionString = builder.ConnectionString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            createCnnString();

            // TEST sui dati inseriti, NON salvati
            if (!TestConnection())
                return;

            // Salva solo se il test passa
            Database.ConnectionString = tempConnectionString;

            MessageBox.Show("Configurazione salvata permanentemente!", "OK",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool TestConnection()
        {
            createCnnString();
            try
            {
                using (var conn = new SqlConnection(tempConnectionString))
                {
                    conn.Open();
                    MessageBox.Show("Test di connessione riuscito!", "Successo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Test di connessione fallito. Errore: {ex.Message}",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidaInput()
        {
            // Tipo connessione
            if (cb_cnType.SelectedItem == null)
            {
                MessageBox.Show("Seleziona il tipo di connessione.");
                return false;
            }

            // Server (solo se non LocalDB)
            if (cb_cnType.SelectedItem.ToString() != "LocalDB" &&
                string.IsNullOrWhiteSpace(txb_svAddress.Text))
            {
                MessageBox.Show("Inserisci l'indirizzo del server.");
                return false;
            }

            // Database
            if (string.IsNullOrWhiteSpace(txb_svName.Text))
            {
                MessageBox.Show("Inserisci il nome del database.");
                return false;
            }

            // Credenziali (se Windows Auth)
            if (ck_Auth.Checked)
            {
                if (string.IsNullOrWhiteSpace(txb_AuthUsername.Text))
                {
                    MessageBox.Show("Inserisci lo username.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txb_AuthPassword.Text))
                {
                    MessageBox.Show("Inserisci la password.");
                    return false;
                }
            }

            return true;
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
