﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Provincia { get; set; }
        public string Partido { get; set; }
        public string Localidad { get; set; }
        public string Departamento { get; set; }
        public string Piso { get; set; }

        public override string ToString()
        {
            return Calle + "" + Numero + "," + Localidad + " " + Partido;
        }
    }
}
