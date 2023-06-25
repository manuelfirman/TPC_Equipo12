using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Productos : System.Web.UI.Page
    {
        private string tipo;
        private string id;
        private Producto producto = new Producto();
        private ProductoNegocio productoNegocio = new ProductoNegocio();
        private MarcaNegocio marcaNegocio = new MarcaNegocio();
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        public List<Marca> marcas { get; set; }
        public List<Categoria> categorias { get; set; }
        public bool estado { get; set; }

        public Productos()
        {
            marcas = new List<Marca>();
            categorias = new List<Categoria>();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            tipo = Request.Params["Tipo"];
            id = Request.Params["Id"];
            if (!IsPostBack)
            {
                if (tipo == null || (tipo != "Agregar" && tipo != "Modificar"))
                {
                    Response.Redirect("404.aspx");
                }
                marcas = marcaNegocio.ListarMarcas();
                categorias = categoriaNegocio.ListarCategoria();
                int posicion = 1;
                ListItem item;
                foreach (Marca marca in marcas)
                {
                    item = new ListItem(marca.Nombre, posicion.ToString());
                    item.Value = $"{marca.Nombre},{marca.IDMarca}";
                    DRPMarca.Items.Add(item);
                    posicion++;
                }
                posicion = 0;
                foreach (Categoria categoria in categorias)
                {
                    item = new ListItem(categoria.Nombre, posicion.ToString());
                    item.Value = $"{categoria.Nombre},{categoria.IDCategoria}";
                    DRPCategoria.Items.Add(item);
                    posicion++;
                }
                item = new ListItem("Activado", "1");
                DRPEstado.Items.Add(item);
                item = new ListItem("Desactivado", "2");
                DRPEstado.Items.Add(item);
                if (tipo == "Modificar")
                {
                    if (id == null || id == "")
                    {
                        Response.Redirect("404.aspx");

                    }
                    producto = productoNegocio.ProductoPorID(long.Parse(id));
                    txtNombre.Value = producto.Nombre;
                    txtCodigo.Value = producto.Codigo;
                    txtDesc.Value = producto.Descripcion;
                    txtPrecio.Value = Math.Round(producto.Precio).ToString();
                    txtStock.Value = producto.Stock.ToString();
                    lblCategoria.InnerText = $"Categoria actual: {producto.Categoria.Nombre}";
                    lblMarca.InnerText = $"Marca actual: {producto.Marca.Nombre}";
                    btnAgregar.Text = "Modificar Producto";
                    string estadoActual = producto.Estado == true ? "Activado" : "Desactivado";
                    lblEstado.InnerText = $"Estado actual: {estadoActual}";
                    txtTitulo.InnerText = "Modificar Producto";
                }else {
                    txtTitulo.InnerText = "Agregar Producto";
                    lblCategoria.InnerText = "Categoria:";
                    lblMarca.InnerText = "Marca:";
                    lblEstado.InnerText = $"Estado:";
                    btnAgregar.Text = "Agregar Producto";
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = true;
            if (txtNombre.Value == "" || txtCodigo.Value == "" || txtDesc.Value == "" || txtPrecio.Value == "" || txtStock.Value == "")
            {
                lblMessage.Text = "Todos los campos deben estar completos";
                return;
            }
            producto.Nombre = txtNombre.Value;
            producto.Codigo = txtCodigo.Value;
            producto.Descripcion = txtDesc.Value;
            producto.Stock = int.Parse(txtStock.Value);
            producto.Precio = int.Parse(txtPrecio.Value);
            producto.Categoria.Nombre = DRPCategoria.SelectedValue.Split(',')[0];
            producto.Categoria.IDCategoria = long.Parse(DRPCategoria.SelectedValue.Split(',')[1]);
            producto.Marca.Nombre = DRPMarca.SelectedValue.Split(',')[0];
            producto.Marca.IDMarca = long.Parse(DRPMarca.SelectedValue.Split(',')[1]);
            producto.Estado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
            if (tipo == "Agregar"){
                
                bool ok = productoNegocio.AgregarProducto(producto);
                if (ok)
                {
                    lblMessage.Text = "agreado";
                    return;
                }
                lblMessage.Text = "error";
            }else
            {
                producto.IDProducto = long.Parse(id);
                bool ok = productoNegocio.ModificarProducto(producto);
                if (ok)
                {
                    lblMessage.Text = "Modificar";
                    return;
                }
                lblMessage.Text = "error";
            }
        }
    }
}