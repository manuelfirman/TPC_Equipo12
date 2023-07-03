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
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        protected Usuario usuario { get; set; }
        protected long IDUsuario { get; set; }
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

            }
            else
            {
                Response.Redirect("404.aspx");
            }

            lblMessageContraseñaError.Visible = false;
            lblMessageContraseñaOk.Visible = false;
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

            if (!usuarioNegocio.CambiarContraseña(usuario.IDUsuario, nuevaContraseña))
            {
                lblMessageContraseñaError.Text = "Error al actualizar la contraseña";
                lblMessageContraseñaError.Visible = true;
            }

            lblMessageContraseñaOk.Text = "Contraseña actualizada correctamente.";
            lblMessageContraseñaOk.Visible = true;
        }
    }
}