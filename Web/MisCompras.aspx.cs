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
    public partial class MisCompras : System.Web.UI.Page
    {
        protected Usuario UsuarioSession { get; set; }
        private VentaNegocio VentaNegocio { get; set; } = new VentaNegocio();
        private UsuarioNegocio usuarioNegocio { get; set; } = new UsuarioNegocio();
        protected List<Venta> Compras { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioSession = Session["Usuario"] as Usuario;
            if (UsuarioSession == null) Response.Redirect("Ingresar.aspx");

            Compras = VentaNegocio.ComprasUsuario(UsuarioSession.IDUsuario);
        }


    }
}