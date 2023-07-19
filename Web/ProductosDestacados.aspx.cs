using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class ProductosDestacados : System.Web.UI.Page
    {
        private Usuario usuario = new Usuario();
        private string tipo;
        private long id;
        bool cambioProd;
        private ProductoDestacadoNegocio productoDestacadoNegocio = new ProductoDestacadoNegocio();
        private ProductoNegocio productoNegocio = new ProductoNegocio();
        private ImagenNegocio imagenNegocio = new ImagenNegocio();

        private Producto producto = new Producto();

        private ProductoDestacado destacado = new ProductoDestacado();
        private List<Producto> listaProductos = new List<Producto>();
        private List<Imagen> listaImagenes = new List<Imagen>();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            tipo = Request.QueryString["Tipo"];
            id = Request.Params["Id"] != null ? long.Parse(Request.Params["Id"]) : -1;
            if (usuario != null && (usuario.TipoUser.Nombre == "Vendedor" || usuario.TipoUser.Nombre == "Admin"))
            {
                if (!IsPostBack)
                {
                    cambioProd = false;
                    if (tipo == null || (tipo != "Agregar" && tipo != "Modificar") || (tipo == "Modificar" && Request.QueryString["Id"] == null || Request.QueryString["Id"] == ""))
                    {
                        Response.Redirect("404.aspx");
                    }

                    ListItem item;
                    lblEstado.InnerText = "Estado";
                    item = new ListItem("Activado", "1");
                    DRPEstado.Items.Add(item);
                    item = new ListItem("Desactivado", "2");
                    DRPEstado.Items.Add(item);
                    listaProductos = productoNegocio.ListarTodosLosProductos();

                    foreach (var producto in listaProductos)
                    {
                        item = new ListItem($"{producto.Nombre}", $"{producto.IDProducto}");
                        ddlProductos.Items.Add(item);
                    }

                    if (tipo == "Modificar")
                    {
                        producto = productoNegocio.ProductoPorID(id);
                        ImgUrl.ImageUrl = producto.Imagenes[0].Url;
                        btnAceptar.Text = "Modificar Producto Destacado";
                        lblModificar.Visible = true;
                        lblProd.Visible = true;
                        lblProd.InnerText = $"Actual: {producto.Nombre}";
                    }
                    else
                    {
                        ImgUrl.ImageUrl = listaProductos[0].Imagenes[0].Url;
                        lblAgregar.Visible = true;
                        btnAceptar.Text = "Agregar Producto Destacado";
                    }


                }

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cambioProd)
            {
                destacado.IDProducto = long.Parse(ddlProductos.SelectedValue);

            }
            destacado.Estado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
            lblMessageOk.Visible = false;
            lblMessageError.Visible = false;
            if (tipo == "Agregar")
            {
                if (productoDestacadoNegocio.AgregarProductoDestacado(destacado))
                {
                    lblMessageOk.Visible = true;
                    lblMessageOk.Text = "Se guardo correctamente";
                    return;
                }
                else
                {
                    lblMessageError.Text = "Hubo un error, intente nuevamente";
                    lblMessageError.Visible = true;
                    return;
                }
            }
            else
            {
                ProductoDestacado aux = productoDestacadoNegocio.ProductoPorID(id);
                if (cambioProd)
                {
                    destacado.IDProducto = long.Parse(ddlProductos.SelectedValue);

                }
                else
                {
                    destacado.IDProducto = aux.IDProducto;

                }
                if (productoDestacadoNegocio.ModificarProductoDestacado(aux.IDProductoDestacado, destacado))
                {
                    lblMessageOk.Visible = true;
                    lblMessageOk.Text = "Se modifico correctamente";
                    return;
                }
                else
                {
                    lblMessageError.Text = "Hubo un error, intente nuevamente";
                    lblMessageError.Visible = true;
                    return;
                }
            }
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioProd = true;

            listaImagenes = imagenNegocio.ImagenesProducto(long.Parse(ddlProductos.SelectedValue));
            ImgUrl.ImageUrl = listaImagenes[0].Url;
        }
    }
}