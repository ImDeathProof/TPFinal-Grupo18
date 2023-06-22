using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
			List<Categoria> lista= new List<Categoria>();
			AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

			try
			{
				datos.setearConsulta("select Id,Nombre from Categorias");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Categoria categoria= new Categoria();
					categoria.Id = (int)datos.Lector["Id"];
					categoria.Nombre = (string)datos.Lector["Nombre"];

					lista.Add(categoria);
				}

				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally {

				datos.cerrarConexion();
			}

        }
    }
}
