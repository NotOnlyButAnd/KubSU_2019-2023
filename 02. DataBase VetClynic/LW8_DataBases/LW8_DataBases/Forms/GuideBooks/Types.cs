using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LW8_DataBases
{
    public partial class Types : Form
    {
        public Types()
        {
            InitializeComponent();
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // записываем данные из DataGridView в DataSet
                dataGridView1.DataSource = veterinary_ClinicDataSet.Illness;

                // обновляем БД
                typesTableAdapter.Update(veterinary_ClinicDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА");
            }
        }

        private void Types_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "veterinary_ClinicDataSet.Types". При необходимости она может быть перемещена или удалена.
            this.typesTableAdapter.Fill(this.veterinary_ClinicDataSet.Types);

        }

        private void deleteCurrentNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // в буферную таблицу записываем текущую таблицу из DataGrid
            CurrencyManager curMan = (CurrencyManager)
                dataGridView1.BindingContext[dataGridView1.DataSource];
            // если таблица непустая, то
            if (curMan.Count > 0)
            {
                curMan.RemoveAt(curMan.Position);   // удаляем текущую позицию
                // по логике, сохранение в БД нам здесь не нужно при удалении
                // ведь у нас есть кнопка "сохранить изменения"
                //illnessTableAdapter.Update(veterinary_ClinicDataSet);
            }
        }

        private void exitFromProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // закрываем текущую форму
            this.Close();

            // выводим на 1 план главную форму
            Program.mainForm.Activate();
        }
    }
}
