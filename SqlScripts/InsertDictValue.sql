insert into public."TypeAppeal" ("Name") values ('Безопасность на дорогах');

insert into public."TypeAppeal" ("Name") values ('Комфортное проживание');

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Качество автомобильных дорог', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Безопасность на дорогах'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Наличие/качество пешеходных переходов', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Безопасность на дорогах'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Наличие/качество освещения', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Безопасность на дорогах'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Безопасная дорога в школу для детей', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Безопасность на дорогах'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Отсутствие/качество тротуаров', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Комфортное проживание'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Отсутствие /качество ливневой канализации', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Комфортное проживание'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Заброшенные объекты строительства / здания', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Комфортное проживание'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Отсутствие /качество детских площадок', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Комфортное проживание'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Проблемы при проведении капитального ремонта', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Комфортное проживание'));

('Стихийные свалки', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Комфортное проживание'));

('Отсутствие /качество инфраструктуры для передвижения людей с ограниченными возможностями', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Комфортное проживание'));