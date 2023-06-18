using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
    
        private int Indice { get; set; }
        private bool HayParam { get; set; }
        public Producto Producto { get; set; }
        private ProductoNegocio ProductoNegocioDetalle { get; set; }

        public DetalleProducto()
        {
            ProductoNegocioDetalle = new ProductoNegocio();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                // TODO: REDIRECT PAGINA 404
                lblError.Text = "NO SE RECIBIO NINGUN ARTICULO";
            }
            if (!IsPostBack)
            {
                int IDProducto = int.Parse(Request.QueryString["id"]);
                Producto = ProductoNegocioDetalle.ProductoPorID(IDProducto);
                Session.Add("Producto", Producto);
                rptImagenes.DataSource = Producto.Imagenes;
                rptImagenes.DataBind();
                rptMiniaturas.DataSource = Producto.Imagenes;
                rptMiniaturas.DataBind();
                rptProductos.DataSource = ProductoNegocioDetalle.ProductosAlAzar(4);
                rptProductos.DataBind();

                List<Producto> comments = ProductoNegocioDetalle.ProductosAlAzar(4);
                rptComments.DataSource = comments;
                rptComments.DataBind();
            }
            else
            {
                Producto = Session["Producto"] as Producto;
            }

            if (Producto != null)
            {
                CargarProducto();
            }
            else
            {
                // TODO: REDIRECT PAGINA 404
                lblError.Text = "NO EXISTE PRODUCTO CON ESE ID";
            }
        }

        public void CargarProducto()
        {

        }

        protected void BtnAgregarCarrito_Click(object sender, EventArgs e)
        {
            var masterPage = this.Master as Master;            

            Producto producto = Session["Producto"] as Producto;

            masterPage.AgregarCarrito(producto, 1);
            masterPage.ActualizarCarrito();
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
    }
}