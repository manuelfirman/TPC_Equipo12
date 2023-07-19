using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProductoDestacado
    {
        public long IDProductoDestacado { get; set; }
        public long IDProducto { get; set; }
        public bool Estado { get; set; }
    }
}
