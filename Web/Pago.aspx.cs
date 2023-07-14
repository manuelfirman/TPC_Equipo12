using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Pago : System.Web.UI.Page
    {
        private Usuario usuario = new Usuario();
        private Domicilio domicilio = new Domicilio();
        private CarritoNegocio carritoNegocio = new CarritoNegocio();
        private VentaNegocio ventaNegocio = new VentaNegocio();
        protected long IDVenta;

        protected decimal total { get; set; }
        protected string PaypalFunctionUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            carritoNegocio = Session["Carrito"] as CarritoNegocio;
            usuario = Session["Usuario"] as Usuario;
            if(usuario != null && carritoNegocio != null)
            {
                if (!IsPostBack)
                {
                    domicilio = Session["Domicilio"] as Domicilio;
                    total = 0;
                    foreach (var elemento in carritoNegocio.GetElementos())
                    {
                        total += elemento.Producto.Precio * elemento.Cantidad;
                    }
                    lblTotal.Text = $"Total a pagar: ${Math.Round(total, 2)}";
                }
                IDVenta = (long)Session["IDVenta"];
            }
            else
            {
                Response.Redirect("404.aspx");
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string tipoPago;
            if (CHKEfectivo.Checked) tipoPago = "EFECTIVO";
            else if (CHKTarjeta.Checked) tipoPago = "TARJETA";
            else tipoPago = "TRANSFERENCIA";

            if (ventaNegocio.PagoVenta(IDVenta, tipoPago))
            {
                Response.Redirect("CompraRealizada.aspx");
            }
            else
            {
                Response.Redirect("404.aspx");
            }

        }

        protected void CHKEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            CHKTarjeta.Checked = false;
            txtNumero.Visible = false;
            lblNumero.Visible = false;
            txtFecha.Visible = false;
            lblFecha.Visible = false;
            txtClave.Visible = false;
            lblClave.Visible = false;
        }

        protected void CHKTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            CHKEfectivo.Checked = false;
            txtNumero.Visible = true;
            lblNumero.Visible = true;
            txtFecha.Visible = true;
            lblFecha.Visible = true;
            txtClave.Visible = true;
            lblClave.Visible = true;
        }
    }
}