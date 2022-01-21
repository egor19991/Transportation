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
            TableComboBox.SelectedItem = ListEntities.Fiz;
        }

        /// <summary>
        /// Кнопка для добавления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            DataRow row = _conector.SelectInformation.Tables[0].NewRow(); // добавляем новую строку в DataTable
            _conector.SelectInformation.Tables[0].Rows.Add(row);
        }

        /// <summary>
        /// Кнопка для удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        /// <summary>
        /// Кнопка для сохранения изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            _conector.SaveInformation(Table);
        }

        /// <summary>
        /// ComboBox для выбора таблицы, с которой будет происходить работа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Запрос 1 к Fiz и Recipient с cube
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFizRecipientButton_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = _conector.SelectFizRecipient.Tables[0];
        }

        /// <summary>
        /// Запрос 2 к Fiz и Sender с rollup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFizSenderButton_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = _conector.SelectFizSender.Tables[0];
        }

        /// <summary>
        /// Запрос 3, обращение к таблицам Fiz и Sender, поиск по фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FizSender2Button_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = _conector.SelectFizSender2.Tables[0];
        }

        /// <summary>
        /// Метод для запроса 4, к таблицам Employee и AcceptanceOrders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectEmployeeAcceptanceOrdersButton_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = _conector.SelectEmployeeAcceptanceOrders(SurnameSelectEmployeeAcceptanceOrdersTextBox.Text,
                namesSelectEmployeeAcceptanceOrdersTextBox.Text,patronymicSelectEmployeeAcceptanceOrdersTextBox.Text).Tables[0];
        }
    }
}
