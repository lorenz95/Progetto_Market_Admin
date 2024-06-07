using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Progetto_Market_Admin
{
    class Ausiliare
    {
        public static void CaricaForm(Form form, Panel panel)
        {
            foreach (Control control in panel.Controls.OfType<Form>())
            {
                panel.Controls.Remove(control);
            }

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            form.Show();            
        }

        public static void DataGridViewStyle(DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dgv.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
