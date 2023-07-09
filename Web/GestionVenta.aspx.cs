﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class GestionVenta : System.Web.UI.Page
    {
        protected Venta Venta { get; set; }
        protected Usuario Usuario { get; set; }
        private VentaNegocio VentaNegocio { get; set; } = new VentaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Session["Usuario"] as Usuario;
            if (Usuario == null || (Usuario.TipoUser.Nombre != "Admin" && Usuario.TipoUser.Nombre != "Vendedor"))
            {
                Response.Redirect("404.aspx");
            }

            long IDVenta = long.Parse(Request.QueryString["Id"]);
            if (IDVenta > 0)
            {
                Venta = VentaNegocio.VentaPorID(IDVenta);
            }

            lblMessageOk.Visible = false;
            lblMessageError.Visible = false;

            if (!IsPostBack)
            {

                List<EstadoVenta> estadoVenta = VentaNegocio.ListarEstadosVenta();
                ListItem itemEstadoVenta;
                foreach (EstadoVenta estado in estadoVenta)
                {
                    itemEstadoVenta = new ListItem(estado.Estado, estado.IDEstado.ToString());
                    DDLEstadoVenta.Items.Add(itemEstadoVenta);
                }

                ListItem estadoActual = DDLEstadoVenta.Items.FindByText(Venta.Estado.Estado);
                if (estadoActual != null)
                {
                    estadoActual.Selected = true;
                }
            }

            
        }

        protected void BtnGestionarVenta_Click(object sender, EventArgs e)
        {
            long estado = long.Parse(DDLEstadoVenta.SelectedItem.Value);

            if(VentaNegocio.ModificarEstadoVenta(Venta.IDVenta, estado))
            {
                lblMessageOk.Visible = true;
                lblMessageOk.Text = "Estado modificado correctamente.";
            }
            else
            {

                lblMessageError.Visible = true;
                lblMessageError.Text = "Error al modificar el estado de la venta.";
            }

        }
    }
}