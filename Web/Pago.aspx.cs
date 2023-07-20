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
        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private CarritoNegocio carritoNegocio = new CarritoNegocio();
        private VentaNegocio ventaNegocio = new VentaNegocio();
        private ChatNegocio ChatNegocio = new ChatNegocio();
        private Chat chat = new Chat();
        private List<Usuario> vendedores = new List<Usuario>();
        protected long IDVenta;

        protected decimal total { get; set; }
        protected string PaypalFunctionUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            carritoNegocio = Session["Carrito"] as CarritoNegocio;
            usuario = Session["Usuario"] as Usuario;
            if (usuario != null && carritoNegocio != null)
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
                if (CHKTarjeta.Checked)
                {
                    if(txtNumero.Value.Trim().Length == 16  && txtClave.Value.Length == 3 && txtClave.Value.Length == 5)
                    {
                        Session["IDVenta"] = IDVenta;
                        Session["Carrito"] = new CarritoNegocio();
                        CrearChat();
                        Response.Redirect("CompraRealizada.aspx");
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "REVISE LOS CAMPOS";
                    }
                }
                else
                {
                    Session["IDVenta"] = IDVenta;
                    Session["Carrito"] = new CarritoNegocio();
                    CrearChat();
                    Response.Redirect("CompraRealizada.aspx");
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }

        }

        protected void CrearChat()
        {
            vendedores = usuarioNegocio.ListarVendedores();
            int cantidad = vendedores.Count;
            if(cantidad > 1)
            {
                Random r = new Random();
                int indice = r.Next(0, cantidad);
                chat.IDVenta = IDVenta;
                chat.Mensaje = $"Hola {usuario.Nombre}!, soy {vendedores[indice].Nombre}, estoy aqui para cualquier duda que tengas. Muchas gracias por tu compra!";
                chat.Remitente = vendedores[indice];
                chat.IDVendedor = long.Parse(vendedores[indice].IDUsuario.ToString());
                ChatNegocio.CrearMensaje(chat);
            }
            else
            {
                chat.IDVenta = IDVenta;
                chat.Mensaje = $"Hola {usuario.Nombre}!, soy {vendedores[0].Nombre}, estoy aqui para cualquier duda que tengas. Muchas gracias por tu compra!";
                chat.Remitente = vendedores[0];
                chat.IDVendedor = long.Parse(vendedores[0].IDUsuario.ToString());
                ChatNegocio.CrearMensaje(chat);
            }

            return;
        }
        protected void CHKEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            CHKTarjeta.Checked = false;
            CHKTransferencia.Checked = false;
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
            CHKTransferencia.Checked = false;
            if (CHKTarjeta.Checked)
            {
                txtNumero.Visible = true;
                lblNumero.Visible = true;
                txtFecha.Visible = true;
                lblFecha.Visible = true;
                txtClave.Visible = true;
                lblClave.Visible = true;
            }
            else
            {
                txtNumero.Visible = false;
                lblNumero.Visible = false;
                txtFecha.Visible = false;
                lblFecha.Visible = false;
                txtClave.Visible = false;
                lblClave.Visible = false;
            }
        }

        protected void CHKTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            CHKTarjeta.Checked = false;
            CHKEfectivo.Checked = false;
            txtNumero.Visible = false;
            lblNumero.Visible = false;
            txtFecha.Visible = false;
            lblFecha.Visible = false;
            txtClave.Visible = false;
            lblClave.Visible = false;
        }
    }
}