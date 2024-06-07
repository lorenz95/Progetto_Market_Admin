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
    public partial class FormCreateAndUpdateUtente : Form
    {

        private FormShowUsers FormShowUser;
        private readonly string Nome;
        private readonly string Cognome;
        private readonly string Utenza; 
        private readonly string Passaparola;

        private int Action; 
        private int Id; 
        private int Profilo;
        private int v;

        public FormCreateAndUpdateUtente(FormShowUsers formShowUser)
        {
            FormShowUser = formShowUser;
        }

        public FormCreateAndUpdateUtente(FormShowUsers formShowUser, int v, int id, string nome, string cognome, string utenza, string passaparola, int profilo) : this(formShowUser)
        {
            this.v = v;
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Utenza = utenza;
            Passaparola = passaparola;
            Profilo = profilo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            Azione();
        }

        //private void label5_Click(object sender, EventArgs e)
        //{

        //}

        private void FillComboProfili()
        {

            var result = DB_Operation.GetListaProfili();

            if (!string.IsNullOrEmpty(result.Errore))
            {
                MessageBox.Show(result.Errore);
            }
            else
            {
                cmbProfili.DataSource = null;
                cmbProfili.DataSource = result.ListaProfili;
                cmbProfili.ValueMember = "ID";
                cmbProfili.DisplayMember = "Tipo";

                cmbProfili.SelectedIndex = -1;
                cmbProfili.Text = "Scegli il profilo";
            }


        }

        private void frmGestUtenti_Load(object sender, EventArgs e)
        {
            FillComboProfili();
            onLoad();
        }

        private void onLoad()
        {
            switch (Action)
            {
                case 1: //comparizione per creazione utente
                    lblTitle.Text = "Crea Utente";
                    btnAction.Text = "Crea Utente";
                    btnAction.BackColor = Color.Green;
                    break;

                case 2: //comparizione per modifica utente
                    lblTitle.Text = "Modifica Utente";
                    btnAction.Text = "Modifica Utente";
                    btnAction.BackColor = Color.Orange;
                    txbNome.Text = Nome; txbCognome.Text = Cognome; txbUtenza.Text = Utenza;
                    txbPass.Text = Passaparola;
                    cmbProfili.SelectedIndex = Profilo;

                    //foreach (Control control in this.Controls.OfType<ComboBox>())
                    //{
                    //    var obj = (ComboBox)control;
                    //    obj.SelectedItem
                    //}

                    break;
                case 3: //comparizione per eliminazione utente
                    lblTitle.Text = "Elimina Utente";
                    btnAction.Text = "Elimina Utente";
                    btnAction.BackColor = Color.Red;

                    foreach (Control control in this.Controls.OfType<TextBox>())
                    {
                        var obj = (TextBox)control;
                        obj.Enabled = false;
                    }

                    cmbProfili.Enabled = false;

                    break;
            }
        }

        private void Azione()
        {
            switch (Action)
            {
                case 1:
                    CreateUser();
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        private void CreateUser()
        {
            if (!string.IsNullOrEmpty(txbNome.Text) || !string.IsNullOrEmpty(txbCognome.Text) || !string.IsNullOrEmpty(txbUtenza.Text) || !string.IsNullOrEmpty(txbPass.Text) || cmbProfili.SelectedIndex > -1)
            {
                Modelli.Utente utente = new Modelli.Utente()
                {
                    Nome = txbNome.Text.Trim(),
                    Cognome = txbCognome.Text.Trim(),
                    Utenza = txbUtenza.Text.Trim(),
                    Passaparola = txbPass.Text.Trim(),
                    Profilo = Convert.ToInt32(cmbProfili.SelectedValue),
                    ID = DB_Operation.GetIdUtente(),
                    Attivo = true
                };

                string info;
                DB_Operation.CreateUser(utente, out info);

                if (string.IsNullOrEmpty(info))
                {
                    FormShowUser.LetturaDati();

                    foreach (Control control in this.Controls.OfType<TextBox>())
                    {
                        var obj = (TextBox)control;
                        obj.Text = string.Empty;
                    }

                    FillComboProfili();
                }
                else
                {
                    MessageBox.Show(info, "Template Creazione Utente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Compilare corretamente i campi.\nTutti i campi sono obbligatori...");
                return;
            }
        }
    }
}
