using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Chat
    {
        public long IDMensaje { get; set; }
        public long IDVenta { get; set; }
        public long IDRemitente { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
    }
}
