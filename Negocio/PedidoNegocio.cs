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
                datos.setearConsulta("select P.Id,P.idUsuario,P.Importe,P.Fecha,P.idMetodoPago,P.Entrega,Ep.Nombre from Pedidos P\r\ninner join EstadoPedido Ep on Ep.Id=P.idEstado \r\n");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.usuario.Id = (int)datos.Lector["idUsuario"];
                    aux.Importe = (float)datos.Lector["Importe"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.MedioPago = (int)datos.Lector["idMetodoPago"];
                    aux.Entrega = (string)datos.Lector["Entrega"];
                    aux.Estado.Descripcion = (string)datos.Lector["Nombre"];

                    lista.Add(aux);
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
