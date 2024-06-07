using System;
using System.Linq;
using System.Windows.Forms;

namespace Progetto_Market_Admin
{
    using static Modelli;

    public partial class FormCreateAndUpdateFornitore : Form
    {
        private FormShowFornitori FormShowFornitori;

        private bool checkValidityString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("Compilare correttamente il campo " + str);
                return false;
            }
            return true;
        }

        private void CreateFornitori()
        {
            string TextPIva = TxbPiva.Text;
            string TextRagSoc = TxbRagSoc.Text;
            string TextNumTel = TxbNumTel.Text;
            string TextEmail = TxbMail.Text;
            string TextIndirizzo = TxbIndirizzo.Text;

            if (!checkValidityString(TextPIva) || !checkValidityString(TextRagSoc) 
                || !checkValidityString(TextNumTel) || !checkValidityString(TextEmail)
                || !checkValidityString(TextIndirizzo))
            {
                return;
            } else if (TextNumTel.Length != 10) {
                MessageBox.Show("Il N Tel deve avere 10 cifre.");
                return;
            }
            /*
            if (string.IsNullOrEmpty(TextPIva))
            {
                MessageBox.Show("Compilare correttamente la P.IVA");
                return;
            }

            if (string.IsNullOrEmpty(TextRagSoc))
            {
                MessageBox.Show("Compilare correttamente la Rag Soc");
                return;
            }

            if (string.IsNullOrEmpty(TextNumTel))
            {
                MessageBox.Show("Compilare correttamente il Num Telefono");
                return;
            }
            else {
                if (TextNumTel.Length != 10)
                {
                    MessageBox.Show("Il N Tel deve avere 10 cifre.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(TextEmail))
            {
                MessageBox.Show("Compilare correttamente la mail");
                return;
            }

            if (string.IsNullOrEmpty(TextIndirizzo))
            {
                MessageBox.Show("Compilare correttamente l'indirizzo");
                return;
            }
            */

            int idFornitore = DB_Operation.GetIdFornitore();
            Fornitore fornitore = new Fornitore()
            {
                ID = idFornitore, 
                PIva = TextPIva,
                RagSoc = TextRagSoc,
                NumTel = TextNumTel,
                Email = TextEmail,
                Indirizzo = TextIndirizzo, 
                Attivo = true
            };

            string info;
            DB_Operation.CreateFornitore(fornitore, out info);

            if (string.IsNullOrEmpty(info))
            {
                FormShowFornitori.LetturaDati();
                foreach (Control control in Controls.OfType<TextBox>())
                {
                    var obj = (TextBox)control;
                    obj.Text = string.Empty;
                }
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Information;
                MessageBox.Show(info, "Template Creazione Fornitore", MessageBoxButtons.OK, icon);
            }
        }

        private void btnFornitore_Click(object sender, EventArgs e)
        {
            CreateFornitori();
        }
    }
}
