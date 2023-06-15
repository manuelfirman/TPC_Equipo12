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
        private ProductoNegocio productoNegocio { get; set; }
        private ImagenNegocio imagenNegocio { get; set; }
        private CategoriaNegocio categoriaNegocio { get; set; }
        private MarcaNegocio marcaNegocio { get; set; }

        private List<Producto> productosCards { get; set; }
        private List<Imagen> imagenesSlider { get; set; }
        private List<Categoria> categoriasRandom { get; set; }
        private List<Marca> marcasRandom { get; set; }

        public Index()
        {
            productoNegocio = new ProductoNegocio(); 
            imagenNegocio = new ImagenNegocio();
            categoriaNegocio = new CategoriaNegocio();
            marcaNegocio = new MarcaNegocio();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Imagenes para Banner Principal
                imagenesSlider = imagenNegocio.ImagenesAlAzar(8);
                rptSlider.DataSource = imagenesSlider;
                rptSlider.DataBind();

                // Productos para Cards
                productosCards = productoNegocio.ProductosAlAzar(6);
                rptProductos.DataSource = productosCards;
                rptProductos.DataBind();

                //Categorias para Cards
                categoriasRandom = categoriaNegocio.CategoriasRandom(4);
                rptCategorias.DataSource = categoriasRandom;
                rptCategorias.DataBind();

                //Marcas para Cards
                marcasRandom = marcaNegocio.MarcasRandom(4);
                rptMarcas.DataSource = marcasRandom;
                rptMarcas.DataBind();

            }

            //productosCards = (List<Producto>)Session["ProductosCards"];
        }

        public string cargarImagen(object dataItem)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Producto producto = (Producto)dataItem;

            if(producto != null & producto.Imagenes != null & producto.Imagenes.Count > 0)
            {
                string url = producto.Imagenes.FirstOrDefault().Url;
                if (imagenNegocio.VerificarUrlImagen(url))
                {
                    return url;
                }
            }

            return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'";
        }

        public string cargarImagenRandomCategoria(string categoria)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> imagenes = imagenNegocio.ImagenesRandomPorCategoria(1, categoria);
            if(imagenes.Count  == 0) return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'";

            return imagenes.FirstOrDefault().Url;
        }

        public string cargarImagenRandomMarca(string marca)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> imagen = new List<Imagen>();
            imagen = imagenNegocio.ImagenesRandomPorCategoria(1, marca);
            return imagen.FirstOrDefault().Url;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected string GetButtonCommandArgument(object dataItem)
        {
            var item = (Producto)dataItem;
            return item.IDProducto.ToString();
        }
    }
}