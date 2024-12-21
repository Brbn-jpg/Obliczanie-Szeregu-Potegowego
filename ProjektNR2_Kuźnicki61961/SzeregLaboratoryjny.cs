using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjektNR2_Kuźnicki61961
{
    public partial class SzeregLaboratoryjny : Form
    {
        //deklaracja stalych okreslajacych granice przedzialu zbierznosci "mojego" szeregu
        const float DgPrzedzialuX = float.MinValue;
        const float GgPrzedzialuX = float.MaxValue;

        //deklaracja zmiennej referencyjnej tablicy dwuwymiarowej
        float[,] TWS;
        public SzeregLaboratoryjny()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //WIZUALIZACJA GRAFICZNA
        {
            errorProvider1.Dispose();
            float Xd, Xg, h, Eps;
            if (!PobranieDanych_Xd_Xg_h_Eps(out Xd, out Xg, out h, out Eps))
                return;
            if (TWS is null)
                TablicowanieWartosciSzeregu(Xd, Xg, h, Eps, out TWS);
            WpisanieWynikowDoKontrolkiChart(TWS, chtWykresSzeregu);
                dgvTablicaWartosciSzeregu.Visible = false;
            chtWykresSzeregu.Visible = true;
            btnWizualizacjaGraficzna.Enabled = false;

        }

        private void btnObliczWartoscSzeregu_Click(object sender, EventArgs e)
        {
            //"zgaszenie" kontrolki errorProvider 
            errorProvider1.Dispose();
            //pobranie dancych wejsciowych z formularza
            // deklaracja zmiennych dla przechowania pobranych danych wejsciowych 
            float X, Eps;
            if (!PobranieDanych_X_Eps(out X, out Eps))
            {//był bład, to go syganlizujemy zapaloeniem kontrolki error provider
                errorProvider1.SetError(txtX, "ERROR: w zapisie wartosci zmiennej X wystapil niedozwolony znak");
                //przerwanie pobierania kolejnych danych
                return;

            }
            //oblicznie wartosci szeregu
            //deklaracja zmiennycb dla przehcowania wynikow obliczen
            float suma;
            ushort licznikZsumowanychWyrazow;
            //wywowlamie metody oblicznia sumy szeregu
            suma = ObliczWartoscSzeregu(X, Eps, out licznikZsumowanychWyrazow);
            //wpisanie wynikow obliczen od odpowiednich kontrolek na formularzu
            txtSumaSzeregu.Text = suma.ToString();
            txtLicznikWyrazow.Text = licznikZsumowanychWyrazow.ToString();
        }

        private void btnWizualizacjaTabelaryczna_Click(object sender, EventArgs e)
        {
            //dekomponujemy obsluge tego zdazenia Click na trzy dzialania:
            //1. pobranie danych wejsciowych
            //2. stablicowanie szeregu
            //3. wypisanie wynikow tablicowania wartosci szeregu do kontrolki DataGridView 
            float Xd, Xg, h, Eps;
            if (!PobranieDanych_Xd_Xg_h_Eps(out Xd, out Xg, out h, out Eps))
            {
                return;
            }

            if (TWS is null) //nie piszemy tak: TWS == null
            {
                TablicowanieWartosciSzeregu(Xd, Xg, h, Eps, out TWS);
            }

            WpisanieWynikuDoKontrolkiDataGridView(TWS, dgvTablicaWartosciSzeregu);

            dgvTablicaWartosciSzeregu.Visible = true;
            //ustawienie stanu braku aktywnosci dla obslugiwanego przycisku polecen
            btnWizualizacjaTabelaryczna.Enabled = true;
        }

        private void btnResetuj_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #region Deklaracja metod pomocniczych

        bool PobranieDanych_X_Eps(out float x, out float eps)
        {
            //"techniczne" ustawienie watrosci domyslnej dla parametru wyjsciowego
            x = eps = 0.0f;
            //pobranie wrtosci zmiennej niezlaeznej x
            if (!float.TryParse(txtX.Text, out x))
            {
                //byl blad to go sygnalizujemy zapaleniem kontrolki errrorProvider
                errorProvider1.SetError(txtX, "ERROR: w zapisie wartosci zmiennej niezaleznej x wystapil niedozwolony znak");
                //przerwanie dalszego pobierania danych wejsciowych 
                return false;
            }
            //sprawdzenie czy wczytana wartosc zmiennej x nalezdy do przedzialu zbierznosci szeregu

            //ustawnienie stanu braku aktywnosci dla kontrolki textBox1
            txtX.Enabled = false;
            //pobranie dokladnosci obliczen Eps
            if (!float.TryParse(txtEps.Text, out eps))
            {
                //byl blad to go sygnalizujemy 
                errorProvider1.SetError(txtEps, "ERROR: w zapisie dokladnosci obliczen Eps wystapil niedozwolony znak");
                return false;
            }
            //sprawdzenie warunlku wyjsciowego dla eps
            if ((eps <= 0f) || (eps >= 1f))
            {
                errorProvider1.SetError(txtEps, "ERROR: podana dokladnosc nie spelnia warunku wyjsciowego: 0 < Eps < 1");
                return false;
            }
            //ustawienie stanu braku aktywnosci dla kontorlki textBox2
            txtEps.Enabled = false;


            //"techniczne" ustawienie watrosci wynikowej
            return true;

        }

        private float ObliczWartoscSzeregu(float x, float eps, out ushort n)
        {
            //"techniczne" ustawienie watrosci domyslnej dla parametru wyjsciowego
            n = 0;
            //ustalenie warunkow brzegowych
            float s = 0f;
            float w = 1f;
            //iteracyjne oblicznie sumy szeregu
            do
            {
                s = s + w;
                n++;
                w = w * (-1) * x / n;
            } while (Math.Abs(w) > eps);


            //wzrot wartosci wynikowej
            return s;
        }

        bool PobranieDanych_Xd_Xg_h_Eps(out float Xd, out float Xg, out float h, out float Eps)
        {
            //przypisanie domyslnych wartosci dla parametrow wyjsciowych
            Xd = Xg = h = Eps = 0f;
            //pobranie Xd
            if (!float.TryParse(txtXd.Text, out Xd))
            {
                //sygnalizacja bledu - zapalenie kontrolki errorProvider
                errorProvider1.SetError(txtXd, "Error: w zapisie Xd wystapil niedozwolony znak");
                //przerwanie pobierania dnych z formularza
                return false;


            }
            //sprawdzenie czy Xd nalezy do przedzialu zbieznosci "mojego" szeregu

            if ((Xd < DgPrzedzialuX) || (Xd > GgPrzedzialuX))
            {
                //sygnalizacja bledu -zapalenie kontrolki errorProvider
                errorProvider1.SetError(txtXd, "Error: podanie Xd mie miesci sie w przedziale zbieznosci 'mojego' szeregu");
                //przerwanie pobierania dnych z formularza
                return false;
            }
            //pobranie Xg
            if (!float.TryParse(txtXg.Text, out Xg))
            {
                //sygnalizacja bledu - zapalenie kontrolki errorProvider
                errorProvider1.SetError(txtXg, "Error: w zapisie Xg wystapil niedozwolony znak");
                //przerwanie pobierania dnych z formularza
                return false;
            }

            //sprawdzenie czy Xg nalzey do przedzialu zbieznosci "mojego" szeregu
            if ((Xg < DgPrzedzialuX) || (Xg > GgPrzedzialuX))
            {
                //sygnalizacja bledu -zapalenie kontrolki errorProvider
                errorProvider1.SetError(txtXg, "Error: podanie Xd mie miesci sie w przedziale zbieznosci 'mojego' szeregu");
                //przerwanie pobierania dnych z formularza
                return false;
            }
            //sprawdzenie poprawnej kojelnosci zapisu granic przedzialu: [Xd, Xg]
            if (Xd > Xg)
            {
                //sygnalizacja bledu -zapalenie kontrolki errorProvider
                errorProvider1.SetError(txtXg, "Error: podanie granice przedzialu [Xd, Xg] zostaly podane w niepoprawnej kolejnosci");
                //przerwanie pobierania dnych z formularza
                return false;
            }

            // ustawienie stanu braku aktrywnosci dla kontrolek txtXd oraz txtXg
            txtXd.Enabled = false;
            txtXg.Enabled = false;

            //pobranie przyrostu h w zamian wartosci zmiennej X
            if (!float.TryParse(txtH.Text, out h))
            {
                //sygnalizacja bledu 
                errorProvider1.SetError(txtH, "Error: w zapisie przyrostu h wystapil niedozwolony znak");
                //przerwanie pobierania danych z formularza
                return false;
            }
            //sprawdzenie warunku wyjsciowego dla h
            if ((h <= 0f) || (h >= (Xg - Xd)))
            {
                //sygnalizacja bledu 
                errorProvider1.SetError(txtH, "Error: podana wartosc przyrostu h nie spelnia podanego warunku wyjsciowego: (h > 0) && (h< (Xd - Xg))");
                //przerwanie pobierania danych z formularza
                return false;
            }
            //pobranie dokladnosci obliczen Eps
            if (!float.TryParse(txtEps.Text, out Eps))
            {
                //sygnalizacja bledu 
                errorProvider1.SetError(txtEps, "Error: w zapisie dokladnosci obliczen Eps wystapil niedozwolony znak");
                //przerwanie pobierania danych z formularza
                return false;
            }
            //sprawdzenie warunku wejsciowego 
            if ((Eps <= 0f) || (Eps >= 1f))
            {
                //sygnalizacja bledu 
                errorProvider1.SetError(txtEps, "Error: podana dokladnosc obliczen Eps nie spelnia tzw warunku wejsciowego: (Eps <= 0f) || (Eps >= 1f)");
                //przerwanie pobierania danych z formularza
                return false;
            }

            //zwrotne przekazanie "informacji" ze nie bylo zadnego bledu
            return true;
        }

        void TablicowanieWartosciSzeregu(float Xd, float Xg, float h, float Eps, out float[,] TWS)
        {
            //wyznaczenie liczby wierszy egzemplarza tablicy TWR
            int n = (int)((Xg - Xd) / h + 1);

            //tworzenie egzemplarza tablicy TWS
            TWS = new float[n, 3];
            //tablicowanie wartosci szeregu w przedziale [Xd, Xg]
            //deklaracje pomocnicze 
            float X;
            int i; //numer podprzedzialu przedzialu [Xd, Xg]
            ushort licznikZsumowanychWyrazow;
            for (X = Xd, i = 0; i < TWS.GetLength(0); i++, X = Xd + i * h) // nie piszemy tak: X = X + h
            {
                TWS[i, 0] = X;
                TWS[i, 1] = ObliczWartoscSzeregu(X, Eps, out licznikZsumowanychWyrazow);
                TWS[i, 2] = licznikZsumowanychWyrazow;
            }
        }

        void WpisanieWynikuDoKontrolkiDataGridView(float[,] TWS, DataGridView dgvTablicaWartosciSzeregu)
        {
            //wyczyszczenie kontrolki DataGdidView
            dgvTablicaWartosciSzeregu.Rows.Clear();
            //wpisywanie danych z tablicy TWS do kontrolki DataGridView
            for (int i = 0; i < TWS.GetLength(0); i++)
            {
                //dodajemy do kontrolki DataGridView nowy, pusty wiersz 
                dgvTablicaWartosciSzeregu.Rows.Add();
                //wpisanie danych z TWS do kolejnych komorek dodanego wiersza do kontrolki DGV 
                dgvTablicaWartosciSzeregu.Rows[i].Cells[0].Value = string.Format("{0:0.00}", TWS[i, 0]);
                dgvTablicaWartosciSzeregu.Rows[i].Cells[1].Value = string.Format("{0:0.00}", TWS[i, 1]);
                dgvTablicaWartosciSzeregu.Rows[i].Cells[2].Value = string.Format("{0}", (ushort)TWS[i, 2]);
            }
        }

        void WpisanieWynikowDoKontrolkiChart(float[,] TWS, Chart chtWykresSzeregu)
        {
            chtWykresSzeregu.BorderlineWidth = 2;
            chtWykresSzeregu.BorderlineColor = Color.Red;
            chtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDotDot;
            chtWykresSzeregu.Titles.Add("Wykres zmian wartości szeregu S(X)");
            chtWykresSzeregu.Legends.FindByName("Legend1").Docking = Docking.Bottom;
            chtWykresSzeregu.BackColor = Color.LightSkyBlue;
            chtWykresSzeregu.ChartAreas[0].AxisX.Title = "Wartości X";
            chtWykresSzeregu.ChartAreas[0].AxisY.Title = "Wartości S(X)";
            chtWykresSzeregu.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f2}";
            chtWykresSzeregu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f2}";
            chtWykresSzeregu.Series.Clear();
            chtWykresSzeregu.Series.Add("Seria 0");
            chtWykresSzeregu.Series[0].XValueMember = "X";
            chtWykresSzeregu.Series[0].YValueMembers = "Y";
            chtWykresSzeregu.Series[0].IsVisibleInLegend = true;
            chtWykresSzeregu.Series[0].Name = "Wartość szeregu potęgowego S(X)";
            chtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line;
            chtWykresSzeregu.Series[0].Color = Color.Black;
            chtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
            chtWykresSzeregu.Series[0].BorderWidth = 1;
            for (int i=0; i<TWS.GetLength(0); i++)
                chtWykresSzeregu.Series[0].Points.AddXY(TWS[i,0], TWS[i,1]);

        }

        #endregion

        private void txtLicznikWyrazow_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvTablicaWartosciSzeregu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void plikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zapisTablicyTWSWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zgaszenie kontrolki errorProvider
            errorProvider1.Dispose();
            //spwadzenie czy zostal utworzony egzemplarz tablicy
            if (TWS is null)
            {
                //egzemplarz tablicy TWS nie zostal jeszcze utworzony co oznacza ze nalezy go utworzyc
                //pobranie danych z formularza
                //deklaracje zmiennych dla prechowywania danych wejsciowych
                float xd, xg, h, eps;
                //wywolanie metody dla pobrania danych wejsciowych 
                if (!PobranieDanych_Xd_Xg_h_Eps(out xd, out xg, out h, out eps))
                {
                    //dodatkowe powiadomienie uzytkownika o zaistnialym bledzie 
                    MessageBox.Show("UWAGA: Podczas pobierania danych wejsciowych z formularza wystapil niedozwolony znak - popraw zapis danej i ponownie wybierz aktualnie obslugiwane polecenie z menu Plik");
                    //przerwanie dalszej obslugi polecenia wybranego z menu plik
                    return;
                }
                //dane zostaly pobrane tablicowanie szeregu
                TablicowanieWartosciSzeregu(xd, xg, h, eps, out TWS);

            }
            //tutaj jest egzemplarz TWS i szereg jest stablicowany 
            //utworzenie okna dialogowego dla wyboru pliku do zapisu
            SaveFileDialog OknoWyboruPlikuDoZapisu = new SaveFileDialog();
            //ustawnie filtru dla wyswietlanych plikow
            OknoWyboruPlikuDoZapisu.Filter = "txtfile (*.txt)|*.txt|All files(*.*)|*.*";
            //ustawnie filtru domyslnego
            OknoWyboruPlikuDoZapisu.FilterIndex = 1;
            //przywrocenie folderu sprzed wyborku pliku do zapisu
            OknoWyboruPlikuDoZapisu.RestoreDirectory = true;
            //ustawienie dysku domyslnego
            OknoWyboruPlikuDoZapisu.InitialDirectory = "C:\\";
            //ustalenie tytulu okna dialogowego do wyboru pliku do zapisu
            OknoWyboruPlikuDoZapisu.Title = "Wybor pliku do zapisu tablicy TWS(Tablica Wartosci Szeregu)";
            if (OknoWyboruPlikuDoZapisu.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter PlikZnakowy = new System.IO.StreamWriter(OknoWyboruPlikuDoZapisu.FileName);
                try
                {
                    for (int i = 0; i < TWS.GetLength(0); i++)
                    {
                        PlikZnakowy.Write(TWS[i, 0].ToString()); //zapisanie wartoisci x
                        PlikZnakowy.Write(";"); //znak ";" oddziela liczby od siebie
                        PlikZnakowy.Write(TWS[i, 1].ToString()); //zapisanie wartoisci x
                        PlikZnakowy.Write(";"); //znak ";" oddziela liczby od siebie
                        PlikZnakowy.WriteLine(TWS[i, 2].ToString()); //zapisanie wartoisci x

                    }
                }
                catch (Exception ex)
                {
                    //wyswietlenie komunikatu
                    MessageBox.Show("UWAGA: podczas zapisu tablicy TWS wystappil blad: " + ex.Message + " co oznacza że tablica TWS nie zostala zapisana do pliku");
                }
                finally
                {
                    PlikZnakowy.Close();
                }
            }
            else
            {
                MessageBox.Show("UWAGA: Nie został wybrany żaden plik i tablica TWS nie zostala zapisana w zadnym pliku");
            }
        }

        private void restartProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void zamknięcieProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult PytanieDoUzytkownika = MessageBox.Show("Czy na pewno chcesz zamknąć formularz (co może skutkować utratą danych zapisanych na formularzu)?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (PytanieDoUzytkownika == DialogResult.Yes)
                Close();
        }

        private void zmianaKoloruTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //okno dialogowe z paleta kolorow
            ColorDialog PaletaKolorow = new ColorDialog();
            //zaznaczenie w PalecieKolorow bierzacego koloru formularza
            PaletaKolorow.Color = this.BackColor;
            //wyswietlenie palety kolorow i "odczytanie" wybranego koloru przez urzytkownika
            if (PaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                //dokonujemy zmiany koloru tla formularza
                this.BackColor = PaletaKolorow.Color;
                //zwolnienie egzemplarza PaletyKolorow
                PaletaKolorow.Dispose();
            }
        }

        private void zmianaCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog OknoCzcionki = new FontDialog();
            //zaznaczenie w oknie czcionki OknoCzcionki bierzacego fontu
            OknoCzcionki.Font = this.Font;
            //wyswietlenie okna dialogowego
            if (OknoCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = OknoCzcionki.Font;
                //zwolnienie 
                OknoCzcionki.Dispose();
            }
        }

        private void zmianaKoloruCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chtWykresSzeregu_Click(object sender, EventArgs e)
        {

        }

        private void odczytanieTablicyTWSZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (!(TWS is null))
            {
                DialogResult OknoMessage = MessageBox.Show("UWAGA: egzemplarz tablicy TWS już istnieje! \r\nCzy bieżący egzemplarz tablicy TWS ma być usunięty i w jego miejsce ma " +
                    "być utoworzony nowy egzemplarz, do którego mają zostać 'wczytane' elementy TWS z pliku?\r\n - kliknij przycisk poleceń 'Nie' dla skasowania polecenia wczytania " +
                    "elementów tabliczy TWS z pliku", "Okno ostrzeżenia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (OknoMessage == DialogResult.Yes)
                {
                    TWS = null;
                    if (OknoMessage == DialogResult.Yes)
                        TWS = null;
                    else
                    {
                        MessageBox.Show("Polecenie odczytania (pobrania) elementów tablicy TWS z pliku zostało anulowane (skasowane)!");
                        //przerwanie obsługi polecenia odczytania elementów tablicy TWS z pliiiku
                        return;
                    }
                }
            }
            //utworzenie egzemplarza okna dialogowego dla wyboru pliku do odczytu
            OpenFileDialog OknoWyboruPlikuDoOdczytu = new OpenFileDialog();
            OknoWyboruPlikuDoOdczytu.Filter = "txtfile (*.txt)|*.txt|All files(*.*)|*.*";
            //ustawienie filtru dla wyboru plików do wyświetlenia w oknie dialogowym
            OknoWyboruPlikuDoOdczytu.FilterIndex = 1;
            OknoWyboruPlikuDoOdczytu.RestoreDirectory = true;
            OknoWyboruPlikuDoOdczytu.InitialDirectory = "C:\\";
            OknoWyboruPlikuDoOdczytu.Title = "Wybór pliku do odczytu TWS (Tabela Wartości Szeregu)";
            if (OknoWyboruPlikuDoOdczytu.ShowDialog() == DialogResult.OK)
            {
                string WierszDanych;
                string[] DaneWiersza;
                ushort LicznikWierszy;
                System.IO.StreamReader PlikZnakowy = new System.IO.StreamReader(OknoWyboruPlikuDoOdczytu.FileName);
                LicznikWierszy = 0;
                while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                    LicznikWierszy++;

                PlikZnakowy.Close();
                TWS = new float[LicznikWierszy, 3];
                PlikZnakowy = new System.IO.StreamReader(OknoWyboruPlikuDoOdczytu.FileName);
                try
                {
                    int NrWiersza = 0;
                    while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                    {
                        DaneWiersza = WierszDanych.Split(';');
                        DaneWiersza[0].Trim();
                        DaneWiersza[1].Trim();
                        DaneWiersza[2].Trim();
                        TWS[NrWiersza, 0] = float.Parse(DaneWiersza[0]);
                        TWS[NrWiersza, 1] = float.Parse(DaneWiersza[1]);
                        TWS[NrWiersza, 2] = float.Parse(DaneWiersza[2]);
                        NrWiersza++;
                    }
                    WpisanieWynikuDoKontrolkiDataGridView(TWS, dgvTablicaWartosciSzeregu);
                    chtWykresSzeregu.Visible = false;
                    dgvTablicaWartosciSzeregu.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: Błąd operacji (działania) na pliku (wyświetlony komunikat): --> " + ex.Message);
                }
                finally
                {
                    PlikZnakowy.Close();
                    PlikZnakowy.Dispose();
                }
            }
            else
                MessageBox.Show("Plik do odczytu tablicy TWS nie został wybrany i obsługa polecenia: 'Odczytanie stablicowanego szeregu z pliku (z menu poziomego Plik) nie może być zrealizowana'");
        }

        private void zmianaCzcionkiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog OknoCzcionki = new FontDialog();
            //zaznaczenie w oknie czcionki OknoCzcionki bierzacego fontu
            OknoCzcionki.Font = this.Font;
            //wyswietlenie okna dialogowego
            if (OknoCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = OknoCzcionki.Font;
                //zwolnienie 
                OknoCzcionki.Dispose();
            }
        }

        private void zmianaTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorow = new ColorDialog();
            //zaznaczenie w PalecieKolorow bierzacego koloru formularza
            PaletaKolorow.Color = this.BackColor;
            //wyswietlenie palety kolorow i "odczytanie" wybranego koloru przez urzytkownika
            if (PaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                //dokonujemy zmiany koloru tla formularza
                this.BackColor = PaletaKolorow.Color;
                //zwolnienie egzemplarza PaletyKolorow
                PaletaKolorow.Dispose();
            }
        }
        private void zmianaTypuWykresuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zmianaKoloruWykresuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zmianaStyluLiniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SzeregLaboratoryjny_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //utworzenie okna dialogowego dla potwierdzenia zamknievia formularza glownego
            DialogResult OknoMessage = MessageBox.Show("Czy napewno chcesz zamknac formularz przejść do formularza głównego?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (OknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;
                foreach (Form Formularz in Application.OpenForms)
                    if (Formularz.Name == "Kokpit_projektu")
                    {
                        //ukrycie bierzcego formularza, ktorego refetencjie udostepnia this
                        this.Hide();
                        //odsloniecie formularza Szereglaboratoryjny
                        Formularz.Show();
                        //zakonczenie wyjscie z obslugi zdarzenia Click dla przycisku polecen
                        e.Cancel = true;
                        return;
                    }
                SzeregLaboratoryjny FormularzSzeregLaboratoryjny = new SzeregLaboratoryjny();
                this.Hide();
                this.Show();
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
