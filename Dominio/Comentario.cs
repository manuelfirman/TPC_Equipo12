using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comentario
    {
        public long IDComentario {  get; set; } 
        public long IDProducto { get; set; }
        public long IDUsuario { get; set; }
        public string TextoComentario { get; set; }
        public bool Estado { get; set; }
    }
}
