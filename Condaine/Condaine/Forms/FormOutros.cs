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
    public partial class FormOutros : Form
    {
        Central cent = new Central();
        EstiloBotoes eb = new EstiloBotoes();
        Cambial camb = new Cambial();
        Setup sec = new Setup();
        public FormOutros()
        {
            InitializeComponent();
            cent.Iniciar(panelCota);
            if (cent.getModoNoturno() == true)
            {
                cent.setaCor(45, 45, 45, 45);
                panelCota.BackColor = panel3.BackColor = Color.FromArgb(45, 45, 45);
                listBox3.BackColor = panel4.BackColor = panel4.BackColor =  panel7.BackColor = button16.BackColor = Color.FromArgb(50, 50, 50);
                button14.BackColor = listView1.BackColor = panel1.BackColor = Color.FromArgb(35, 35, 35);
                button14.ForeColor = Color.FromArgb(80, 80, 80);
            }
            else { cent.setaCor(90, 80, 0, 64); }
        }
        //Núcleo principal
        public void carrega()
        {
            listView1.Items.Clear();
            listBox3.Items.Clear();
            listBox3.Items.Add("                        DATA" + " \u2BC5");
            listBox3.Items.Add("                      COMPRA");
            listBox3.Items.Add("                     VENDA");
            foreach (string value in sec.getAmd()) { listView1.Items.Add(" " + value); }
            int i = 0;
            foreach (string value in sec.getCompra())
            {
                listView1.Items[i].SubItems.Add(value);
                ++i;
            }
            i = 0;
            foreach (string value in sec.getVenda())
            {
                listView1.Items[i].SubItems.Add(value);
                ++i;
            }
        }

        //Botão Cotações Históricas
        private void iconButton4_Click(object sender, EventArgs e)
        {
            cent.corClick(sender, cent.getModoNoturno());
            listBox3.Items.Clear();
            listView1.Items.Clear();
            button14.Visible = false;
            listView1.Visible = panel4.Visible = panel6.Visible = true;
            listBox3.Items.Add("  Selecione o ano desejado.");
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            cent.corClick(sender, cent.getModoNoturno());
            listBox3.Items.Clear();
            panel4.Visible = false;
            panel6.Visible = button14.Visible = true;
            PegaWeb pw = new PegaWeb();
            String pega = pw.pegar();
            if (pega.Contains("OFF")) { button14.Text = pw.pegar(); }
            else { button14.Text = "R$ " + pw.pegar(); }         
            listBox3.Items.Clear();
            listBox3.Items.Add("  " + DateTime.Today.ToLongDateString());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(Em breve)");
        }

        //Seletor de ano
        private void button1_Click(object sender, EventArgs e)
        {
            Button aux = (Button)sender;
            if (aux.Text == "Todos") { camb.selectDolar(0); }
            else { camb.selectDolar(int.Parse(aux.Text)); }
            carrega();
        }
    }
}
