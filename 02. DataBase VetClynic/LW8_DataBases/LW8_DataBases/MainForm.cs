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
    }
}
