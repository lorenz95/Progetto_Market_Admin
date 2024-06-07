using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progetto_Market_Admin
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();

            ManageStyleButton();
        }

        private void btnProfili_Click(object sender, EventArgs e)
        {
            Ausiliare.CaricaForm(new FormShowProfili(), pnlForm);
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }

        private void ManageStyleButton()
        {
            foreach (Control control in flpButton.Controls.OfType<Button>())
            {
                var obj = (Button)control;

                obj.Click += delegate
                {
                    foreach (Control control2 in flpButton.Controls.OfType<Button>())
                    {
                        var obj2 = (Button)control2;

                        obj2.BackColor = Color.White;
                        obj2.ForeColor = Color.SteelBlue;
                    }

                    obj.BackColor = Color.LightBlue;
                    obj.ForeColor = Color.Blue;
                };
            }
        }

        private void btnUtenti_Click(object sender, EventArgs e)
        {
            Ausiliare.CaricaForm(new FormShowUsers(), pnlForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ausiliare.CaricaForm(new FormShowFornitori(), pnlForm);
        }
    }
}
