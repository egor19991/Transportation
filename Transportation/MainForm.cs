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

            
            var table = new TableForm();
            //add.@Note = note;
            table.ShowDialog();

           






        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
