using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        ADMIN = 1,
        NORMAL = 2
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public TipoUsuario IdTipoUser { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Domicilio Domicilio { get; set; }
        public Usuario(){}
        public Usuario(string user, string pass, bool admin)
        {
            NombreUsuario = user;
            Contraseña = pass;
            IdTipoUser = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }
}
