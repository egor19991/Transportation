--Физическое лицо
CREATE TABLE Fiz (
    IDFiz int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Surnames char(30) NOT NULL,
	Names char(30) NOT NULL,
	Patronymic char(30) NOT NULL,
	PhoneNumber char(11) NOT NULL,
	ResidenceAddress char(100) NOT NULL,
	SeriesPassportNumber char(10) NOT NULL,
	CONSTRAINT AK_PhoneNumber UNIQUE(PhoneNumber),
	CONSTRAINT AK_SeriesPassportNumberFiz UNIQUE(SeriesPassportNumber)
);
SET IDENTITY_INSERT Fiz ON;  
GO  
INSERT INTO Fiz (IDFiz,Surnames,Names,Patronymic,PhoneNumber,ResidenceAddress, SeriesPassportNumber)   
    VALUES (0,'0', '0', '0','0', '0', '0'); 
GO
SET IDENTITY_INSERT Fiz OFF;  
GO  

--Юридеческое лицо
CREATE TABLE Entity (
    IDEntitys int NOT NULL IDENTITY(1,1) PRIMARY KEY,
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
SET IDENTITY_INSERT Entity ON;  
GO  
INSERT INTO Entity (IDEntitys,NamesOrganization,LegalAddress,INN,KPP,NamesBank,BIK,PaymentAccount,CorporateAccount)   
    VALUES (0,'0', '0', '0','0', '0', '0','0','0'); 
GO
SET IDENTITY_INSERT Entity OFF;  
GO  

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
	IDTypeCargo int FOREIGN KEY REFERENCES CargoType(IDTypeCargo),
	CargoVolume float NOT NULL,
	CargoWeight float NOT NULL,
	ShippingAddress char(100) NOT NULL,
	DeliveryAddress char(100) NOT NULL,
	IDRate int FOREIGN KEY REFERENCES Rate(IDRate)
);

--ЗаказРейс
CREATE TABLE RateFlight (
	IDRate int NOT NULL,
		CONSTRAINT FK_RateFlight_Rate FOREIGN KEY (IDRate)
       REFERENCES Rate (IDRate)
       ON DELETE CASCADE
       ON UPDATE CASCADE,
	IDOrders int NOT NULL,
       CONSTRAINT PK_RateFligh  PRIMARY KEY NONCLUSTERED (IDOrders,IDRate),
       CONSTRAINT FK_RateFlight_Orders FOREIGN KEY (IDOrders)
       REFERENCES Orders (IDOrders)
       ON DELETE CASCADE
       ON UPDATE CASCADE
);

--Выдача заказа
CREATE TABLE IssueOrders (
	IDEmployee int NOT NULL,
		CONSTRAINT FK_IssueOrders_Employee FOREIGN KEY (IDEmployee)
        REFERENCES Employee (IDEmployee)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	IDOrders int NOT NULL,
        CONSTRAINT PK_IssueOrders  PRIMARY KEY NONCLUSTERED (IDOrders,IDEmployee),
        CONSTRAINT FK_IssueOrders_Orders FOREIGN KEY (IDOrders)
        REFERENCES Orders (IDOrders)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

--Прием заказа
CREATE TABLE AcceptanceOrders (
	IDEmployee int NOT NULL,
		CONSTRAINT FK_AcceptanceOrders_Employee FOREIGN KEY (IDEmployee)
        REFERENCES Employee (IDEmployee)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	IDOrders int NOT NULL,
        CONSTRAINT PK_AcceptanceOrders  PRIMARY KEY NONCLUSTERED (IDOrders,IDEmployee),
        CONSTRAINT FK_AcceptanceOrders_Orders FOREIGN KEY (IDOrders)
        REFERENCES Orders (IDOrders)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

--Отправитель
CREATE TABLE Sender (
	IDFiz int ,
		CONSTRAINT FK_Sender_Fiz FOREIGN KEY (IDFiz)
        REFERENCES Fiz (IDFiz)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	IDEntitys int ,
		CONSTRAINT FK_Sender_Entity FOREIGN KEY (IDEntitys)
        REFERENCES Entity (IDEntitys)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	IDOrders int NOT NULL,
        CONSTRAINT PK_Sender  PRIMARY KEY NONCLUSTERED (IDFiz,IDEntitys,IDOrders),
        CONSTRAINT FK_Sender_Orders FOREIGN KEY (IDOrders)
        REFERENCES Orders (IDOrders)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

--Получатель
CREATE TABLE Recipient (
	IDFiz int ,
		CONSTRAINT FK_Recipient_Fiz FOREIGN KEY (IDFiz)
        REFERENCES Fiz (IDFiz)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	IDEntitys int ,
		CONSTRAINT FK_Recipient_Entity FOREIGN KEY (IDEntitys)
        REFERENCES Entity (IDEntitys)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	IDOrders int NOT NULL,
        CONSTRAINT PK_Recipient  PRIMARY KEY NONCLUSTERED (IDFiz,IDEntitys,IDOrders),
        CONSTRAINT FK_Recipient_Orders FOREIGN KEY (IDOrders)
        REFERENCES Orders (IDOrders)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);