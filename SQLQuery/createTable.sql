--Клиент
CREATE TABLE Client (
    IDClient int NOT NULL IDENTITY(1,1) PRIMARY KEY
);

--Физическое лицо
CREATE TABLE Fiz (
	IDClient int NOT NULL,
        CONSTRAINT PK_AcceptanceFiz  PRIMARY KEY NONCLUSTERED (IDClient),
        CONSTRAINT FK_AcceptanceClient_Fiz FOREIGN KEY (IDClient)
        REFERENCES Client (IDClient)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    Surnames char(30) NOT NULL,
	Names char(30) NOT NULL,
	Patronymic char(30) NOT NULL,
	PhoneNumber char(11) NOT NULL,
	ResidenceAddress char(100) NOT NULL,
	SeriesPassportNumber char(10) NOT NULL,
	CONSTRAINT AK_PhoneNumber UNIQUE(PhoneNumber),
	CONSTRAINT AK_SeriesPassportNumberFiz UNIQUE(SeriesPassportNumber)
);
 


--Юридеческое лицо
CREATE TABLE Entity (
    IDClient int NOT NULL,
        CONSTRAINT PK_AcceptanceEntity  PRIMARY KEY NONCLUSTERED (IDClient),
        CONSTRAINT FK_AcceptanceClient_Entity FOREIGN KEY (IDClient)
        REFERENCES Client (IDClient)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    NamesOrganization char(100) NOT NULL,
	LegalAddress char(100) NOT NULL,
	INN char(12) NOT NULL,
	KPP char(9) NOT NULL,
	NamesBank char(100) NOT NULL,
	BIK char(9) NOT NULL,
	PaymentAccount char(20) NOT NULL,
	CorporateAccount char(20) NOT NULL,
	CONSTRAINT AK_INN UNIQUE(INN),
	CONSTRAINT AK_KPP UNIQUE(KPP),
	CONSTRAINT AK_BIK UNIQUE(BIK),
	CONSTRAINT AK_PaymentAccount UNIQUE(PaymentAccount),
	CONSTRAINT AK_CorporateAccount UNIQUE(CorporateAccount)
);
 
 

--Маршрут
CREATE TABLE Route (
    IDRoute int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    PointDeparture char(70) NOT NULL,
	Destination char(70) NOT NULL,
	Distance float NOT NULL,
);

--Сотрудник
CREATE TABLE Employee (
    IDEmployee int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Surnames char(30) NOT NULL,
	Names char(30) NOT NULL,
	Patronymic char(30) NOT NULL,
	DateBirth date NOT NULL,
	INN char(12) NOT NULL,
	SNILS char(11) NOT NULL,
	Position char(50) NOT NULL,
	SeriesPassportNumber char(10) NOT NULL
	CONSTRAINT AK_INN_Employee UNIQUE(INN),
	CONSTRAINT AK_SNILS_Employee UNIQUE(SNILS),
	CONSTRAINT AK_SeriesPassportNumber_Employee UNIQUE(SeriesPassportNumber)
);

--Вид груза
CREATE TABLE CargoType (
    IDTypeCargo int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CargoType char(70) NOT NULL
	CONSTRAINT AK_CargoType_CargoType UNIQUE(CargoType),
);

--Транспортное средство
CREATE TABLE Vehicle (
    IDVehicle int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IDTypeCargo int FOREIGN KEY REFERENCES CargoType(IDTypeCargo),
    VehicleType char(50) NOT NULL,
	MaxVolume float NOT NULL,
	WeightLimit float NOT NULL
);

--Рейс
CREATE TABLE Flight (
    IDFlight int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IDVehicle int FOREIGN KEY REFERENCES Vehicle(IDVehicle),
	IDRoute int FOREIGN KEY REFERENCES Route(IDRoute),
	DateTimeDeparture datetime,
	DateTimeArrival datetime,
);

--Тариф
CREATE TABLE Rate (
    IDRate int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IDTypeCargo int FOREIGN KEY REFERENCES CargoType(IDTypeCargo),
    LoadDensity float NOT NULL,
	Price float NOT NULL
);

--Заказ
CREATE TABLE Orders (
    IDOrders int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	CargoVolume float NOT NULL,
	CargoWeight float NOT NULL,
	ShippingAddress char(100) NOT NULL,
	DeliveryAddress char(100) NOT NULL,
	IDRate int FOREIGN KEY REFERENCES Rate(IDRate),
	IDSender int NOT NULL,
		CONSTRAINT FK_OrdersIDSender_Client FOREIGN KEY (IDSender)
        REFERENCES Client(IDClient)
        ON DELETE NO ACTION,
	IDRecipient int NOT NULL,
		CONSTRAINT FK_OrdersIDRecipient_Client FOREIGN KEY (IDRecipient)
        REFERENCES Client(IDClient)
        ON DELETE NO ACTION,
	IDEmployeeRegistration int NOT NULL,
		CONSTRAINT FK_OrdersIDEmployeeRegistration_Employee FOREIGN KEY (IDEmployeeRegistration)
        REFERENCES Employee(IDEmployee)
        ON DELETE NO ACTION,
	IDEmployeeExtradition int NOT NULL,
		CONSTRAINT FK_IDEmployeeExtradition_Employee FOREIGN KEY (IDEmployeeExtradition)
        REFERENCES Employee(IDEmployee)
        ON DELETE NO ACTION
);

--ЗаказРейс
CREATE TABLE RateFlight (
	IDRate int NOT NULL,
	   CONSTRAINT FK_RateFlight_Rate FOREIGN KEY (IDRate)
       REFERENCES Rate (IDRate)
       ON DELETE CASCADE
       ON UPDATE CASCADE,
	IDOrders int NOT NULL,
		CONSTRAINT PK_AcceptanceOrders  PRIMARY KEY NONCLUSTERED (IDOrders,IDRate),
       CONSTRAINT FK_RateFlight_Orders FOREIGN KEY (IDOrders)
       REFERENCES Orders (IDOrders)
       ON DELETE CASCADE
       ON UPDATE CASCADE
);
