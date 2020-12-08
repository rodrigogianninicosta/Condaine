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
    public partial class FormIbovespa : Form
    {
        Central cent = new Central();

        public FormIbovespa()
        {
            InitializeComponent();
            cent.Iniciar(panelCota);
            if (cent.getModoNoturno() == true) 
            {
                cent.setaCor(40, 40, 40, 40);
                panelCota.BackColor = panel1.BackColor = button2.BackColor = button3.BackColor = button3.FlatAppearance.MouseDownBackColor = button3.FlatAppearance.MouseOverBackColor = button2.FlatAppearance.MouseDownBackColor = button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 40, 40);
                panelMain.BackColor = panel2.BackColor = button1.BackColor = Color.FromArgb(45, 45, 45);
                button2.ForeColor = button2.FlatAppearance.BorderColor = button3.ForeColor = button3.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
            }
            else { cent.setaCor(90, 80, 0, 64); }     
        }

        #region ButtonClick
        //Cotações Históricas
        //Chama o FormAux
        private void iconButton1_Click(object sender, EventArgs e)
        {
            cent.fechaForm();
            setaNome(false);
            panel2.Visible = false;
            cent.corClick(sender, cent.getModoNoturno());
            cent.setPanel(panelMain);
            cent.abreForm(cent.iniciarFormAux());
        }
        //Cotações em Tempo Real
        private void iconButton2_Click(object sender, EventArgs e)
        {
            cent.fechaForm();
            setaNome(false);
            panel2.Visible = false;
            cent.corClick(sender, cent.getModoNoturno());
            cent.setPanel(panelMain);
            cent.abreForm(new FormIbovTempoReal());
        }
        //Cotações Futuras
        private void iconButton3_Click(object sender, EventArgs e)
        {
            cent.corClick(sender, cent.getModoNoturno());
        }
        #endregion

        #region Mensagens
        //Mesagens ao colocar o mouse nos botões
        private void iconButton1_MouseHover(object sender, EventArgs e)
        {
            button1.Visible = true;
            Button valor = (Button)sender;
            if(valor.Text.Contains("Históricas"))
            {
                this.panel2.Size = new System.Drawing.Size(1150, 130);        
                button1.Text = "Veja as cotações históricas das empresas da Ibovespa entre os períodos de 2008 a 2020.";
            }
            else if(valor.Text.Contains("Real"))
            {
                this.panel2.Size = new System.Drawing.Size(1150, 190);
                button1.Text = "Veja as cotações do dia de hoje das empresas da Ibovespa.";
            }
            else
            {
                this.panel2.Size = new System.Drawing.Size(1150, 250);
                button1.Text = "Veja uma previsão das cotações das empresas da Ibovespa. (Em breve)";
            }
       
        }
        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            button1.Visible = false;
        }
        #endregion

        //Mostar nome da Empresa
        public void setaNome(bool saber)
        {
            if (saber == true)
            {
                Entrada ent = new Entrada();
                button2.Visible = true;
                button2.Text = ent.getNome();
                button3.Visible = true;
                MudaAno mud = new MudaAno();
                if (mud.getYearFinal() != 0) { button3.Text = mud.getYear() + " - " + mud.getYearFinal(); }
                else { button3.Text = mud.getYear().ToString(); }
            }
            else
            {
                button2.Visible = false;
                button3.Visible = false;
            }
        }
    }
}
