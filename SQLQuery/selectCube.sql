select R.IDFiz,F.Surnames,F.Names, COUNT(*) as NumberItems
from Recipient R
inner join Fiz F ON F.IDFiz = R.IDFiz
group by cube(R.IDFiz,F.Surnames,F.Names) ;