USE master
GO
DROP DATABASE AlmacenBebidas
GO
create database AlmacenBebidas
GO
USE AlmacenBebidas
GO
CREATE TABLE TipoUsuario(
Id INT PRIMARY KEY identity(1,1),
Nombre VARCHAR(50) NOT NULL
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
create table Banners(
    IdBanner int PRIMARY key IDENTITY(1,1),
    Nombre varchar(300) not null,
    Fecha datetime null DEFAULT(getdate()),
    UrlImg varchar(400) not null
)
go
create table CarritoXUsuarios(
Id int primary key identity(1,1),
IdUsuario int foreign key references Usuarios(Id),
IdCarrito int  foreign key references Carrito(IdCarrito)
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
idEstado int not null foreign key references EstadoPedido(Id),
NumOperacion varchar(50)
)
GO
create table DetallePedido(
Id int primary key identity (1,1),
IdPedido int not null foreign key references Pedidos(Id),
IdBebida int not null foreign key references Bebidas(Id),
Cantidad int not null check (Cantidad>0),
Precio money not null check(Precio>0)
)
go
create procedure SP_AgregarPedido(
@idUsuario int,
@Importe money,
@idMetodoPago int,
@Entrega varchar(100),
@Estado int,
@NumOperacion varchar(50)
)
as
begin
	insert into Pedidos (idUsuario,Importe,idMetodoPago,Entrega,idEstado,NumOperacion) output inserted.Id values(@idUsuario,@Importe,@idMetodoPago,@Entrega,@Estado,@NumOperacion)
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
insert into Marcas values('Coca Cola',0,1),
('Manaos',1,0),
('Branca',1,0),
('Termidor',1,0),
('Jack Daniels',1,1),
('Coca-Cola', 1, 0),
('Pepsi', 1, 0),
('Red Bull', 1, 1)
go
--insert Categorias
insert into Categorias values('Gaseosa',1,0),
('Vino',1,1),
('Aperitivo',1,1),
('Whisky',1,1),
('Energizante',1,0),
('Agua', 1, 0)
go
--insert Bebidas Codigo
insert into Bebidas(Codigo, Nombre, Precio, Descripcion, ContenidoNeto, Estado, UrlImg, IdMarca, IdCategoria, Stock) 
values('A11','Fernet ',2000,'Bebida alcoholica elaborada con hierbas',500,1,'https://labebidadetusfiestas.com.ar/37266/fernet-branca-1lt.jpg',3,3,50),
('A22','Manao ',300,'Gaseosa berreta',2500,0,'https://www.argensend.com/wp-content/uploads/2021/09/D_NQ_NP_716200-MLA43739181284_102020-F.webp',2,1,10),
('B33','Terminaitor ',500,'Jugo de estracto de uva',1000,1,'https://s3.amazonaws.com/storage.wobiz.com/138/138495/images/Large/1557322653_c2314b5790046933a89ca07dbc544870.138495.jpeg',4,2,100),
('JD01','Jack Daniels',25000,'Whisky yanki',1000,1,'https://borrachines.com.ar/wp-content/uploads/2021/11/Jack-Daniels-Old-No.7-Whisky-Destilado-750ml.jpg',5,4,150),
('001', 'Coca-Cola Clasica', 2.99, 'Refresco carbonatado de cola', 355, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSuPG_UiU5N_bv03CJFww0jlpyW-dsYFHLRNg&usqp=CAU', 1, 1, 100),
('002', 'Pepsi Max', 2.49, 'Refresco carbonatado de cola sin azúcar', 330, 0, 'https://secure.ce-tescoassets.com/assets/CZ/913/8594008043913/ShotType1_540x540.jpg', 7, 1, 50),
('003', 'Red Bull Energy Drink', 3.99, 'Bebida energética', 250, 1, 'https://d3ugyf2ht6aenh.cloudfront.net/stores/861/458/products/340861-ef4bc86b471fc2670315743589613643-640-0.webp', 8, 5, 200)
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
--Inserts Banners
insert into Banners(Nombre, UrlImg)
values('Black Friday','https://img.freepik.com/vector-gratis/banner-horizontal-viernes-negro-moderno-fondo-trazo-pincel-blanco_1361-3703.jpg?w=2000'),
('Cyber Monday','https://static.vecteezy.com/system/resources/previews/000/688/545/non_2x/cyber-monday-banner-design-with-neon-lettering-vector.jpg'),
('San Patricio', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcREFoGqc6Cuub3dzTKXMFNgB_Yee8rCxkypkA&usqp=CAU')
go
--Consultas
