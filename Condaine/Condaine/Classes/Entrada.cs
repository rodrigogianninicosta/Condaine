using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condaine
{
    public class Entrada
    {
        //Nome da empresa escolhida pelo usuário
        private static String nome = " ";
        public void setNome(string _nome) { nome = _nome; }
        public String getNome() { return nome; }

        //Modo Noturno
        private static bool modoNoturno;
        public void setModoNoturno(bool _modoNoturno) { modoNoturno = _modoNoturno; }
        public bool getModoNoturno() { return modoNoturno; }
    }
}
