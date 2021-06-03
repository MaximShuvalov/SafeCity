insert into public."ClassAppeal" ("Name") values ('Предложение');

insert into public."ClassAppeal" ("Name") values ('Замечание');

insert into public."ClassAppeal" ("Name") values ('Жалоба');

insert into public."TypeAppeal" ("Name") values ('Водитель');

insert into public."TypeAppeal" ("Name") values ('Пешеход');

insert into public."TypeAppeal" ("Name") values ('Пассажир');

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Item1', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Водитель'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Item2', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Водитель'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Item3', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Водитель'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Item1', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Пассажир'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Item2', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Пассажир'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Item3', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Пассажир'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Item1', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Пешеход'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Item2', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Пешеход'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('Item3', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = 'Пешеход'));