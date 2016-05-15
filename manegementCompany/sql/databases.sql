/* service */
create table service(
	id int auto_increment, 
	name varchar(30), 
	description varchar(50), 
	price int, 
	isGeneral tinyint, 
	period int, 
	primary key(id)
);

/* owner */

create table owner(
	id int auto_increment,
	name varchar(10),
	last_name varchar(10),
	patronimic varchar(10),
	phone varchar(15),
	email varchar(20),
	room int,
	primary key(id)
);

/* room */

create table room(
	id int auto_increment,
	count_room int,
	count_people int,
	owner int,
	services varchar(500),
	primary key(id)
);

create table address(
	id int auto_increment,
	region varchar(30),
	area varchar(30),
	city varchar(30),
	street varchar(30),
	house int,
	primary key(id)
);

create table house(
	id int auto_increment,
	number varchar(10),
	count_floor int,
	count_porch int,
	count_room int,
	services varchar(200),
	address int,
	primary key(id)
);

create table organization(
	id int auto_increment,
	full_name varchar(50),
	name varchar(30),
	legal_address int,
	address int,
	OGRN varchar(20),
	INN varchar(20),
	KPP varchar(20),
	OKTMO varchar(20),
	phone varchar(200),
	email varchar(20),
	psw varchar(20),
	unique(email),
	primary key(id)
);

create table region(
	id int auto_increment,
	name varchar(30),
	city varchar(500),
	primary key(id)
);

create table city(
	id int auto_increment,
	name varchar(30),
	street varchar(500),
	primary key(id)
);

create table street(
	id int auto_increment,
	name varchar(30),
	house varchar(500),
	primary key(id)
);