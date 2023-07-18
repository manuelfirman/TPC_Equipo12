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
        private long id;
        private BannerNegocio bannerNegocio = new BannerNegocio();
        private Dominio.Banner banner = new Dominio.Banner();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            tipo = Request.QueryString["Tipo"];
            id = Request.Params["Id"] != null ? long.Parse(Request.Params["Id"]) : -1 ;
            if (usuario != null && (usuario.TipoUser.Nombre == "Vendedor" || usuario.TipoUser.Nombre == "Admin"))
            {
                if (!IsPostBack)
                {
                    if (tipo == null || (tipo != "Agregar" && tipo != "Modificar") || (tipo == "Modificar" && Request.QueryString["Id"] == null || Request.QueryString["Id"] == ""))
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
                        contUrl.Visible = true;
                        ImgUrl.Visible = true;
                        banner = bannerNegocio.BannerPorID(id);
                        ImgUrl.ImageUrl = banner.ImagenUrl;
                        txtUrl.Value = banner.ImagenUrl;
                        txtTitulo.Value = banner.Titulo;
                        txtRef.Value = banner.Referencia;
                        txtTexto.Value = banner.Texto;
                        btnAceptar.Text = "Modificar Imagen";
                    }
                    else
                    {
                        btnAceptar.Text = "Agregar Imagen";
                        contUrl.Visible = true;
                    }


                }

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtTitulo.Value != "" && txtRef.Value != "" && txtTexto.Value != "" && txtUrl.Value != "")
            {
                lblMessageOk.Visible = false;
                lblMessageError.Visible = false;
                banner.Titulo = txtTitulo.Value;
                banner.Referencia = txtRef.Value;
                banner.ImagenUrl = txtUrl.Value;
                banner.Texto = txtTexto.Value;
                banner.Estado = DRPEstado.SelectedItem.ToString() == "Activada" ? true : false;
                if (tipo == "Agregar")
                {
                    if (bannerNegocio.AgregarBanner(banner))
                    {
                        lblMessageOk.Visible = true;
                        lblMessageOk.Text = "SE AGREGO CORRECTAMENTE";
                    }
                    else
                    {
                        lblMessageError.Visible = true;
                        lblMessageError.Text = "Hubo un error. intente nuevamente";
                    }
                }
                else
                {
                    if (bannerNegocio.ModificarBanner(id, banner))
                    {
                        lblMessageOk.Visible = true;
                        lblMessageOk.Text = "Banner modifcado correctamente";
                    }
                    else
                    {
                        lblMessageError.Visible = true;
                        lblMessageError.Text = "Hubo un error. intente nuevamente";
                    }
                }
            }
        }
    }
}