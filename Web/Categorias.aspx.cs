using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Categorias : System.Web.UI.Page
    {
        private string tipo;
        private long id;
        private Categoria categoria = new Categoria();
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        private Usuario usuario;

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
                    txtTitulo.InnerText = $"{tipo} Categoria";
                    lblEstado.InnerText = "Estado";
                    item = new ListItem("Activado", "1");
                    DRPEstado.Items.Add(item);
                    item = new ListItem("Desactivado", "2");
                    DRPEstado.Items.Add(item);
                    btnAgregar.Text = "Agregar Categoria";

                    if (tipo == "Modificar")
                    {
                        if (Request.QueryString["Id"] == null || Request.QueryString["Id"] == "")
                        {
                            Response.Redirect("404.aspx");
                        }
                        id = long.Parse(Request.QueryString["Id"]);
                        categoria = categoriaNegocio.CategoriaPorID(id);
                        if (categoria.IDCategoria == 0) Response.Redirect("404.aspx");
                        string estadoActual = categoria.Estado == true ? "Activado" : "Desactivado";
                        lblEstado.InnerText = $"Estado Actual: {estadoActual}";
                        txtNombre.Value = categoria.Nombre;
                        btnAgregar.Text = "Modificar Categoria";
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
            if (tipo == "Agregar")
            {
                categoria.Estado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
                categoria.Nombre = txtNombre.Value;
                if (categoriaNegocio.AgregarCategoria(categoria))
                {
                    lblMessageOk.Visible = true;
                    lblMessageOk.Text = "Categoria agregada correctamente";
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
                categoria = categoriaNegocio.CategoriaPorID(id);
                bool nuevoEstado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
                string nuevoNombre = txtNombre.Value;
                if (categoria.Nombre == nuevoNombre && nuevoEstado == categoria.Estado)
                {
                    lblMessageError.Visible = true;
                    lblMessageError.Text = "Debe cambiar algun valor";
                    return;
                }
                else
                {
                    categoria.Estado = nuevoEstado;
                    categoria.Nombre = nuevoNombre;
                    categoria.IDCategoria = long.Parse(Request.QueryString["Id"]);
                    if (categoriaNegocio.ModificarCategoria(categoria))
                    {
                        lblMessageOk.Visible = true;
                        lblMessageOk.Text = "Categoria agregada correctamente";

                    }
                    else
                    {
                        lblMessageError.Visible = true;
                        lblMessageError.Text = "Hubo un error";
                    }

                }
            }
        }
    }
}