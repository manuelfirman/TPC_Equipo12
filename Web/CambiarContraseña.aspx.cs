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
        protected Usuario UsuarioSession { get; set; }
        protected Usuario UsuarioModificado { get; set; }
        protected long IDUsuario { get; set; }
        protected bool propio;
        private UsuarioNegocio usuarioNegocio { get; set; } = new UsuarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioSession = Session["Usuario"] as Usuario;
            if (UsuarioSession == null) Response.Redirect("404.aspx");
            propio = true;

            if (UsuarioSession.TipoUser.Nombre == "Vendedor" || UsuarioSession.TipoUser.Nombre == "Admin")
            {
                string parametro = Request.QueryString["Id"];
                if (!string.IsNullOrEmpty(parametro))
                {
                    propio = false;
                    IDUsuario = int.Parse(parametro);
                    UsuarioModificado = usuarioNegocio.UsuarioPorID(IDUsuario);
                }
                else
                {
                    IDUsuario = UsuarioSession.IDUsuario;
                }
            }
            else if (UsuarioSession != null)
            {
                IDUsuario = UsuarioSession.IDUsuario;
            }
            else
            {
                Response.Redirect("404.aspx");
            }

            lblMessageContraseñaError.Visible = false;
            lblMessageContraseñaOk.Visible = false;
            lblMessageContraseñaRedirect.Visible = false;
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
            if (propio)
            {
                if (!usuarioNegocio.CambiarContraseña(UsuarioSession.IDUsuario, nuevaContraseña))
                {
                    lblMessageContraseñaError.Text = "Error al actualizar la contraseña";
                    lblMessageContraseñaError.Visible = true;
                }
            }
            else
            {
                if (!usuarioNegocio.CambiarContraseña(UsuarioModificado.IDUsuario, nuevaContraseña))
                {
                    lblMessageContraseñaError.Text = "Error al actualizar la contraseña";
                    lblMessageContraseñaError.Visible = true;
                }
            }

            lblMessageContraseñaOk.Text = "Contraseña actualizada correctamente.";
            lblMessageContraseñaOk.Visible = true;
            lblMessageContraseñaRedirect.Text = "Redireccionando a perfil en 3 segundos...";
            lblMessageContraseñaRedirect.Visible = true;

            Redireccion("PerfilUsuario");
        }

        protected void Redireccion(string pagina)
        {
            string script = "<script type='text/javascript'>setTimeout(function(){ window.location.href = '" + pagina + ".aspx'; }, 3000);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Redireccionar", script);
        }
    }
}