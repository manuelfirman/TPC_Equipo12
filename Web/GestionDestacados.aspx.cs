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
    public partial class GestionDestacados : System.Web.UI.Page
    {
        private Usuario usuario = new Usuario();
        private BannerNegocio bannerNegocio = new BannerNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            if (usuario == null || usuario.TipoUser.Nombre == "Usuario")
            {
                Response.Redirect("404.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarImagenes();
                }
            }
        }

        protected void BtnModificarProducto_Click(object sender, EventArgs e)
        {
            string IDProducto = ddlProductos.SelectedValue;
            Response.Redirect($"ProductosDestacados.aspx?Tipo=Modificar&Id={IDProducto}");
        }

        protected void BtnModificarImagen_Click(object sender, EventArgs e)
        {
            string IDImagen = dllImagenes.SelectedValue;
            Response.Redirect($"Banners.aspx?Tipo=Modificar&Id={IDImagen}");
        }

        protected void CargarImagenes()
        {
            List<Dominio.Banner> banners = bannerNegocio.ListarBanners();
            foreach (Dominio.Banner banner in banners)
            {
                dllImagenes.Items.Add(new ListItem(banner.Titulo, banner.IDBanner.ToString()));
            }

        }

        protected void CargarProductos()
        {
            List<Dominio.Banner> banners = bannerNegocio.ListarBanners();
            foreach (Dominio.Banner banner in banners)
            {
                dllImagenes.Items.Add(new ListItem(banner.Titulo, banner.IDBanner.ToString()));
            }

        }
    }
}