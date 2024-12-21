using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjektNR2_Kuźnicki61961
{
    public partial class SzeregIndywidualny : Form
    {
        const float JKDgPrzedzialuX = float.MinValue;
        const float JKGgPrzedzialuX = float.MaxValue;
        float[,] JKTWS;
        public SzeregIndywidualny()
        {
            InitializeComponent();
        }
        private void SzeregIndywidualny_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                SzeregIndywidualny FormularzSzeregIndywidualny = new SzeregIndywidualny();
                this.Hide();
                FormularzSzeregIndywidualny.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void JKbtnWizualizacjaTabelaryczna_Click(object sender, EventArgs e)
        {
            float JKXd, JKXg, JKh, JKEps;
            if (!JKPobranieDanych_Xd_Xg_h_Eps(out JKXd, out JKXg, out JKh, out JKEps))
            {
                return;
            }

            if (JKTWS is null)
            {
                JKTablicowanieWartosciSzeregu(JKXd, JKXg, JKh, JKEps, out JKTWS);
            }

            JKWpisanieWynikuDoKontrolkiDataGridView(JKTWS, JKdgvTablicaWartosciSzeregu);

            JKdgvTablicaWartosciSzeregu.Visible = true;

            JKbtnWizualizacjaTabelaryczna.Enabled = true;
        }

        private void JKbtnObliczWartoscSzeregu_Click(object sender, EventArgs e)
        {
            //"zgaszenie" kontrolki errorProvider 
            errorProvider1.Dispose();
            //pobranie dancych wejsciowych z formularza
            // deklaracja zmiennych dla przechowania pobranych danych wejsciowych 
            float X, Eps;
            if (!JKPobranieDanych_X_Eps(out X, out Eps))
            {//był bład, to go syganlizujemy zapaloeniem kontrolki error provider
                //errorProvider1.SetError(JKtxtX, "ERROR: w zapisie wartosci zmiennej X wystapil niedozwolony znak");
                //przerwanie pobierania kolejnych danych
                return;

            }
            //oblicznie wartosci szeregu
            //deklaracja zmiennycb dla przehcowania wynikow obliczen
            float JKsuma;
            ushort JKlicznikZsumowanychWyrazow;
            //wywowlamie metody oblicznia sumy szeregu
            JKsuma = JKObliczWartoscSzeregu(X, Eps, out JKlicznikZsumowanychWyrazow);
            //wpisanie wynikow obliczen od odpowiednich kontrolek na formularzu
            JKtxtSumaSzeregu.Text = JKsuma.ToString();
            JKtxtLicznikWyrazow.Text = JKlicznikZsumowanychWyrazow.ToString();
        }

        private void JKbtnWizualizacjaGraficzna_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            float JKXd, JKXg, JKh, JKEps;
            if (!JKPobranieDanych_Xd_Xg_h_Eps(out JKXd, out JKXg, out JKh, out JKEps))
                return;
            if (JKTWS is null)
                JKTablicowanieWartosciSzeregu(JKXd, JKXg, JKh, JKEps, out JKTWS);
            WpisanieWynikowDoKontrolkiChart(JKTWS, JKchtWykresSzeregu);
            JKdgvTablicaWartosciSzeregu.Visible = false;
            JKchtWykresSzeregu.Visible = true;
            JKbtnWizualizacjaGraficzna.Enabled = false;
        }

        private void JKbtnResetuj_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #region deklaracje metod pomocniczych
        bool JKPobranieDanych_X_Eps(out float JKx, out float JKeps)
        {
            JKx = JKeps = 0.0f;
            if (!float.TryParse(JKtxtX.Text, out JKx))
            {
                errorProvider1.SetError(JKtxtX, "ERROR: w zapisie wartosci zmiennej niezaleznej x wystapil niedozwolony znak"); //wypisanie blędu
                return false;
            }
            if ((JKx <= -3f) || (JKx <= -1f))
            {
                errorProvider1.SetError(JKtxtX, "ERROR: podana wartość nie spelnia warunku wyjsciowego: x < -3 oraz -1 < x"); //wypisanie blędu
                return false;
            }
            if (!float.TryParse(JKtxtEps.Text, out JKeps))
            {
                errorProvider1.SetError(JKtxtEps, "ERROR: w zapisie dokladnosci obliczen Eps wystapil niedozwolony znak"); //wypisanie blędu
                return false;
            }
            if ((JKeps <= 0f) || (JKeps >= 1f))
            {
                errorProvider1.SetError(JKtxtEps, "ERROR: podana dokladnosc nie spelnia warunku wyjsciowego: 0 < Eps < 1"); //wypisanie blędu
                return false;
            }
            JKtxtEps.Enabled = false;
            return true;
        }
        bool JKPobranieDanych_Xd_Xg_h_Eps(out float JKXd, out float JKXg, out float JKh, out float JKEps)
        {
            //przypisanie domyslnych wartosci dla parametrow wyjsciowych
            JKXd = JKXg = JKh = JKEps = 0f;
            //pobranie Xd
            if (!float.TryParse(JKtxtXd.Text, out JKXd))
            {
                //sygnalizacja bledu - zapalenie kontrolki errorProvider
                errorProvider1.SetError(JKtxtXd, "Error: w zapisie Xd wystapil niedozwolony znak");
                //przerwanie pobierania dnych z formularza
                return false;


            }
            //sprawdzenie czy Xd nalezy do przedzialu zbieznosci "mojego" szeregu

            if ((JKXd < JKDgPrzedzialuX) || (JKXd > JKGgPrzedzialuX))
            {
                //sygnalizacja bledu -zapalenie kontrolki errorProvider
                errorProvider1.SetError(JKtxtXd, "Error: podanie Xd mie miesci sie w przedziale zbieznosci 'mojego' szeregu");
                //przerwanie pobierania dnych z formularza
                return false;
            }
            //pobranie Xg
            if (!float.TryParse(JKtxtXg.Text, out JKXg))
            {
                //sygnalizacja bledu - zapalenie kontrolki errorProvider
                errorProvider1.SetError(JKtxtXg, "Error: w zapisie Xg wystapil niedozwolony znak");
                //przerwanie pobierania dnych z formularza
                return false;
            }

            //sprawdzenie czy Xg nalzey do przedzialu zbieznosci "mojego" szeregu
            if ((JKXg < JKDgPrzedzialuX) || (JKXg > JKGgPrzedzialuX))
            {
                //sygnalizacja bledu -zapalenie kontrolki errorProvider
                errorProvider1.SetError(JKtxtXg, "Error: podanie Xd mie miesci sie w przedziale zbieznosci 'mojego' szeregu");
                //przerwanie pobierania dnych z formularza
                return false;
            }
            //sprawdzenie poprawnej kojelnosci zapisu granic przedzialu: [Xd, Xg]
            if (JKXd > JKXg)
            {
                //sygnalizacja bledu -zapalenie kontrolki errorProvider
                errorProvider1.SetError(JKtxtXg, "Error: podanie granice przedzialu [Xd, Xg] zostaly podane w niepoprawnej kolejnosci");
                //przerwanie pobierania dnych z formularza
                return false;
            }

            // ustawienie stanu braku aktrywnosci dla kontrolek txtXd oraz txtXg
            JKtxtXd.Enabled = false;
            JKtxtXg.Enabled = false;

            //pobranie przyrostu h w zamian wartosci zmiennej X
            if (!float.TryParse(JKtxtH.Text, out JKh))
            {
                //sygnalizacja bledu 
                errorProvider1.SetError(JKtxtH, "Error: w zapisie przyrostu h wystapil niedozwolony znak");
                //przerwanie pobierania danych z formularza
                return false;
            }
            //sprawdzenie warunku wyjsciowego dla h
            if ((JKh <= 0f) || (JKh >= (JKXg - JKXd)))
            {
                //sygnalizacja bledu 
                errorProvider1.SetError(JKtxtH, "Error: podana wartosc przyrostu h nie spelnia podanego warunku wyjsciowego: (h > 0) && (h< (Xd - Xg))");
                //przerwanie pobierania danych z formularza
                return false;
            }
            //pobranie dokladnosci obliczen Eps
            if (!float.TryParse(JKtxtEps.Text, out JKEps))
            {
                //sygnalizacja bledu 
                errorProvider1.SetError(JKtxtEps, "Error: w zapisie dokladnosci obliczen Eps wystapil niedozwolony znak");
                //przerwanie pobierania danych z formularza
                return false;
            }
            //sprawdzenie warunku wejsciowego 
            if ((JKEps <= 0f) || (JKEps >= 1f))
            {
                //sygnalizacja bledu 
                errorProvider1.SetError(JKtxtEps, "Error: podana dokladnosc obliczen Eps nie spelnia tzw warunku wejsciowego: (Eps <= 0f) || (Eps >= 1f)");
                //przerwanie pobierania danych z formularza
                return false;
            }

            //zwrotne przekazanie "informacji" ze nie bylo zadnego bledu
            return true;
        }
        void JKTablicowanieWartosciSzeregu(float JKXd, float JKXg, float JKh, float JKEps, out float[,] JKTWS)
        {
            //wyznaczenie liczby wierszy egzemplarza tablicy TWR
            int JKn = (int)((JKXg - JKXd) / JKh + 1);

            //tworzenie egzemplarza tablicy TWS
            JKTWS = new float[JKn, 3];
            //tablicowanie wartosci szeregu w przedziale [Xd, Xg]
            //deklaracje pomocnicze 
            float JKX;
            int JKi; //numer podprzedzialu przedzialu [Xd, Xg]
            ushort JKlicznikZsumowanychWyrazow;
            for (JKX = JKXd, JKi = 0; JKi < JKTWS.GetLength(0); JKi++, JKX = JKXd + JKi * JKh)
            {
                JKTWS[JKi, 0] = JKX;
                JKTWS[JKi, 1] = JKObliczWartoscSzeregu(JKX, JKEps, out JKlicznikZsumowanychWyrazow);
                JKTWS[JKi, 2] = JKlicznikZsumowanychWyrazow;
            }
        }
        void JKWpisanieWynikuDoKontrolkiDataGridView(float[,] JKTWS, DataGridView JKdgvTablicaWartosciSzeregu)
        {
            //wyczyszczenie kontrolki DataGdidView
            JKdgvTablicaWartosciSzeregu.Rows.Clear();
            //wpisywanie danych z tablicy TWS do kontrolki DataGridView
            for (int JKi = 0; JKi < JKTWS.GetLength(0); JKi++)
            {
                //dodajemy do kontrolki DataGridView nowy, pusty wiersz 
                JKdgvTablicaWartosciSzeregu.Rows.Add();
                //wpisanie danych z TWS do kolejnych komorek dodanego wiersza do kontrolki DGV 
                JKdgvTablicaWartosciSzeregu.Rows[JKi].Cells[0].Value = string.Format("{0:0.00}", JKTWS[JKi, 0]);
                JKdgvTablicaWartosciSzeregu.Rows[JKi].Cells[1].Value = string.Format("{0:0.00}", JKTWS[JKi, 1]);
                JKdgvTablicaWartosciSzeregu.Rows[JKi].Cells[2].Value = string.Format("{0}", (ushort)JKTWS[JKi, 2]);
            }
        }
        private float JKObliczWartoscSzeregu(float JKx, float JKeps, out ushort JKn)   
        {
            //"techniczne" ustawienie watrosci domyslnej dla parametru wyjsciowego
            JKn = 0;
            //ustalenie warunkow brzegowych
            float JKs = 0f;
            float JKw = (-1)/(JKx+2);
            //iteracyjne oblicznie sumy szeregu
            do
            {
                JKs = JKs + JKw;
                JKn++;
                JKw = JKw * 1 / (-JKx - 2);
            } while (Math.Abs(JKw) > JKeps);


            //zwrot wartosci wynikowej
            return JKs;
        }
        #endregion


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
            for (int i = 0; i < TWS.GetLength(0); i++)
                chtWykresSzeregu.Series[0].Points.AddXY(TWS[i, 0], TWS[i, 1]);

        }


        private void zapisTablicyTWSWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zgaszenie kontrolki errorProvider
            errorProvider1.Dispose();
            //spwadzenie czy zostal utworzony egzemplarz tablicy
            if (JKTWS is null)
            {
                //egzemplarz tablicy TWS nie zostal jeszcze utworzony co oznacza ze nalezy go utworzyc
                //pobranie danych z formularza
                //deklaracje zmiennych dla prechowywania danych wejsciowych
                float JKxd, JKxg, JKh, JKeps;
                //wywolanie metody dla pobrania danych wejsciowych 
                if (!JKPobranieDanych_Xd_Xg_h_Eps(out JKxd, out JKxg, out JKh, out JKeps))
                {
                    //dodatkowe powiadomienie uzytkownika o zaistnialym bledzie 
                    MessageBox.Show("UWAGA: Podczas pobierania danych wejsciowych z formularza wystapil niedozwolony znak - popraw zapis danej i ponownie wybierz aktualnie obslugiwane polecenie z menu Plik");
                    //przerwanie dalszej obslugi polecenia wybranego z menu plik
                    return;
                }
                //dane zostaly pobrane tablicowanie szeregu
                JKTablicowanieWartosciSzeregu(JKxd, JKxg, JKh, JKeps, out JKTWS);

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
                    for (int JKi = 0; JKi < JKTWS.GetLength(0); JKi++)
                    {
                        PlikZnakowy.Write(JKTWS[JKi, 0].ToString()); //zapisanie wartoisci x
                        PlikZnakowy.Write(";"); //znak ";" oddziela liczby od siebie
                        PlikZnakowy.Write(JKTWS[JKi, 1].ToString()); //zapisanie wartoisci x
                        PlikZnakowy.Write(";"); //znak ";" oddziela liczby od siebie
                        PlikZnakowy.WriteLine(JKTWS[JKi, 2].ToString()); //zapisanie wartoisci x

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

        private void zmianaCzcionkiToolStripMenuItem_Click(object sender, EventArgs e) //z jakiegos powodu nie chce u mnie działać
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog JKOknoCzcionki = new FontDialog();
            //zaznaczenie w oknie czcionki JKOknoCzcionki bierzacego fontu
            JKOknoCzcionki.Font = this.Font;
            //wyswietlenie okna dialogowego
            if (JKOknoCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = JKOknoCzcionki.Font;
                //zwolnienie 
                JKOknoCzcionki.Dispose();
            }
        }

        private void odczytanieTablicyTWSZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (!(JKTWS is null))
            {
                DialogResult OknoMessage = MessageBox.Show("UWAGA: egzemplarz tablicy TWS już istnieje! \r\nCzy bieżący egzemplarz tablicy TWS ma być usunięty i w jego miejsce ma " +
                    "być utoworzony nowy egzemplarz, do którego mają zostać 'wczytane' elementy TWS z pliku?\r\n - kliknij przycisk poleceń 'Nie' dla skasowania polecenia wczytania " +
                    "elementów tabliczy TWS z pliku", "Okno ostrzeżenia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (OknoMessage == DialogResult.Yes)
                {
                    JKTWS = null;
                    if (OknoMessage == DialogResult.Yes)
                        JKTWS = null;
                    else
                    {
                        MessageBox.Show("Polecenie odczytania (pobrania) elementów tablicy TWS z pliku zostało anulowane (skasowane)!");
                        //przerwanie obsługi polecenia odczytania elementów tablicy TWS z pliiiku
                        return;
                    }
                }
            }
        //utworzenie egzemplarza okna dialogowego dla wyboru pliku do odczytu
        OpenFileDialog JKOknoWyboruPlikuDoOdczytu = new OpenFileDialog();
        JKOknoWyboruPlikuDoOdczytu.Filter = "txtfile (*.txt)|*.txt|All files(*.*)|*.*";
            //ustawienie filtru dla wyboru plików do wyświetlenia w oknie dialogowym
            JKOknoWyboruPlikuDoOdczytu.FilterIndex = 1;
            JKOknoWyboruPlikuDoOdczytu.RestoreDirectory = true;
            JKOknoWyboruPlikuDoOdczytu.InitialDirectory = "C:\\";
            JKOknoWyboruPlikuDoOdczytu.Title = "Wybór pliku do odczytu TWS (Tabela Wartości Szeregu)";
            if (JKOknoWyboruPlikuDoOdczytu.ShowDialog() == DialogResult.OK)
            {
                string JKWierszDanych;
        string[] JKDaneWiersza;
        ushort LicznikWierszy;
        System.IO.StreamReader JKPlikZnakowy = new System.IO.StreamReader(JKOknoWyboruPlikuDoOdczytu.FileName);
        LicznikWierszy = 0;
                while (!((JKWierszDanych = JKPlikZnakowy.ReadLine()) is null))
                    LicznikWierszy++;

                JKPlikZnakowy.Close();
                JKTWS = new float[LicznikWierszy, 3];
                JKPlikZnakowy = new System.IO.StreamReader(JKOknoWyboruPlikuDoOdczytu.FileName);
                try
                {
                    int JKNrWiersza = 0;
                    while (!((JKWierszDanych = JKPlikZnakowy.ReadLine()) is null))
                    {
                    JKDaneWiersza = JKWierszDanych.Split(';');
                    JKDaneWiersza[0].Trim();
                    JKDaneWiersza[1].Trim();
                    JKDaneWiersza[2].Trim();
                    JKTWS[JKNrWiersza, 0] = float.Parse(JKDaneWiersza[0]);
                    JKTWS[JKNrWiersza, 1] = float.Parse(JKDaneWiersza[1]);
                    JKTWS[JKNrWiersza, 2] = float.Parse(JKDaneWiersza[2]);
                    JKNrWiersza++;
                    }
                    JKWpisanieWynikuDoKontrolkiDataGridView(JKTWS, JKdgvTablicaWartosciSzeregu);
                JKchtWykresSzeregu.Visible = false;
                    JKdgvTablicaWartosciSzeregu.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: Błąd operacji (działania) na pliku (wyświetlony komunikat): --> " + ex.Message);
                }
                finally
                {
                    JKPlikZnakowy.Close();
                    JKPlikZnakowy.Dispose();
                }
            }
            else
    MessageBox.Show("Plik do odczytu tablicy TWS nie został wybrany i obsługa polecenia: 'Odczytanie stablicowanego szeregu z pliku (z menu poziomego Plik) nie może być zrealizowana'");
        }

        private void zamknięcieProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult JKPytanieDoUzytkownika=MessageBox.Show("Czy na pewno chcesz zamknąć formularz (co może skutkować utratą danych zapisanych na formularzu)?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (JKPytanieDoUzytkownika == DialogResult.Yes)
                Close();
        }


        private void zmianaTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog apPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru tła wykresu
            apPaletaKolorow.Color = this.JKdgvTablicaWartosciSzeregu.BackgroundColor;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru obramowania tabeli
                this.JKdgvTablicaWartosciSzeregu.BackgroundColor = apPaletaKolorow.Color;
            // zwolnienie egzemplarza apPaletyKolorow
            apPaletaKolorow.Dispose();
        }

        private void zmianaCzcionkiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog JKOknoCzcionki = new FontDialog();
            //zaznaczenie w oknie czcionki JKOknoCzcionki bierzacego fontu
            JKOknoCzcionki.Font = this.Font;
            //wyswietlenie okna dialogowego
            if (JKOknoCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = JKOknoCzcionki.Font;
                //zwolnienie 
                JKOknoCzcionki.Dispose();
            }
        }

        private void zmianaKoloruWykresuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderWidth = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderWidth = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderWidth = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderWidth = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderWidth = 5;
        }

        private void liniaKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Dash;
        }

        private void liniaCiagłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.DashDot;
        }

        private void liniaKreskowaKropkowaKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.DashDotDot;
        }

        private void liniaKropkowaDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Dot;
        }

        private void liniaCiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
        }

        private void wykresLiniowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line;
        }

        private void wykresPunktowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].ChartType = SeriesChartType.Point;
        }

        private void wykresKolumnowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].ChartType = SeriesChartType.Column;
        }

        private void wykresSłupkowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKchtWykresSzeregu.Series[0].ChartType = SeriesChartType.Bar;
        }

        private void kolorTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog JKPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru formularza
            JKPaletaKolorow.Color = this.JKchtWykresSzeregu.BackColor;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (JKPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru tła formularza
                this.JKchtWykresSzeregu.BackColor = JKPaletaKolorow.Color;
            // zwolnienie egzemplarza PaletyKolorow
            JKPaletaKolorow.Dispose();
        }

        private void kolorLiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog JKPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru tła wykresu
            JKPaletaKolorow.Color = this.JKchtWykresSzeregu.Series[0].Color;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (JKPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru tła wykresu
                this.JKchtWykresSzeregu.Series[0].Color = JKPaletaKolorow.Color;
            // zwolnienie egzemplarza PaletyKolorow
            JKPaletaKolorow.Dispose();
        }
        private void zmianaCzcionkiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog JKOknoCzcionki = new FontDialog();
            //zaznaczenie w oknie czcionki JKOknoCzcionki bierzacego fontu
            JKOknoCzcionki.Font = this.Font;
            //wyswietlenie okna dialogowego
            if (JKOknoCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = JKOknoCzcionki.Font;
                //zwolnienie 
                JKOknoCzcionki.Dispose();
            }
        }

    }
}
