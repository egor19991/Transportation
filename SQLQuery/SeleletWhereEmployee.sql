select *
from Employee E
left join Orders O ON O.IDEmployeeRegistration = E.IDEmployee
WHERE (E.Surnames = 'Соломин') and (E.Names = 'Юрий') and (E.Patronymic = 'Мефодьевич') ;