using System;
using System.Drawing;
using System.Windows.Forms;

namespace Progetto_Market_Admin
{
    public partial class FormShowUsers : Form
    {
        public FormShowUsers()
        {
            InitializeComponent();
            Ausiliare.DataGridViewStyle(dataGridView1);
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LetturaDati();
        }

        public void LetturaDati()
        {
            var result = DB_Operation.GetListaUtenti();

            if (string.IsNullOrEmpty(result.Errore))
            {
                if (result.ListaUtenti.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var item in result.ListaUtenti)
                    {
                        dataGridView1.Rows.Add(item.ID, item.Nome, item.Cognome, item.Utenza,item.Passaparola,item.Profilo,item.Attivo);
                    }

                    dataGridView1.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show(result.Errore, "Lettura Utenti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmUsers_SizeChanged(object sender, EventArgs e)
        {
            grbSearch.Location = new Point((this.Width - grbSearch.Width)/2, grbSearch.Location.Y);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //new FormCreateUtente(this,1,0,string.Empty,string.Empty,string.Empty,string.Empty,0).ShowDialog();
            new FormCreateAndUpdateUtente(this).ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];

            int id = Convert.ToInt32(dataGridViewRow.Cells[0].Value);
            string nome = dataGridViewRow.Cells[1].Value.ToString();
            string cognome = dataGridViewRow.Cells[2].Value.ToString();
            string utenza = dataGridViewRow.Cells[3].Value.ToString();
            string passaparola = dataGridViewRow.Cells[4].Value.ToString();
            int profilo = Convert.ToInt32(dataGridViewRow.Cells[5].Value);

            if (e.ColumnIndex == dataGridView1.Columns[7].Index && e.RowIndex >= 0)
            {
                new FormCreateAndUpdateUtente(this, 2, id, nome, cognome, utenza, passaparola, profilo).ShowDialog();
            }
            if (e.ColumnIndex == dataGridView1.Columns[8].Index && e.RowIndex >= 0)
            {
                new FormCreateAndUpdateUtente(this, 3, id, nome, cognome, utenza, passaparola, profilo).ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
