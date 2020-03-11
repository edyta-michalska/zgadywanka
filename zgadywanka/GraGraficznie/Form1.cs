using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelGry;

namespace GraGraficznie
{
    public partial class Form1 : Form
    {
        private Gra g = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBoxLosowanie.Visible = true;
            button1.Enabled = false;
            buttonPrzerwij.Visible = true;


        }

        private void textBoxZakresDo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonWylosuj_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBoxZakresOd.Text);
            int b = int.Parse(textBoxZakresDo.Text);
            g = new Gra(a, b);
            //wypisz komunikat, żeby odgadywać
            labelKomunikat1.Text = $"wylosowano liczbe od {a} do {b}";
            groupBoxLosowanie.Enabled = false;

            groupBoxPropozycja.Visible = true;

        }

        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            int propozycja = int.Parse(textBoxPropozycja.Text);

            var odp = g.Odpowiedz(propozycja);
            switch (odp)
            {

                case Odp.ZaMalo:
                    labelOdpowiedz.ForeColor = Color.Red;
                    labelOdpowiedz.Text = "Za malo";
                    break;

                case Odp.ZaDuzo:
                    labelOdpowiedz.ForeColor = Color.Red;
                    labelOdpowiedz.Text = "Za duzo";
                    break;

                case Odp.Trafiono:
                    labelOdpowiedz.ForeColor = Color.Green;
                    labelOdpowiedz.Text = "trafiono";
                    groupBoxPropozycja.Enabled = false;
                    button1.Enabled = true;

                    break;
            }

        }

        private void textBoxZakresOd_TextChanged(object sender, EventArgs e)
        {
            int wynik = 0;
            if
                (int.TryParse(textBoxZakresOd.Text, out wynik))
            {

                textBoxZakresOd.BackColor = Color.LightGreen;
                buttonWylosuj.Enabled = true;
            }

            else
            {

                textBoxZakresOd.BackColor = Color.PaleVioletRed;
                buttonWylosuj.Enabled = false;
            }
        }
    }
}
