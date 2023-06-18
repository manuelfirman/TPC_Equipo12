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



            string hashPass = UsuarioNegocioLogin.PassPorEmail(email);

            //if(Crypt.VerificarPassword(pass, hashPass))
            if(pass == hashPass)
            {
                
                Session["Usuario"] = UsuarioNegocioLogin.UsuarioPorEmail(email);
                Response.Redirect("Index.aspx");
            }
            else
            {
                lblMessage.Text = "Usuario o contraseña incorrectos.";
                lblMessage.Visible = true;
            }
        }
    }
}