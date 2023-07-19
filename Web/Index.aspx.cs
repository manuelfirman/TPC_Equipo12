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
    public partial class Index : System.Web.UI.Page
    {
        private ProductoNegocio ProductoNegocioHome { get; set; }
        private ProductoDestacadoNegocio ProductoDestacadoNegocio { get; set; }
        private BannerNegocio bannerNegocio { get; set; }
        private CategoriaNegocio CategoriaNegocioHome { get; set; }
        private MarcaNegocio MarcaNegocioHome { get; set; }

        private List<Producto> ProductosCards { get; set; }
        private List<ProductoDestacado> destacados { get; set; }
        private List<Dominio.Banner> banners { get; set; }
        private List<Dominio.Banner> bannerSlider { get; set; }
        private List<Categoria> CategoriasRandom { get; set; }
        private List<Marca> MarcasRandom { get; set; }

        public Index()
        {
            ProductoDestacadoNegocio = new ProductoDestacadoNegocio();
            ProductoNegocioHome = new ProductoNegocio();
            bannerNegocio = new BannerNegocio();
            CategoriaNegocioHome = new CategoriaNegocio();
            MarcaNegocioHome = new MarcaNegocio();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Imagenes para Banner Principal
                bannerSlider = new List<Dominio.Banner>();
                banners = bannerNegocio.ListarBanners();
                foreach (var banner in banners)
                {
                    if (banner.Estado)
                    {
                        bannerSlider.Add(banner);
                    }
                }
                rptSlider.DataSource = bannerSlider;
                rptSlider.DataBind();

                // Productos para Cards
                Producto aux;
                ProductosCards = new List<Producto>();
                destacados = ProductoDestacadoNegocio.ListarProductos();
                foreach (var destacado in destacados)
                {
                    aux = new Producto();
                    aux = ProductoNegocioHome.ProductoPorID(destacado.IDProducto);
                    ProductosCards.Add(aux);
                }
                rptProductos.DataSource = ProductosCards;
                rptProductos.DataBind();

                //Categorias para Cards
                CategoriasRandom = CategoriaNegocioHome.CategoriasRandom(4);
                rptCategorias.DataSource = CategoriasRandom;
                rptCategorias.DataBind();

                //Marcas para Cards
                MarcasRandom = MarcaNegocioHome.MarcasRandom(4);
                rptMarcas.DataSource = MarcasRandom;
                rptMarcas.DataBind();

            }

            //productosCards = (List<Producto>)Session["ProductosCards"];
        }

        public string CargarImagen(object dataItem)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Producto producto = (Producto)dataItem;

            if (producto != null & producto.Imagenes != null & producto.Imagenes.Count > 0)
            {
                string url = producto.Imagenes.FirstOrDefault().Url;
                if (imagenNegocio.VerificarUrlImagen(url))
                {
                    return url;
                }
            }

            return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'";
        }

        public string CargarImagenRandomCategoria(string categoria)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> imagenes = imagenNegocio.ImagenesRandomPorCategoria(1, categoria);
            if (imagenes.Count == 0) return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'";

            return imagenes.FirstOrDefault().Url;
        }

        public string CargarImagenRandomMarca(string marca)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> imagenes = imagenNegocio.ImagenesRandomPorMarca(1, marca);
            if (imagenes.Count == 0) return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'";

            return imagenes.FirstOrDefault().Url;
        }

        protected string GetButtonCommandArgument(object dataItem)
        {
            var item = (Producto)dataItem;
            return item.IDProducto.ToString();
        }

        protected string EstiloProducto(Producto producto)
        {
            
            if (!producto.Estado)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    if (usuario.TipoUser.Nombre == "Admin" || usuario.TipoUser.Nombre == "Vendedor")
                    {
                        return "opacity-25";
                    }
                }
                return "hide-product";
            }

            return string.Empty;
        }
    }
}