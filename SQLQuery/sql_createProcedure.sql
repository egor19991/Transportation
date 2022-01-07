----Физическое лицо
CREATE PROCEDURE [dbo].[sp_Fiz]
    --@name nvarchar(50),
    --@age int,
    --@Id int out,
	@ID int out,
    @surnames char(30),
	@names char(30),
	@patronymic char(30),
	@phoneNumber char(11),
	@residenceAddress char(100),
	@seriesPassportNumber char(10)
AS
    INSERT INTO Fiz(Surnames,Names,Patronymic,PhoneNumber,ResidenceAddress, SeriesPassportNumber)
    VALUES (@surnames,@names, @patronymic, @phoneNumber, @residenceAddress, @seriesPassportNumber)
  
    SET @ID=SCOPE_IDENTITY()
GO

--Юридеческое лицо
CREATE PROCEDURE [dbo].[sp_Entity]
	@ID int out,
    @namesOrganization char(100),
	@legalAddress char(100),
	@INN char(12),
	@KPP char(9),
	@namesBank char(100),
	@BIK char(9),
	@paymentAccount char(20),
	@corporateAccount char(20)
AS
    INSERT INTO Entity(NamesOrganization,LegalAddress,INN,KPP,NamesBank,BIK,PaymentAccount,CorporateAccount)
    VALUES (@namesOrganization,@legalAddress, @INN, @KPP, @namesBank, @BIK, @paymentAccount, @corporateAccount)
  
    SET @ID=SCOPE_IDENTITY()
GO

--Маршрут
CREATE PROCEDURE [dbo].[sp_Route]
	@ID int out,
    @pointDeparture char(70),
	@destination char(70),
	@distance float
AS
    INSERT INTO Route(PointDeparture,Destination,Distance)
    VALUES (@pointDeparture, @destination, @distance)
  
    SET @ID=SCOPE_IDENTITY()
GO

--Сотрудник
CREATE PROCEDURE [dbo].[sp_Employee]
	@ID int out,
    @surnames char(30),
	@names char(30),
	@patronymic char(30),
	@dateBirth date,
	@INN char(12),
	@SNILS char(11),
	@position char(50),
	@seriesPassportNumber char(10)
AS
    INSERT INTO Employee(Surnames,Names,Patronymic,DateBirth,INN,SNILS,Position, SeriesPassportNumber)
    VALUES (@surnames, @names, @patronymic, @dateBirth, @INN, @SNILS, @position, @seriesPassportNumber)
  
    SET @ID=SCOPE_IDENTITY()
GO

--Вид груза
CREATE PROCEDURE [dbo].[sp_CargoType]
	@ID int out,
    @cargoType char(70)
AS
    INSERT INTO CargoType(CargoType)
    VALUES (@cargoType)
  
    SET @ID=SCOPE_IDENTITY()
GO

--Транспортное средство
CREATE PROCEDURE [dbo].[sp_Vehicle]
	@ID int out,
    @IDTypeCargo int,
    @vehicleType char(50),
	@maxVolume float,
	@weightLimit float
AS
    INSERT INTO Vehicle(IDTypeCargo, VehicleType,MaxVolume,WeightLimit)
    VALUES (@IDTypeCargo, @vehicleType, @maxVolume, @weightLimit)
  
    SET @ID=SCOPE_IDENTITY()
GO

--Рейс
CREATE PROCEDURE [dbo].[sp_Flight]
	@ID int out,
    @IDVehicle int,
	@IDRoute int,
	@dateTimeDeparture datetime,
	@dateTimeArrival datetime
AS
    INSERT INTO Flight(IDVehicle,IDRoute,DateTimeDeparture,DateTimeArrival)
    VALUES (@IDVehicle, @IDRoute,@dateTimeDeparture, @dateTimeArrival)
  
    SET @ID=SCOPE_IDENTITY()
GO

--Тариф
CREATE PROCEDURE [dbo].[sp_Rate]
	@ID int out,
    @IDTypeCargo int,
    @loadDensity float,
	@price float
AS
    INSERT INTO Rate(IDTypeCargo,LoadDensity,Price)
    VALUES (@IDTypeCargo, @loadDensity,@price)
  
    SET @ID=SCOPE_IDENTITY()
GO

--Заказ
CREATE PROCEDURE [dbo].[sp_Orders]
	@ID int out,
    @IDTypeCargo int,
	@cargoVolume float,
	@cargoWeight float,
	@shippingAddress char(100),
	@deliveryAddress char(100),
	@IDRate int
AS
    INSERT INTO Orders(IDTypeCargo,CargoVolume,CargoWeight,ShippingAddress,DeliveryAddress,IDRate)
    VALUES (@IDTypeCargo, @cargoVolume, @cargoWeight, @shippingAddress, @deliveryAddress, @IDRate)
  
    SET @ID=SCOPE_IDENTITY()
GO

--ЗаказРейс
CREATE PROCEDURE [dbo].[sp_RateFlight]
	@IDRate int,
	@IDOrders int 
AS
    INSERT INTO RateFlight(IDRate,IDOrders)
    VALUES (@IDRate,@IDOrders)
GO

--Выдача заказа
CREATE PROCEDURE [dbo].[sp_IssueOrders]
	@IDEmployee int,
	@IDOrders int
AS
    INSERT INTO IssueOrders(IDEmployee,IDOrders)
    VALUES (@IDEmployee, @IDOrders)
GO

--Прием заказа
CREATE PROCEDURE [dbo].[sp_AcceptanceOrders]
	@IDEmployee int,
	@IDOrders int
AS
    INSERT INTO AcceptanceOrders(IDEmployee,IDOrders)
    VALUES (@IDEmployee, @IDOrders)
GO

--Отправитель
CREATE PROCEDURE [dbo].[sp_Sender]
	@IDFiz int ,
	@IDEntitys int ,
	@IDOrders int
AS
    INSERT INTO Sender(IDFiz,IDEntitys,IDOrders)
    VALUES (@IDFiz, @IDEntitys, @IDOrders)
GO

--Получатель
CREATE PROCEDURE [dbo].[sp_Recipient]
	@IDFiz int ,
	@IDEntitys int ,
	@IDOrders int
AS
    INSERT INTO Recipient(IDFiz,IDEntitys,IDOrders)
    VALUES (@IDFiz, @IDEntitys, @IDOrders)
GO