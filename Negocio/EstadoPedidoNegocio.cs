using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EstadoPedidoNegocio
    {
        public List<EstadoPedido> listar()
        {
            List<EstadoPedido> lista = new List<EstadoPedido>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("select Id,Descripcion from EstadoPedido");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    EstadoPedido Estado = new EstadoPedido();
                    Estado.Id = (int)datos.Lector["Id"];
                    Estado.Descripcion = (string)datos.Lector["Nombre"];

                    lista.Add(Estado);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                datos.cerrarConexion();
            }

        }

    }
}
