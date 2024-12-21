using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNR2_Kuźnicki61961
{
    public partial class Kokpit_projektu : Form
    {
        public Kokpit_projektu()
        {
            InitializeComponent();
        }

        private void btnSzeregLaboratoryjny_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)

                if (Formularz.Name == "SzeregLaboratoryjny")
                {
                    //ukrycie bierzcego formularza, ktorego refetencjie udostepnia this
                    this.Hide();
                    //odsloniecie formularza Szereglaboratoryjny
                    Formularz.Show();
                    //zakonczenie wyjscie z obslugi zdarzenia Click dla przycisku polecen
                    return;
                }
            //tworzymy egzemplarz formularza Szereglaboratoryjny
            SzeregLaboratoryjny AnalizatorSzeregu = new SzeregLaboratoryjny();
            //ukrycie bierzcego formularza
            this.Hide();
            //odsloniecie nowego formularza
            AnalizatorSzeregu.Show();
        }

        private void btnSzeregIndywidualny_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)

                if (Formularz.Name == "SzeregIndywidualny")
                {
                    //ukrycie bierzcego formularza, ktorego refetencjie udostepnia this
                    this.Hide();
                    //odsloniecie formularza Szereglaboratoryjny
                    Formularz.Show();
                    //zakonczenie wyjscie z obslugi zdarzenia Click dla przycisku polecen
                    return;
                }
            //tworzymy egzemplarz formularza Szereglaboratoryjny
            SzeregIndywidualny AnalizatorSzeregu = new SzeregIndywidualny();
            //ukrycie bierzcego formularza
            this.Hide();
            //odsloniecie nowego formularza
            AnalizatorSzeregu.Show();
        }
        private void Kokpit_projektu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //utworzenie okna dialogowego dla potwierdzenia zamknievia formularza glownego
            DialogResult OknoMessage = MessageBox.Show("Czy napewno chcesz zamknac formularz glowny i zakonczyc dzialanie programu", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (OknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;
                Application.ExitThread();
            }
            e.Cancel = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
