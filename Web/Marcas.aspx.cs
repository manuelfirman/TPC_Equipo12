using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private Marca marca = new Marca();
        private MarcaNegocio marcaNegocio = new MarcaNegocio();
        protected void Page_Load(object sender, EventArgs e)
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

                    long id = long.Parse(Request.QueryString["Id"]);
                    marca = marcaNegocio.MarcaPorID(id);
                    if (marca.IDMarca == 0) Response.Redirect("404.aspx");
                    string estadoActual = marca.Estado == true ? "Activado" : "Desactivado";
                    lblEstado.InnerText = $"Estado Actual: {estadoActual}";
                    txtNombre.Value = marca.Nombre;
                    btnAgregar.Text = "Modificar Marca";
                }

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            lblMessage.Visible = true;
            if (tipo == "Agregar")
            {
                marca.Estado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
                marca.Nombre = txtNombre.Value;
                //marca.IDMarca = long.Parse(Request.QueryString["Id"]);
                if (marcaNegocio.AgregarMarca(marca)) lblMessage.Text = "Marca agregada correctamente";
                else lblMessage.Text = "Hubo un error";
            }
            else
            {
                bool nuevoEstado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
                string nuevoNombre = txtNombre.Value;
                if (marca.Nombre == nuevoNombre && nuevoEstado == marca.Estado)
                {
                    lblMessage.Text = "PARA ACTUALIZAR DEBE CAMBIAR ALGUN VALOR";
                    return;
                }
                else
                {
                    marca.Estado = nuevoEstado;
                    marca.Nombre = nuevoNombre;
                    marca.IDMarca = long.Parse(Request.QueryString["Id"]);
                    if (marcaNegocio.ModificarMarca(marca)) lblMessage.Text = "Marca Modificada correctamente";
                    else lblMessage.Text = "Hubo un error";

                }
            }
        }
    }
}