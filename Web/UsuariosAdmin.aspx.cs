using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class UsuariosAdmin : System.Web.UI.Page
    {
        private UsuarioNegocio UsuarioNegocio { get; set; } = new UsuarioNegocio();
        protected List<Usuario> Usuarios { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Usuarios = UsuarioNegocio.ListarUsuarios();
                rptUsuarios.DataSource = Usuarios;
                rptUsuarios.DataBind();
            }
        }
    }
}