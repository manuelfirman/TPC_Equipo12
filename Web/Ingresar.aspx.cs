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
    public partial class Ingresar : System.Web.UI.Page
    {
        private UsuarioNegocio UsuarioNegocioLogin { get; set; } = new UsuarioNegocio();
        private Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            if (usuario != null){
                Response.Redirect("404.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Value;
            string pass = txtPassword.Value;
            lblMessage.Visible = false;
            if (email.Length == 0 || pass.Length == 0)
            {
                lblMessage.Text = "Ingresar todos los campos";
                lblMessage.Visible = true;
                return;
            }

            if (UsuarioNegocioLogin.LoginUsuario(email, pass))
            {
                Session["Usuario"] = UsuarioNegocioLogin.BuscarUsuario("Email",email);
                Response.Redirect("Index.aspx");
            }
            else
            {
                lblMessage.Text = "Usuario o contraseña incorrectos.";
                lblMessage.Visible = true;
            }
        }

        protected void btnOlvidePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecuperarContraseña.aspx");
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCuenta.aspx");
        }
    }
}