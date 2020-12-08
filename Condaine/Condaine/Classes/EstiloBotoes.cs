using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Drawing;

namespace Condaine
{
    public class EstiloBotoes
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public void Iniciar(Panel pan)
        {
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            pan.Controls.Add(leftBorderBtn);
        }
        public void ActivateButton(object senderBtn, int corAbrir, int corFechar, int corMeio,  int corPrincipal)
        {
            if (senderBtn != null)
            {
                Color color = Color.FromArgb(172, 126, 241);
                if (noturno == true) { color = Color.FromArgb(64, 64, 64); }     
                DisableButton(corFechar, corMeio, corPrincipal);
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(corAbrir, corMeio, corPrincipal);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }
        private void DisableButton(int corFechar, int corMeio, int corPrincipal)
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(corFechar, corMeio, corPrincipal);
                currentBtn.ForeColor = Color.WhiteSmoke;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.WhiteSmoke;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        public void reset()
        {
            DisableButton(40, 0, 64);
            leftBorderBtn.Visible = false;
        }

        //Muda a cor do botão ao ser clicado
        int cor1, cor2, cor3, cor4;
        public void setaCores(int _cor1, int _cor2, int _cor3, int _cor4)
        {
            cor1 = _cor1;
            cor2 = _cor2;
            cor3 = _cor3;
            cor4 = _cor4;
        }
        static bool noturno;
        public void cores(object sender, bool _noturno)
        {
            noturno = _noturno;
            if (noturno == true) { ActivateButton(sender, cor1, cor2, cor3, cor4); }
            else { ActivateButton(sender, cor1, cor2, cor3, cor4); }
        }
    }
}
