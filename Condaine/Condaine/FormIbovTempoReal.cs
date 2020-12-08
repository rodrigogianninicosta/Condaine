using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condaine
{
    public partial class FormIbovTempoReal : Form
    {
        public FormIbovTempoReal()
        {
            InitializeComponent();
            ativa();
        }
        static int z = 0;
        private void ativa()
        {
            int con = 1;
            int y = 0;
            var botoes = new[] { button1, button2, button3, button4, button5, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16, b17, b18, b19, b20, b21, b22, b23, b24, b25, b26, b27, b28, b29, b30, b31, b32, b33, b34, b35, b36, b37, b38, b39, b40 };
            List<String> val = WebIbov.pegar();
            do
            {
                for (int i = 0; i < 6; ++i)
                {
                    switch (i)
                    {
                        case 0: botoes[i + y].Text = val[i + y + z]; break;
                        case 1: botoes[i + y].Text = "Última\n" + val[i + y + z]; break;
                        case 2: botoes[i + y].Text = "Máxima\n" + val[i + y + z]; break;
                        case 3: botoes[i + y].Text = "Mínima\n" + val[i + y + z]; break;
                        case 4: botoes[i + y].Text = "Variação: " + val[i + y + z]; break;
                        case 5: botoes[i - 1 + y].Text += " (" + val[i + y + z] + "%)"; break;
                    }
                }
                ++con;
                y += 5;
                z += 2;
            }
            while (con < 10);
            z += y;
        }
        static bool pass;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pass == false)
            {
                pass = true;
                panel11.BackColor = panel28.BackColor = panel13.BackColor = panel19.BackColor = panel20.BackColor = panel21.BackColor = panel23.BackColor = panel26.BackColor = panel27.BackColor = button6.BackColor = Color.FromArgb(40, 0, 64);
            }
            else
            {
                pass = false;
                panel11.BackColor = panel28.BackColor = panel13.BackColor = panel19.BackColor = panel20.BackColor = panel21.BackColor = panel23.BackColor = panel26.BackColor = panel27.BackColor = button6.BackColor = Color.FromArgb(80, 0, 64);
            }
        }
        static int con = 0;
        private void iconButton2_Click(object sender, EventArgs e)
        {
            con = (con < 5) ? ++con : con = z = 0;
            ativa();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            z = (z <= 126) ? z = 0 : z -= 126;
            ativa();          
        }
    }
}
