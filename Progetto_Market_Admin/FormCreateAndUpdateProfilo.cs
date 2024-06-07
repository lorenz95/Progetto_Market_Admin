using System;
using System.Drawing;
using System.Windows.Forms;

namespace Progetto_Market_Admin
{
    public partial class FormCreateAndUpdateProfilo : Form
    {
        private FormShowProfili FormShowProfili;
        int Action, Id;
        string Tipo, Descrizione;
        
        public FormCreateAndUpdateProfilo(FormShowProfili frm, int action, string tipo, string descrizione, int id)
        {
            InitializeComponent();
            FormShowProfili = frm;
            Action = action;
            Tipo = tipo;
            Descrizione = descrizione;
            Id = id;
        }

        private void onLoad()
        {
            switch (Action)
            {
                case 1: //creazione
                    lblTitle.Text = "Crea Profilo";
                    btnAction.Text = "Crea Profilo";
                    btnAction.BackColor = Color.Green;
                    break;
                case 2: //modifica
                    lblTitle.Text = "Modifica Profilo";
                    btnAction.Text = "Modifica Profilo";
                    btnAction.BackColor = Color.Orange;

                    //popolazione dei campi

                    txbTipo.Text = Tipo;
                    txbDesc.Text = Descrizione;


                    break;
                case 3: //eliminazione
                    lblTitle.Text = "Elimina Profilo";
                    btnAction.Text = "Elimina Profilo";
                    btnAction.BackColor = Color.Red;

                    //popolazione dei campi

                    txbTipo.Text = Tipo;
                    txbDesc.Text = Descrizione;

                    txbTipo.Enabled = false;
                    txbDesc.Enabled = false;

                    break;
            }
        }

        private void onAction(string action)
        {
            switch (action)
            {
                case "crea":
                    CreateProfil();
                    break;
            }
            /*
            switch (Action)
            {
                case 1:
                    CreateProfil();
                    break;
                case 2:
                    ModifyProfil();
                    break;
                case 3:
                    DeleteProfil();
                    break;
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onAction("crea");
        }

        private void CreateProfil()
        {
            try
            {
                Modelli.Profilo profilo = new Modelli.Profilo
                {
                    Tipo = txbTipo.Text,
                    Descrizione = txbDesc.Text,
                    ID = DB_Operation.GetIdProfili()
                };

                string info;
                DB_Operation.CreateProfilo(profilo, out info);
                if (!string.IsNullOrEmpty(info))
                {
                    MessageBox.Show(info, "Errore durante la creazione del profilo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message + "\n" + ex.StackTrace), "Errore durante la creazione del profilo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txbDesc.Clear(); 
                txbTipo.Clear();
                FormShowProfili.LetturaDati();
            }
        }

        private void ModifyProfil()
        {
            try
            {
                Modelli.Profilo profilo = new Modelli.Profilo
                {
                    Tipo = txbTipo.Text,
                    Descrizione = txbDesc.Text,
                    ID = Id
                };

                string info;
                DB_Operation.ModificaProfilo(profilo, out info);
                if (!string.IsNullOrEmpty(info))
                {
                    MessageBox.Show(info, "Errore durante la modifica del profilo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message + "\n" + ex.StackTrace), "Errore durante la modifica del profilo nel interface", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txbDesc.Clear(); txbTipo.Clear();
                FormShowProfili.LetturaDati();
                this.Close();
            }
        }

        private void DeleteProfil()
        {
            try
            {
                Modelli.Profilo profilo = new Modelli.Profilo
                {
                    Tipo = txbTipo.Text,
                    Descrizione = txbDesc.Text,
                    ID = Id
                };

                string info;
                DB_Operation.EliminazioneProfilo(profilo, out info);
                if (!string.IsNullOrEmpty(info))
                {
                    MessageBox.Show(info, "Errore durante la modifica del profilo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message + "\n" + ex.StackTrace), "Errore durante la modifica del profilo nel interface", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txbDesc.Clear(); txbTipo.Clear();
                FormShowProfili.LetturaDati();
                this.Close();
            }
        }

        private void frmGestProfilo_Load(object sender, EventArgs e)
        {
            onLoad();
        }
    }
}
