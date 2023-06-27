using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, NombreUsuario, Contraseña, IdTipoUsser from USUARIOS where NombreUsuario = @user AND Contraseña = @pass ");
                datos.setearParametros("@user",usuario.NombreUsuario);
                datos.setearParametros("@pass", usuario.Contraseña);

                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.IdTipoUser = (int)(datos.Lector["IdTipoUsser"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;
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
        public void Registrar(Usuario Nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Usuarios values (@NombreUsuario, @Contraseña, @IdTipoUsser,@Nombre, @Apellido, @Dni, @Email, @Telefono, @FechaNacimiento, @IdDomicilio)");
                
                datos.setearParametros("@NombreUsuario", Nuevo.NombreUsuario);
                datos.setearParametros("@Contraseña", Nuevo.Contraseña);
                datos.setearParametros("@IdTipoUsser", 2);
                datos.setearParametros("@Nombre", Nuevo.Nombre);
                datos.setearParametros("@Apellido", Nuevo.Apellido);
                datos.setearParametros("@Dni", Nuevo.DNI);
                datos.setearParametros("@Email", Nuevo.Email);
                datos.setearParametros("@Telefono", Nuevo.Telefono);
                datos.setearParametros("@FechaNacimiento", Nuevo.FechaNacimiento);
                datos.setearParametros("@IdDomicilio", 1);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public bool Buscar(string NUsuario)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Select NombreUsuario from Usuarios");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    if ((string)datos.Lector["NombreUsuario"] == NUsuario)
                    {
                        return true;
                    }
                }
                return false;
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
