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
        private Usuario usuario = new Usuario();
        private ProductoNegocio productoNegocio = new ProductoNegocio();
        private MarcaNegocio marcaNegocio = new MarcaNegocio();
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        private ImagenNegocio imagenNegocio = new ImagenNegocio();
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
            usuario = Session["Usuario"] as Usuario;
            if (usuario != null && (usuario.TipoUser.Nombre == "Vendedor" || usuario.TipoUser.Nombre == "Admin"))
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
                        BtnAgrearImagen.Visible = true;
                        BtnModificarImagen.Visible = true;
                    }
                    else
                    {
                        txtTitulo.InnerText = "Agregar Producto";
                        lblCategoria.InnerText = "Categoria:";
                        lblMarca.InnerText = "Marca:";
                        lblEstado.InnerText = $"Estado:";
                        btnAgregar.Text = "Agregar Producto";
                        lblUrl.Visible = true;
                        txtUrl.Visible = true;
                        txtInfo.Visible = true;
                    }
                }
            }
            else{
                Response.Redirect("404.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblMessageOk.Visible = false;
            lblMessageError.Visible = false;

            if (txtNombre.Value == "" || txtCodigo.Value == "" || txtDesc.Value == "" || txtPrecio.Value == "" || txtStock.Value == "")
            {
                lblMessageError.Text = "Todos los campos deben estar completos";
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
            if (tipo == "Agregar")
            {

                long id = productoNegocio.AgregarProducto(producto);
                if (id != -1)
                {
                    if (txtUrl.Value != "")
                    {
                        int cantidadUrls = txtUrl.Value.Split(',').Length;
                        int okimg = 0;
                        for (int i = 0; i < cantidadUrls; i++)
                        {
                            Imagen imagenAux = new Imagen();
                            imagenAux.IDProducto = id;
                            imagenAux.Url = txtUrl.Value.Split(',')[i];
                            imagenAux.Descripcion = imagenAux.Descripcion == null ? "" : imagenAux.Descripcion;
                            okimg = imagenNegocio.Guardar(imagenAux) ? okimg + 1 : okimg;
                        }
                        
                        if (okimg != cantidadUrls)
                        {
                            lblMessageError.Visible = true;
                            lblMessageError.Text = "Hubo un error al guardar las imagenes, el producto se guardo correctamente, para agregar imagenes dirigase a 'Modificar Productos' ";
                        }
                    }
                    lblMessageError.Visible = false;
                    lblMessageOk.Visible = true;
                    lblMessageOk.Text = "Producto agregado correctamente";
                    lblMessageRedirect.Visible = true;
                    lblMessageRedirect.Text = "Redireccionando en 3 segundos...";
                    Redireccion("Vendedor");
                    return;
                }
                lblMessageError.Visible = true;
                lblMessageError.Text = "error";
            }
            else
            {
                producto.IDProducto = long.Parse(id);
                bool ok = productoNegocio.ModificarProducto(producto);
                if (ok)
                {
                    lblMessageOk.Visible = true;
                    lblMessageOk.Text = "Producto Modificado correctamente";
                    lblMessageRedirect.Visible = true;
                    lblMessageRedirect.Text = "Redireccionando en 3 segundos...";
                    Redireccion("Vendedor");
                    return;
                }
                lblMessageError.Visible = true;
                lblMessageError.Text = "error";
            }
        }

        protected void Redireccion(string pagina)
        {
            string script = "<script type='text/javascript'>setTimeout(function(){ window.location.href = '" + pagina + ".aspx'; }, 3000);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Redireccionar", script);
        }

        protected void BtnAgrearImagen_Click(object sender, EventArgs e)
        {
            string IDProducto = Request.Params["Id"];
            Response.Redirect($"Imagenes.aspx?Tipo=Agregar&Id={IDProducto}");
        }

        protected void BtnModificarImagen_Click(object sender, EventArgs e)
        {
            string IDProducto = Request.Params["Id"];
            Response.Redirect($"Imagenes.aspx?Tipo=Modificar&Id={IDProducto}");
        }
    }
}