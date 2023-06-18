using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
        public long IDFactura { get; set; }
        public bool Pago { get; set; }
        public bool Cancelada { get; set; }
        public List<ElementoCarrito> Productos { get; set; }

        public Factura()
        {
            Productos = new List<ElementoCarrito>();
        }
    }
}
