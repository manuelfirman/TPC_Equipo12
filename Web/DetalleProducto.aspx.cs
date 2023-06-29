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
        protected bool HayComentarios { get; set; }
        public Producto Producto { get; set; }
        private ProductoNegocio ProductoNegocioDetalle { get; set; }
        private ComentarioNegocio ComentarioNegocio { get; set; } = new ComentarioNegocio();
        private List<Comentario> Comentarios { get; set; }

        public DetalleProducto()
        {
            ProductoNegocioDetalle = new ProductoNegocio();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("404.aspx");
            }

            int IDProducto = int.Parse(Request.QueryString["id"]);
            Producto = ProductoNegocioDetalle.ProductoPorID(IDProducto);
            Session["Producto"] = Producto;
            rptImagenes.DataSource = Producto.Imagenes;
            rptImagenes.DataBind();
            rptMiniaturas.DataSource = Producto.Imagenes;
            rptMiniaturas.DataBind();
            rptProductos.DataSource = ProductoNegocioDetalle.ProductosAlAzar(4);
            rptProductos.DataBind();

            if (!IsPostBack)
            {
                ActualizarComentarios(IDProducto);
                
            }
            else if (Producto != null)
            {
                Producto = Session["Producto"] as Producto;
                Comentarios = Session["Comentarios"] as List<Comentario>;
            }
            else
            {
                Response.Redirect("404.aspx");
            }

            if (Comentarios.Count == 0) HayComentarios = false;
            else HayComentarios = true;
        }

        public void ActualizarComentarios(long IDProducto)
        {
            Comentarios = ComentarioNegocio.ComentariosPorProducto(IDProducto);
            Session["Comentarios"] = Comentarios;
            rptComments.DataSource = Comentarios;
            rptComments.DataBind();
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

        protected void BtnComentar_Click(object sender, EventArgs e)
        {
            Comentario comentario = new Comentario();
            comentario.IDProducto = Producto.IDProducto;
            comentario.IDUsuario = ((Usuario)Session["Usuario"]).IDUsuario;
            comentario.TextoComentario = txtComment.Text;

            if(txtComment.Text != "")
            {
                if (ComentarioNegocio.CrearComentario(comentario))
                {
                    txtComment.Text = "";
                    comentario = new Comentario();
                }
            }

            ActualizarComentarios(Producto.IDProducto);
        }

        protected void BtnBorrarComentario_Click(object sender, EventArgs e)
        {
            Button btnBorrar = (Button)sender;
            int IDComentario = int.Parse(btnBorrar.CommandArgument);

            if(ComentarioNegocio.EliminarComentario(IDComentario))
            {
                // TODO: Cartelito de comentario eliminado
            }

            ActualizarComentarios(((Producto)Session["Producto"]).IDProducto);
        }

        protected void BotonEditarProducto(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                
                ProductoNegocioDetalle.EstadoProducto(Producto.IDProducto, false);
                Response.Redirect($"Filtro.aspx?Filtro=Eliminar&Nombre={Producto.Nombre}");
            }
            else if (e.CommandName == "Editar")
            {
                Response.Redirect("Productos.aspx?Tipo=Modificar&Id=" + Producto.IDProducto);
            }

        }
    }
}