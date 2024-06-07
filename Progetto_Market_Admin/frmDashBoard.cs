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
    public partial class frmDashBoard : Form
    {
        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmLogIn().Show();
        }

        private void frmDashBoard_SizeChanged(object sender, EventArgs e)
        {
            this.lblSlogan.Location = new Point((this.pnlTop.Width - this.lblSlogan.Width)/2, 
                                                                                          this.lblSlogan.Location.Y);
            this.lblCopyRight.Location = new Point((this.pnlBottom.Width - this.lblCopyRight.Width) / 2, 
                                                                                       this.lblCopyRight.Location.Y);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Ausiliare.CaricaForm(new frmAdmin(),pnlForm);
        }
    }
}
