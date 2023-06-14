create database AlmacenBebidas
go
create table TipoUsuario(
Id int primary key identity(1,1),
Nombre varchar(50) not null
)
go
create table Domicilio(
Id int primary key identity(1,1),
Calle varchar(100) not null,
Numero varchar(10) not null,
Provincia varchar(50) not null,
Partido varchar(50) not null,
Localidad varchar(50) not null,
Departamento varchar(10),
Piso varchar(10)
)
go
create table Usuarios(
Id int primary key identity(1,1),
NombreUsuario varchar(50) not null,
Contraseña varchar(50) not null,
IdTipoUsser int foreign key references TipoUsuario(Id),
Nombre varchar(50) not null,
Apellido varchar(50) not null,
Dni varchar(50) not null,
Email varchar(50) not null,
Telefono varchar(50),
FechaNacimiento date,
IdDomicilio int foreign key references Domicilio(Id)
)
go

create table Marcas(
Id int primary key identity(1,1),
Nombre varchar(50) not null,
Importado bit default 0
)
go
create table Categorias(
Id int primary key identity(1,1),
Nombre varchar(50) not null
)

go
create table Bebidas(
Id int primary key identity(1,1),
Codigo varchar(10) not null,
Nombre varchar(50) not null,
Precio money not null check(Precio>0),
Descripcion varchar(300) not null ,
ContenidoNeto decimal check(ContenidoNeto>0),
Estado bit default 1,
UrlImg varchar(300) not null,
IdMarca int foreign key references Marcas(Id),
IdCategoria int foreign key references Categorias(Id)
)
go
create table Carrito(
IdCarrito int primary key identity(1,1),
IdBebida int foreign key references Bebidas(Id),
Cantidad int not null,
ImporteTotal money not null
)

go
create table CarritoXUsuarios(
Id int primary key identity(1,1),
IdUsuario int foreign key references Usuarios(Id),
IdCarrito int  foreign key references Carrito(IdCarrito)
)
go
create table Ventas(
IdVenta int primary key identity(1,1),
IdUsuario int foreign key references Usuarios(Id),
ImporteTotal money not null,
FormaDePago varchar(50) not null
)