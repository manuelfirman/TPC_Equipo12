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
    public partial class Banner : System.Web.UI.Page
    {
        private Usuario usuario = new Usuario();
        private string tipo;
        private BannerNegocio BannerNegocio = new BannerNegocio();
        private List<Banner> Banners = new List<Banner>();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            tipo = Request.QueryString["Tipo"];
            if (usuario != null && (usuario.TipoUser.Nombre == "Vendedor" || usuario.TipoUser.Nombre == "Admin"))
            {
                if (!IsPostBack)
                {
                    if (tipo == null || (tipo != "Agregar" && tipo != "Modificar") || (tipo == "Modificar" && Request.QueryString["Id"] == null || Request.QueryString["Id"] == ""))
                    {
                        Response.Redirect("404.aspx");
                    }

                    //ListItem item;
                    //lblEstado.InnerText = "Estado";
                    //item = new ListItem("Activada", "1");
                    //DRPEstado.Items.Add(item);
                    //item = new ListItem("Desactivada", "2");
                    //DRPEstado.Items.Add(item);

                    if (tipo == "Modificar")
                    {
                        ImgUrl.Visible = true;
                        long IDBanner = long.Parse(Request.QueryString["Id"]);
                        
                        
                        int indice = 1;

                        btnAceptar.Text = "Modificar Banner Promocion";
                    }
                    else
                    {
                        btnAceptar.Text = "Agregar Banner Promocion";
                        contUrl.Visible = true;
                    }


                }

            }
        }
    }
}