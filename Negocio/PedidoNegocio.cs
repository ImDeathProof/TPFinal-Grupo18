using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoNegocio
    {

        public List<Pedido> Listar()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("select P.Id,P.idUsuario,P.Importe,P.Fecha,P.idMetodoPago,P.Entrega,Ep.Nombre,U.NombreUsuario,U.Email from Pedidos P inner join EstadoPedido Ep on Ep.Id=P.idEstado inner join Usuarios U on U.Id=P.idUsuario");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.usuario= new Usuario();
                    aux.usuario.Id = (int)datos.Lector["idUsuario"];
                    aux.Importe = (decimal)datos.Lector["Importe"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.MedioPago = (int)datos.Lector["idMetodoPago"];
                    aux.Entrega = (string)datos.Lector["Entrega"];
                    aux.Estado= new EstadoPedido();
                    aux.Estado.Descripcion = (string)datos.Lector["Nombre"];
                    aux.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    aux.Email= (string)datos.Lector["Email"];
                    

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int agregar(Pedido nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AgregarPedido");
                datos.setearParametros("@idUsuario", nuevo.usuario.Id);
                datos.setearParametros("@Importe",nuevo.Importe);
                datos.setearParametros("@idMetodoPago",1);
                datos.setearParametros("@Entrega",nuevo.Entrega);
                datos.setearParametros("@Estado",nuevo.Estado.Id);
                
                return datos.ejecutarAccionScalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void cambiarEstado(int id,int estado)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("update Pedidos set idEstado= @Estado where Id=@Id");
                datos.setearParametros("@Estado",estado);
                datos.setearParametros("@Id",id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Pedido> ListarPorUsuario(int id)
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("select P.Id,P.idUsuario,P.Importe,P.Fecha,P.idMetodoPago,P.Entrega,Ep.Nombre,U.NombreUsuario,U.Email from Pedidos P inner join EstadoPedido Ep on Ep.Id=P.idEstado inner join Usuarios U on U.Id=P.idUsuario where P.idUsuario = @idUsuario");
                datos.setearParametros("@idUsuario", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.usuario = new Usuario();
                    aux.usuario.Id = (int)datos.Lector["idUsuario"];
                    aux.Importe = (decimal)datos.Lector["Importe"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.MedioPago = (int)datos.Lector["idMetodoPago"];
                    aux.Entrega = (string)datos.Lector["Entrega"];
                    aux.Estado = new EstadoPedido();
                    aux.Estado.Descripcion = (string)datos.Lector["Nombre"];
                    aux.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    aux.Email = (string)datos.Lector["Email"];


                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void guardarDetalle(int idPedido, int idProducto, int cantidad, decimal precio)
        {
            AccesoDatos.AccesoDatos datos= new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("insert into DetallePedido (IdPedido,IdBebida,Cantidad,Precio) values(@idPedido,@idProducto,@Cantidad,@Precio)");
                datos.setearParametros("@idPedido",idPedido);
                datos.setearParametros("@idProducto",idProducto);
                datos.setearParametros("@Cantidad",cantidad);
                datos.setearParametros("@Precio",precio);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DetallePedido> listarDetalle(int Id)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            List<DetallePedido> lista= new List<DetallePedido>();

            try
            {
                datos.setearConsulta("select Id,IdPedido,IdBebida,Cantidad,Precio from DetallePedido where IdPedido=@Id");
                datos.setearParametros("@Id", Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetallePedido detalle =new DetallePedido();

                    detalle.Id = (int)datos.Lector["Id"];
                    detalle.IdBebida = (int)datos.Lector["IdBebida"];
                    detalle.IdPedido = (int)datos.Lector["IdPedido"];
                    detalle.Cantidad = (int)datos.Lector["Cantidad"];
                    detalle.Precio = (decimal)datos.Lector["Precio"];


                    lista.Add(detalle);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
