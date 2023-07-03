using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        public long IDDomicilio { get; set; }
        public long IDUsuario { get; set; }
        public Provincia Provincia { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string CodigoPostal { get; set; }
        public string Piso { get; set; }
        public string Referencia { get; set; }
        public string Alias { get; set; }
        public bool Estado { get; set; }

        public Domicilio()
        {
            Provincia = new Provincia();
        }

        public override string ToString()
        {
            string domicilio = $"{Calle} {Altura}, {Localidad}. {Provincia}.";
            return domicilio;
        }
    }
}
