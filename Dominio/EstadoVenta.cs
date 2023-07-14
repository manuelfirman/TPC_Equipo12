using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EstadoVenta
    {
        public long IDEstado { get; set; }
        public string Estado { get; set; }
        public bool Terminal { get; set; }
    }
}
