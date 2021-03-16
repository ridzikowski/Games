using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games
{
    public partial class Gra : Form
    {

        public bool symbol;
        public int liczba;
        public int[,] pola;
        public int wygrane1;
        public int wygrane2;
        public Gra()
        {
            InitializeComponent();
            symbol = true;
            liczba = 0;
            textBoxRuchy.Text = liczba.ToString();
            textBoxRuchy.ReadOnly = true;
            pola = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    pola[i, j] = 0;
            wygrane1 = 0;
            wygrane2 = 0;
            textBoxG1.Text = wygrane1.ToString();
            textBoxG2.Text = wygrane2.ToString();
            textBoxRuchy.Visible = false;
        }

        public void przypisz(Button button, int w, int k)
        {
            textBox1.Text = button.Name;
            if (button.Text == "")
            {
                if (symbol)
                {
                    button.Text = "X";
                    symbol = false;
                    pola[w-1, k-1] = 1;
                }
                else
                {
                    button.Text = "O";
                    symbol = true;
                    pola[w-1, k-1] = 2;
                }
                liczba++;
                textBoxRuchy.Text = liczba.ToString();
            }
            if(liczba > 5)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (pola[0, i]>0 &&pola[0, i] == pola[1, i] && pola[0, i] == pola[2, i])
                        koniec(pola[0, i]);
                    if (pola[i, 0] > 0 && pola[i, 0] == pola[i, 1] && pola[i, 0] == pola[i, 2])
                       koniec(pola[0, i]);
                }
                if (pola[0, 0] > 0 && pola[0, 0] == pola[1, 1] && pola[0, 0] == pola[2, 2])
                    koniec(pola[0, 0]);
                if (pola[2, 0] > 0 && pola[2, 0] == pola[1, 1] && pola[2, 0] == pola[0, 2])
                    koniec(pola[2, 0]);
                if(liczba==9)
                    koniec(-1);
            }
        }

        public void koniec (int gracz)
        {
            
            if(gracz>0)
            {
                MessageBox.Show("wygrał gracz: " + gracz.ToString());
                if(gracz == 1)
                {
                    wygrane1++;
                    textBoxG1.Text = wygrane1.ToString();
                }
                else
                {
                    wygrane2++;
                    textBoxG2.Text = wygrane1.ToString();
                }
            }    
            else
                MessageBox.Show("remis");
            symbol = true;
            liczba = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    pola[i, j] = 0;
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button21.Text = "";
            button22.Text = "";
            button23.Text = "";
            button31.Text = "";
            button32.Text = "";
            button33.Text = "";
            textBoxRuchy.Text = 0.ToString();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            przypisz(button11, 1, 1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            przypisz(button12, 1, 2);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            przypisz(button13, 1, 3);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            przypisz(button21, 2, 1);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            przypisz(button22, 2, 2);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            przypisz(button23, 2, 3);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            przypisz(button31, 3, 1);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            przypisz(button32, 3, 2);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            przypisz(button33, 3, 3);
        }
    }
}
