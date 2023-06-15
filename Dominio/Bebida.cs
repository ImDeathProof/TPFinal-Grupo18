﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Bebida
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal ContenidoNeto { get; set; }
        public bool Estado { get; set; }
        public string UrlImg { get; set; }
        public Marca IdMarca { get; set; }
        public Categoria IdCategoria { get; set; }
    }
}
