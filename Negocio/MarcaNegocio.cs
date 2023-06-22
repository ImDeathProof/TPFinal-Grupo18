using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("select Id,Nombre from Marcas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Lector["Id"];
                    marca.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(marca);
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
