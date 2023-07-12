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
IdDomicilio int foreign key references Domicilio(Id),
Estado bit not null default 1,
Avatar varchar(300) null default 'default.jpg'
)
go

create table Marcas(
Id int primary key identity(1,1),
Nombre varchar(50) not null,
Estado bit not null default 1,
Importado bit default 0
)
go
create table Categorias(
Id int primary key identity(1,1),
Nombre varchar(50) not null,
Estado bit not null default 1,
Alcoholica bit not null default 1
)

go
create table Bebidas(
Id int primary key identity(1,1),
Codigo varchar(10) not null,
Nombre varchar(50) not null,
Precio money not null check(Precio>0),
Descripcion varchar(300) not null ,
ContenidoNeto decimal check(ContenidoNeto>0),
Estado bit default 1 not null,
UrlImg varchar(300) not null,
IdMarca int foreign key references Marcas(Id),
IdCategoria int foreign key references Categorias(Id),
Stock int not null default 0
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
go
create table MetodosPagos(
Id int primary key identity(1,1),
Nombre varchar(50) not null
)
go
create table EstadoPedido(
Id int primary key identity(1,1),
Nombre varchar(50) not null
)
go
create table Pedidos(
Id int primary key identity (1,1),
idUsuario int not null foreign key references Usuarios (Id),
Importe money not null check(Importe>0),
Fecha date not null default getdate(),
idMetodoPago int not null foreign key references MetodosPagos(Id),
Entrega varchar(100) not null,
idEstado int not null foreign key references EstadoPedido(Id)
)
GO
create table DetallePedido(
Id int primary key identity (1,1),
IdPedido int not null foreign key references Pedidos(Id),
IdBebida int not null foreign key references Bebidas(Id),
Cantidad int not null check (Cantidad>1),
Precio money not null check(Precio>0)
)
go
create procedure SP_AgregarPedido(
@idUsuario int,
@Importe money,
@idMetodoPago int,
@Entrega varchar(100),
@Estado int
)
as
begin
	insert into Pedidos (idUsuario,Importe,idMetodoPago,Entrega,idEstado) output inserted.Id values(@idUsuario,@Importe,@idMetodoPago,@Entrega,@Estado)
end
go
--Inserts EstadoPedido
insert into EstadoPedido values('En preparacion'),
('Enviado'),
('Finalizado'),
('Cancelado')
go
--Inserts MetodosPagos
insert into MetodosPagos values('Mercado Pago')
go
--Insert de Marcas
insert into Marcas values('Coca Cola',0,1)
insert into Marcas values('Manaos',0,1)
insert into Marcas values('Branca',0,1)
insert into Marcas values('Termidor',0,1)
insert into Marcas values('Jack Daniels',1,1)
go
--insert Categorias
insert into Categorias values('Gaseosa',1,0)
insert into Categorias values('Vino',1,1)
insert into Categorias values('Aperitivo',1,1)
insert into Categorias values('Whisky',1,1)
go
--insert Bebidas
insert into Bebidas values('A11','Fernet ',2000,'Bebida alcoholica elaborada con hierbas',1,1,'https://labebidadetusfiestas.com.ar/37266/fernet-branca-1lt.jpg',3,2,50)
insert into Bebidas values('A22','Manao ',300,'Gaseosa berreta',1,1,'https://www.argensend.com/wp-content/uploads/2021/09/D_NQ_NP_716200-MLA43739181284_102020-F.webp',3,3,1)
insert into Bebidas values('B33','Terminaitor ',500,'Jugo de estracto de uva',1000,1,'https://s3.amazonaws.com/storage.wobiz.com/138/138495/images/Large/1557322653_c2314b5790046933a89ca07dbc544870.138495.jpeg',4,3,100)
insert into Bebidas values('JD01','Jack Daniels',25000,'Whisky yanki',1000,1,'https://borrachines.com.ar/wp-content/uploads/2021/11/Jack-Daniels-Old-No.7-Whisky-Destilado-750ml.jpg',5,4,150)
go
--Insert TipoUsuario
insert into TipoUsuario(Nombre)
values('Admin'),
    ('Normal')
go
--Insert Domicilio
insert into Domicilio(Calle, Numero, Provincia, Partido, Localidad)
values ('Av. Corrientes', '992','Buenos Aires','CABA','Monserrat')
go
--Inserts Usuario ADMIN
insert into usuarios(NombreUsuario, Contraseña, IdTipoUsser, Nombre, Apellido, Dni, Email, Telefono, FechaNacimiento, IdDomicilio, Estado, Avatar)
values ('admin','123456',1,'Juan Roman', 'Riquelme', '41239483', 'administrador@almacenBebidas.com', '1521342834','1978-06-24', 1, 1, 'perfil-1')
go
--Consultas
