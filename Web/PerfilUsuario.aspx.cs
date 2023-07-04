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
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected Usuario UsuarioSession { get; set; }
        private UsuarioNegocio UsuarioNegocio { get; set; } = new UsuarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioSession = Session["Usuario"] as Usuario;
            if (UsuarioSession == null) Response.Redirect("Ingresar.aspx");

            if (!IsPostBack)
            {
                if (UsuarioSession.TipoUser.Nombre == "Vendedor" || UsuarioSession.TipoUser.Nombre == "Admin")
                {
                    string parametro = Request.QueryString["Id"];
                    if (!string.IsNullOrEmpty(parametro))
                    {
                        Usuario user = UsuarioNegocio.UsuarioPorID(long.Parse(parametro));
                        rptUsuario.DataSource = new List<Usuario> { user };
                        rptUsuario.DataBind();
                    }
                    else
                    {
                        rptUsuario.DataSource = new List<Usuario> { UsuarioSession };
                        rptUsuario.DataBind();
                    }
                }
                else if (UsuarioSession != null)
                {
                    rptUsuario.DataSource = new List<Usuario> { UsuarioSession };
                    rptUsuario.DataBind();
                }
                else
                {
                    Response.Redirect("Ingresar.aspx");
                }
            }
        }
    }
}