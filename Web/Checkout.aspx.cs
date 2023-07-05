using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Checkout : System.Web.UI.Page
    {
        private Usuario usuario = new Usuario();
        private List<ElementoCarrito> elementoCarritos = new List<ElementoCarrito>();
        public CarritoNegocio carritoNegocio { get; set; }
        
        public List<Producto> productos { get; set; }

        public Checkout()
        {
            productos = new List<Producto>();
            carritoNegocio = new CarritoNegocio();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            
            if (!IsPostBack) {
                carritoNegocio = Session["Carrito"] as CarritoNegocio;
                ListItem item;
                int indice = 0;
                foreach (var domicilio in usuario.Domicilios)
                {
                    item = new ListItem($"{domicilio.Calle} {domicilio.Altura}", "1");
                    item.Value = $"{indice}";
                    DRPDomicilios.Items.Add(item);
                    indice++;
                }
                
                txtCalle.Value = usuario.Domicilios[0].Calle;
                txtNumero.Value = usuario.Domicilios[0].Altura;
                txtLocalidad.Value = usuario.Domicilios[0].Localidad;
                txtCodPos.Value = usuario.Domicilios[0].CodigoPostal;
                txtPiso.Value = usuario.Domicilios[0].Piso == null ? "" : usuario.Domicilios[indice].Piso;
                txtReferencia.Value = usuario.Domicilios[0].Referencia == null ? "" : usuario.Domicilios[indice].Referencia;
                elementoCarritos = carritoNegocio.GetElementos();
                RPDetalle.DataSource = elementoCarritos;
                RPDetalle.DataBind();

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}