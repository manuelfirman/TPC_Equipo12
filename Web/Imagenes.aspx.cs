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
    public partial class Imagenes : System.Web.UI.Page
    {
        private string tipo;
        private long id;
        private Imagen imagen = new Imagen();
        private ImagenNegocio imagenNegocio = new ImagenNegocio();
        private Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            if (usuario != null && (usuario.TipoUser.Nombre == "Vendedor" || usuario.TipoUser.Nombre == "Admin"))
            {
                tipo = Request.QueryString["Tipo"];
                if (!IsPostBack)
                {
                    txtTitulo.InnerText = $"{tipo} Imagen";
                    if (tipo == null || (tipo != "Agregar" && tipo != "Modificar") || Request.QueryString["Id"] == null || Request.QueryString["Id"] == "")
                    {
                        Response.Redirect("404.aspx");
                    }
                    ListItem item;
                    lblEstado.InnerText = "Estado";
                    item = new ListItem("Activada", "1");
                    DRPEstado.Items.Add(item);
                    item = new ListItem("Desactivada", "2");
                    DRPEstado.Items.Add(item);
                    if (tipo == "Modificar")
                    {
                        id = long.Parse(Request.QueryString["Id"]);
                        imagen = imagenNegocio.ImagenPorId(id);
                        txtDesc.Value = imagen.Descripcion;
                        string estadoActual = imagen.Estado == true ? "Activada" : "Desactivada";
                        lblEstado.InnerText = $"Estado Actual: {estadoActual}";
                        btnAceptar.Text = "Modificar Imagen";
                    }
                    else
                    {
                        btnAceptar.Text = "Agregar Imagen";
                        contUrl.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMessageError.Visible = false;
            lblMessageOk.Visible = false;
            id = long.Parse(Request.QueryString["Id"]);
            if (tipo == "Agregar")
            {

                imagen.Estado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
                imagen.Descripcion = txtDesc.Value;
                imagen.IDProducto = id;
                imagen.Url = txtUrl.Value;
                if (imagenNegocio.Guardar(imagen))
                {
                    lblMessageOk.Visible = true;
                    lblMessageOk.Text = "Imagen agregada correctamente";
                }
                else
                {
                    lblMessageError.Visible = true;
                    lblMessageError.Text = "Hubo un error";
                }
            }
            else
            {
                imagen = imagenNegocio.ImagenPorId(id);
                string desc = txtDesc.Value;
                bool estado = DRPEstado.SelectedItem.ToString() == "Activado" ? true : false;
                long idImg = imagen.IDImagen;
                if (imagenNegocio.Modificar(idImg, desc, estado))
                {
                    lblMessageOk.Visible = true;
                    lblMessageOk.Text = "Imagen modificada correctamente";
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