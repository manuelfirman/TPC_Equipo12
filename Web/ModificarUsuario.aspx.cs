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
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        private Usuario usuario;
        private Domicilio domicilio;
        private UsuarioNegocio usuarioNegocio { get; set; } = new UsuarioNegocio();
        private DomicilioNegocio domicilioNegocio { get; set; } = new DomicilioNegocio();
        private long IDUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            if (usuario != null && (usuario.TipoUser.Nombre != "Vendedor" || usuario.TipoUser.Nombre != "Admin"))
            {
                IDUsuario = long.Parse(Request.QueryString["Id"]);
                if (IDUsuario == 0 || IDUsuario != usuario.IDUsuario)
                {
                    Response.Redirect("404.aspx");
                }

                txtNombre.Value = usuario.Nombre;
                txtApellido.Value = usuario.Apellido;
                txtEmail.Value = usuario.Email;
                txtTelefono.Value = usuario.Telefono;
                txtFechaNacimiento.Value = usuario.FechaNacimiento.ToString();
                ListItem itemUser;
                lblEstadoUser.InnerText = "Estado";
                itemUser = new ListItem("Activado", "1");
                DRPEstadoUser.Items.Add(itemUser);
                itemUser = new ListItem("Desactivado", "2");
                DRPEstadoUser.Items.Add(itemUser);

                List<Provincia> provincias = domicilioNegocio.ListarProvincias();
                ListItem itemProvincias;
                foreach (Provincia provincia in provincias)
                {
                    itemProvincias = new ListItem(provincia.Nombre, provincia.IDProvincia.ToString());
                    DRPProvincia.Items.Add(itemProvincias);
                }
                txtLocalidad.Value = usuario.Domicilio.Localidad;
                txtCalle.Value = usuario.Domicilio.Calle;
                txtAltura.Value = usuario.Domicilio.Altura;
                txtReferencia.Value = usuario.Domicilio.Referencia;
                txtPiso.Value = usuario.Domicilio.Piso;
                txtAlias.Value = usuario.Domicilio.Alias;
                ListItem itemDom;
                lblEstadoUser.InnerText = "Estado";
                itemDom = new ListItem("Activado", "1");
                DRPEstadoUser.Items.Add(itemDom);
                itemDom = new ListItem("Desactivado", "2");
                DRPEstadoUser.Items.Add(itemDom);

            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {

        }

        protected void btnCambioContraseña_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarDatos_Click(object sender, EventArgs e)
        {

        }
    }
}