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
    }
}
