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
        double[] ceny = new double[8];
        double cena = 0, zaplata = 0, reszta = 0;
        bool b2click = false, b1click = false, test = false;

        public Form1()
        {
            InitializeComponent();
            Clean();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b1click = true;
            Calculate();
            cena = 0;
            foreach (double element in ceny)
            {
                cena += element;
            }
            label12.Text = "Do zapłaty: " + cena + "zł.";
            if (pozycja > 0 && pozycja < 8) { button1.Enabled = true; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zaplata = Convert.ToDouble(textBox3.Text);
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
            MessageBox.Show("Program Kasa Fiskalna.\n\n Program przyjmuje liczby w formacie np. '12,00'.\n Podaj nazwę przedmiotu i jego cenę. Wciśnij przycisk 'Dodaj'. \n Jeśli chcesz usunąć przedmiot wciśnij 'Usuń ostatni'.\n Aby wydać reszte podaj wpłaconą kwotę i wciśnij przycisk 'Reszta'.\n\nAutor: Kamil Kijańczuk");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b2click = true;
            Calculate();
            if (test == false)
            {
                if (pozycja >= 0) { cena -= ceny[pozycja]; ceny[pozycja] = 0; }
                label12.Text = "Do zapłaty: " + cena + "zł.";
            }
            test = false;
        }

        private void Calculate()
        {
                try
                {
                    switch (pozycja)
                    {
                        case 0: { if (b1click == true) { b1click = false; b2click = false; ceny[pozycja] = Convert.ToDouble(textBox2.Text); label4.Text = textBox1.Text + " - " + textBox2.Text; pozycja++; button2.Enabled = true; } break; }
                        case 1: { if (b1click == true) { b1click = false; ceny[pozycja] = Convert.ToDouble(textBox2.Text); label5.Text = textBox1.Text + " - " + textBox2.Text; pozycja++;  } if (b2click == true) { b2click = false; label4.Text = ""; pozycja--; button2.Enabled = false; } break; }
                        case 2: { if (b1click == true) { b1click = false; ceny[pozycja] = Convert.ToDouble(textBox2.Text); label6.Text = textBox1.Text + " - " + textBox2.Text; pozycja++;  } if (b2click == true) { b2click = false; label5.Text = ""; pozycja--;  } break; }
                        case 3: { if (b1click == true) { b1click = false; ceny[pozycja] = Convert.ToDouble(textBox2.Text); label7.Text = textBox1.Text + " - " + textBox2.Text; pozycja++;  } if (b2click == true) { b2click = false; label6.Text = ""; pozycja--;  } break; }
                        case 4: { if (b1click == true) { b1click = false; ceny[pozycja] = Convert.ToDouble(textBox2.Text); label8.Text = textBox1.Text + " - " + textBox2.Text; pozycja++;  } if (b2click == true) { b2click = false; label7.Text = ""; pozycja--;  } break; }
                        case 5: { if (b1click == true) { b1click = false; ceny[pozycja] = Convert.ToDouble(textBox2.Text); label9.Text = textBox1.Text + " - " + textBox2.Text; pozycja++;  } if (b2click == true) { b2click = false; label8.Text = ""; pozycja--;  } break; }
                        case 6: { if (b1click == true) { b1click = false; ceny[pozycja] = Convert.ToDouble(textBox2.Text); label10.Text = textBox1.Text + " - " + textBox2.Text; pozycja++;  } if (b2click == true) { b2click = false; label9.Text = ""; pozycja--;  } break; }
                        case 7: { if (b1click == true) { b1click = false; ceny[pozycja] = Convert.ToDouble(textBox2.Text); label11.Text = textBox1.Text + " - " + textBox2.Text; pozycja++; button1.Enabled = false; } if (b2click == true) { b2click = false; label10.Text = ""; pozycja--;  } break; }
                        case 8: { if (b2click == true) { b1click = false; b2click = false; label11.Text = ""; pozycja--; button1.Enabled = true; } break; }
                        default: { b1click = false; b2click = false; break; }
                    }
                }
                catch (FormatException) { MessageBox.Show("Niepoprawny format. Spróbuj liczb z przecinkiem."); test = true; }
        }

        private void Clean() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
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
