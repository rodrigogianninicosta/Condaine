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
    public partial class FormResultado : Form
    {
        List<String> tip, ano, inic, max, min, med, enc;
        Central cent = new Central();
        Setup sec = new Setup();
        Zero zer = new Zero();
        static bool pass;

        public FormResultado()
        {
            InitializeComponent();
            if (cent.getModoNoturno() == true)
            {
                listView1.ForeColor = listBox3.ForeColor = Color.DarkGray;
                listView1.BackColor = panel5.BackColor = Color.FromArgb(35, 35, 35);
                listBox3.BackColor =  panel3.BackColor = Color.FromArgb(50, 50, 50);
            }
            carrega();
        }

        //Núcleo Principal
        //Preenche o listView
        public void carrega()
        {
            listView1.Items.Clear();
            limpaAno();
            arrumaAno();
            zer.fazer();
            tip = sec.getTipos();
            ano = sec.getAammdd();
            inic = sec.getAber();
            max = sec.getMax();
            min = sec.getMin();
            med = sec.getMed();
            enc = sec.getEncer();
            int y = 0;
            if (listView1.Sorting == SortOrder.Descending) { listView1.Sorting = SortOrder.None; }
            for (int i = 0; i < sec.getAber().Count; i++)
            {
                try
                {
                    listView1.Items.Add("       " + tip[i]);
                    listView1.Items[y].SubItems.Add(ano[i]);
                    listView1.Items[y].SubItems.Add(inic[i].PadLeft(8, ' '));
                    listView1.Items[y].SubItems.Add(max[i].PadLeft(8, ' '));
                    listView1.Items[y].SubItems.Add(min[i].PadLeft(8, ' '));
                    listView1.Items[y].SubItems.Add(med[i].PadLeft(8, ' '));
                    listView1.Items[y].SubItems.Add("      " + enc[i].PadLeft(8, ' '));
                    ++y;
                }
                catch
                {
                    if (pass == false)
                    {
                        pass = true;
                        MessageBox.Show("Tentando de novo");
                        carrega();
                    }
                }
            }
            listBox3.Items.Clear();
            listBox3.Items.Add("       BVMF");
            if (zer.getYearFinal() < zer.getYear() && zer.getYearFinal() != 0)
            {
                listView1.Sorting = SortOrder.Descending;
                listBox3.Items.Add("         DATA" + " \u2BC6");
            }
            else { listBox3.Items.Add("         DATA" + " \u2BC5"); }
            listBox3.Items.Add("      ABERTURA");
            listBox3.Items.Add("          ALTA");
            listBox3.Items.Add("         BAIXA");
            listBox3.Items.Add("          MEDIA");
            listBox3.Items.Add("   FECHAMENTO");
        }

        //Seletor de ano
        static Button valor;
        private void button15_Click(object sender, EventArgs e)
        {
            pass = true;
            if (valor != null)
            {
                Button valor2 = (Button)sender;
                zer.setYear(int.Parse(valor.Text));
                if (valor.Text == valor2.Text)
                {
                    zer.setYearFinal(0);
                    zer.setAlgo("");
                }
                else
                {
                    listView1.Visible = false;
                    zer.setYearFinal(int.Parse(valor2.Text));
                    zer.setAlgo(null);
                }
                valor = null;
                carrega();
                listView1.Visible = true;
                cent.setaNomeFormIbovespa(true);
            }
            else
            {
                limpaAno();
                valor = (Button)sender;
                valor.BackColor = cent.getColor1();
            }
        }

        //Chamar o FormGráfico
        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            cent.abreForm(cent.iniciarFormGrafico());
        }

        //Voltar para o FormAux
        private void iconButton1_Click(object sender, EventArgs e)
        {
            cent.setaNomeFormIbovespa(false);
            if (pass == true)
            {
                cent.abreForm(cent.iniciarFormAux());
                cent.carregaFormAux();
                pass = false;
            }
            else
            {
                cent.abrirFormAux();
            }
            this.Hide();
        }

        #region CorBotão
        private void limpaAno()
        {
            var botoes = new[] { button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15 };
            foreach (var botao in botoes)
            {
                Button valor3 = (Button)botao;
                valor3.BackColor = cent.getColor3();
            }
        }
        private void arrumaAno()
        {
            var botoes = new[] { button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15 };
            if (zer.getYearFinal() != 0)
            {
                foreach (var botao in botoes)
                {
                    Button valor3 = (Button)botao;
                    if (zer.getYear() > zer.getYearFinal())
                    {
                        if (int.Parse(valor3.Text) < zer.getYear() && int.Parse(valor3.Text) > zer.getYearFinal()) { valor3.BackColor = cent.getColor2(); }
                        else if (int.Parse(valor3.Text) == zer.getYear() || int.Parse(valor3.Text) == zer.getYearFinal()) { valor3.BackColor = cent.getColor1(); }
                    }
                    else
                    {
                        if (int.Parse(valor3.Text) < zer.getYearFinal() && int.Parse(valor3.Text) > zer.getYear()) { valor3.BackColor = cent.getColor2(); }
                        else if (int.Parse(valor3.Text) == zer.getYear() || int.Parse(valor3.Text) == zer.getYearFinal()) { valor3.BackColor = cent.getColor1(); }
                    }
                }
            }
            else
            {
                foreach (var botao in botoes)
                {
                    Button valor3 = (Button)botao;
                    if (int.Parse(valor3.Text) == zer.getYear() || int.Parse(valor3.Text) == zer.getYearFinal()) { valor3.BackColor = cent.getColor1(); }
                }
            }
        }
        #endregion
    }
}
