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
        protected Usuario UsuarioSession;
        protected Usuario UsuarioModificado;
        protected long IDUsuario;
        protected bool admin;
        protected bool propio;
        private UsuarioNegocio usuarioNegocio { get; set; } = new UsuarioNegocio();
        private DomicilioNegocio domicilioNegocio { get; set; } = new DomicilioNegocio();
        private TipoUsuarioNegocio tipoUsuarioNegocio { get; set; } = new TipoUsuarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioSession = Session["Usuario"] as Usuario;
            if (UsuarioSession == null) Response.Redirect("404.aspx");
            admin = false;
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
                    if (!IsPostBack) setDatosUsuario(UsuarioModificado);
                }
                else
                {
                    IDUsuario = UsuarioSession.IDUsuario;
                    if (!IsPostBack) setDatosUsuario(UsuarioSession);
                }
            }
            else if (UsuarioSession != null)
            {
                IDUsuario = UsuarioSession.IDUsuario;
                if (!IsPostBack) setDatosUsuario(UsuarioSession);
            }
            else
            {
                Response.Redirect("404.aspx");
            }

            lblMessageDatosError.Visible = false;
            lblMessageDatosOk.Visible = false;
            lblMessageDatosRedirect.Visible = false;
        }

        protected void setDatosUsuario(Usuario usuario)
        {
            txtNombre.Value = usuario.Nombre;
            txtApellido.Value = usuario.Apellido;
            txtEmail.Value = usuario.Email;
            txtTelefono.Value = usuario.Telefono;
            txtDni.Value = usuario.DNI;
            txtFechaNacimiento.Value = usuario.FechaNacimiento.ToString("yyyy-MM-dd");
            txtDomicilio.Text = usuario.Domicilios.Any() ? $"{usuario.Domicilios.First().Calle} {usuario.Domicilios.First().Altura}, {usuario.Domicilios.First().Localidad}" : "Sin cargar";

            // DDL Estado
            ListItem itemUser;
            lblEstadoUser.InnerText = "Estado";
            itemUser = new ListItem("Activado", "1");
            DRPEstadoUser.Items.Add(itemUser);
            itemUser = new ListItem("Desactivado", "0");
            DRPEstadoUser.Items.Add(itemUser);

            // DDL Tipo Usuario
            List<TipoUsuario> tipousuarios = tipoUsuarioNegocio.ListarTiposUsuario();
            lblTipoUsuario.InnerText = "Rol de usuario";
            ListItem itemTipo;
            foreach (TipoUsuario tipo in tipousuarios)
            {
                itemTipo = new ListItem(tipo.Nombre, tipo.IDTipo.ToString());
                DRPTipoUsuario.Items.Add(itemTipo);

            }

            string nombreRol = usuario.TipoUser.Nombre;
            ListItem rolUsuario = DRPTipoUsuario.Items.FindByText(nombreRol);
            if (rolUsuario != null)
            {
                rolUsuario.Selected = true;
            }
        }

        protected void btnAgregarDatos_Click(object sender, EventArgs e)
        {
            if (txtNombre.Value == "" || txtApellido.Value == "" || txtDni.Value == "")
            {
                lblMessageDatosError.Text = "Los campos con * no pueden quedar incompletos.";
                lblMessageDatosError.Visible = true;
                return;
            }

            // Fecha de Nacimiento
            string fecha = txtFechaNacimiento.Value;
            DateTime fechaNacimiento;
            if (!DateTime.TryParse(fecha, out fechaNacimiento))
            {
                lblMessageDatosError.Text = "Formato de fecha incorrecto.";
                lblMessageDatosError.Visible = true;
                return;
            }

            Usuario user = new Usuario();
            user.Email = propio ? UsuarioSession.Email : txtEmail.Value;
            user.Nombre = txtNombre.Value;
            user.Apellido = txtApellido.Value;
            user.DNI = txtDni.Value;
            user.Telefono = txtTelefono.Value;
            user.Estado = DRPEstadoUser.SelectedItem.Value == "1";
            user.TipoUser.IDTipo = int.Parse(DRPTipoUsuario.SelectedItem.Value);
            user.TipoUser.Nombre = DRPTipoUsuario.SelectedItem.Text;
            user.FechaNacimiento = fechaNacimiento;
            user.IDUsuario = IDUsuario;

            if (!usuarioNegocio.ActualizarUsuario(user))
            {
                lblMessageDatosError.Text = "Error al actualizar el usuario.";
                lblMessageDatosError.Visible = true;
                return;
            }

            // Mensaje OK
            lblMessageDatosOk.Text = "Usuario actualizado correctamente.";
            lblMessageDatosRedirect.Text = "Redireccionando a perfil en 3 segundos...";
            lblMessageDatosOk.Visible = true;
            lblMessageDatosRedirect.Visible = true;

            ActualizarUsuario();
            Redireccion("PerfilUsuario");
        }

        protected void ActualizarUsuario()
        {
            Usuario userActualizado = usuarioNegocio.UsuarioPorID(UsuarioSession.IDUsuario);
            Session["Usuario"] = userActualizado;
            UsuarioSession = Session["Usuario"] as Usuario;
        }

        protected void Redireccion(string pagina)
        {
            string script = "<script type='text/javascript'>setTimeout(function(){ window.location.href = '" + pagina + ".aspx'; }, 3000);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Redireccionar", script);
        }
    }
}