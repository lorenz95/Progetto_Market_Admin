using System;
using System.Windows.Forms;

namespace Progetto_Market_Admin
{
    public partial class FormShowFornitori : Form
    {
        public FormShowFornitori()
        {
            InitializeComponent();
            Ausiliare.DataGridViewStyle(DataGridFornitori);
        }

        private void grbSearch_Enter(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
        }

        public void LetturaDati()
        {
            var result = DB_Operation.GetListaProfili();
            if (string.IsNullOrEmpty(result.Errore))
            {
                if (result.ListaProfili.Count > 0)
                {
                    var dataGridViewCollection = DataGridFornitori.Rows;
                    
                    dataGridViewCollection.Clear();
                    foreach (var item in result.ListaProfili)
                    {
                        dataGridViewCollection.Add(item.ID, item.Tipo, item.Descrizione);
                    }
                    
                    DataGridFornitori.ClearSelection();
                }
            } else {
                MessageBox.Show(result.Errore, "Lettura Profili", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
