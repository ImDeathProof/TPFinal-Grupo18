using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public Usuario usuario { get; set; }
        public float Importe { get; set; }
        public DateTime Fecha { get; set; }
        public int MedioPago { get; set; }
        public string Entrega { get; set; }
        public EstadoPedido Estado { get; set; }
    }
}
