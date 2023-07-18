using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Banner
    {
        public long IDBanner { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Referencia { get; set; }
        public string ImagenUrl { get; set; }
        public bool Estado { get; set; }
    }
}
