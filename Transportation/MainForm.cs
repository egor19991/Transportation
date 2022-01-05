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
using TransportDB;

namespace Transportation
{
    public partial class MainForm : Form
    {
        private Conector _conector = new Conector();

        public ListEntities Table { get; set; }

        //private DataSet _ds;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var tables = Enum.GetValues(typeof(ListEntities));
            foreach (ListEntities tablelist in tables)
            {
                TableComboBox.Items.Add(tablelist);
            }
            Table = ListEntities.Fiz;
            TableComboBox.SelectedItem = ListEntities.Fiz;
            //_conector.Conect(Table);
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.DataSource = _conector.SelectInformation.Tables[0];
            //// делаем недоступным столбец id для изменения
            //if (_conector.IdTableDicionary.ContainsKey(Table.ToString()))
            //{
            //    dataGridView1.Columns[$"{_conector.IdTableDicionary[Table.ToString()]}"].ReadOnly = true;
            //}

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DataRow row = _conector.SelectInformation.Tables[0].NewRow(); // добавляем новую строку в DataTable
            _conector.SelectInformation.Tables[0].Rows.Add(row);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _conector.SaveInformation(Table);
        }

        private void TableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TableComboBox.SelectedIndex == -1)
            {
                return;
            }
            Table = (ListEntities)TableComboBox.SelectedItem;
            _conector.Conect(Table);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = _conector.SelectInformation.Tables[0];
            // делаем недоступным столбец id для изменения
            if (_conector.IdTableDicionary.ContainsKey(Table.ToString()))
            {
                dataGridView1.Columns[$"{_conector.IdTableDicionary[Table.ToString()]}"].ReadOnly = true;
            }
        }

        private void SelectFizRecipientButton_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = _conector.SelectFizRecipient.Tables[0];
        }

        private void SelectFizSenderButton_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = _conector.SelectFizSender.Tables[0];
        }

        private void FizSender2Button_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = _conector.SelectFizSender2(FizSender2TextBox.Text).Tables[0];
        }

        private void SelectEmployeeAcceptanceOrdersButton_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = _conector.SelectEmployeeAcceptanceOrders(SurnameSelectEmployeeAcceptanceOrdersTextBox.Text,
                namesSelectEmployeeAcceptanceOrdersTextBox.Text,patronymicSelectEmployeeAcceptanceOrdersTextBox.Text).Tables[0];
        }
    }
}
