
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
Fecha date not null,
idMetodoPago int not null foreign key references MetodosPagos(Id),
Entrega varchar(100) not null,
idEstado int not null foreign key references EstadoPedido(Id)
)

alter table Pedidos add default getdate() for Fecha


insert into Pedidos values (1,1,1,'',1)

insert into EstadoPedido values('En preparacion')
insert into EstadoPedido values('Enviado')
insert into EstadoPedido values('Finalizado')
insert into EstadoPedido values('Cancelado')

insert into MetodosPagos values('Mercado Pago')