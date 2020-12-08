using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Condaine
{
    public partial class FormGrafico : Form
    {
        Central cent = new Central();
        static String exonerador = "";
        String mes = "";
        static Zero p0 = new Zero();
        Entrada ent = new Entrada();
        Setup sec = new Setup();
        public FormGrafico()
        {
            InitializeComponent();
            if (cent.getModoNoturno() == true)
            {
                chart1.BackColor = Color.FromArgb(64, 64, 64);
                chart1.BackSecondaryColor = Color.DimGray;
                chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Percent05;
                panel2.BackColor = Color.FromArgb(50, 50, 50);
                panel1.BackColor = panel6.BackColor = panel5.BackColor = listBox1.BackColor = Color.FromArgb(45, 45, 45);
                panel3.BackColor = Color.FromArgb(40, 40, 40);
                var botoes = new[] { button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25, button26};
                foreach (var botao in botoes)
                {
                    Button val = (Button)botao;
                    val.ForeColor = val.FlatAppearance.BorderColor= Color.FromArgb(80, 80, 80);
                }
            }
            chamaButton();
            carrega();
        }

        #region Botoes
        public void chamaButton()
        {
            List<String> vari = sec.getTipos().Distinct().ToList();
            if (vari.Count <= 250)
            {
                listBox1.Visible = false;
                geraBotao(ent.getNome());    
                foreach (string imp in vari) { geraBotao(imp.Replace(" ", "")); }
            }
            else
            {
                listBox1.Visible = true;
                listBox1.Items.Add(ent.getNome());
                foreach (string imp in vari) { listBox1.Items.Add(imp.Replace(" ", "")); }
            }
        }
        //Selecionar tipos das ações
        public void clickBotao(object sender, EventArgs e)
        {
            try
            {
                Button valor = (Button)sender;
                if (valor.Text == ent.getNome())
                {
                    exonerador = null;
                    cent.setaNomeFormIbovespa(true);
                }
                else
                {
                    exonerador = valor.Text;
                    String guard = cent.getNome();
                    cent.setNome(exonerador);
                    cent.setaNomeFormIbovespa(true);
                    cent.setNome(guard);
                }
            }
            catch
            {
                ListBox valor = (ListBox)sender;
                if (valor.Text == ent.getNome())
                {
                    exonerador = null;
                    cent.setaNomeFormIbovespa(true);
                }
                else
                {
                    exonerador = valor.Text;
                    String guard = cent.getNome();
                    cent.setNome(exonerador);
                    cent.setaNomeFormIbovespa(true);
                    cent.setNome(guard);
                }
            }
            mes = "";
            carrega();
        }
        //Cria os botões com os tipos das ações
        public void geraBotao(String n )
        {
            Button btn = new Button();
            btn.Text = n;
            btn.Dock = DockStyle.Bottom;
            btn.Size = new Size(100, 50);
            btn.FlatAppearance.BorderSize = 1;
            btn.Font = new System.Drawing.Font("Arial Narrow", 10F);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            if (cent.getModoNoturno() == true) { btn.ForeColor = btn.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80); }
            else
            {
                btn.ForeColor = Color.FromArgb(220, 0, 64);
                btn.FlatAppearance.BorderColor = Color.FromArgb(220, 0, 64);
            }       
            btn.Click += new EventHandler(clickBotao);
            panel6.Controls.Add(btn);
        }
        //Mostra os botões e os tipos das ações
        public void popula()
        {
            arrumaAno();
            if (p0.getAlgo() == null || exonerador == "" || exonerador == null)
            {
                button14.Visible = button15.Visible = button16.Visible = button17.Visible = button18.Visible = button19.Visible = button20.Visible = button21.Visible = button22.Visible = button23.Visible = button24.Visible = button25.Visible = button26.Visible = false;
            }
            else
            {
                button14.Visible = button15.Visible = button16.Visible = button17.Visible = button18.Visible = button19.Visible = button20.Visible = button21.Visible = button22.Visible = button23.Visible = button24.Visible = button25.Visible = button26.Visible = true;
            }
        }
        #endregion

        //Núcleo Principal
        //Preenche o Chart
        public void carrega()
        {
            popula();
            chart1.Series[0].Points.Clear();
            List<String> year, med, tipos;
            year = sec.getAammdd();
            med = sec.getEncer();
            tipos = sec.getTipos();
            String ano = null, algo = null, compar = "", salv = null;
            int conteiro = 0;
            double sav = 0;
            bool sair = false;
            for (int i = 0; i < year.Count; i++)
            {
                if (p0.getAlgo() == null && i == year.Count - 1)
                {
                    try
                    {
                        chart1.Series[0].Points.AddXY(ano, sav / conteiro);
                    }
                    catch
                    {
                        chart1.Series[0].Points.AddXY(ano, sav / 1);
                    }
                    break;
                }
                else
                {
                    //Entrada para vários anos
                    if (tipos[i].Replace(" ", "") == exonerador || exonerador == null || exonerador == "" || i == year.Count - 1)
                    {
                        algo = year[i];
                        if (p0.getAlgo() == null)
                        {
                            if (ano == null || algo[6].ToString() + algo[7].ToString() + algo[8].ToString() + algo[9].ToString() != ano)
                            {
                                if (sair == true)
                                {
                                    try
                                    {
                                        chart1.Series[0].Points.AddXY(ano, sav / conteiro);
                                    }
                                    catch
                                    {
                                        chart1.Series[0].Points.AddXY(ano, sav / 1);
                                    }
                                    conteiro = 1;
                                    sav = 0;
                                }
                                ano = algo[6].ToString() + algo[7].ToString() + algo[8].ToString() + algo[9].ToString();
                                i--;
                                sair = true;
                            }
                            else
                            {
                                sav += double.Parse(med[i]);
                                conteiro++;
                            }
                        }
                        else
                        {
                            //Entrada para um mês 
                            if (mes != "")
                            {
                                if (algo[3].ToString() + algo[4].ToString() == mes && i != year.Count - 1)
                                {
                                    salv = algo[0].ToString() + algo[1].ToString();
                                    chart1.Series[0].Points.AddXY(salv, double.Parse(med[i]));
                                }
                                else
                                {
                                    if (int.Parse(algo[3].ToString() + algo[4].ToString()) > int.Parse(mes))
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //Entrada para apenas um ano completo
                                if (i == year.Count - 1)
                                {
                                    compar = algo[3].ToString() + algo[4].ToString();
                                    conteiro++;
                                    sav += double.Parse(med[i]);
                                    sair = true;
                                }
                                if (compar == algo[3].ToString() + algo[4].ToString() && sair == false || i == 0)
                                {
                                    compar = algo[3].ToString() + algo[4].ToString();
                                    conteiro++;
                                    sav += double.Parse(med[i]);
                                }
                                else
                                {
                                    try
                                    {
                                        chart1.Series[0].Points.AddXY(compar, sav / conteiro);
                                    }
                                    catch
                                    {
                                        chart1.Series[0].Points.AddXY(compar, sav / 1);
                                    }
                                    conteiro = 1;
                                    sav = double.Parse(med[i]);
                                    compar = algo[3].ToString() + algo[4].ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        //Voltar para o FormResultado
        private void iconButton4_Click(object sender, EventArgs e)
        {
            cent.setaNomeFormIbovespa(true);
            cent.abrirFormResultado();
            exonerador = null;
            this.Hide();
        }

        //Selecionar mês
        private void listBox4_DoubleClick(object sender, EventArgs e)
        {
            Button valor = (Button)sender;
            String guard = cent.getNome();
            if (valor.Text != "Anual")
            {
                cent.setNome(exonerador + "\n(" + valor.Text + ')');
                cent.setaNomeFormIbovespa(true);
            }
            else
            {
                cent.setNome(exonerador);
                cent.setaNomeFormIbovespa(true);
            }
            cent.setNome(guard);
            switch (valor.Text)
            {
                case "Janeiro":
                    mes = "01";
                    break;
                case "Fevereiro":
                    mes = "02";
                    break;
                case "Março":
                    mes = "03";
                    break;
                case "Abril":
                    mes = "04";
                    break;
                case "Maio":
                    mes = "05";
                    break;
                case "Junho":
                    mes = "06";
                    break;
                case "Julho":
                    mes = "07";
                    break;
                case "Agosto":
                    mes = "08";
                    break;
                case "Setembro":
                    mes = "09";
                    break;
                case "Outubro":
                    mes = "10";
                    break;
                case "Novembro":
                    mes = "11";
                    break;
                case "Dezembro":
                    mes = "12";
                    break;
                case "Anual":
                    mes = "";
                    break;
            }
            carrega();
        }

        //Selecionar ano
        static Button valor;
        private void button1_Click(object sender, EventArgs e)
        {
            if (valor != null)
            {
                panel6.Controls.Clear();
                chart1.Visible = false;
                Button valor2 = (Button)sender;
                p0.setYear(int.Parse(valor.Text));
                if (valor.Text == valor2.Text)
                {
                    p0.setYearFinal(0);
                    p0.setAlgo("");
                }
                else
                {
                    p0.setYearFinal(int.Parse(valor2.Text));
                    p0.setAlgo(null);
                }
                valor = null;
                p0.faz();
                p0.fazer();
                chamaButton();
                exonerador = "";
                mes = "";
                carrega();
                cent.setaNomeFormIbovespa(true);
                chart1.Visible = true;
            }
            else
            {
                limpaAno();
                valor = (Button)sender;
                valor.BackColor = cent.getColor1();
            }
        }

        #region CorBotão
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
            if (p0.getYearFinal() != 0)
            {
                foreach (var botao in botoes)
                {
                    Button valor3 = (Button)botao;
                    if (p0.getYear() > p0.getYearFinal())
                    {
                        if (int.Parse(valor3.Text) < p0.getYear() && int.Parse(valor3.Text) > p0.getYearFinal()) { valor3.BackColor = cent.getColor2(); }
                        else if (int.Parse(valor3.Text) == p0.getYear() || int.Parse(valor3.Text) == p0.getYearFinal()) { valor3.BackColor = cent.getColor1(); }
                    }
                    else
                    {
                        if (int.Parse(valor3.Text) < p0.getYearFinal() && int.Parse(valor3.Text) > p0.getYear()) { valor3.BackColor = cent.getColor2(); }
                        else if (int.Parse(valor3.Text) == p0.getYear() || int.Parse(valor3.Text) == p0.getYearFinal()) { valor3.BackColor = cent.getColor1(); }
                    }
                }
            }
            else
            {
                foreach (var botao in botoes)
                {
                    Button valor3 = (Button)botao;
                    if (int.Parse(valor3.Text) == p0.getYear() || int.Parse(valor3.Text) == p0.getYearFinal()) { valor3.BackColor = cent.getColor1(); }
                }
            }
        }
        #endregion
    }
}
