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
    public partial class CompraRealizada : System.Web.UI.Page
    {

        private VentaNegocio ventaNegocio { get; set; } = new VentaNegocio();
        private Usuario usuario = new Usuario();
        protected List<Venta> Compras { get; set; }
        protected long IDVenta;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            if (usuario != null)
            {
                if (!IsPostBack)
                {
                    IDVenta = (long)Session["IDVenta"];
                    long idUsuario = usuario.IDUsuario;
                    Compras = ventaNegocio.CompraPorId(idUsuario, IDVenta);

                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }
    }
}