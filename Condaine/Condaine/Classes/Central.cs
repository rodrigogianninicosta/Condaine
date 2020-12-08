using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Condaine
{
    public class Central
    {
        #region Entrada
        Entrada ent = new Entrada();
        public void setNome(string _nome)
        {
            ent.setNome(_nome);
        }
        public String getNome()
        {
            return ent.getNome();
        }
        public void setModoNoturno(bool _modo)
        {
            ent.setModoNoturno(_modo);
        }
        public bool getModoNoturno()
        {
            return ent.getModoNoturno();
        }
        #endregion

        #region EstiloBotoes
        EstiloBotoes eb = new EstiloBotoes();
        public void Iniciar(Panel pan)
        {
            eb.Iniciar(pan);
        }
        public void ativarBotao(object sender, int corAbrir, int corFechar, int corMeio, int corPrincipal)
        {
            eb.ActivateButton(sender, corAbrir, corFechar, corMeio , corPrincipal);
        }
        public void reset()
        {
            eb.reset();
        }
        public void setaCor(int cor1, int cor2, int cor3, int cor4)
        {
            eb.setaCores(cor1, cor2, cor3, cor4);
        }
        public void corClick(object sender, bool noturno)
        {
            eb.cores(sender, noturno);
        }
        #endregion

        #region AbreForm
        AbreForm af = new AbreForm();
        public void abreForm(Form form)
        {
            af.openChildForm(form);
        }
        public void fechaForm()
        {
            af.fechaForm();
        }
        public void setPanel(Panel pan)
        {
            af.setPanel(pan);
        }
        #endregion

        #region FormIbovespa
        static FormIbovespa fi;
        public Form iniciarFormIbovespa()
        {
            return fi = new FormIbovespa();
        }
        public void setaNomeFormIbovespa(bool saber)
        {
            fi.setaNome(saber);
        }
        #endregion

        #region FormAux
        static FormAux fx;
        public Form iniciarFormAux()
        {
            return fx = new FormAux();
        }
        public void abrirFormAux()
        {
            fx.Show();
        }
        public void carregaFormAux()
        {
            fx.carrega(null);
        }
        #endregion

        #region FormResultado
        static FormResultado fr;
        public Form iniciarFormResultado()
        {
            return fr = new FormResultado();
        }
        public void abrirFormResultado()
        {
            fr.Show();
        }
        //public void arrumarFormResultado()
        //{
        //    fr.arrumaAno();
        //}
        #endregion

        #region FormGrafico
        static FormGrafico fg;
        public Form iniciarFormGrafico()
        {
            return fg = new FormGrafico();
        }
        public void abrirFormGrafico()
        {
            fg.Show();
        }
        #endregion

        #region CorBotao
        static CorBotao cb;
        public void abreCorBotao(bool noturno) { cb = new CorBotao(noturno); }
        public Color getColor1() { return cb.getColor1(); }
        public Color getColor2() { return cb.getColor2(); }
        public Color getColor3() { return cb.getColor3(); }
        #endregion
    }
}
