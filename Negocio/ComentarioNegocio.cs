using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ComentarioNegocio
    {

        public bool CrearComentario(Comentario comentario)
        {
            return true;
        }

        public List<Comentario> ComentariosPorProducto(long IDProducto)
        {
            return new List<Comentario>();
        }

        public List<Comentario> ComentariosPorUsuario(long IDUsuario)
        {
            return new List<Comentario>();
        }

        public bool EliminarComentario(long IDComentario)
        {
            return true;
        }
    }
}
