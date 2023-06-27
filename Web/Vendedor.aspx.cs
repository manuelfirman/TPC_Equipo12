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
    public partial class Vendedor : System.Web.UI.Page
    {
        protected MarcaNegocio MarcaNegocio { get; set; } = new MarcaNegocio();
        protected CategoriaNegocio CategoriaNegocio { get; set; } = new CategoriaNegocio();
        protected ProductoNegocio ProductoNegocio { get; set; } = new ProductoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategorias();
                CargarProductos();
            }
        }



        protected void BtnModificarMarca_Click(object sender, EventArgs e)
        {
            string IDMarca = ddlMarcas.SelectedValue;
            Response.Redirect($"Marcas.aspx?Tipo=Modificar&Id={IDMarca}");
        }

        protected void BtnModificarCategoria_Click(object sender, EventArgs e)
        {
            string IDCategoria = ddlCategorias.SelectedValue;
            Response.Redirect($"Categorias.aspx?Tipo=Modificar&Id={IDCategoria}");
        }

        protected void BtnModificarProducto_Click(object sender, EventArgs e)
        {
            string IDProducto = ddlProductos.SelectedValue;
            Response.Redirect($"Productos.aspx?Tipo=Modificar&Id={IDProducto}");
        }

        protected void CargarMarcas()
        {
            List<Marca> marcas = MarcaNegocio.ListarMarcas();
            foreach (Marca marca in marcas)
            {
                ddlMarcas.Items.Add(new ListItem(marca.Nombre, marca.IDMarca.ToString()));
            }

        }

        protected void CargarCategorias()
        {
            List<Categoria> categorias = CategoriaNegocio.ListarCategoria();
            foreach (Categoria categoria in categorias)
            {
                ddlCategorias.Items.Add(new ListItem(categoria.Nombre, categoria.IDCategoria.ToString()));
            }

        }

        protected void CargarProductos()
        {
            List<Producto> productos = ProductoNegocio.ListarTodosLosProductos();
            foreach (Producto producto in productos)
            {
                ddlProductos.Items.Add(new ListItem(producto.Nombre, producto.IDProducto.ToString()));
            }

        }
    }
}