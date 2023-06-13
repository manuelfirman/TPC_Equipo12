using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoUsuario
    {
        public int IDTipo { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre.ToString();
        }
    }
}
