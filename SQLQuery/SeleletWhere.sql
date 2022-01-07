select *
from Fiz F
left join Sender S ON S.IDFiz = F.IDFiz
WHERE F.Surnames = 'Евец' ;