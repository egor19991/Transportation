select *
from Employee E
left join AcceptanceOrders A ON A.IDEmployee = E.IDEmployee
WHERE (E.Surnames = 'Соломин') and (E.Names = 'Юрий') and (E.Patronymic = 'Мефодьевич') ;