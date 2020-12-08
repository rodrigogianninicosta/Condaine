using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Condaine
{
    public class CorBotao
    {
        static Color cor1;
        static Color cor2;
        static Color cor3;
        public CorBotao(bool noturno)
        {
            if (noturno == false)
            {
                cor1 = Color.FromArgb(60, 0, 64);
                cor2 = Color.FromArgb(240, 0, 64);
                cor3 = Color.FromArgb(160, 0, 64);
            }
            else
            {
                cor1 = Color.FromArgb(35, 35, 35);
                cor2 = Color.FromArgb(80, 80, 80);
                cor3 = Color.FromArgb(50, 50, 50);
            }
        }
        public Color getColor1() { return cor1; }
        public Color getColor2() { return cor2; }
        public Color getColor3() { return cor3; }
    }
}
