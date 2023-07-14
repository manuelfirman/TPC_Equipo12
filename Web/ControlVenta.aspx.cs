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
        private VentaNegocio VentaNegocio { get; set; } = new VentaNegocio();
        protected long IDVenta { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioSession = Session["Usuario"] as Usuario;
            if (UsuarioSession == null) Response.Redirect("Ingresar.aspx");
            if (Request.QueryString["Id"] == null) Response.Redirect("404.aspx");

            IDVenta = long.Parse(Request.QueryString["Id"]);
            Compra = VentaNegocio.VentaPorID(IDVenta);
            
            if (UsuarioSession.IDUsuario != Compra.Usuario.IDUsuario || UsuarioSession.TipoUser.Nombre != "Admin")
            {
                Response.Redirect("404.aspx");
            }


        }
    }
}