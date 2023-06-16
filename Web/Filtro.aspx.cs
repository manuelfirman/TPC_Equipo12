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
    public partial class Filtro : System.Web.UI.Page
    {
        List<Producto> listaProductos = new List<Producto>();
        ProductoNegocio productoNegocio = new ProductoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tipo = Request.QueryString["Tipo"];
                string nombre = Request.QueryString["Nombre"];
                if (nombre == null || tipo == null)
                {
                    lblTitulo.Text = "NO SE A SELECCIONADO NADA";
                    return;
                }else if (tipo == "Marca" || tipo == "Categoria")
                {
                    listaProductos = productoNegocio.listarPorTipo(nombre, tipo);
                    lblTitulo.Text = "Productos para la marca" + tipo;
                    if(listaProductos.Count == 0)
                    {
                        lblTitulo.Text = "NO EXISTEN PRODUCTOS PARA " + tipo;
                        return;
                    }
                    RepFiltro.DataSource = listaProductos;
                    RepFiltro.DataBind();
                }
                else
                {
                    lblTitulo.Text = tipo + " no existe";
                }

            }
        }

        public string cargarImagen(object dataItem)
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