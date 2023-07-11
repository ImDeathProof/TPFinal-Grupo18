
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




insert into Pedidos values (1,1,1,'',1)

insert into EstadoPedido values('En preparacion')
insert into EstadoPedido values('Enviado')
insert into EstadoPedido values('Finalizado')
insert into EstadoPedido values('Cancelado')

insert into MetodosPagos values('Mercado Pago')

create table DetallePedido(
Id int primary key identity (1,1),
IdPedido int not null foreign key references Pedidos(Id),
IdBebida int not null foreign key references Bebidas(Id),
Cantidad int not null check (Cantidad>1),
Precio money not null check(Precio>0)
)

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

exec SP_AgregarPedido 1,100,1,'',1

insert into DetallePedido (IdPedido,IdBebida,Cantidad,Precio) values(1,3,10,1)

