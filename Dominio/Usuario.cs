using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public long IDUsuario { get; set; }
        public TipoUsuario TipoUser { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Domicilio Domicilio { get; set; }
        public bool Estado { get; set; }

        public Usuario()
        {
            TipoUser = new TipoUsuario();
        }
    }
}
