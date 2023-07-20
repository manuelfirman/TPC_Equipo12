using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {

        private Usuario usuario  = new Usuario();
        private UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
        private EmailService emailService = new EmailService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                contEmail.Visible = true;
                btnEmail.Visible = true;
            }
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            if (txtEmail.Value != "")
            {
                usuario = UsuarioNegocio.BuscarUsuario("Email", txtEmail.Value);
                if(usuario != null )
                {
                    emailService.armarCorreo(usuario.Email, "Recuperacion de contraseña", "<h1>Codigo para recuperar contraseña</h1> <p>CODIGO: ABC123 </p> </br> <p>NO LO COMPARTAS CON NADIE!</p>");
                    emailService.enviarEmail();
                    btnCodigo.Visible = true;
                    contCodigo.Visible = true;
                    btnEmail.Visible=false;
                    contEmail.Visible = false;
                }
                else
                {
                    lblMessage.Text = "No existe una cuenta con ese email";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                lblMessage.Text = "revise todos los campos";
                lblMessage.Visible = true;
            }
        }

        protected void btnCodigo_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            if (txtCodigo.Value == "ABC123")
            {
                txtCodigo.Visible = false;
                txtContra.Visible = true;
                contContraseña.Visible = true;
                contCodigo.Visible=false;
                btnCodigo.Visible = false;
                btnCont.Visible = true;
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "CODIGO INCORRECTO";
            }
        }

        protected void btnCont_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            string contrasena = txtContra.Value.Trim();
            if (contrasena.Length < 8)
            {
                lblMessage.Text = "Minimo 8 caracteres en la contraseña";
                lblMessage.Visible = true;
                return;
            }
            usuario = UsuarioNegocio.BuscarUsuario("Email", txtEmail.Value);
            if (UsuarioNegocio.CambiarContraseña(usuario.IDUsuario, contrasena))
            {
                lblMessage.Text = "SE CAMBIO CORRECTAMENTE";
                lblMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = "HUBO UN ERROR";
                lblMessage.Visible = true;
            }

        }
    }
}