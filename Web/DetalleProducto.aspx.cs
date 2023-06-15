using Dominio;
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
        private List<Producto> productos {  get; set; }
        private int indice { get; set; }
        private bool hayParam { get; set; }
        private Producto producto { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            hayParam = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    productos = (List<Producto>)Session["ListaProductos"];
                    int parametro = int.Parse(Request.QueryString["id"]);
                    indice = 0;
                    foreach (var producto in productos)
                    {

                        if (producto.IDProducto == parametro)
                        {
                            hayParam = true;
                            Session.Add("Producto", producto);
                            break;
                        }
                        indice++;
                    }

                }
                else
                {
                    lblError.Text = "NO SE RECIBIO NINGUN ARTICULO";
                }
            }
            else
            {
                hayParam = true;
            }

            if (hayParam)
            {
                cargarProducto();
            }
            else
            {
                lblError.Text = "NO EXISTE PRODUCTO CON ESE ID";
            }
        }

        public void cargarProducto()
        {

        }
    }
}