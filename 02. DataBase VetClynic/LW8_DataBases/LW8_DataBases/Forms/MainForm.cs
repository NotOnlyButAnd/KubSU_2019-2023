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
    public partial class MainForm : Form
    {
        public System.Data.SqlClient.SqlConnection connect;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Создаем подключение к БД, которая лежит на сервере, который лежит на компе
            String connectionString = "Data Source = DESKTOP-TDTVJ8G; " +
                "Initial Catalog = Veterinary_Clinic; Integrated Security = True";
            connect = new
                System.Data.SqlClient.SqlConnection(connectionString);
            connect.Open();
        }


        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Types typesForm = new Types();
            typesForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void illnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Illness illnessForm = new Illness();
            illnessForm.Show();
        }

        private void breedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Breeds breedsForm = new Breeds();
            breedsForm.Show();
        }

        private void ownersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Owners ownersForm = new Owners();
            ownersForm.Show();
        }

        private void petsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pets petsForm = new Pets();
            petsForm.Show();
        }

        private void petsIllnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PetsIllness petsIllnessForm = new PetsIllness();
            petsIllnessForm.Show();
        }

        private void visitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visits visitsForm = new Visits();
            visitsForm.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports reportsForm = new Reports();
            reportsForm.Show();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram aboutProgramForm = new AboutProgram();
            aboutProgramForm.Show();
        }
    }
}
