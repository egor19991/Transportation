using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Transportation
{
    public partial class MainForm : Form
    {
        //DataSet ds;
        //SqlDataAdapter adapter;
        //SqlCommandBuilder commandBuilder;
        //string connectionString = @"Persist Security Info=False;User ID=sqlUser;Password=123;Initial Catalog=TransportnoyeAgentstvo;Network Address=192.168.0.2";
        //string sql = "SELECT * FROM Fiz";

        public MainForm()
        {
            InitializeComponent();

            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.AllowUserToAddRows = false;

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    adapter = new SqlDataAdapter(sql, connection);

            //    ds = new DataSet();
            //    adapter.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];
            //    // делаем недоступным столбец id для изменения
            //    dataGridView1.Columns["IDFiz"].ReadOnly = true;

            //    //for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
            //    //{
            //    //    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    //}
            
            var table = new TableForm();
            //add.@Note = note;
            table.ShowDialog();

            //}






        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
