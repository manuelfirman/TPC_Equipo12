using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public long IDCategoria { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public override string ToString()
        {
            return Nombre.ToString();
        }
    }
}
