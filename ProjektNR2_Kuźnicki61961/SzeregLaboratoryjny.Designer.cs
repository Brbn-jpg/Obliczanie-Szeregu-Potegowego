namespace ProjektNR2_Kuźnicki61961
{
    partial class SzeregLaboratoryjny
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnObliczWartoscSzeregu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXd = new System.Windows.Forms.TextBox();
            this.txtSumaSzeregu = new System.Windows.Forms.TextBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.txtXg = new System.Windows.Forms.TextBox();
            this.txtEps = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtLicznikWyrazow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnWizualizacjaTabelaryczna = new System.Windows.Forms.Button();
            this.btnWizualizacjaGraficzna = new System.Windows.Forms.Button();
            this.btnResetuj = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvTablicaWartosciSzeregu = new System.Windows.Forms.DataGridView();
            this.WartoscX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WartoscSzeregu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicznikWyrazu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapisTablicyTWSWPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknięcieProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrybutyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaKoloruTłaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaCzcionkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaKoloruCzcionkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrybutyKontrolkiDataGridViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaCzcionkiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaTłaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrybutyKontrolkiChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaTypuWykresuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaKoloruWykresuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaStyluLiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chtWykresSzeregu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablicaWartosciSzeregu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnObliczWartoscSzeregu
            // 
            this.btnObliczWartoscSzeregu.Location = new System.Drawing.Point(995, 332);
            this.btnObliczWartoscSzeregu.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnObliczWartoscSzeregu.Name = "btnObliczWartoscSzeregu";
            this.btnObliczWartoscSzeregu.Size = new System.Drawing.Size(193, 53);
            this.btnObliczWartoscSzeregu.TabIndex = 0;
            this.btnObliczWartoscSzeregu.Text = " Oblicz wartość szeregu";
            this.btnObliczWartoscSzeregu.UseVisualStyleBackColor = true;
            this.btnObliczWartoscSzeregu.Click += new System.EventHandler(this.btnObliczWartoscSzeregu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(356, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Analizator Laboratoryjnego Szeregu Potęgowego";
            // 
            // txtXd
            // 
            this.txtXd.Location = new System.Drawing.Point(351, 315);
            this.txtXd.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtXd.Name = "txtXd";
            this.txtXd.Size = new System.Drawing.Size(180, 29);
            this.txtXd.TabIndex = 2;
            // 
            // txtSumaSzeregu
            // 
            this.txtSumaSzeregu.Location = new System.Drawing.Point(738, 194);
            this.txtSumaSzeregu.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtSumaSzeregu.Name = "txtSumaSzeregu";
            this.txtSumaSzeregu.ReadOnly = true;
            this.txtSumaSzeregu.Size = new System.Drawing.Size(180, 29);
            this.txtSumaSzeregu.TabIndex = 3;
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(351, 440);
            this.txtH.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(180, 29);
            this.txtH.TabIndex = 4;
            // 
            // txtXg
            // 
            this.txtXg.Location = new System.Drawing.Point(351, 380);
            this.txtXg.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtXg.Name = "txtXg";
            this.txtXg.Size = new System.Drawing.Size(180, 29);
            this.txtXg.TabIndex = 5;
            // 
            // txtEps
            // 
            this.txtEps.Location = new System.Drawing.Point(351, 254);
            this.txtEps.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtEps.Name = "txtEps";
            this.txtEps.Size = new System.Drawing.Size(180, 29);
            this.txtEps.TabIndex = 6;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(351, 200);
            this.txtX.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(180, 29);
            this.txtX.TabIndex = 7;
            // 
            // txtLicznikWyrazow
            // 
            this.txtLicznikWyrazow.Location = new System.Drawing.Point(738, 260);
            this.txtLicznikWyrazow.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtLicznikWyrazow.Name = "txtLicznikWyrazow";
            this.txtLicznikWyrazow.ReadOnly = true;
            this.txtLicznikWyrazow.Size = new System.Drawing.Size(180, 29);
            this.txtLicznikWyrazow.TabIndex = 8;
            this.txtLicznikWyrazow.TextChanged += new System.EventHandler(this.txtLicznikWyrazow_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(15, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Wartość zmiennej niezależnej X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(15, 256);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dokładność obliczeń";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(15, 321);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Dolna granica Xd";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(15, 380);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Górna granica Xg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(15, 442);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(324, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Przyrost h zmian wartości zmiennej X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(1050, 200);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Obliczona wartość szeregu";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(930, 262);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(353, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Licznik zsumowanych wartości szeregów";
            // 
            // btnWizualizacjaTabelaryczna
            // 
            this.btnWizualizacjaTabelaryczna.Location = new System.Drawing.Point(995, 395);
            this.btnWizualizacjaTabelaryczna.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnWizualizacjaTabelaryczna.Name = "btnWizualizacjaTabelaryczna";
            this.btnWizualizacjaTabelaryczna.Size = new System.Drawing.Size(193, 74);
            this.btnWizualizacjaTabelaryczna.TabIndex = 16;
            this.btnWizualizacjaTabelaryczna.Text = "Wizualizacja zmian wartości szeregu potęgowego";
            this.btnWizualizacjaTabelaryczna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaTabelaryczna.Click += new System.EventHandler(this.btnWizualizacjaTabelaryczna_Click);
            // 
            // btnWizualizacjaGraficzna
            // 
            this.btnWizualizacjaGraficzna.Location = new System.Drawing.Point(995, 479);
            this.btnWizualizacjaGraficzna.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnWizualizacjaGraficzna.Name = "btnWizualizacjaGraficzna";
            this.btnWizualizacjaGraficzna.Size = new System.Drawing.Size(193, 76);
            this.btnWizualizacjaGraficzna.TabIndex = 17;
            this.btnWizualizacjaGraficzna.Text = "Wizualizacja graficzna zmian wartości";
            this.btnWizualizacjaGraficzna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaGraficzna.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnResetuj
            // 
            this.btnResetuj.Location = new System.Drawing.Point(995, 565);
            this.btnResetuj.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnResetuj.Name = "btnResetuj";
            this.btnResetuj.Size = new System.Drawing.Size(193, 53);
            this.btnResetuj.TabIndex = 18;
            this.btnResetuj.Text = "RESETUJ (ustaw stan początkowy)";
            this.btnResetuj.UseVisualStyleBackColor = true;
            this.btnResetuj.Click += new System.EventHandler(this.btnResetuj_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dgvTablicaWartosciSzeregu
            // 
            this.dgvTablicaWartosciSzeregu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablicaWartosciSzeregu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WartoscX,
            this.WartoscSzeregu,
            this.LicznikWyrazu});
            this.dgvTablicaWartosciSzeregu.Location = new System.Drawing.Point(573, 342);
            this.dgvTablicaWartosciSzeregu.Name = "dgvTablicaWartosciSzeregu";
            this.dgvTablicaWartosciSzeregu.Size = new System.Drawing.Size(345, 276);
            this.dgvTablicaWartosciSzeregu.TabIndex = 19;
            this.dgvTablicaWartosciSzeregu.Visible = false;
            this.dgvTablicaWartosciSzeregu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablicaWartosciSzeregu_CellContentClick);
            // 
            // WartoscX
            // 
            this.WartoscX.HeaderText = "Wartość zmiennej niezależnej X";
            this.WartoscX.Name = "WartoscX";
            // 
            // WartoscSzeregu
            // 
            this.WartoscSzeregu.HeaderText = "Obliczona wartość szeregu";
            this.WartoscSzeregu.Name = "WartoscSzeregu";
            // 
            // LicznikWyrazu
            // 
            this.LicznikWyrazu.HeaderText = "Liczba zsumowanych wyrazów szeregu";
            this.LicznikWyrazu.Name = "LicznikWyrazu";
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.atrybutyToolStripMenuItem,
            this.atrybutyKontrolkiDataGridViewToolStripMenuItem,
            this.atrybutyKontrolkiChartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1467, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zapisTablicyTWSWPlikuToolStripMenuItem,
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem,
            this.restartProgramuToolStripMenuItem,
            this.zamknięcieProgramuToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            this.plikToolStripMenuItem.Click += new System.EventHandler(this.plikToolStripMenuItem_Click);
            // 
            // zapisTablicyTWSWPlikuToolStripMenuItem
            // 
            this.zapisTablicyTWSWPlikuToolStripMenuItem.Name = "zapisTablicyTWSWPlikuToolStripMenuItem";
            this.zapisTablicyTWSWPlikuToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.zapisTablicyTWSWPlikuToolStripMenuItem.Text = "Zapis tablicy TWS w pliku";
            this.zapisTablicyTWSWPlikuToolStripMenuItem.Click += new System.EventHandler(this.zapisTablicyTWSWPlikuToolStripMenuItem_Click);
            // 
            // odczytanieTablicyTWSZPlikuToolStripMenuItem
            // 
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem.Name = "odczytanieTablicyTWSZPlikuToolStripMenuItem";
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem.Text = "Odczytanie tablicy TWS z pliku";
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem.Click += new System.EventHandler(this.odczytanieTablicyTWSZPlikuToolStripMenuItem_Click);
            // 
            // restartProgramuToolStripMenuItem
            // 
            this.restartProgramuToolStripMenuItem.Name = "restartProgramuToolStripMenuItem";
            this.restartProgramuToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.restartProgramuToolStripMenuItem.Text = "Restart programu";
            this.restartProgramuToolStripMenuItem.Click += new System.EventHandler(this.restartProgramuToolStripMenuItem_Click);
            // 
            // zamknięcieProgramuToolStripMenuItem
            // 
            this.zamknięcieProgramuToolStripMenuItem.Name = "zamknięcieProgramuToolStripMenuItem";
            this.zamknięcieProgramuToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.zamknięcieProgramuToolStripMenuItem.Text = "Zamknięcie programu";
            this.zamknięcieProgramuToolStripMenuItem.Click += new System.EventHandler(this.zamknięcieProgramuToolStripMenuItem_Click);
            // 
            // atrybutyToolStripMenuItem
            // 
            this.atrybutyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmianaKoloruTłaToolStripMenuItem,
            this.zmianaCzcionkiToolStripMenuItem,
            this.zmianaKoloruCzcionkiToolStripMenuItem});
            this.atrybutyToolStripMenuItem.Name = "atrybutyToolStripMenuItem";
            this.atrybutyToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.atrybutyToolStripMenuItem.Text = "Atrybuty";
            // 
            // zmianaKoloruTłaToolStripMenuItem
            // 
            this.zmianaKoloruTłaToolStripMenuItem.Name = "zmianaKoloruTłaToolStripMenuItem";
            this.zmianaKoloruTłaToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaKoloruTłaToolStripMenuItem.Text = "Zmiana koloru tła";
            this.zmianaKoloruTłaToolStripMenuItem.Click += new System.EventHandler(this.zmianaKoloruTłaToolStripMenuItem_Click);
            // 
            // zmianaCzcionkiToolStripMenuItem
            // 
            this.zmianaCzcionkiToolStripMenuItem.Name = "zmianaCzcionkiToolStripMenuItem";
            this.zmianaCzcionkiToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaCzcionkiToolStripMenuItem.Text = "Zmiana czcionki";
            this.zmianaCzcionkiToolStripMenuItem.Click += new System.EventHandler(this.zmianaCzcionkiToolStripMenuItem_Click);
            // 
            // zmianaKoloruCzcionkiToolStripMenuItem
            // 
            this.zmianaKoloruCzcionkiToolStripMenuItem.Name = "zmianaKoloruCzcionkiToolStripMenuItem";
            this.zmianaKoloruCzcionkiToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaKoloruCzcionkiToolStripMenuItem.Text = "Zmiana koloru czcionki";
            this.zmianaKoloruCzcionkiToolStripMenuItem.Click += new System.EventHandler(this.zmianaKoloruCzcionkiToolStripMenuItem_Click);
            // 
            // atrybutyKontrolkiDataGridViewToolStripMenuItem
            // 
            this.atrybutyKontrolkiDataGridViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmianaCzcionkiToolStripMenuItem1,
            this.zmianaTłaToolStripMenuItem});
            this.atrybutyKontrolkiDataGridViewToolStripMenuItem.Name = "atrybutyKontrolkiDataGridViewToolStripMenuItem";
            this.atrybutyKontrolkiDataGridViewToolStripMenuItem.Size = new System.Drawing.Size(189, 20);
            this.atrybutyKontrolkiDataGridViewToolStripMenuItem.Text = "Atrybuty kontrolki DataGridView";
            // 
            // zmianaCzcionkiToolStripMenuItem1
            // 
            this.zmianaCzcionkiToolStripMenuItem1.Name = "zmianaCzcionkiToolStripMenuItem1";
            this.zmianaCzcionkiToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.zmianaCzcionkiToolStripMenuItem1.Text = "Zmiana czcionki";
            this.zmianaCzcionkiToolStripMenuItem1.Click += new System.EventHandler(this.zmianaCzcionkiToolStripMenuItem1_Click);
            // 
            // zmianaTłaToolStripMenuItem
            // 
            this.zmianaTłaToolStripMenuItem.Name = "zmianaTłaToolStripMenuItem";
            this.zmianaTłaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.zmianaTłaToolStripMenuItem.Text = "Zmiana tła";
            this.zmianaTłaToolStripMenuItem.Click += new System.EventHandler(this.zmianaTłaToolStripMenuItem_Click);
            // 
            // atrybutyKontrolkiChartToolStripMenuItem
            // 
            this.atrybutyKontrolkiChartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmianaTypuWykresuToolStripMenuItem,
            this.zmianaKoloruWykresuToolStripMenuItem,
            this.zmianaStyluLiniToolStripMenuItem});
            this.atrybutyKontrolkiChartToolStripMenuItem.Name = "atrybutyKontrolkiChartToolStripMenuItem";
            this.atrybutyKontrolkiChartToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.atrybutyKontrolkiChartToolStripMenuItem.Text = "Atrybuty kontrolki Chart";
            // 
            // zmianaTypuWykresuToolStripMenuItem
            // 
            this.zmianaTypuWykresuToolStripMenuItem.Name = "zmianaTypuWykresuToolStripMenuItem";
            this.zmianaTypuWykresuToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaTypuWykresuToolStripMenuItem.Text = "Zmiana typu wykresu";
            this.zmianaTypuWykresuToolStripMenuItem.Click += new System.EventHandler(this.zmianaTypuWykresuToolStripMenuItem_Click);
            // 
            // zmianaKoloruWykresuToolStripMenuItem
            // 
            this.zmianaKoloruWykresuToolStripMenuItem.Name = "zmianaKoloruWykresuToolStripMenuItem";
            this.zmianaKoloruWykresuToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaKoloruWykresuToolStripMenuItem.Text = "Zmiana koloru wykresu";
            this.zmianaKoloruWykresuToolStripMenuItem.Click += new System.EventHandler(this.zmianaKoloruWykresuToolStripMenuItem_Click);
            // 
            // zmianaStyluLiniToolStripMenuItem
            // 
            this.zmianaStyluLiniToolStripMenuItem.Name = "zmianaStyluLiniToolStripMenuItem";
            this.zmianaStyluLiniToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zmianaStyluLiniToolStripMenuItem.Text = "Zmiana stylu lini";
            this.zmianaStyluLiniToolStripMenuItem.Click += new System.EventHandler(this.zmianaStyluLiniToolStripMenuItem_Click);
            // 
            // JKchtWykresSzeregu
            // 
            chartArea3.Name = "ChartArea1";
            this.chtWykresSzeregu.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chtWykresSzeregu.Legends.Add(legend3);
            this.chtWykresSzeregu.Location = new System.Drawing.Point(164, 477);
            this.chtWykresSzeregu.Name = "JKchtWykresSzeregu";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chtWykresSzeregu.Series.Add(series3);
            this.chtWykresSzeregu.Size = new System.Drawing.Size(367, 247);
            this.chtWykresSzeregu.TabIndex = 21;
            this.chtWykresSzeregu.Text = "chart1";
            this.chtWykresSzeregu.Visible = false;
            this.chtWykresSzeregu.Click += new System.EventHandler(this.chtWykresSzeregu_Click);
            // 
            // SzeregLaboratoryjny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 762);
            this.Controls.Add(this.chtWykresSzeregu);
            this.Controls.Add(this.dgvTablicaWartosciSzeregu);
            this.Controls.Add(this.btnResetuj);
            this.Controls.Add(this.btnWizualizacjaGraficzna);
            this.Controls.Add(this.btnWizualizacjaTabelaryczna);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLicznikWyrazow);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtEps);
            this.Controls.Add(this.txtXg);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.txtSumaSzeregu);
            this.Controls.Add(this.txtXd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnObliczWartoscSzeregu);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "SzeregLaboratoryjny";
            this.Text = "Szereg Laboratoryjny";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SzeregLaboratoryjny_FormClosing_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablicaWartosciSzeregu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnObliczWartoscSzeregu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXd;
        private System.Windows.Forms.TextBox txtSumaSzeregu;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtXg;
        private System.Windows.Forms.TextBox txtEps;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtLicznikWyrazow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnWizualizacjaTabelaryczna;
        private System.Windows.Forms.Button btnWizualizacjaGraficzna;
        private System.Windows.Forms.Button btnResetuj;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dgvTablicaWartosciSzeregu;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.DataGridViewTextBoxColumn WartoscX;
        private System.Windows.Forms.DataGridViewTextBoxColumn WartoscSzeregu;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicznikWyrazu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapisTablicyTWSWPlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odczytanieTablicyTWSZPlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartProgramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknięcieProgramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrybutyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaKoloruTłaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaCzcionkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaKoloruCzcionkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrybutyKontrolkiDataGridViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaCzcionkiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zmianaTłaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrybutyKontrolkiChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaTypuWykresuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaKoloruWykresuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaStyluLiniToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtWykresSzeregu;
    }
}