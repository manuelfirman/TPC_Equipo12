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
        private TipoUsuarioNegocio tipoUsuarioNegocio { get; set; } = new TipoUsuarioNegocio();
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

                setDatosUsuario();

                setDomicilio();

            }
            else
            {
                Response.Redirect("404.aspx");
            }

            lblMessageDatosError.Visible = false;
            lblMessageDatosOk.Visible = false;
            lblMessageContraseñaError.Visible = false;
            lblMessageContraseñaOk.Visible = false;
            lblMessageDomicilioError.Visible = false;
            lblMessageDomicilioOk.Visible = false;
        }

        protected void setDatosUsuario()
        {
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


            List<TipoUsuario> tipousuarios = tipoUsuarioNegocio.ListarTiposUsuario();
            lblTipoUsuario.InnerText = "Rol de usuario";
            foreach (TipoUsuario tipo in tipousuarios)
            {
                itemUser = new ListItem(tipo.Nombre, tipo.IDTipo.ToString());
                DRPTipoUsuario.Items.Add(itemUser);
            }
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

            if(usuarioNegocio.ActualizarDomicilio(usuario.IDUsuario, domicilio))
            {
                lblMessageDomicilioError.Text = "Error al actualizar el domicilio.";
                lblMessageDomicilioError.Visible = true;
                return;
            }

            lblMessageDomicilioOk.Text = "Domicilio actualizado correctamente.";
            lblMessageDomicilioOk.Visible = true;
        }

        protected void btnCambioContraseña_Click(object sender, EventArgs e)
        {
            string contrasena = txtContraseña1.Value;
            string confirmarContrasena = txtContraseña2.Value;

            if (contrasena != confirmarContrasena)
            {
                lblMessageContraseñaError.Text = "Las contraseñas son distintas";
                lblMessageContraseñaError.Visible = true;
                return;
            }

            Crypt crypt = new Crypt();
            string nuevaContraseña = crypt.GenerarHash(contrasena);

            if(!usuarioNegocio.CambiarContraseña(usuario.IDUsuario, nuevaContraseña))
            {
                lblMessageContraseñaError.Text = "Error al actualizar la contraseña";
                lblMessageContraseñaError.Visible = true;
            }

            lblMessageContraseñaOk.Text = "Contraseña actualizada correctamente.";
            lblMessageContraseñaOk.Visible = true;
        }

        protected void btnAgregarDatos_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Value;
            string apellido = txtApellido.Value;
            string email = txtEmail.Value;
            string dni = txtDni.Value;
            string telefono = txtTelefono.Value;
            bool estado = bool.Parse(DRPEstadoUser.SelectedValue);
            int tipoUser = int.Parse(DRPTipoUsuario.SelectedItem.Value);
            string nombreTipoUser = DRPTipoUsuario.SelectedItem.Text;
            string fecha = txtFechaNacimiento.Value;
            DateTime fechaNacimiento;

            if (DateTime.TryParse(fecha, out fechaNacimiento))
            {
                lblMessageDatosError.Text = "Formato de fecha incorrecto.";
                lblMessageDatosError.Visible = true;
                return;
            }

            if (nombre == "" || apellido == "" || email == "" || dni == "")
            {
                lblMessageDatosError.Text = "Los campos con * no pueden quedar incompletos.";
                lblMessageDatosError.Visible = true;
                return;
            }

            Usuario user = new Usuario();
            user.Email = email;
            user.Nombre = nombre;
            user.Apellido = apellido;
            user.DNI = dni;
            user.Telefono = telefono;
            user.Estado = estado;
            user.TipoUser.IDTipo = tipoUser;
            user.TipoUser.Nombre = nombreTipoUser;
            user.FechaNacimiento = fechaNacimiento;
            user.IDUsuario = usuario.IDUsuario;

            if (!usuarioNegocio.ActualizarUsuario(user))
            {
                lblMessageDatosError.Text = "Error al actualizar el usuario.";
                lblMessageDatosError.Visible = true;
                return;
            }

            lblMessageDatosOk.Text = "Datos actualizados correctamente.";
            lblMessageDatosOk.Visible = true;
        }
    }
}