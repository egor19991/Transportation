select F.IDClient,F.Surnames,F.Names, COUNT(*) as NumberItems
from Orders O
inner join Fiz F ON F.IDClient = O.IDSender
group by rollup(F.IDClient,F.Surnames,F.Names) ;