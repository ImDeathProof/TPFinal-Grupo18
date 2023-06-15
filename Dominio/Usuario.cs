using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Usuario
    {
        public int Id {get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int IdTipoUser { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Domicilio Domicilio { get; set; }
    }
}
