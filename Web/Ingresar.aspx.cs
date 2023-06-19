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
        private Crypt Crypt { get; set; } = new Crypt();

        protected void Page_Load(object sender, EventArgs e)
        {

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

            string hashPass = UsuarioNegocioLogin.PassPorEmail(email);

            // TODO: Descomentar y reemplazar cuando este el registro
            //if(Crypt.VerificarPassword(pass, hashPass))
            if (pass == hashPass)
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