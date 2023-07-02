using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Microsoft.Win32;

namespace Negocio
{
    public class DomicilioNegocio
    {
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
                }else
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
    }
}
