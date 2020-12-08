using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Condaine
{
    public partial class FormMenu : Form
    {
        Central cent = new Central();
        static SoundPlayer simpleSound;

        public FormMenu()
        {
            InitializeComponent();
            cent.Iniciar(panelMenu);
            cent.setaCor(30, 40, 0, 64);
            iconButton2_Click(iconButton1, null);
            simpleSound = new SoundPlayer("Elise.wav");
            simpleSound.Play();
        }

        //Limpa as cores
        private void limpaCor()
        {
            var botoes = new[] { iconButton1, iconButton2, iconButton3, iconButton5, iconButton4 };
            foreach (var botao in botoes)
            {
                Button valor3 = (Button)botao;
                cent.corClick(valor3,cent.getModoNoturno());
            }
        }

        #region ButtonClick
        //Botão Home
        private void iconButton2_Click(object sender, EventArgs e)
        {
            cent.fechaForm();
            cent.corClick(sender,cent.getModoNoturno());
        }
        //Botão Ibovespa
        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            cent.fechaForm();
            cent.corClick(sender,cent.getModoNoturno());
            cent.setPanel(panelMain);
            cent.abreForm(cent.iniciarFormIbovespa());
        }
        //Botão Câmbio
        private void iconButton2_Click_2(object sender, EventArgs e)
        {
            cent.fechaForm();
            cent.corClick(sender,cent.getModoNoturno());
            cent.setPanel(panelMain);
            cent.abreForm(new FormCambio());
        }
        //Botão Modo Noturno
        private void iconButton4_Click(object sender, EventArgs e)
        {
            cent.fechaForm();
            if (pictureBox1.BackColor == System.Drawing.Color.WhiteSmoke )
            {
                cent.setModoNoturno(true);
                pictureBox1.Image = global::Condaine.Properties.Resources.trans3;
                pictureBox1.BackColor = Color.FromArgb(51, 51, 51);
                iconButton4.Text = "Modo Normal";
                iconButton4.IconChar = FontAwesome.Sharp.IconChar.Sun;
                panelTitleBar.BackColor = panelLogo.BackColor = panelMenu.BackColor = iconButton6.FlatAppearance.MouseDownBackColor = iconButton6.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 30, 30);
                cent.setaCor(30, 30, 30, 30);
            }
            else
            {
                cent.setModoNoturno(false);
                pictureBox1.Image = global::Condaine.Properties.Resources.trans2;
                pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
                iconButton4.Text = "Modo Noturno";
                iconButton4.IconChar = FontAwesome.Sharp.IconChar.Adjust;
                panelTitleBar.BackColor = panelLogo.BackColor = panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                cent.setaCor(30, 40, 0, 64);
            }
            limpaCor();
        }
        //Música
        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (iconButton5.IconChar == FontAwesome.Sharp.IconChar.Microphone)
            {
                simpleSound.Play();
                iconButton5.Text = "Parar Música";
                iconButton5.IconChar = FontAwesome.Sharp.IconChar.MicrophoneSlash;
            }
            else
            {
                simpleSound.Stop();
                iconButton5.Text = "Retomar Música";
                iconButton5.IconChar = FontAwesome.Sharp.IconChar.Microphone;
            }
        }
        //Botão sair
        private void iconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        //Relógio
        private void timer1_Tick(object sender, EventArgs e) { iconButton6.Text = DateTime.Now.ToLongTimeString(); }

        #region ArrastaForm
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
