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
    public partial class ControlVenta : System.Web.UI.Page
    {
        protected Usuario UsuarioSession { get; set; }
        protected Venta Compra { get; set; }
        protected List<Chat> Mensajes { get; set; }
        private VentaNegocio VentaNegocio { get; set; } = new VentaNegocio();
        private ChatNegocio ChatNegocio { get; set; } = new ChatNegocio();

        private EmailService EmailService = new EmailService();
        protected long IDVenta { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioSession = Session["Usuario"] as Usuario;
            if (UsuarioSession == null) Response.Redirect("Ingresar.aspx");
            if (Request.QueryString["Id"] == null) Response.Redirect("404.aspx");


            IDVenta = long.Parse(Request.QueryString["Id"]);

            Compra = VentaNegocio.VentaPorID(IDVenta);
            Mensajes = ChatNegocio.ChatPorVenta(IDVenta);

            if ((UsuarioSession.TipoUser.Nombre == "Usuario" && UsuarioSession.IDUsuario != Compra.Usuario.IDUsuario) && (UsuarioSession.TipoUser.Nombre != "Admin" || UsuarioSession.TipoUser.Nombre != "Vendedor"))
            {
                Response.Redirect("404.aspx");
            }

            if (!IsPostBack)
            {
                if (Mensajes.Count > 0)
                {
                    if (UsuarioSession.TipoUser.Nombre == "Usuario" || Mensajes[0].IDVendedor == UsuarioSession.IDUsuario)
                    {
                        contenedorChat.Visible = true;
                        ListItem item;
                        item = new ListItem("Mensaje", "1");
                        ddlTipoMensaje.Items.Add(item);
                        item = new ListItem("Comprobante", "2");
                        ddlTipoMensaje.Items.Add(item);
                        return;
                    }
                }
            }

        }

        protected void btnPagar_Click1(object sender, EventArgs e)
        {
            CarritoNegocio carrito = new CarritoNegocio();
            foreach (ElementoCarrito elemento in Compra.Factura.Productos)
            {
                carrito.AgregarProducto(elemento.Producto, elemento.Cantidad);
            }
            Session["Carrito"] = carrito;
            Session["IDVenta"] = IDVenta;
            Session["Domicilio"] = UsuarioSession.Domicilios[0];
            Response.Redirect("Pago.aspx");
        }

        protected void BtnComentar_Click(object sender, EventArgs e)
        {
            Chat mensaje = new Chat();
            mensaje.IDVenta = IDVenta;
            mensaje.Remitente = new Usuario();
            mensaje.Remitente.IDUsuario = UsuarioSession.IDUsuario;
            mensaje.IDVendedor = Mensajes[0].IDVendedor;
            mensaje.Mensaje = txtMensaje.Text;

            if (ChatNegocio.CrearMensaje(mensaje)){
                if (Compra.Estado.Estado == "PAGO PENDIENTE" && ddlTipoMensaje.SelectedItem.ToString() == "Comprobante" && UsuarioSession.TipoUser.Nombre == "Usuario")
                {
                    if(txtMensaje.Text.Length == 5)
                    {
                        if (VentaNegocio.CodigoPago(Compra.IDVenta, txtMensaje.Text))
                        {
                            mensaje.Remitente = new Usuario();
                            mensaje.Remitente.IDUsuario = mensaje.IDVendedor;
                            mensaje.Mensaje = "El comprobante se subio con exito";
                            ChatNegocio.CrearMensaje(mensaje);
                            EmailService.armarCorreo(UsuarioSession.Email, "Estado actualizado", $"<h1>SE ACTUALIZO EL ESTADO DE SU COMPRA</h1> <p>ESTADO:PAGADO </p> </br> <p>Muchas gracias!</p>");
                            EmailService.enviarEmail();
                            Redireccion();
                        }
                    }
                    else
                    {
                        mensaje.Remitente = new Usuario();
                        mensaje.Remitente.IDUsuario = mensaje.IDVendedor;
                        mensaje.Mensaje = "Error en la escritura del comprobante";
                        ChatNegocio.CrearMensaje(mensaje);
                    }
                }
                txtMensaje.Text = "";
                Mensajes = ChatNegocio.ChatPorVenta(IDVenta);
                
            }
        }

        protected void ddlTipoMensaje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Redireccion()
        {
            string script = "<script type='text/javascript'>setTimeout(function(){ window.location.href = 'MisCompras.aspx'; }, 200);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Redireccionar", script);
        }
    }
}