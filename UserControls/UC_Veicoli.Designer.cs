namespace FleetManager
{
    partial class UC_Veicoli
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dGw_Veicoli = new DataGridView();
            ID_Veicolo = new DataGridViewTextBoxColumn();
            Targa = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            NomeModello = new DataGridViewTextBoxColumn();
            AnnoProduzione = new DataGridViewTextBoxColumn();
            Chilometraggio = new DataGridViewTextBoxColumn();
            Stato = new DataGridViewComboBoxColumn();
            Veicoli_ContextMenu = new ContextMenuStrip(components);
            Fleet_ContextMenu_EliminaVeicolo = new ToolStripMenuItem();
            txb_FilterTarga = new TextBox();
            cmb_FilterModello = new ComboBox();
            cmb_FilterYearProd = new ComboBox();
            cmb_FilterStato = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            nUd_FilterKm = new NumericUpDown();
            label6 = new Label();
            btn_FilterUnderOver = new Button();
            label1 = new Label();
            cmb_FilterMarca = new ComboBox();
            panel1 = new Panel();
            btn_AddVeicolo = new Button();
            btn_addModello = new Button();
            nUd_AddAnnoProd = new NumericUpDown();
            cmb_AddModello = new ComboBox();
            cmb_NewMarca = new ComboBox();
            cmb_AddMarca = new ComboBox();
            txb_AddTarga = new TextBox();
            txt_NewModello = new TextBox();
            label13 = new Label();
            label7 = new Label();
            label8 = new Label();
            label14 = new Label();
            label9 = new Label();
            label15 = new Label();
            label10 = new Label();
            nUd_AddChilometraggio = new NumericUpDown();
            label11 = new Label();
            label12 = new Label();
            btn_FilterMarcaOrder = new Button();
            btn_FilterModelloOrder = new Button();
            btn_FilterAnnoProduzioneOrder = new Button();
            btn_FilterStatoOrder = new Button();
            btn_FilterChilometraggioOrder = new Button();
            btn_FilterInfo = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dGw_Modelli = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Modelli_Modello = new DataGridViewTextBoxColumn();
            Modelli_Marca = new DataGridViewTextBoxColumn();
            Vehicles_Number = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dGw_Veicoli).BeginInit();
            Veicoli_ContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nUd_FilterKm).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nUd_AddAnnoProd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUd_AddChilometraggio).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGw_Modelli).BeginInit();
            SuspendLayout();
            // 
            // dGw_Veicoli
            // 
            dGw_Veicoli.AllowUserToAddRows = false;
            dGw_Veicoli.AllowUserToDeleteRows = false;
            dGw_Veicoli.AllowUserToResizeColumns = false;
            dGw_Veicoli.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(224, 224, 224);
            dGw_Veicoli.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dGw_Veicoli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGw_Veicoli.BackgroundColor = SystemColors.Control;
            dGw_Veicoli.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dGw_Veicoli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Veicoli.Columns.AddRange(new DataGridViewColumn[] { ID_Veicolo, Targa, Marca, NomeModello, AnnoProduzione, Chilometraggio, Stato });
            dGw_Veicoli.EditMode = DataGridViewEditMode.EditOnEnter;
            dGw_Veicoli.Location = new Point(3, 93);
            dGw_Veicoli.MultiSelect = false;
            dGw_Veicoli.Name = "dGw_Veicoli";
            dGw_Veicoli.RowHeadersVisible = false;
            dGw_Veicoli.ScrollBars = ScrollBars.Vertical;
            dGw_Veicoli.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGw_Veicoli.Size = new Size(670, 565);
            dGw_Veicoli.TabIndex = 0;
            dGw_Veicoli.CellClick += dGw_Veicoli_CellClick;
            dGw_Veicoli.CellMouseDown += dGw_Veicoli_CellMouseDown;
            dGw_Veicoli.CellValueChanged += dGw_Veicoli_CellValueChanged;
            // 
            // ID_Veicolo
            // 
            ID_Veicolo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ID_Veicolo.DataPropertyName = "ID_Veicolo";
            ID_Veicolo.Frozen = true;
            ID_Veicolo.HeaderText = "ID";
            ID_Veicolo.Name = "ID_Veicolo";
            ID_Veicolo.ReadOnly = true;
            ID_Veicolo.Visible = false;
            // 
            // Targa
            // 
            Targa.DataPropertyName = "Targa";
            Targa.HeaderText = "Targa";
            Targa.Name = "Targa";
            Targa.ReadOnly = true;
            // 
            // Marca
            // 
            Marca.DataPropertyName = "Marca";
            Marca.HeaderText = "Marca";
            Marca.Name = "Marca";
            Marca.ReadOnly = true;
            // 
            // NomeModello
            // 
            NomeModello.DataPropertyName = "NomeModello";
            NomeModello.HeaderText = "NomeModello";
            NomeModello.Name = "NomeModello";
            NomeModello.ReadOnly = true;
            // 
            // AnnoProduzione
            // 
            AnnoProduzione.DataPropertyName = "AnnoProduzione";
            AnnoProduzione.HeaderText = "Anno Produzione";
            AnnoProduzione.Name = "AnnoProduzione";
            AnnoProduzione.ReadOnly = true;
            // 
            // Chilometraggio
            // 
            Chilometraggio.DataPropertyName = "Chilometraggio";
            Chilometraggio.HeaderText = "Chilometraggio";
            Chilometraggio.Name = "Chilometraggio";
            // 
            // Stato
            // 
            Stato.DataPropertyName = "Stato";
            Stato.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            Stato.FlatStyle = FlatStyle.Popup;
            Stato.HeaderText = "Stato";
            Stato.Items.AddRange(new object[] { "Disponibile", "Non Disponibile", "In Uso", "In Manutenzione" });
            Stato.MaxDropDownItems = 4;
            Stato.Name = "Stato";
            Stato.ToolTipText = "Gestisci lo stato del veicolo";
            // 
            // Veicoli_ContextMenu
            // 
            Veicoli_ContextMenu.Items.AddRange(new ToolStripItem[] { Fleet_ContextMenu_EliminaVeicolo });
            Veicoli_ContextMenu.Name = "Veicoli_ContextMenu";
            Veicoli_ContextMenu.Size = new Size(114, 26);
            // 
            // Fleet_ContextMenu_EliminaVeicolo
            // 
            Fleet_ContextMenu_EliminaVeicolo.Name = "Fleet_ContextMenu_EliminaVeicolo";
            Fleet_ContextMenu_EliminaVeicolo.Size = new Size(113, 22);
            Fleet_ContextMenu_EliminaVeicolo.Text = "Elimina";
            Fleet_ContextMenu_EliminaVeicolo.Click += Fleet_ContextMenu_EliminaVeicolo_Click;
            // 
            // txb_FilterTarga
            // 
            txb_FilterTarga.Location = new Point(3, 21);
            txb_FilterTarga.Name = "txb_FilterTarga";
            txb_FilterTarga.Size = new Size(137, 23);
            txb_FilterTarga.TabIndex = 1;
            txb_FilterTarga.TextChanged += txb_FilterTarga_TextChanged;
            // 
            // cmb_FilterModello
            // 
            cmb_FilterModello.FormattingEnabled = true;
            cmb_FilterModello.Location = new Point(188, 64);
            cmb_FilterModello.Name = "cmb_FilterModello";
            cmb_FilterModello.Size = new Size(135, 23);
            cmb_FilterModello.TabIndex = 2;
            cmb_FilterModello.SelectedIndexChanged += cmb_FilterModello_SelectedIndexChanged;
            // 
            // cmb_FilterYearProd
            // 
            cmb_FilterYearProd.FormattingEnabled = true;
            cmb_FilterYearProd.Location = new Point(188, 20);
            cmb_FilterYearProd.Name = "cmb_FilterYearProd";
            cmb_FilterYearProd.Size = new Size(132, 23);
            cmb_FilterYearProd.TabIndex = 2;
            cmb_FilterYearProd.SelectedIndexChanged += cmb_FilterYearProd_SelectedIndexChanged;
            // 
            // cmb_FilterStato
            // 
            cmb_FilterStato.FormattingEnabled = true;
            cmb_FilterStato.Location = new Point(370, 64);
            cmb_FilterStato.Name = "cmb_FilterStato";
            cmb_FilterStato.Size = new Size(143, 23);
            cmb_FilterStato.TabIndex = 2;
            cmb_FilterStato.SelectedIndexChanged += cmb_FilterStato_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "Targa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(188, 2);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 4;
            label3.Text = "Anno di Produzione";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(188, 46);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 4;
            label4.Text = "Modello";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(370, 48);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 4;
            label5.Text = "Stato";
            // 
            // nUd_FilterKm
            // 
            nUd_FilterKm.Location = new Point(410, 20);
            nUd_FilterKm.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nUd_FilterKm.Name = "nUd_FilterKm";
            nUd_FilterKm.Size = new Size(103, 23);
            nUd_FilterKm.TabIndex = 5;
            nUd_FilterKm.ThousandsSeparator = true;
            nUd_FilterKm.ValueChanged += nUd_FiltroKm_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(369, 3);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 4;
            label6.Text = "Chilometraggio";
            // 
            // btn_FilterUnderOver
            // 
            btn_FilterUnderOver.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_FilterUnderOver.Location = new Point(369, 20);
            btn_FilterUnderOver.Name = "btn_FilterUnderOver";
            btn_FilterUnderOver.Size = new Size(35, 23);
            btn_FilterUnderOver.TabIndex = 6;
            btn_FilterUnderOver.Text = ">";
            btn_FilterUnderOver.UseVisualStyleBackColor = true;
            btn_FilterUnderOver.MouseDown += btn_FilterUnderOver_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 46);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 4;
            label1.Text = "Marca";
            // 
            // cmb_FilterMarca
            // 
            cmb_FilterMarca.FormattingEnabled = true;
            cmb_FilterMarca.Location = new Point(3, 64);
            cmb_FilterMarca.Name = "cmb_FilterMarca";
            cmb_FilterMarca.Size = new Size(139, 23);
            cmb_FilterMarca.TabIndex = 2;
            cmb_FilterMarca.SelectedIndexChanged += cmb_FilterMarca_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_AddVeicolo);
            panel1.Controls.Add(btn_addModello);
            panel1.Controls.Add(nUd_AddAnnoProd);
            panel1.Controls.Add(cmb_AddModello);
            panel1.Controls.Add(cmb_NewMarca);
            panel1.Controls.Add(cmb_AddMarca);
            panel1.Controls.Add(txb_AddTarga);
            panel1.Controls.Add(txt_NewModello);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(nUd_AddChilometraggio);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label12);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(669, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(208, 685);
            panel1.TabIndex = 7;
            // 
            // btn_AddVeicolo
            // 
            btn_AddVeicolo.Location = new Point(18, 280);
            btn_AddVeicolo.Name = "btn_AddVeicolo";
            btn_AddVeicolo.Size = new Size(172, 23);
            btn_AddVeicolo.TabIndex = 7;
            btn_AddVeicolo.Text = "Aggiungi Veicolo";
            btn_AddVeicolo.UseVisualStyleBackColor = true;
            btn_AddVeicolo.Click += btn_AddVeicolo_Click;
            // 
            // btn_addModello
            // 
            btn_addModello.Location = new Point(18, 497);
            btn_addModello.Name = "btn_addModello";
            btn_addModello.Size = new Size(172, 23);
            btn_addModello.TabIndex = 7;
            btn_addModello.Text = "Aggiungi Modello";
            btn_addModello.UseVisualStyleBackColor = true;
            btn_addModello.Click += btn_addModello_Click;
            // 
            // nUd_AddAnnoProd
            // 
            nUd_AddAnnoProd.Location = new Point(18, 207);
            nUd_AddAnnoProd.Name = "nUd_AddAnnoProd";
            nUd_AddAnnoProd.Size = new Size(172, 23);
            nUd_AddAnnoProd.TabIndex = 6;
            // 
            // cmb_AddModello
            // 
            cmb_AddModello.FormattingEnabled = true;
            cmb_AddModello.Location = new Point(18, 162);
            cmb_AddModello.Name = "cmb_AddModello";
            cmb_AddModello.Size = new Size(172, 23);
            cmb_AddModello.TabIndex = 5;
            // 
            // cmb_NewMarca
            // 
            cmb_NewMarca.FormattingEnabled = true;
            cmb_NewMarca.Location = new Point(18, 424);
            cmb_NewMarca.Name = "cmb_NewMarca";
            cmb_NewMarca.Size = new Size(172, 23);
            cmb_NewMarca.TabIndex = 5;
            // 
            // cmb_AddMarca
            // 
            cmb_AddMarca.FormattingEnabled = true;
            cmb_AddMarca.Location = new Point(18, 118);
            cmb_AddMarca.Name = "cmb_AddMarca";
            cmb_AddMarca.Size = new Size(172, 23);
            cmb_AddMarca.TabIndex = 5;
            cmb_AddMarca.SelectedIndexChanged += cmb_AddMarca_SelectedIndexChanged;
            // 
            // txb_AddTarga
            // 
            txb_AddTarga.Location = new Point(18, 73);
            txb_AddTarga.Name = "txb_AddTarga";
            txb_AddTarga.Size = new Size(172, 23);
            txb_AddTarga.TabIndex = 1;
            // 
            // txt_NewModello
            // 
            txt_NewModello.Location = new Point(18, 468);
            txt_NewModello.Name = "txt_NewModello";
            txt_NewModello.Size = new Size(172, 23);
            txt_NewModello.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Black", 14F);
            label13.Location = new Point(25, 351);
            label13.Name = "label13";
            label13.Size = new Size(157, 50);
            label13.TabIndex = 0;
            label13.Text = "Aggiungi \r\nMarca/Modello";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 14F);
            label7.Location = new Point(18, 9);
            label7.Name = "label7";
            label7.Size = new Size(172, 25);
            label7.TabIndex = 0;
            label7.Text = "Aggiungi Veicolo";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 55);
            label8.Name = "label8";
            label8.Size = new Size(36, 15);
            label8.TabIndex = 4;
            label8.Text = "Targa";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(18, 406);
            label14.Name = "label14";
            label14.Size = new Size(40, 15);
            label14.TabIndex = 4;
            label14.Text = "Marca";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 100);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 4;
            label9.Text = "Marca";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(18, 450);
            label15.Name = "label15";
            label15.Size = new Size(51, 15);
            label15.TabIndex = 4;
            label15.Text = "Modello";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 144);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 4;
            label10.Text = "Modello";
            // 
            // nUd_AddChilometraggio
            // 
            nUd_AddChilometraggio.Location = new Point(18, 251);
            nUd_AddChilometraggio.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nUd_AddChilometraggio.Name = "nUd_AddChilometraggio";
            nUd_AddChilometraggio.Size = new Size(172, 23);
            nUd_AddChilometraggio.TabIndex = 5;
            nUd_AddChilometraggio.ThousandsSeparator = true;
            nUd_AddChilometraggio.ValueChanged += nUd_FiltroKm_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(18, 189);
            label11.Name = "label11";
            label11.Size = new Size(112, 15);
            label11.TabIndex = 4;
            label11.Text = "Anno di Produzione";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(18, 233);
            label12.Name = "label12";
            label12.Size = new Size(90, 15);
            label12.TabIndex = 4;
            label12.Text = "Chilometraggio";
            // 
            // btn_FilterMarcaOrder
            // 
            btn_FilterMarcaOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_FilterMarcaOrder.Location = new Point(141, 64);
            btn_FilterMarcaOrder.Name = "btn_FilterMarcaOrder";
            btn_FilterMarcaOrder.Size = new Size(35, 23);
            btn_FilterMarcaOrder.TabIndex = 6;
            btn_FilterMarcaOrder.Text = "↹";
            btn_FilterMarcaOrder.UseVisualStyleBackColor = true;
            btn_FilterMarcaOrder.MouseDown += btn_FilterMarcaOrder_MouseDown;
            // 
            // btn_FilterModelloOrder
            // 
            btn_FilterModelloOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_FilterModelloOrder.Location = new Point(320, 64);
            btn_FilterModelloOrder.Name = "btn_FilterModelloOrder";
            btn_FilterModelloOrder.Size = new Size(35, 23);
            btn_FilterModelloOrder.TabIndex = 6;
            btn_FilterModelloOrder.Text = "↹";
            btn_FilterModelloOrder.UseVisualStyleBackColor = true;
            btn_FilterModelloOrder.MouseDown += btn_FilterModelloOrder_MouseDown;
            // 
            // btn_FilterAnnoProduzioneOrder
            // 
            btn_FilterAnnoProduzioneOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_FilterAnnoProduzioneOrder.Location = new Point(320, 20);
            btn_FilterAnnoProduzioneOrder.Name = "btn_FilterAnnoProduzioneOrder";
            btn_FilterAnnoProduzioneOrder.Size = new Size(35, 24);
            btn_FilterAnnoProduzioneOrder.TabIndex = 6;
            btn_FilterAnnoProduzioneOrder.Text = "↹";
            btn_FilterAnnoProduzioneOrder.UseVisualStyleBackColor = true;
            btn_FilterAnnoProduzioneOrder.MouseDown += btn_FilterAnnoProduzioneOrder_MouseDown;
            // 
            // btn_FilterStatoOrder
            // 
            btn_FilterStatoOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_FilterStatoOrder.Location = new Point(512, 64);
            btn_FilterStatoOrder.Name = "btn_FilterStatoOrder";
            btn_FilterStatoOrder.Size = new Size(35, 23);
            btn_FilterStatoOrder.TabIndex = 6;
            btn_FilterStatoOrder.Text = "↹";
            btn_FilterStatoOrder.UseVisualStyleBackColor = true;
            btn_FilterStatoOrder.MouseDown += btn_FilterStatoOrder_MouseDown;
            // 
            // btn_FilterChilometraggioOrder
            // 
            btn_FilterChilometraggioOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_FilterChilometraggioOrder.Location = new Point(512, 20);
            btn_FilterChilometraggioOrder.Name = "btn_FilterChilometraggioOrder";
            btn_FilterChilometraggioOrder.Size = new Size(35, 24);
            btn_FilterChilometraggioOrder.TabIndex = 6;
            btn_FilterChilometraggioOrder.Text = "↹";
            btn_FilterChilometraggioOrder.UseVisualStyleBackColor = true;
            btn_FilterChilometraggioOrder.MouseDown += btn_FilterChilometraggioOrder_MouseDown;
            // 
            // btn_FilterInfo
            // 
            btn_FilterInfo.Location = new Point(569, 36);
            btn_FilterInfo.Name = "btn_FilterInfo";
            btn_FilterInfo.Size = new Size(75, 39);
            btn_FilterInfo.TabIndex = 8;
            btn_FilterInfo.Text = "How to Filter?";
            btn_FilterInfo.UseVisualStyleBackColor = true;
            btn_FilterInfo.Click += btn_FilterInfo_Click;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(669, 685);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Tan;
            tabPage1.BackgroundImageLayout = ImageLayout.None;
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(dGw_Veicoli);
            tabPage1.Controls.Add(btn_FilterInfo);
            tabPage1.Controls.Add(txb_FilterTarga);
            tabPage1.Controls.Add(cmb_FilterModello);
            tabPage1.Controls.Add(btn_FilterChilometraggioOrder);
            tabPage1.Controls.Add(cmb_FilterMarca);
            tabPage1.Controls.Add(btn_FilterAnnoProduzioneOrder);
            tabPage1.Controls.Add(cmb_FilterStato);
            tabPage1.Controls.Add(btn_FilterStatoOrder);
            tabPage1.Controls.Add(cmb_FilterYearProd);
            tabPage1.Controls.Add(btn_FilterModelloOrder);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(btn_FilterMarcaOrder);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(btn_FilterUnderOver);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(nUd_FilterKm);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label6);
            tabPage1.Location = new Point(4, 27);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(661, 654);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Veicoli";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Tan;
            tabPage2.Controls.Add(dGw_Modelli);
            tabPage2.Location = new Point(4, 27);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(661, 654);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // dGw_Modelli
            // 
            dGw_Modelli.AllowUserToAddRows = false;
            dGw_Modelli.AllowUserToDeleteRows = false;
            dGw_Modelli.AllowUserToResizeColumns = false;
            dGw_Modelli.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(224, 224, 224);
            dGw_Modelli.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dGw_Modelli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGw_Modelli.BackgroundColor = SystemColors.Control;
            dGw_Modelli.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dGw_Modelli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGw_Modelli.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, Modelli_Modello, Modelli_Marca, Vehicles_Number });
            dGw_Modelli.EditMode = DataGridViewEditMode.EditOnEnter;
            dGw_Modelli.Location = new Point(-1, 3);
            dGw_Modelli.MultiSelect = false;
            dGw_Modelli.Name = "dGw_Modelli";
            dGw_Modelli.ReadOnly = true;
            dGw_Modelli.RowHeadersVisible = false;
            dGw_Modelli.ScrollBars = ScrollBars.Vertical;
            dGw_Modelli.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGw_Modelli.Size = new Size(666, 655);
            dGw_Modelli.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewTextBoxColumn1.DataPropertyName = "ID_Modello";
            dataGridViewTextBoxColumn1.Frozen = true;
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Modelli_Modello
            // 
            Modelli_Modello.DataPropertyName = "NomeModello";
            Modelli_Modello.HeaderText = "Modello";
            Modelli_Modello.Name = "Modelli_Modello";
            Modelli_Modello.ReadOnly = true;
            // 
            // Modelli_Marca
            // 
            Modelli_Marca.DataPropertyName = "Marca";
            Modelli_Marca.HeaderText = "Marca";
            Modelli_Marca.Name = "Modelli_Marca";
            Modelli_Marca.ReadOnly = true;
            // 
            // Vehicles_Number
            // 
            Vehicles_Number.DataPropertyName = "NumeroVeicoli";
            Vehicles_Number.HeaderText = "Numero Beicoli";
            Vehicles_Number.Name = "Vehicles_Number";
            Vehicles_Number.ReadOnly = true;
            // 
            // UC_Veicoli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "UC_Veicoli";
            Size = new Size(877, 685);
            Load += UC_Veicoli_Load;
            ((System.ComponentModel.ISupportInitialize)dGw_Veicoli).EndInit();
            Veicoli_ContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nUd_FilterKm).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nUd_AddAnnoProd).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUd_AddChilometraggio).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGw_Modelli).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGw_Veicoli;
        private TextBox txb_FilterTarga;
        private ComboBox cmb_FilterModello;
        private ComboBox cmb_FilterYearProd;
        private ComboBox cmb_FilterStato;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown nUd_FilterKm;
        private Label label6;
        private Button btn_FilterUnderOver;
        private Label label1;
        private ComboBox cmb_FilterMarca;
        private Panel panel1;
        private Button btn_FilterMarcaOrder;
        private Button btn_FilterModelloOrder;
        private Button btn_FilterAnnoProduzioneOrder;
        private Button btn_FilterStatoOrder;
        private Button btn_FilterChilometraggioOrder;
        private Button btn_FilterInfo;
        private NumericUpDown nUd_AddAnnoProd;
        private ComboBox cmb_AddModello;
        private ComboBox cmb_AddMarca;
        private TextBox txt_NewModello;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button btn_addModello;
        private ComboBox cmb_NewMarca;
        private Label label13;
        private NumericUpDown nUd_AddChilometraggio;
        private Label label14;
        private TextBox txb_AddTarga;
        private Label label15;
        private Button btn_AddVeicolo;
        private ContextMenuStrip Veicoli_ContextMenu;
        private ToolStripMenuItem Fleet_ContextMenu_EliminaVeicolo;
        private DataGridViewTextBoxColumn ID_Veicolo;
        private DataGridViewTextBoxColumn Targa;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn NomeModello;
        private DataGridViewTextBoxColumn AnnoProduzione;
        private DataGridViewTextBoxColumn Chilometraggio;
        private DataGridViewComboBoxColumn Stato;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dGw_Modelli;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Modelli_Modello;
        private DataGridViewTextBoxColumn Modelli_Marca;
        private DataGridViewTextBoxColumn Vehicles_Number;
    }
}
