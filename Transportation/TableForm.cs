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
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"Persist Security Info=False;User ID=sqlUser;Password=123;Initial Catalog=TransportnoyeAgentstvo;Network Address=192.168.0.2";
        string sql = "SELECT * FROM Fiz";


        private void TableForm_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                // делаем недоступным столбец id для изменения
                dataGridView1.Columns["IDFiz"].ReadOnly = true;

                //for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
                //{
                //    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //}
            }
        }

        

        private void addButton_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("Fizе", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("Surnames", SqlDbType.NVarChar, 30, "Surnames"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("Names", SqlDbType.NVarChar, 30, "Names"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("Patronymic", SqlDbType.NVarChar, 30, "Patronymic"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("PhoneNumber", SqlDbType.NVarChar, 11, "PhoneNumber"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("ResidenceAddress", SqlDbType.NVarChar, 100, "ResidenceAddress"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("SeriesPassportNumber", SqlDbType.NVarChar, 10, "SeriesPassportNumber"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 30, "Names"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 30, "Names"));



                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("IDFiz", SqlDbType.Int, 0, "IDFiz");
                parameter.Direction = ParameterDirection.Output;

                adapter.Update(ds);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
