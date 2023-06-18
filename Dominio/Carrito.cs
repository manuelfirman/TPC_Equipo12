using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public List<ElementoCarrito> Elementos {  get; set; }
        public decimal Total { get; set; }

        public Carrito()
        {
            Elementos = new List<ElementoCarrito>();
            Total = 0;
        }

    }
}
