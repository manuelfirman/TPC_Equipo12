using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ElementoCarrito
    {
        public int IDElemento { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
    }
}
