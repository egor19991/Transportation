select *
from Employee E
left join AcceptanceOrders A ON A.IDEmployee = E.IDEmployee
WHERE (E.Surnames = '�������') and (E.Names = '����') and (E.Patronymic = '����������') ;