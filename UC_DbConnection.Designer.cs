namespace FleetManager
{
    partial class UC_DbConnection
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            cb_cnType = new ComboBox();
            txb_svAddress = new TextBox();
            txb_svName = new TextBox();
            ck_Auth = new CheckBox();
            txb_AuthUsername = new TextBox();
            txb_AuthPassword = new TextBox();
            btn_testConnection = new Button();
            btn_SaveConfig = new Button();
            SuspendLayout();
            // 
            // cb_cnType
            // 
            cb_cnType.FormattingEnabled = true;
            cb_cnType.Items.AddRange(new object[] { "LocalDB", "ServerRemoto (SQL Server)" });
            cb_cnType.Location = new Point(349, 132);
            cb_cnType.Name = "cb_cnType";
            cb_cnType.Size = new Size(172, 23);
            cb_cnType.TabIndex = 0;
            // 
            // txb_svAddress
            // 
            txb_svAddress.Location = new Point(257, 176);
            txb_svAddress.Name = "txb_svAddress";
            txb_svAddress.Size = new Size(172, 23);
            txb_svAddress.TabIndex = 1;
            // 
            // txb_svName
            // 
            txb_svName.Location = new Point(435, 176);
            txb_svName.Name = "txb_svName";
            txb_svName.Size = new Size(172, 23);
            txb_svName.TabIndex = 1;
            // 
            // ck_Auth
            // 
            ck_Auth.AutoSize = true;
            ck_Auth.Location = new Point(257, 205);
            ck_Auth.Name = "ck_Auth";
            ck_Auth.Size = new Size(157, 19);
            ck_Auth.TabIndex = 2;
            ck_Auth.Text = "Windows Authentication";
            ck_Auth.UseVisualStyleBackColor = true;
            ck_Auth.CheckedChanged += ck_Auth_CheckedChanged;
            // 
            // txb_AuthUsername
            // 
            txb_AuthUsername.Location = new Point(257, 226);
            txb_AuthUsername.Name = "txb_AuthUsername";
            txb_AuthUsername.Size = new Size(172, 23);
            txb_AuthUsername.TabIndex = 1;
            txb_AuthUsername.Visible = false;
            // 
            // txb_AuthPassword
            // 
            txb_AuthPassword.Location = new Point(435, 226);
            txb_AuthPassword.Name = "txb_AuthPassword";
            txb_AuthPassword.Size = new Size(172, 23);
            txb_AuthPassword.TabIndex = 1;
            txb_AuthPassword.Visible = false;
            // 
            // btn_testConnection
            // 
            btn_testConnection.Location = new Point(257, 270);
            btn_testConnection.Name = "btn_testConnection";
            btn_testConnection.Size = new Size(172, 23);
            btn_testConnection.TabIndex = 3;
            btn_testConnection.Text = "Test Connection";
            btn_testConnection.UseVisualStyleBackColor = true;
            btn_testConnection.Click += btn_testConnection_Click;
            // 
            // btn_SaveConfig
            // 
            btn_SaveConfig.Location = new Point(435, 270);
            btn_SaveConfig.Name = "btn_SaveConfig";
            btn_SaveConfig.Size = new Size(172, 23);
            btn_SaveConfig.TabIndex = 3;
            btn_SaveConfig.Text = "Save Configuration";
            btn_SaveConfig.UseVisualStyleBackColor = true;
            btn_SaveConfig.Click += btnSave_Click;
            // 
            // UC_DbConnection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_SaveConfig);
            Controls.Add(btn_testConnection);
            Controls.Add(ck_Auth);
            Controls.Add(txb_AuthPassword);
            Controls.Add(txb_AuthUsername);
            Controls.Add(txb_svName);
            Controls.Add(txb_svAddress);
            Controls.Add(cb_cnType);
            Name = "UC_DbConnection";
            Size = new Size(886, 466);
            Load += UC_DbConnection_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cb_cnType;
        private TextBox txb_svAddress;
        private TextBox txb_svName;
        private CheckBox ck_Auth;
        private TextBox txb_AuthUsername;
        private TextBox txb_AuthPassword;
        private Button btn_testConnection;
        private Button btn_SaveConfig;
    }
}
