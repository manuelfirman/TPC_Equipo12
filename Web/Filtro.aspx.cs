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
                // Sugeridos
                rptProductos.DataSource = productoNegocio.ProductosAlAzar(4);
                rptProductos.DataBind();

                string filtro = Request.QueryString["Filtro"];
                string tipo = Request.QueryString["Tipo"];
                string nombre = Request.QueryString["Nombre"];
                string busqueda = Request.QueryString["Busqueda"];


                switch (filtro)
                {
                    case null:
                        lblTitulo.Text = "Lo sentimos. No se encontraron resultados :(";
                        return;

                    case "Busqueda":
                        FiltroBusqueda(busqueda);
                        break;
                    case "Detalle":
                        FiltroDetalle(nombre, tipo);
                        break;
                    case "Eliminar":
                        lblTitulo.Text = $"Producto '{nombre}' eliminado correctamente.";
                        break;
                }

                if (filtro == null)
                {
                    lblTitulo.Text = "Lo sentimos. No se encontraron resultados :(";
                    return;
                }
                else if (filtro == "Busqueda")
                {
                    FiltroBusqueda(busqueda);
                }
                else if (filtro == "Detalle")
                {
                    FiltroDetalle(nombre, tipo);
                }

            }
        }

        public void FiltroDetalle(string nombre, string tipo)
        {
            if (nombre == null || tipo == null)
            {
                lblTitulo.Text = "No se recibieron parametros para la busqueda";
                return;
            }
            else if (tipo == "Marca" || tipo == "Categoria")
            {
                listaProductos = productoNegocio.ListarPorTipo(nombre, tipo);
                lblTitulo.Text = $"{tipo} {nombre}";
                if (listaProductos.Count == 0)
                {
                    lblTitulo.Text = $"No hay productos para la busqueda {nombre}";
                    return;
                }
                RepFiltro.DataSource = listaProductos;
                RepFiltro.DataBind();
            }
            else
            {
                lblTitulo.Text = $"No existen productos con el nombre {nombre}";
            }
        }

        public void FiltroBusqueda(string busqueda)
        {
            listaProductos = productoNegocio.BuscadorProductos(busqueda);
            lblTitulo.Text = "Resultado de la busqueda: " + busqueda;
            if (listaProductos.Count == 0)
            {
                lblTitulo.Text = $"No se encontraron productos para la busqueda: {busqueda}";
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

        protected void BotonEditarProducto(object sender, CommandEventArgs e)
        {
            string IDProducto = e.CommandArgument.ToString();
            if (e.CommandName == "Eliminar")
            {
                productoNegocio.EstadoProducto(int.Parse(IDProducto), false);
                Response.Redirect($"Filtro.aspx?Filtro=Eliminar&Nombre={IDProducto}");
            }
            else if (e.CommandName == "Editar")
            {
                Response.Redirect("Productos.aspx?Tipo=Modificar&Id=" + IDProducto);
            }
        }

    }
}