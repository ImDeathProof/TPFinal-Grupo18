using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BannerNegocio
    {
        public List<Banner> listar()
        {
            List<Banner> lista = new List<Banner>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("select IdBanner, Nombre, Fecha, UrlImg from Banners");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Banner banner = new Banner();
                    banner.Id = (int)datos.Lector["IdBanner"];
                    banner.Nombre = (string)datos.Lector["Nombre"];
                    banner.UrlImg = (string)datos.Lector["UrlImg"];
                    banner.Fecha = DateTime.Parse(datos.Lector["Fecha"].ToString());

                    lista.Add(banner);
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

        public void Guardar(Banner Nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Banners values(Nombre = @Nombre, UrlImg = @UrlImg, Fecha = @Fecha)");

                datos.setearParametros("@Nombre", Nuevo.Nombre);
                datos.setearParametros("@UrlImg", Nuevo.UrlImg);
                datos.setearParametros("@Fecha", Nuevo.Fecha);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void Modificar(Banner Nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("update Banners set Nombre = @Nombre, UrlImg = @UrlImg, Fecha = @Fecha where IdBanner = @Id");

                datos.setearParametros("@Nombre", Nuevo.Nombre);
                datos.setearParametros("@UrlImg", Nuevo.UrlImg);
                datos.setearParametros("@Fecha", Nuevo.Fecha);
                datos.setearParametros("@Id", Nuevo.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public Banner Buscar(int id)
        {
            Banner banner = new Banner();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("select IdBanner, Nombre, Fecha, UrlImg from Banners where IdBanner = @Id");
                datos.setearParametros("@Id", id);
                datos.ejecutarLectura();

                datos.Lector.Read();
                banner.Id = (int)datos.Lector["IdBanner"];
                banner.Nombre = (string)datos.Lector["Nombre"];
                banner.UrlImg = (string)datos.Lector["UrlImg"];
                banner.Fecha = DateTime.Parse(datos.Lector["Fecha"].ToString());

                return banner;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool existe(int id)
        {

            return true;
        }

    }
}