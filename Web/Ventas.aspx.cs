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
    public partial class Ventas : System.Web.UI.Page
    {
        protected List<Venta> ventas { get; set; }
        protected Usuario Usuario { get; set; }
        private VentaNegocio ventaNegocio { get; set; } = new VentaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Session["Usuario"] as Usuario;
            if(Usuario == null || (Usuario.TipoUser.Nombre != "Admin" && Usuario.TipoUser.Nombre != "Vendedor"))
            {
                Response.Redirect("404.aspx");
            }

            ventas = ventaNegocio.ListarVentas();
            rptVentas.DataSource = ventas;
            rptVentas.DataBind();

        }
    }
}