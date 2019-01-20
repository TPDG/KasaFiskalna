using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasaFiskalna
{
    public partial class Form1 : Form
    {
        int pozycja = 0;
        decimal[] ceny = new decimal[50];
        decimal cena = 0, zaplata = 0, reszta = 0;
        bool test = false;

        public Form1()
        {
            InitializeComponent();
            Clean();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ceny[pozycja] = Convert.ToDecimal(textBox2.Text) * Convert.ToDecimal(textBox4.Text);
            if (pozycja < 50) { pozycja++; button1.Enabled = true; } else { button1.Enabled = false; }
            if (pozycja > 0) { button2.Enabled = true; }
            richTextBox1.Text += textBox1.Text + " - " + Convert.ToDouble(textBox4.Text) * Convert.ToDouble(textBox2.Text) + ";\n";
            cena = 0;
            foreach (decimal element in ceny)
            {
                cena += element;
            }
            label12.Text = "Do zapłaty: " + cena + "zł.";
            if (pozycja > 0 && pozycja < 8) { button1.Enabled = true; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zaplata = Convert.ToDecimal(textBox3.Text);
            reszta = zaplata - cena;
            label13.Text = "Reszta: " + reszta + "zł.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program Kasa Fiskalna.\n\n Program przyjmuje liczby w formacie np. '12,00'.\n Podaj nazwę przedmiotu, jego cenę oraz ilość. Wciśnij przycisk 'Dodaj'. \n Jeśli chcesz usunąć przedmiot wciśnij 'Usuń ostatni'.\n Aby wydać reszte podaj wpłaconą kwotę i wciśnij przycisk 'Reszta'.\n\nAutor: Kamil Kijańczuk");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pozycja > 0) { pozycja--; }
            if (pozycja <= 0) { button2.Enabled = false; }
            if (test == false)
            {
                if (pozycja >= 0) { cena -= ceny[pozycja]; ceny[pozycja] = 0; }
                label12.Text = "Do zapłaty: " + cena + "zł.";
            }
            test = false;

            var last = richTextBox1.Text.LastIndexOf(";");
            if (last > 0)
            {
                richTextBox1.Text = richTextBox1.Text.Substring(0, last - 1);
                var beforelast = richTextBox1.Text.LastIndexOf(";");
                richTextBox1.Text = richTextBox1.Text.Substring(0, beforelast + 1);
            }
            else
            {
                richTextBox1.Text = "";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clean() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
            label12.Text = "";
            label13.Text = "";
            textBox4.Text = "1";
            int i = 0;
            foreach (int element in ceny)
            {
                ceny[i] = 0;
                i++;
            }
            pozycja = 0;
        }

    }
}
