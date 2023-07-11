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


        public void agregar(Marca nueva)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("insert into marcas (Nombre) values(@Nombre)");
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
                datos.setearConsulta("update Marcas set Estado = 0 where id = @id");
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
                datos.setearConsulta("update Marcas set Estado = 1 where id = @id");
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
                datos.setearConsulta("delete from Marcas where id = @id");
                datos.setearParametros("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Marca Buscar(int id)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Select Nombre from marcas where id = @id");
                datos.setearParametros("id", id);
                datos.ejecutarLectura();
                datos.Lector.Read();
                Marca marca = new Marca();
                marca.Id = id;
                marca.Nombre = (string)datos.Lector["Nombre"];
                return marca;
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
