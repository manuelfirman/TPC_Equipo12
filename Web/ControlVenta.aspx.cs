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

        }

        protected void btnPagar_Click1(object sender, EventArgs e)
        {
            CarritoNegocio carrito = new CarritoNegocio();
            foreach(ElementoCarrito elemento in Compra.Factura.Productos)
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
            mensaje.Mensaje = txtMensaje.Text;
            if (ChatNegocio.CrearMensaje(mensaje))
            {
                txtMensaje.Text = string.Empty;
                Mensajes = ChatNegocio.ChatPorVenta(IDVenta);
            }
        }
    }
}