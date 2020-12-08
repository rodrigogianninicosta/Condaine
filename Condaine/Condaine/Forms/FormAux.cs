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
    public partial class FormAux : Form
    {
        Central cent = new Central();
        NovoFast fk = new NovoFast();
        Setup set = new Setup();

        public FormAux()
        {
            InitializeComponent();
            valor = null;
            listBox1.Items.Add("  Selecione o intervalo de tempo ou o ano desejado.");
            if (cent.getModoNoturno() == true)
            {
                cent.abreCorBotao(true);
                listBox1.BackColor = textBox1.BackColor = panel2.BackColor = panel3.BackColor = panel5.BackColor = Color.FromArgb(35, 35, 35);
                panel1.BackColor = panel4.BackColor = Color.FromArgb(50, 50, 50);
                listBox1.ForeColor = Color.DarkGray;
                limpaAno();
            }
            else { cent.abreCorBotao(false); }
        }

        #region CorBotao
        private void limpaAno()
        {
            var botoes = new[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13 };
            foreach (var botao in botoes)
            {
                Button valor3 = (Button)botao;
                valor3.BackColor = cent.getColor3();
            }
        }
        private void arrumaAno()
        {
            var botoes = new[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13 };
            if (fk.getYearFinal() != 0)
            {
                foreach (var botao in botoes)
                {
                    Button valor3 = (Button)botao;
                    if (fk.getYear() > fk.getYearFinal())
                    {
                        if (int.Parse(valor3.Text) < fk.getYear() && int.Parse(valor3.Text) > fk.getYearFinal()) { valor3.BackColor = cent.getColor2(); }
                        else if (int.Parse(valor3.Text) == fk.getYear() || int.Parse(valor3.Text) == fk.getYearFinal()) { valor3.BackColor = cent.getColor1(); }
                    }
                    else
                    {
                        if (int.Parse(valor3.Text) < fk.getYearFinal() && int.Parse(valor3.Text) > fk.getYear()) { valor3.BackColor = cent.getColor2(); }
                        else if (int.Parse(valor3.Text) == fk.getYear() || int.Parse(valor3.Text) == fk.getYearFinal()) { valor3.BackColor = cent.getColor1(); }
                    }
                }
            }
            else
            {
                foreach (var botao in botoes)
                {
                    Button valor3 = (Button)botao;
                    if (int.Parse(valor3.Text) == fk.getYear() || int.Parse(valor3.Text) == fk.getYearFinal()) { valor3.BackColor = cent.getColor1(); }
                }
            }
        }
        #endregion

        //Núcleo Principal
        public void carrega(String recebido)
        {
            listBox1.Items.Clear();
            limpaAno();
            arrumaAno();
            if (recebido != null) { busca(recebido); }
            else
            {
                fk.faz();
                foreach (string emp in set.getEmp()) { listBox1.Items.Add("  " + emp); }
            }   
        }

        //Buscar nome digitado pelo usuário
        public void busca(String recebido)
        {
            foreach (String emp in set.getEmp())
            {
                int cont = 0;
                for (int i = 0; i < recebido.Length; i++)
                {
                    try
                    {
                        if (emp[i] != recebido[i])
                        {
                            cont = 0;
                            break;
                        }
                        else { ++cont; }
                    }
                    catch { break; }
                }
                if (cont != 0 || recebido == "") { listBox1.Items.Add("  " + emp); }
            }
        }

        //Chamar o FormResultado
        private void FormAux_DoubleClick(object sender, EventArgs e)
        {
            ListBox valor = (ListBox)sender;
            if (valor.Text != "")
            {
                textBox1.Clear();
                this.Hide();
                cent.setNome(valor.Text.Remove(0,2));
                cent.setaNomeFormIbovespa(true);         
                cent.abreForm(cent.iniciarFormResultado());
            }
        }

        //Barra de busca
        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    TextBox valor = (TextBox)sender;
                    if (valor.Text != "") { carrega(valor.Text); }
                    else { carrega(""); }
                }
            }
            catch { }
        }

        //Botão de busca
        private void iconButton14_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "") { carrega(textBox1.Text); }
                else { carrega(""); }
            }
            catch { }
        }

        //Seletor de ano
        static Button valor;
        private void button1_Click(object sender, EventArgs e)
        {
            if (valor != null)
            {
                Button valor2 = (Button)sender;
                fk.setYear(int.Parse(valor.Text));
                listBox1.Visible = false;
                if (valor.Text == valor2.Text)
                {
                    fk.setYearFinal(0);
                    fk.setAlgo("");
                }
                else
                {
                    fk.setYearFinal(int.Parse(valor2.Text));
                    fk.setAlgo(null);          
                }
                valor = null;
                carrega(null);
                listBox1.Visible = true;
            }
            else
            {
                limpaAno();
                valor = (Button)sender;
                valor.BackColor = cent.getColor1();
            }
        }
    }
}
