create database gestion_membresias
go

use gestion_membresias
go

--Tabla Cliente
create table Cliente
(
	id_cliente int not null,
	nombre varchar(50) not null,
	apellido varchar(50) not null,
	direccion varchar(50),
	telefono varchar(10) ,
	email varchar(50),
	foto VARBINARY(MAX),
	altura decimal(5,2),
	peso decimal(5,2),
	estado bit not null,
	constraint PK_Cliente primary key(id_Cliente)
)

--Tabla Usuario
create table Usuario
(
	id_usuario int not null,
	nombre varchar(50) not null,
	apellido varchar(50) not null,
	email varchar(50) not null,
	nombre_usuario varchar(30) not null,
	contraseña varchar(30) not null,
	constraint PK_Usuario primary key(id_usuario)
	--fecha_ingreso TIMESTAMP
)

--Tabla de pagos diarios
create table Pago_diario
(
	id_pago_diario int not null,
	fecha date not null,
	monto money not null,
	estado bit not null,
	constraint PK_Pago_diario primary key(id_pago_diario)
)

--Tabala de membresias
create table Membresias
(
	id_membresia int not null,
	tipo varchar(50) not null,
	costo money not null,
	fecha_inicio date not null,
	fecha_fin date not null,
	estado bit not null,
	constraint PK_Membresias primary key(id_membresia)
)

--Tabla promociones
create table Promociones
(
	id_Promocion int not null,
	tipo varchar(50) not null,
	costo money not null,
	estado bit not null,
	constraint PK_Promociones primary key(id_Promocion)
)

create table Promociones_membresias
(
	id_Promocion_membresia int not null,
	numero_beneficiados tinyint not null,
	constraint PK_Promociones_membresias primary key(id_Promocion_membresia)
)