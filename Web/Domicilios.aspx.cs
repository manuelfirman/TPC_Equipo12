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
    public partial class Domicilios : System.Web.UI.Page
    {
        protected Usuario UsuarioSession { get; set; }
        protected Usuario UsuarioModificado { get; set; }
        protected bool admin;
        protected bool propio;
        protected long IDUsuario { get; set; }
        private DomicilioNegocio domicilioNegocio { get; set; } = new DomicilioNegocio();
        private UsuarioNegocio usuarioNegocio { get; set; } = new UsuarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioSession = Session["Usuario"] as Usuario;
            if (UsuarioSession == null) Response.Redirect("404.aspx");
            propio = true;

            if (UsuarioSession.TipoUser.Nombre == "Vendedor" || UsuarioSession.TipoUser.Nombre == "Admin")
            {
                admin = true;
                string parametro = Request.QueryString["Id"];
                if (!string.IsNullOrEmpty(parametro))
                {
                    propio = false;
                    IDUsuario = long.Parse(parametro);
                    UsuarioModificado = usuarioNegocio.UsuarioPorID(IDUsuario);
                    if (!IsPostBack) setDomicilio(UsuarioModificado);
                }
                else
                {
                    IDUsuario = UsuarioSession.IDUsuario;
                    if (!IsPostBack) setDomicilio(UsuarioSession);
                }
            }
            else if(UsuarioSession != null)
            {
                IDUsuario = UsuarioSession.IDUsuario;
                if (!IsPostBack) setDomicilio(UsuarioSession);
            }
            else
            {
                Response.Redirect("404.aspx");
            }

            lblMessageDomicilioError.Visible = false;
            lblMessageDomicilioOk.Visible = false;
            lblMessageDomicilioRedirect.Visible = false;
        }

        protected void setDomicilio(Usuario usuario)
        {
            List<Provincia> provincias = domicilioNegocio.ListarProvincias();
            ListItem itemProvincias;
            foreach (Provincia provincia in provincias)
            {
                itemProvincias = new ListItem(provincia.Nombre, provincia.IDProvincia.ToString());
                DRPProvincia.Items.Add(itemProvincias);
            }

            if (usuario.Domicilios.Count > 0)
            {
                string nombreProvincia = usuario.Domicilios.First().Provincia.Nombre;
                ListItem provinciaDomicilio = DRPProvincia.Items.FindByText(nombreProvincia);
                if (provinciaDomicilio != null)
                {
                    provinciaDomicilio.Selected = true;
                }

                txtLocalidad.Value = usuario.Domicilios.First().Localidad;
                txtCalle.Value = usuario.Domicilios.First().Calle;
                txtAltura.Value = usuario.Domicilios.First().Altura;
                txtCodigoPostal.Value = usuario.Domicilios.First().CodigoPostal;
                txtReferencia.Value = usuario.Domicilios.First().Referencia;
                txtPiso.Value = usuario.Domicilios.First().Piso;
                txtAlias.Value = usuario.Domicilios.First().Alias;

                ListItem itemDom;
                lblEstadoDomicilio.InnerText = "Estado";
                itemDom = new ListItem("Activado", "1");
                DRPEstadoDomicilio.Items.Add(itemDom);
                itemDom = new ListItem("Desactivado", "0");
                DRPEstadoDomicilio.Items.Add(itemDom);
            }


        }

        protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {

            if (txtLocalidad.Value == "" || txtCalle.Value == "" || txtAltura.Value == "" || txtCodigoPostal.Value == "")
            {
                lblMessageDomicilioError.Text = "Los campos con * no pueden estar vacios.";
                lblMessageDomicilioError.Visible = true;
                return;
            }

            Domicilio domicilio = new Domicilio();

            if (UsuarioSession.Domicilios.Count != 0) domicilio.IDDomicilio = UsuarioSession.Domicilios.FirstOrDefault().IDDomicilio;
            else domicilio.IDDomicilio = -1;

            domicilio.Localidad = txtLocalidad.Value;
            domicilio.Calle = txtCalle.Value;
            domicilio.Altura = txtAltura.Value;
            domicilio.CodigoPostal = txtCodigoPostal.Value;
            domicilio.Referencia = txtReferencia.Value;
            domicilio.Piso = txtPiso.Value;
            domicilio.Alias = txtAlias.Value;
            domicilio.Provincia.IDProvincia = long.Parse(DRPProvincia.SelectedItem.Value);
            domicilio.Provincia.Nombre = DRPProvincia.SelectedItem.Text;
            domicilio.Estado = true;

            if (!usuarioNegocio.ActualizarDomicilio(IDUsuario, domicilio))
            {
                lblMessageDomicilioError.Text = "Error al actualizar el domicilio.";
                lblMessageDomicilioError.Visible = true;
                return;
            }

            lblMessageDomicilioOk.Text = "Domicilio actualizado correctamente.";
            lblMessageDomicilioRedirect.Text = "Redireccionando a perfil en 3 segundos...";
            lblMessageDomicilioOk.Visible = true;
            lblMessageDomicilioRedirect.Visible = true;

            Usuario userActualizado = usuarioNegocio.UsuarioPorID(IDUsuario);
            Session["Usuario"] = userActualizado;
            UsuarioSession = Session["Usuario"] as Usuario;

            setDomicilio(userActualizado);

            // Redireccion
            Redireccion("PerfilUsuario");
        }

        protected void Redireccion(string pagina)
        {
            string script = "<script type='text/javascript'>setTimeout(function(){ window.location.href = '" + pagina + ".aspx'; }, 3000);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Redireccionar", script);
        }

    }
}