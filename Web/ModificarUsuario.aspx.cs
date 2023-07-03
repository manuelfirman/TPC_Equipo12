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
        protected Usuario usuario;
        protected long IDUsuario;
        private Domicilio domicilio;
        private UsuarioNegocio usuarioNegocio { get; set; } = new UsuarioNegocio();
        private DomicilioNegocio domicilioNegocio { get; set; } = new DomicilioNegocio();
        private TipoUsuarioNegocio tipoUsuarioNegocio { get; set; } = new TipoUsuarioNegocio();

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

            }
            else
            {
                Response.Redirect("404.aspx");
            }

            lblMessageDatosError.Visible = false;
            lblMessageDatosOk.Visible = false;
        }

        protected void setDatosUsuario()
        {
            txtNombre.Value = usuario.Nombre;
            txtApellido.Value = usuario.Apellido;
            txtEmail.Value = usuario.Email;
            txtTelefono.Value = usuario.Telefono;
            txtDni.Value = usuario.DNI;
            txtFechaNacimiento.Value = usuario.FechaNacimiento.ToString();
            ListItem itemUser;
            lblEstadoUser.InnerText = "Estado";
            itemUser = new ListItem("Activado", "1");
            DRPEstadoUser.Items.Add(itemUser);
            itemUser = new ListItem("Desactivado", "0");
            DRPEstadoUser.Items.Add(itemUser);


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
            string nombre = txtNombre.Value;
            string apellido = txtApellido.Value;
            string email = txtEmail.Value;
            string dni = txtDni.Value;
            string telefono = txtTelefono.Value;
            bool estado = DRPEstadoUser.SelectedItem.Value == "1";
            int tipoUser = int.Parse(DRPTipoUsuario.SelectedItem.Value);
            string nombreTipoUser = DRPTipoUsuario.SelectedItem.Text;
            string fecha = txtFechaNacimiento.Value;
            DateTime fechaNacimiento;

            if (!DateTime.TryParse(fecha, out fechaNacimiento))
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

            Usuario userActualizado = usuarioNegocio.UsuarioPorID(usuario.IDUsuario);
            Session["Usuario"] = userActualizado;
            usuario = Session["Usuario"] as Usuario;
        }
    }
}