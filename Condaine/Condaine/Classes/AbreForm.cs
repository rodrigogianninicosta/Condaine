using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condaine
{
    public class AbreForm
    {
        private Form activeForm = null;
        static Panel panelMain;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void fechaForm()
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }

        public void setPanel(Panel _pan) { panelMain = _pan; }
    }
}
