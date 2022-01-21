--Клиент
INSERT INTO Client DEFAULT VALUES;
INSERT INTO Client DEFAULT VALUES;
INSERT INTO Client DEFAULT VALUES;
INSERT INTO Client DEFAULT VALUES;
INSERT INTO Client DEFAULT VALUES;
INSERT INTO Client DEFAULT VALUES;
INSERT INTO Client DEFAULT VALUES;


--Таблица Физ лиц
insert into Fiz(IDClient,Surnames,Names,Patronymic,PhoneNumber,ResidenceAddress, SeriesPassportNumber)
values(1,'Валигура', 'Иван', 'Трофимович','89991112233', 'Кемеровская область, г.Новокузнецк, ул. Кирова 71', '3218111222'),
(2,'Галкин', 'Лев', 'Фёдорович','85551112233', 'Кемеровская область, п.Чистогорский, ул. Курако 2', '3218111555'),
(3,'Евец', 'Михаил', 'Юрьевич','85554442233', 'Кемеровская область, г.Новокузнецк, ул.Пирогова 40-21', '3290111555'),
(4,'Егоров', 'Алексей', 'Андреевич','83334442233', 'Кемеровская область, г.Междуреченск, ул.Металлургов 345-7', '3291444555'),
(5,'Шумилов', 'Василий', 'Тимофеевич','85559992233', 'Кемеровская область, г.Мыски, ул.ДОЗ 27-87', '3298111556')
; 

--Юридеческое лицо
insert into Entity(IDClient,NamesOrganization,LegalAddress,INN,KPP,NamesBank,BIK,PaymentAccount,CorporateAccount)
values(6,'ЕВРАЗ ЗСМК', 'Кемеровская область, г.Кемерово, шс. Космическое 20', '012345678911','012345678', 'КББ', '012345675', '01234567891234567892','00112233445566778899'),
(7,'Кузнецкие ферросплавы', 'Кемеровская область, г.Мариинск, ул.Обнорского 170', '212366678911','555345678', 'НМБ', '333345675', '44434567891234567892','55512233445566778899');

--Маршрут
insert into Route(PointDeparture,Destination,Distance)
values('г.Новокузнецк','г.Кемерово',221.5),
('г.Новокузнецк','г.Мариинск',386.2),
('г.Новокузнецк','г.Мыски',52.54),
('г.Новокузнецк','г.Междуреченск',78.42),
('г.Новокузнецк','п.Чистогорский',38.142)
;

--Сотрудник
insert into Employee(Surnames,Names,Patronymic,DateBirth,INN,SNILS,Position, SeriesPassportNumber)
values('Соломин', 'Юрий', 'Мефодьевич', '18-07-1935', '123469789112','11346978911','Оператор' ,'3218444222'),
('Табаков', 'Олег', 'Павлович', '17-05-1935', '693469789112', '22346978911','Оператор' ,'3218555222'),
('Пуговкин', 'Михаил', 'Иванович', '13-07-1923', '123469789169', '33346978912', 'Оператор' ,'3218555212'),
('Ротару', 'София', 'Михайловна', '7-07-1947', '553469789169', '44346978912', 'Оператор' ,'3218443322')
;

--Вид груза
insert into CargoType(CargoType)
values('Насыпной и навалочный'),
('Наливные грузы'),
('Штучные грузы');

--Транспортное средство
insert into Vehicle(IDTypeCargo, VehicleType,MaxVolume,WeightLimit)
values(3,'Тентованный полуприцеп',10,12000),
(1,'Открытый бортовой полуприцеп',18,14000),
(2,'Автоцистерна',15,15000)
;

--Рейс
insert into Flight(IDVehicle,IDRoute,DateTimeDeparture,DateTimeArrival)
values(1,1,'10-05-2021 21:00','11-05-2021 06:00'),
(2,5,'10-06-2021 11:00','11-06-2021 18:00'),
(3,4,'11-05-2021 10:00','11-05-2021 20:00');

--Тариф
insert into Rate(IDTypeCargo,LoadDensity,Price)
values(1,200,1000),
(1,500,2000),
(1,800,3000),
(2,200,500),
(2,500,1000),
(2,800,4000),
(3,200,100),
(3,500,200),
(3,800,300);

--Заказ
insert into Orders(CargoVolume,CargoWeight,ShippingAddress,DeliveryAddress,IDRate, IDSender,IDRecipient,IDEmployeeRegistration,IDEmployeeExtradition)
values(0.35,22.5,'Кемеровская область, г.Новокузнецк, ул.Пирогова 40-21' ,'Кемеровская область, г.Кемерово, шс. Космическое 20',7,3,6,1,2),
(0.5,10.5,'Кемеровская область, г.Новокузнецк, ул. Кирова 71' ,'Кемеровская область, п.Чистогорский, ул. Курако 2',1,1,2,1,3),
(0.5,10.5,'Кемеровская область, г.Новокузнецк, ул.Пирогова 40-21' ,'Кемеровская область, г.Междуреченск, ул.Металлургов 345-7',4,3,4,1,4);

--Отправитель
/*insert into Sender(IDFiz,IDEntitys,IDOrders)
values(3,0,1);
insert into Sender(IDFiz,IDEntitys,IDOrders)
values(1,0,2);
insert into Sender(IDFiz,IDEntitys,IDOrders)
values(3,0,3);*/

--Получатель
/*insert into Recipient(IDFiz,IDEntitys,IDOrders)
values(0,1,1);
insert into Recipient(IDFiz,IDEntitys,IDOrders)
values(2,0,2);
insert into Recipient(IDFiz,IDEntitys,IDOrders)
values(4,0,3);*/ 

--ЗаказРейс
insert into RateFlight(IDRate,IDOrders)
values(1,1),
(5,2),
(4,3);

--Выдача заказа
/*insert into IssueOrders(IDEmployee,IDOrders)
values(2,1),
(3,2),
(4,3);

--Прием заказа
insert into AcceptanceOrders(IDEmployee,IDOrders)
values(1,1),
(1,2),
(1,3);*/
