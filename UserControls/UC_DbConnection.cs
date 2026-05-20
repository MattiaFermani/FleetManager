using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using FleetManager.DB;

namespace FleetManager
{
    public partial class UC_DbConnection : UserControl
    {
        string tempConnectionString;

        public UC_DbConnection()
        {
            InitializeComponent();
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            createCnnString();

            if (!await TestConnectionAsync())
                return;

            Database.ConnectionString = tempConnectionString;

            try
            {
                Database.Connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'inizializzazione del database: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Configurazione salvata permanentemente!", "OK",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private async Task<bool> TestConnectionAsync()
        {
            createCnnString();
            try
            {
                using (var conn = new SqlConnection(tempConnectionString))
                {
                    await conn.OpenAsync();
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
            if (cb_cnType.SelectedItem == null)
            {
                MessageBox.Show("Seleziona il tipo di connessione.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cb_cnType.SelectedItem.ToString() != "LocalDB" && string.IsNullOrWhiteSpace(txb_svAddress.Text))
            {
                MessageBox.Show("Inserisci l'indirizzo del server.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txb_svName.Text))
            {
                MessageBox.Show("Inserisci il nome del database.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ck_Auth.Checked)
            {
                if (string.IsNullOrWhiteSpace(txb_AuthUsername.Text))
                {
                    MessageBox.Show("Inserisci lo username per l'autenticazione SQL.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txb_AuthPassword.Text))
                {
                    MessageBox.Show("Inserisci la password per l'autenticazione SQL.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private async void btn_testConnection_Click(object sender, EventArgs e) => await TestConnectionAsync();

        private void UC_DbConnection_Load(object sender, EventArgs e)
        {
            string currentConn = Database.ConnectionString;
            if (!string.IsNullOrEmpty(currentConn))
            {
                var builder = new SqlConnectionStringBuilder(currentConn);

                ck_Auth.Checked = builder.IntegratedSecurity;
                cb_cnType.SelectedItem = builder.DataSource.Contains("(localdb)") ? "LocalDB" : "SQL Server";

                if (cb_cnType.SelectedItem.ToString() == "SQL Server")
                {
                    txb_svAddress.Text = builder.DataSource;
                }

                txb_svName.Text = builder.InitialCatalog;

                if (!builder.IntegratedSecurity)
                {
                    txb_AuthUsername.Text = builder.UserID;
                    txb_AuthPassword.Text = builder.Password;
                }
            }
        }

        private void ck_Auth_CheckedChanged(object sender, EventArgs e)
        {
            // CORRETTO: Se usi Windows Auth (Checked), nascondi o disabilita i campi di testo
            // Se NON lo usi (Unchecked), mostrali perché servono le credenziali SQL
            bool richiedeCredenziali = ck_Auth.Checked;

            txb_AuthUsername.Visible = richiedeCredenziali;
            txb_AuthPassword.Visible = richiedeCredenziali;
            txb_AuthUsername.Enabled = richiedeCredenziali;
            txb_AuthPassword.Enabled = richiedeCredenziali;
        }
    }
}