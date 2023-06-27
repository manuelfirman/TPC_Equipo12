using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                string filtro = Request.QueryString["Filtro"];
                string tipo = Request.QueryString["Tipo"];
                string nombre = Request.QueryString["Nombre"];
                string busqueda = Request.QueryString["Busqueda"];

                if(filtro == null)
                {
                    lblTitulo.Text = "NO SE HA SELECCIONADO NADA";
                    return;
                }
                else if(filtro == "busqueda")
                {
                    FiltroBusqueda(busqueda);
                }
                else if (filtro == "detalle")
                {
                    FiltroDetalle(nombre, tipo);
                }

                rptProductos.DataSource = productoNegocio.ProductosAlAzar(4);
                rptProductos.DataBind();
            }
        }

        public void FiltroDetalle(string nombre, string tipo)
        {
            if (nombre == null || tipo == null)
            {

                lblTitulo.Text = "NO SE HA SELECCIONADO NADA";
                return;
            }
            else if (tipo == "Marca" || tipo == "Categoria")
            {
                listaProductos = productoNegocio.ListarPorTipo(nombre, tipo);
                lblTitulo.Text = tipo.ToUpper() + " " + nombre.ToUpper();
                if (listaProductos.Count == 0)
                {
                    lblTitulo.Text = "NO EXISTEN PRODUCTOS PARA " + nombre.ToUpper();
                    return;
                }
                RepFiltro.DataSource = listaProductos;
                RepFiltro.DataBind();
            }
            else
            {
                lblTitulo.Text = nombre.ToUpper() + " NO EXISTE";
            }
        }

        public void FiltroBusqueda(string busqueda)
        {
            listaProductos = productoNegocio.BuscadorProductos(busqueda);
            lblTitulo.Text = "Resultado de la busqueda: " + busqueda;
            if (listaProductos.Count == 0)
            {
                lblTitulo.Text = "NO SE ENCONTRARON PRODUCTOS PARA LA BUSQUEDA: " + busqueda;
                return;
            }
            RepFiltro.DataSource = listaProductos;
            RepFiltro.DataBind();
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