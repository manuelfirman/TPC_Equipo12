using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Web
{
    public partial class Marcas : System.Web.UI.Page
    {
        private string tipo;
        private long id;
        private Marca marca = new Marca();
        private MarcaNegocio marcaNegocio = new MarcaNegocio();
        private Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            if (usuario != null && (usuario.TipoUser.Nombre == "Vendedor" || usuario.TipoUser.Nombre == "Admin"))
            {
                tipo = Request.QueryString["Tipo"];
                if (!IsPostBack)
                {

                    if (tipo == null || (tipo != "Agregar" && tipo != "Modificar"))
                    {
                        Response.Redirect("404.aspx");
                    }
                    ListItem item;
                    txtTitulo.InnerText = $"{tipo} Marca";
                    lblEstado.InnerText = "Estado";
                    item = new ListItem("Activado", "1");
                    DRPEstado.Items.Add(item);
                    item = new ListItem("Desactivado", "2");
                    DRPEstado.Items.Add(item);
                    btnAgregar.Text = "Agregar Marca";

                    if (tipo == "Modificar")
                    {
                        if (Request.QueryString["Id"] == null || Request.QueryString["Id"] == "")
                        {
                            Response.Redirect("404.aspx");
                        }
                        id = long.Parse(Request.QueryString["Id"]);
                        marca = marcaNegocio.MarcaPorID(id);
                        if (marca.IDMarca == 0) Response.Redirect("404.aspx");
                        string estadoActual = marca.Estado == true ? "Activado" : "Desactivado";
                        lblEstado.InnerText = $"Estado Actual: {estadoActual}";
                        txtNombre.Value = marca.Nombre;
                        btnAgregar.Text = "Modificar Marca";
                    }

                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            lblMessageError.Visible = false;
            lblMessageOk.Visible = false;
            lblMessageRedirect.Visible = false;
            if (tipo == "Agregar")
            {
                marca.Estado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
                marca.Nombre = txtNombre.Value;
                //marca.IDMarca = long.Parse(Request.QueryString["Id"]);
                if (marcaNegocio.AgregarMarca(marca))
                {
                    lblMessageOk.Visible = true;
                    lblMessageOk.Text = "Marca agregada correctamente";
                    lblMessageRedirect.Visible = true;
                    lblMessageRedirect.Text = "Redireccionando en 3 segundos...";
                    Redireccion("Vendedor");
                }
                else
                {
                    lblMessageError.Visible = true;
                    lblMessageError.Text = "Hubo un error";
                }
            }
            else
            {
                id = long.Parse(Request.QueryString["Id"]);
                marca = marcaNegocio.MarcaPorID(id);
                bool nuevoEstado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
                string nuevoNombre = txtNombre.Value;
                if (marca.Nombre == nuevoNombre && nuevoEstado == marca.Estado)
                {
                    lblMessageError.Visible = true;
                    lblMessageError.Text = "Debe cambiar algun valor";
                    return;
                }
                else
                {
                    marca.Estado = nuevoEstado;
                    marca.Nombre = nuevoNombre;
                    marca.IDMarca = long.Parse(Request.QueryString["Id"]);
                    if (marcaNegocio.ModificarMarca(marca))
                    {
                        lblMessageOk.Visible = true;
                        lblMessageOk.Text = "Marca agregada correctamente";
                        lblMessageRedirect.Visible = true;
                        lblMessageRedirect.Text = "Redireccionando en 3 segundos...";
                        Redireccion("Vendedor");

                    }
                    else
                    {
                        lblMessageError.Visible = true;
                        lblMessageError.Text = "Hubo un error";
                    }

                }
            }
        }

        protected void Redireccion(string pagina)
        {
            string script = "<script type='text/javascript'>setTimeout(function(){ window.location.href = '" + pagina + ".aspx'; }, 3000);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Redireccionar", script);
        }
    }
}