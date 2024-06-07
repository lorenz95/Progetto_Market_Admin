using System;
using System.Windows.Forms;

namespace Progetto_Market_Admin
{
    public partial class FormShowProfili : Form
    {
        public FormShowProfili()
        {
            InitializeComponent();
            Ausiliare.DataGridViewStyle(dataGridView1);
        }

        private void frmProfili_Load(object sender, EventArgs e)
        {
            LetturaDati();
        }

        public void LetturaDati()
        {
            var result = DB_Operation.GetListaProfili();

            if (string.IsNullOrEmpty(result.Errore))
            {
                if (result.ListaProfili.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var item in result.ListaProfili)
                    {
                        dataGridView1.Rows.Add(item.ID, item.Tipo, item.Descrizione);
                    }
                    dataGridView1.ClearSelection();
                }
            } else {
                MessageBox.Show(result.Errore, "Lettura Profili", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new FormCreateAndUpdateProfilo(this,1, string.Empty, string.Empty,0).ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            string tipo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string descrizione = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (e.ColumnIndex == dataGridView1.Columns[3].Index && e.RowIndex >= 0)
            {
                new FormCreateAndUpdateProfilo(this,2, tipo, descrizione, id).ShowDialog();

                id = 0; tipo = string.Empty; descrizione = string.Empty;
            }
            if (e.ColumnIndex == dataGridView1.Columns[4].Index && e.RowIndex >= 0)
            {
                new FormCreateAndUpdateProfilo(this, 3, tipo, descrizione, id).ShowDialog();
                id = 0; tipo = string.Empty; descrizione = string.Empty;
            }
        }
    }
}
