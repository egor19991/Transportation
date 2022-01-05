using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TransportDB
{
    /// <summary>
    /// Класс конектор для соединения с бд и передачи данных
    /// </summary>
    public class Conector
    {
        /// <summary>
        /// Кэш данных
        /// </summary>
        private DataSet _ds;

        /// <summary>
        /// Класс который создает инструкции для TranscatSQl, и ищет различия между dataset и sql
        /// </summary>
        private SqlDataAdapter _adapter;

        /// <summary>
        /// 
        /// </summary>
        private SqlCommandBuilder _commandBuilder;

        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private string _connectionString = @"Persist Security Info=False;User ID=sqlUser;Password=123;Initial Catalog=TransportnoyeAgentstvo;Network Address=192.168.0.2";

        private SqlConnection _connection;

        /// <summary>
        /// Метод для подключения к БД
        /// </summary>
        public void Conect(ListEntities entities)
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
            string _sql = $"SELECT * FROM {entities.ToString()}";
            _adapter = new SqlDataAdapter(_sql, _connection);
            _ds = new DataSet();
            _adapter.Fill(_ds);
        }

        /// <summary>
        /// Словарь с id таблиц с автоинкрементом
        /// </summary>
        private readonly Dictionary<string, string> _IdTableDictionary;

        public Dictionary<string, string> IdTableDicionary
        {
            get { return _IdTableDictionary; }
        }

        /// <summary>
        /// Метод для получения данных из таблиц (SELECT *)
        /// </summary>
        /// <param name="entities">Название таблицы из которой нужно получить данные</param>
        /// <returns>DataSet</returns>
        public DataSet SelectInformation
        {
            get { return _ds; }
        }

        public void SaveInformation(ListEntities entities)
        {
            _commandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.InsertCommand = new SqlCommand("sp_Fiz", _connection);
            _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@surnames", SqlDbType.Char, 30, "Surnames"));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@names", SqlDbType.Char, 30, "Names"));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@patronymic", SqlDbType.Char, 30, "Patronymic"));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@phoneNumber", SqlDbType.Char, 11, "PhoneNumber"));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@residenceAddress", SqlDbType.Char, 100, "ResidenceAddress"));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@seriesPassportNumber", SqlDbType.Char, 10, "SeriesPassportNumber"));
            SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "IDFiz");
            parameter.Direction = ParameterDirection.Output;

            _adapter.Update(_ds);
          

        }



        public Conector()
        {
            _IdTableDictionary = new Dictionary<string, string>()
            {
                {"Fiz","IDFiz" },
                {"Entity","IDEntitys" },
                {"Route","IDRoute" },
                {"Employee","IDEmployee" },
                {"CargoType","IDTypeCargo" },
                {"Vehicle","IDVehicle" },
                {"Flight","IDFlight" },
                {"Rate","IDRate" },
                {"Orders","IDOrders" },
            };
        }

    }
}
