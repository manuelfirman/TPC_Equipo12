using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public long IDImagen { get; set; }
        public long IDProducto { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public bool Estado { get; set; }
    }
}
