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
        private ProductoDestacadoNegocio productoDestacadoNegocio = new ProductoDestacadoNegocio();
        private ProductoNegocio productoNegocio = new ProductoNegocio();
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
                    CargarProductos();
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
            List<ProductoDestacado> destacados = productoDestacadoNegocio.ListarProductos();
            foreach (ProductoDestacado destacado in destacados)
            {
                Producto productoAux = new Producto();
                productoAux = productoNegocio.ProductoPorID(destacado.IDProducto);
                ddlProductos.Items.Add(new ListItem(productoAux.Nombre, productoAux.IDProducto.ToString()));
            }

        }
    }
}