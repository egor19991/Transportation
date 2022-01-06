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
        /// SqlCommandBuilder
        /// </summary>
        private SqlCommandBuilder _commandBuilder;

        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private string _connectionString = @"Persist Security Info=False;User ID=sqlUser;Password=123;Initial Catalog=TransportnoyeAgentstvo;Network Address=192.168.0.2";

        /// <summary>
        /// SqlConnection
        /// </summary>
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

        /// <summary>
        /// Запрос 1 к Fiz и Recipient с cube
        /// </summary>
        public DataSet SelectFizRecipient
        {
            get
            {
                string _sql = $"select R.IDFiz,F.Surnames,F.Names, COUNT(*) as NumberItems from Recipient" +
                    $" R inner join Fiz F ON F.IDFiz = R.IDFiz group by cube(R.IDFiz, F.Surnames, F.Names)";
                _adapter = new SqlDataAdapter(_sql, _connection);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                return _ds;
            }
        }

        /// <summary>
        /// Запрос 2 к Fiz и Sender с rollup
        /// </summary>
        public DataSet SelectFizSender
        {
            get
            {
                string _sql = $"select S.IDFiz,F.Surnames,F.Names, COUNT(*) as NumberItems from Sender S " +
                    $"inner join Fiz F ON F.IDFiz = S.IDFiz group by rollup(S.IDFiz,F.Surnames,F.Names)";
                _adapter = new SqlDataAdapter(_sql, _connection);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                return _ds;
            }
        }

        /// <summary>
        /// Запрос 3, обращение к таблицам Fiz и Sender, поиск по фамилии
        /// </summary>
        /// <param name="surnames"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectFizSender2(string surnames)
        {
            string _sql = $"select * from Fiz F left join Sender S " +
                $"ON S.IDFiz = F.IDFiz WHERE F.Surnames = '{surnames}'";
            _adapter = new SqlDataAdapter(_sql, _connection);
            _ds = new DataSet();
            _adapter.Fill(_ds);
            return _ds;
        }

        /// <summary>
        /// Метод для запроса 4, к таблицам Employee и AcceptanceOrders
        /// </summary>
        /// <param name="surnames">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <returns>Dataset</returns>
        public DataSet SelectEmployeeAcceptanceOrders(string surnames, string name, string patronymic)
        {
            string _sql = $"select * from Employee E left join AcceptanceOrders A ON A.IDEmployee = E.IDEmployee" +
                $" WHERE (E.Surnames = '{surnames}') and (E.Names = '{name}') and (E.Patronymic = '{patronymic}')";
            _adapter = new SqlDataAdapter(_sql, _connection);
            _ds = new DataSet();
            _adapter.Fill(_ds);
            return _ds;
        }

        /// <summary>
        /// Метод для сохранения изменений в таблицу
        /// </summary>
        /// <param name="entitie">Название талбицы из листа</param>
        public void SaveInformation(ListEntities entitie)
        {
            _commandBuilder = new SqlCommandBuilder(_adapter);
            switch (entitie)
            {
                case ListEntities.Fiz:
                    {
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
                        break;
                    }
                case ListEntities.Entity:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_Entity", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@namesOrganization", SqlDbType.Char, 100, "NamesOrganization"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@legalAddress", SqlDbType.Char, 100, "LegalAddress"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@INN", SqlDbType.Char, 12, "INN"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@KPP", SqlDbType.Char, 9, "KPP"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@namesBank", SqlDbType.Char, 100, "NamesBank"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@BIK", SqlDbType.Char, 9, "BIK"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@paymentAccount", SqlDbType.Char, 20, "PaymentAccount"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@corporateAccount", SqlDbType.Char, 20, "CorporateAccount"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "IDEntitys");
                        parameter.Direction = ParameterDirection.Output;
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.Route:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_Route", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@pointDeparture", SqlDbType.Char, 70, "PointDeparture"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@destination", SqlDbType.Char, 70, "Destination"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@distance", SqlDbType.Float, 0, "Distance"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "IDRoute");
                        parameter.Direction = ParameterDirection.Output;
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.Employee:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_Employee", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@surnames", SqlDbType.Char, 30, "Surnames"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@names", SqlDbType.Char, 30, "Names"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@patronymic", SqlDbType.Char, 30, "Patronymic"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@dateBirth", SqlDbType.Date, 0, "DateBirth"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@INN", SqlDbType.Char, 12, "INN"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@SNILS", SqlDbType.Char, 11, "SNILS"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@position", SqlDbType.Char, 50, "Position"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@seriesPassportNumber", SqlDbType.Char, 10, "SeriesPassportNumber"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "IDEmployee");
                        parameter.Direction = ParameterDirection.Output;
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.CargoType:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_CargoType", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@cargoType", SqlDbType.Char, 70, "CargoType"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "IDTypeCargo");
                        parameter.Direction = ParameterDirection.Output;
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.Vehicle:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_Vehicle", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDTypeCargo", SqlDbType.Int, 0, "IDTypeCargo"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@vehicleType", SqlDbType.Char, 50, "VehicleType"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@maxVolume", SqlDbType.Float, 0, "MaxVolume"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@weightLimit", SqlDbType.Float, 0, "WeightLimit"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "IDVehicle");
                        parameter.Direction = ParameterDirection.Output;
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.Flight:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_Flight", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDVehicle", SqlDbType.Int, 0, "IDVehicle"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDRoute", SqlDbType.Int, 0, "IDRoute"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@dateTimeDeparture", SqlDbType.DateTime, 0, "DateTimeDeparture"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@dateTimeArrival", SqlDbType.DateTime, 0, "DateTimeArrival"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "IDFlight");
                        parameter.Direction = ParameterDirection.Output;
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.Rate:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_Rate", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDTypeCargo", SqlDbType.Int, 0, "IDTypeCargo"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@loadDensity", SqlDbType.Float, 0, "LoadDensity"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.Float, 0, "Price"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "IDRate");
                        parameter.Direction = ParameterDirection.Output;
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.Orders:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_Orders", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDTypeCargo", SqlDbType.Int, 0, "IDTypeCargo"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@cargoVolume", SqlDbType.Float, 0, "CargoVolume"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@cargoWeight", SqlDbType.Float, 0, "CargoWeight"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@shippingAddress", SqlDbType.Char, 100, "ShippingAddress"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@deliveryAddress", SqlDbType.Char, 100, "DeliveryAddress"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDRate", SqlDbType.Int, 0, "IDRate"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "IDOrders");
                        parameter.Direction = ParameterDirection.Output;
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.RateFlight:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_RateFlight", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDRate", SqlDbType.Int, 0, "IDRate"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@IDOrders", SqlDbType.Int, 0, "IDRate");
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.IssueOrders:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_IssueOrders", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDEmployee", SqlDbType.Int, 0, "IDEmployee"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@IDOrders", SqlDbType.Int, 0, "IDRate");
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.AcceptanceOrders:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_AcceptanceOrders", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDEmployee", SqlDbType.Int, 0, "IDEmployee"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@IDOrders", SqlDbType.Int, 0, "IDRate");
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.Sender:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_Sender", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDFiz", SqlDbType.Int, 0, "IDFiz"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDEntitys", SqlDbType.Int, 0, "IDEntitys"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@IDOrders", SqlDbType.Int, 0, "IDOrders");
                        _adapter.Update(_ds);
                        break;
                    }
                case ListEntities.Recipient:
                    {
                        _adapter.InsertCommand = new SqlCommand("sp_Recipient", _connection);
                        _adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDFiz", SqlDbType.Int, 0, "IDFiz"));
                        _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IDEntitys", SqlDbType.Int, 0, "IDEntitys"));
                        SqlParameter parameter = _adapter.InsertCommand.Parameters.Add("@IDOrders", SqlDbType.Int, 0, "IDOrders");
                        _adapter.Update(_ds);
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// Конструктор класса, для инициализации словаря IdTableDictionary
        /// </summary>
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
