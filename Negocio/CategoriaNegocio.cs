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
        public void agregar(Categoria nueva)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("insert into categorias (Nombre) values(@Nombre)");
                datos.setearParametros("@Nombre", nueva.Nombre);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void bajaLogica(int id)
        {
            try
            {
                AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
                datos.setearConsulta("update categorias set Estado = 0 where id = @id");
                datos.setearParametros("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void altaLogica(int id)
        {
            try
            {
                AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
                datos.setearConsulta("update categorias set Estado = 1 where id = @id");
                datos.setearParametros("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
                datos.setearConsulta("delete from categorias where id = @id");
                datos.setearParametros("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
