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
    public partial class Checkout : System.Web.UI.Page
    {
        private List<ElementoCarrito> elementoCarritos = new List<ElementoCarrito>();
        private CarritoNegocio carritoNegocio = new CarritoNegocio();
        private Domicilio domicilio = new Domicilio();
        private Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;

            if (!IsPostBack)
            {
                carritoNegocio = Session["Carrito"] as CarritoNegocio;
                if (usuario != null && carritoNegocio.GetCantidad() > 0)
                {
                    ListItem item;
                    int indice = 0;
                    if (usuario.Domicilios.Count > 0)
                    {
                        foreach (var domicilio in usuario.Domicilios)
                        {
                            item = new ListItem($"{domicilio.Calle} {domicilio.Altura}", $"{indice + 1}");
                            item.Value = $"{indice}";
                            DRPDomicilios.Items.Add(item);
                            indice++;
                        }
                        txtCalle.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Calle;
                        txtNumero.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Altura;
                        txtLocalidad.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Localidad;
                        txtCodPos.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].CodigoPostal;
                        txtPiso.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Piso == null ? "" : usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Piso;
                        txtReferencia.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Referencia == null ? "" : usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Referencia;
                    }
                    item = new ListItem("Nuevo domicilio", $"{indice + 1}");
                    item.Value = $"{indice}";
                    DRPDomicilios.Items.Add(item);
                    elementoCarritos = carritoNegocio.GetElementos();
                    RPDetalle.DataSource = elementoCarritos;
                    RPDetalle.DataBind();
                    decimal total = 0;
                    foreach (var elemento in carritoNegocio.GetElementos())
                    {
                        total += elemento.Producto.Precio * elemento.Cantidad;
                    }
                    lblTotal.Text = $"Total a pagar: {Math.Round(total)}$";
                }
                else
                {
                    Response.Redirect("404.aspx");
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            domicilio.Calle = txtCalle.Value;
            domicilio.Altura = txtNumero.Value;
            domicilio.Referencia = txtReferencia.Value != "" ? txtReferencia.Value : null;
            domicilio.CodigoPostal = txtCodPos.Value;
            //TODO: REALIZAR DRP PROVINCIAS
            //domicilio.Provincia = txtProvincia.Value;
            domicilio.Localidad = txtLocalidad.Value;
            domicilio.Piso = txtPiso.Value != "" ? txtPiso.Value : null;
            Session["Domicilio"] = domicilio;
            Response.Redirect("Pago.aspx");
        }

        protected void DRPDomicilios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DRPDomicilios.SelectedItem.ToString() == "Nuevo domicilio")
            {
                txtCalle.Value = "";
                txtNumero.Value = "";
                txtLocalidad.Value = "";
                txtCodPos.Value = "";
                txtPiso.Value = "";
                txtReferencia.Value = "";
            }
            else
            {
                txtCalle.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Calle;
                txtNumero.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Altura;
                txtLocalidad.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Localidad;
                txtCodPos.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].CodigoPostal;
                txtPiso.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Piso == null ? "" : usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Piso;
                txtReferencia.Value = usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Referencia == null ? "" : usuario.Domicilios[int.Parse(DRPDomicilios.SelectedIndex.ToString())].Referencia;
            }
        }
    }
}