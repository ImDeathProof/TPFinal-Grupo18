using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Microsoft.Win32;

namespace Negocio
{
    public class DomicilioNegocio
    {
        public void Actualizar(Domicilio nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Update Domicilio set Calle = @Calle, Numero = @Numero, Provincia = @Provincia, Partido = @Partido, Localidad = @Localidad, Departamento = @Departamento, Piso = @Piso where Id = @Id");
                datos.setearParametros("@Calle", nuevo.Calle);
                datos.setearParametros("@Numero", nuevo.Numero);
                datos.setearParametros("@Provincia", nuevo.Provincia);
                datos.setearParametros("@Partido", nuevo.Partido);
                datos.setearParametros("@Localidad", nuevo.Localidad);
                datos.setearParametros("@Departamento", nuevo.Departamento);
                datos.setearParametros("@Piso", nuevo.Piso);
                datos.setearParametros("@Id", nuevo.Id);
                datos.ejecutarAccion();

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

        public Domicilio Buscar(Usuario User)
        {
            Domicilio encontrado = new Domicilio();
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.setearConsulta("Select D.Id, D.Calle, D.Numero, D.Provincia, D.Partido, D.Localidad, D.Departamento, D.Piso from Domicilio D inner join Usuarios U on U.IdDomicilio = D.Id where U.Id = @IdUsuario");
                Datos.setearParametros("@IdUsuario", User.Id);
                Datos.ejecutarLectura();
                Datos.Lector.Read();
                encontrado.Id = (int)Datos.Lector["Id"];
                encontrado.IdUsuario = User.Id;
                encontrado.Numero = (string)Datos.Lector["Numero"];
                encontrado.Calle = (string)Datos.Lector["Calle"];
                encontrado.Provincia = (string)Datos.Lector["Provincia"];
                encontrado.Partido = (string)Datos.Lector["Partido"];
                encontrado.Localidad = (string)Datos.Lector["Localidad"];
                if (Datos.Lector["Departamento"] is DBNull)
                {
                    encontrado.Departamento = "-";
                }
                else
                {
                    encontrado.Departamento = (string)Datos.Lector["Departamento"];
                }
                if (Datos.Lector["Piso"] is DBNull)
                {
                    encontrado.Piso = "-";
                }
                else
                {
                    encontrado.Piso = (string)Datos.Lector["Piso"];
                }

                return encontrado;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }

        public void Cargar(Domicilio nuevo, Usuario user)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Domicilio values (@Calle, @Numero, @Provincia, @Partido, @Localidad, @Departamento, @Piso); SELECT SCOPE_IDENTITY(); ");
                datos.setearParametros("@Calle", nuevo.Calle);
                datos.setearParametros("@Numero", nuevo.Numero);
                datos.setearParametros("@Provincia", nuevo.Provincia);
                datos.setearParametros("@Partido", nuevo.Partido);
                datos.setearParametros("@Localidad", nuevo.Localidad);
                datos.setearParametros("@Departamento", nuevo.Departamento);
                datos.setearParametros("@Piso", nuevo.Piso);
                datos.ejecutarAccion();
                datos.cerrarConexion();
                int idDomicilio = obtenerUltimaId();
                datos = new AccesoDatos.AccesoDatos();
                ///CARGA LA ID EN LA TABLA DE USUARIOS
                datos.setearConsulta("UPDATE Usuarios SET IdDomicilio = @IdDomicilio WHERE Id = @IdUsuario");
                datos.setearParametros("@IdDomicilio", idDomicilio);
                datos.setearParametros("@IdUsuario", user.Id);
                datos.ejecutarAccion();
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
        protected int obtenerUltimaId()
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            int ultima;
            try
            {
                datos.setearConsulta("select count(*) as id from Domicilio");
                datos.ejecutarLectura();
                datos.Lector.Read();
                ultima = (int)datos.Lector["id"];
                return ultima;

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
