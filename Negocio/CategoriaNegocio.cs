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
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Nombre, Alcoholica from Categorias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)datos.Lector["Id"];
                    categoria.Nombre = (string)datos.Lector["Nombre"];
                    categoria.Tipo = (bool)datos.Lector["Alcoholica"];

                    lista.Add(categoria);
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
        public void agregar(Categoria nueva)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("insert into categorias (Nombre, Alcoholica) values(@Nombre, @Tipo)");
                datos.setearParametros("@Nombre", nueva.Nombre);
                datos.setearParametros("@Tipo", nueva.Tipo);
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
        public Categoria Buscar(int id)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Select Nombre, Alcoholica from Categorias where id = @id");
                datos.setearParametros("id", id);
                datos.ejecutarLectura();
                datos.Lector.Read();
                Categoria categoria = new Categoria();
                categoria.Id = id;
                categoria.Nombre = (string)datos.Lector["Nombre"];
                categoria.Tipo = (bool)datos.Lector["Alcoholica"];
                return categoria;
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
