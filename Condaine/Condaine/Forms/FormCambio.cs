using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Condaine
{
    public partial class FormCambio : Form
    {
        Central cent = new Central();
        public FormCambio()
        {
            InitializeComponent();
            cent.Iniciar(panelCota);
            if (cent.getModoNoturno() == true)
            {
                cent.setaCor(40, 40, 40, 40);
                panelCota.BackColor = panel1.BackColor = Color.FromArgb(40, 40, 40);
                button1.BackColor = panelMain.BackColor = panel2.BackColor = Color.FromArgb(45, 45, 45);
            }
            else { cent.setaCor(70, 60, 0, 64); }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            cent.corClick(sender, cent.getModoNoturno());
            cent.setPanel(panelMain);
            cent.abreForm(new FormOutros());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            cent.corClick(sender, cent.getModoNoturno());
        }

        private void iconButton1_MouseHover(object sender, EventArgs e)
        {
            button1.Visible = true;
            Button valor = (Button)sender;
            if (valor.Text.Contains("Dólar"))
            {
                this.panel2.Size = new System.Drawing.Size(1134, 220);
                button1.Text = "Veja as cotações históricas do Dólar de 2008 até hoje.";
            }
            else
            {
                this.panel2.Size = new System.Drawing.Size(1134, 280);
                button1.Text = "Veja as cotações históricas do Euro de 2008 até hoje. (Em breve)";
            }
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            button1.Visible = false;
        }
    }
}
