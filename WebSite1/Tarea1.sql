create database Tarea1;

use Tarea1;

create table Province (
	id int identity(1,1) primary key,
	name varchar(40),
);

insert into Province(name)
	values ('San José'),
	('Alajuela'),
	('Cartago'),
	('Heredia'),
	('Guanacaste'),
	('Puntarenas'),
	('Limón');

create table Canton (
	id int identity(1,1) primary key,
	name varchar(40),
	province_id int foreign key references Province(id)
);

insert into Canton(name, province_id)
	values ('Escazu', 1),
	('Atenas', 2),
	('Reventazón', 3),
	('San Pablo', 4),
	('Liberia', 5),
	('Esparza', 6),
	('Talamanca', 7);

create table IdType (
	id int identity(1,1) primary key,
	name varchar(40),
);

insert into IdType(name)
	values ('Cédula nacional'),
	('Cédula de residencia');

create table Users (
	id int primary key,
	id_type int foreign key references IdType(id),
	name varchar(40),
	last_name varchar(40),
	email varchar(40),
	phone varchar(12),
	password varchar(40),
	canton_id int foreign key references Canton(id),
);

insert into Users(id, id_type, name, last_name, email, phone, password, canton_id)
	values (1, 1, 'Admin', 'Admin', 'admin@admin.com', '+50688888888', 'admin', 1);

create table LegislativeProposals (
	id int identity(1,1) primary key,
	title varchar(40),
	description varchar(200),
	users_id int foreign key references Users(id)
);

insert into LegislativeProposals(title, description, users_id)
	values ('Propuesta numero 1', 'Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 1);
