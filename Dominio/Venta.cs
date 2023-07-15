using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public long IDVenta { get; set; }
        public Factura Factura { get; set; }
        public Usuario Usuario { get; set; }
        public EstadoVenta Estado { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string TipoPago { get; set; }
        public string CodigoPago { get; set; }
        public string CodigoSeguimiento { get; set; }

        public Venta()
        {
            Factura = new Factura();
            Usuario = new Usuario();
            Estado = new EstadoVenta();
        }
    }
}
