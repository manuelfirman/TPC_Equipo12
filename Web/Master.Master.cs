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
    public partial class Master : System.Web.UI.MasterPage
    {
        private List<Categoria> Categorias { get; set; }
        private List<Marca> Marcas{ get; set; }
        private CategoriaNegocio CategoriaNegocioMaster { get; set; }
        private MarcaNegocio MarcaNegocioMaster { get; set; }
        protected CarritoNegocio Carrito { get; set; }

        public Master()
        {
            CategoriaNegocioMaster = new CategoriaNegocio();
            MarcaNegocioMaster = new MarcaNegocio();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Carrito = Session["Carrito"] as CarritoNegocio;
            if (Carrito == null)
            {
                Carrito = new CarritoNegocio();
                Session["Carrito"] = Carrito;
            }

            if (!IsPostBack)
            {
                Categorias = CategoriaNegocioMaster.ListarCategoria();
                Marcas = MarcaNegocioMaster.ListarMarcas();
                repCategorias.DataSource = Categorias;
                repCategorias.DataBind();

                repMarcas.DataSource = Marcas;
                repMarcas.DataBind();

                

            }

            ActualizarCarrito();
        }

        public int CantidadCarrito()
        {
            return Carrito.Cantidad();
        }

        public void AgregarCarrito(Producto producto, int cantidad)
        {
            Carrito.AgregarProducto(producto, cantidad);
        }

        public void QuitarCarrito(Producto producto)
        {
            Carrito.QuitarProducto(producto.IDProducto);
        }

        public void ActualizarCarrito()
        {
            Session["Carrito"] = Carrito;
            rptModal.DataSource = Carrito.Elementos();
            rptModal.DataBind();
        }

        public void MostrarCarrito()
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}