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
    public partial class Banner : System.Web.UI.Page
    {
        private Usuario usuario = new Usuario();
        private string tipo;
        private ImagenNegocio imagenNegocio = new ImagenNegocio();
        private List<Imagen> imagenes = new List<Imagen>();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            tipo = Request.QueryString["Tipo"];
            if (usuario != null && (usuario.TipoUser.Nombre == "Vendedor" || usuario.TipoUser.Nombre == "Admin"))
            {
                if (!IsPostBack)
                {
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
                        DRPUrls.Visible = true;
                        lblUrls.Visible = true;
                        ImgUrl.Visible = true;
                        imagenes = imagenNegocio.ImagenesProducto(long.Parse(Request.Params["Id"]));
                        ImgUrl.ImageUrl = imagenes[0].Url;
                        txtDesc.Value = imagenes[0].Descripcion;
                        int indice = 1;
                        foreach (var imagen in imagenes)
                        {
                            //item = new ListItem(imagen.Url, $"{indice}");
                            item = new ListItem($"Imagen {indice}", $"{indice}");
                            item.Value = $"{imagen.Url},{imagen.IDImagen}";
                            DRPUrls.Items.Add(item);
                            indice++;
                        }
                        btnAceptar.Text = "Modificar Banner Promocion";
                    }
                    else
                    {
                        btnAceptar.Text = "Agregar Banner Promocion";
                        contUrl.Visible = true;
                    }


                }

            }
        }
    }
}