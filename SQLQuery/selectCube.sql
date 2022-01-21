select F.IDClient,F.Surnames,F.Names, COUNT(*) as NumberItems
from  Fiz F
inner join Orders O ON O.IDRecipient = F.IDClient
group by cube(F.IDClient,F.Surnames,F.Names) ;