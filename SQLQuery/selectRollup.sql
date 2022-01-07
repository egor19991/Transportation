select S.IDFiz,F.Surnames,F.Names, COUNT(*) as NumberItems
from Sender S
inner join Fiz F ON F.IDFiz = S.IDFiz
group by rollup(S.IDFiz,F.Surnames,F.Names) ;