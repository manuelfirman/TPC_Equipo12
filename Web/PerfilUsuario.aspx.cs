using Dominio;
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
        protected Usuario Usuario { get; set; }
        private bool HayDomicilio { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Session["Usuario"] as Usuario;
            if (Usuario == null) Response.Redirect("Ingresar.aspx");
            if (Usuario.Domicilios.First() != null) HayDomicilio = true;

            if (!IsPostBack)
            {
                rptUsuario.DataSource = new List<Usuario> { Usuario };
                rptUsuario.DataBind();
            }

        }


        protected void BtnGuardarDatosPersonales_Click(object sender, EventArgs e)
        {

        }

        protected void BtnGuardarDomicilio_Click(object sender, EventArgs e)
        {

        }
    }
}