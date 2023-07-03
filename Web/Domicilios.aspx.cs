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
        protected Usuario usuario { get; set; }
        protected long IDUsuario { get; set; }
        private DomicilioNegocio domicilioNegocio { get; set; } = new DomicilioNegocio();
        private UsuarioNegocio usuarioNegocio { get; set; } = new UsuarioNegocio();

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

                setDomicilio();

            }
            else
            {
                Response.Redirect("404.aspx");
            }


            lblMessageDomicilioError.Visible = false;
            lblMessageDomicilioOk.Visible = false;
        }

        protected void setDomicilio()
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
                itemDom = new ListItem("Desactivado", "2");
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

            domicilio.Localidad = txtLocalidad.Value;
            domicilio.Calle = txtCalle.Value;
            domicilio.Altura = txtAltura.Value;
            domicilio.CodigoPostal = txtCodigoPostal.Value;
            domicilio.Referencia = txtReferencia.Value;
            domicilio.Piso = txtPiso.Value;
            domicilio.Alias = txtAlias.Value;
            domicilio.Provincia.IDProvincia = long.Parse(DRPProvincia.SelectedItem.Value);
            domicilio.Provincia.Nombre = DRPProvincia.SelectedItem.Text;

            if (usuarioNegocio.ActualizarDomicilio(usuario.IDUsuario, domicilio))
            {
                lblMessageDomicilioError.Text = "Error al actualizar el domicilio.";
                lblMessageDomicilioError.Visible = true;
                return;
            }

            lblMessageDomicilioOk.Text = "Domicilio actualizado correctamente.";
            lblMessageDomicilioOk.Visible = true;
        }
    }
}