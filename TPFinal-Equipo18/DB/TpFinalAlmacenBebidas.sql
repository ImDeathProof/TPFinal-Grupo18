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
Estado bit default 1 not null,
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

select *from Bebidas
select *from Marcas
select *from Categorias

--Insert de Marcas
insert into Marcas values('Coca Cola',0)
insert into Marcas values('Manaos',0)
insert into Marcas values('Branca',0)
insert into Marcas values('Termidor',0)

--insert Categorias
insert into Categorias values('Gaseosa')
insert into Categorias values('Vino')
insert into Categorias values('Aperitivo')

--insert Bebidas
insert into Bebidas values('A11','Fernet ',2000,'Bebida alcoholica elaborada con hierbas',1,1,'https://labebidadetusfiestas.com.ar/37266/fernet-branca-1lt.jpg',3,2)
insert into Bebidas values('A22','Manao ',300,'Gaseosa berreta',1,1,'https://www.argensend.com/wp-content/uploads/2021/09/D_NQ_NP_716200-MLA43739181284_102020-F.webp',3,3)
insert into Bebidas values('B33','Terminaitor ',500,'Jugo de estracto de uva',1,1,'https://s3.amazonaws.com/storage.wobiz.com/138/138495/images/Large/1557322653_c2314b5790046933a89ca07dbc544870.138495.jpeg',4,3)

SELECT * FROM Bebidas
SELECT * FROM Categorias
SELECT * FROM Marcas

SELECT A.Id, A.Precio, A.Codigo,A.Nombre, A.Descripcion, M.Descripcion Marca ,C.Descripcion Categoria from ARTICULOS A inner join MARCAS M on M.Id=A.IdMarca inner join CATEGORIAS C on C.Id=A.IdCategoria
Select B.Id, B.Codigo, B.Nombre, B.Precio, B.Descripcion, B.ContenidoNeto, B.Estado, B.UrlImg, M.Nombre Marca, C.Nombre Categoria from Bebidas B inner JOIN MARCAS M on M.Id=B.IdMarca inner join CATEGORIAS C on C.Id=B.idCategoria