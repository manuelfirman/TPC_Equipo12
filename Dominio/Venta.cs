using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public long IDVenta { get; set; }
        public Factura Factura { get; set; }
        public Usuario Usuario { get; set; }
        public EstadoVenta Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
