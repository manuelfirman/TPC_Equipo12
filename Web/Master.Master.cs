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
        protected Usuario Usuario { get; set; }

        public Master()
        {
            CategoriaNegocioMaster = new CategoriaNegocio();
            MarcaNegocioMaster = new MarcaNegocio();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // USUARIO
            CheckCerrarSesion();

            // CARRITO
            Carrito = Session["Carrito"] as CarritoNegocio;
            if (Carrito == null)
            {
                Carrito = new CarritoNegocio();
                Session["Carrito"] = Carrito;
            }

            if (!IsPostBack)
            {
                Usuario = Session["Usuario"] as Usuario;

                Categorias = CategoriaNegocioMaster.ListarCategoria();
                Marcas = MarcaNegocioMaster.ListarMarcas();
                repCategorias.DataSource = Categorias;
                repCategorias.DataBind();

                repMarcas.DataSource = Marcas;
                repMarcas.DataBind();
                ActualizarCarrito();
            }
        }

        public int CantidadCarrito()
        {
            return Carrito.Cantidad();
        }

        public void AgregarCarrito(Producto producto, int cantidad)
        {
            Carrito.AgregarProducto(producto, cantidad);
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

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int IDProducto = int.Parse(btnEliminar.CommandArgument);
            Carrito.QuitarProducto(IDProducto);
            ActualizarCarrito();
        }

        protected void BtnSumarCantidad_Click(object sender, EventArgs e)
        {
            Button btnSumar = (Button)sender;
            int IDProducto = int.Parse(btnSumar.CommandArgument);
            Carrito.SumarUnProducto(IDProducto);
            ActualizarCarrito();
        }

        protected void BtnRestarCantidad_Click(object sender, EventArgs e)
        {
            Button btnRestar = (Button)sender;
            int IDProducto = int.Parse(btnRestar.CommandArgument);
            Carrito.RestarUnProducto(IDProducto);
            ActualizarCarrito();
        }

        protected void CheckCerrarSesion()
        {
            string salir = Request.QueryString["salir"];
            if (salir != null)
            {
                if (salir == "true")
                {
                    Session["Usuario"] = null;
                    Response.Redirect("Ingresar.aspx");
                }
            }
        }
    }
}