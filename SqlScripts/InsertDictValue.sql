insert into public."TypeAppeal" ("Name") values ('������������ �� �������');

insert into public."TypeAppeal" ("Name") values ('���������� ����������');

insert into public."SubtypeAppeals" ("Name","TypesId") values
('�������� ������������� �����', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '������������ �� �������'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('�������/�������� ���������� ���������', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '������������ �� �������'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('�������/�������� ���������', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '������������ �� �������'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('���������� ������ � ����� ��� �����', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '������������ �� �������'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('����������/�������� ���������', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '���������� ����������'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('���������� /�������� �������� �����������', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '���������� ����������'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('����������� ������� ������������� / ������', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '���������� ����������'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('���������� /�������� ������� ��������', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '���������� ����������'));

insert into public."SubtypeAppeals" ("Name","TypesId") values
('�������� ��� ���������� ������������ �������', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '���������� ����������'));

('��������� ������', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '���������� ����������'));

('���������� /�������� �������������� ��� ������������ ����� � ������������� �������������', (select t1."Key" from public."TypeAppeal" t1 where t1."Name" = '���������� ����������'));