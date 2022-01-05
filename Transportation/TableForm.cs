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
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }
        private Conector _conector = new Conector();

        public ListEntities Table { get; set; }

        //private DataSet _ds;

        private void TableForm_Load(object sender, EventArgs e)
        {
            Table = ListEntities.Fiz;
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

        private void addButton_Click(object sender, EventArgs e)
        {
            DataRow row = _conector.SelectInformation.Tables[0].NewRow(); // добавляем новую строку в DataTable
            _conector.SelectInformation.Tables[0].Rows.Add(row);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _conector.SaveInformation(Table);
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
