using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected List<Venta> ventas { get; set; }
        protected Usuario Usuario { get; set; }
        private VentaNegocio ventaNegocio { get; set; } = new VentaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Session["Usuario"] as Usuario;
            if(Usuario == null || (Usuario.TipoUser.Nombre != "Admin" && Usuario.TipoUser.Nombre != "Vendedor"))
            {
                Response.Redirect("404.aspx");
            }

            if (!IsPostBack)
            {
                ventas = ventaNegocio.ListarVentas();
                rptVentas.DataSource = ventas;
                rptVentas.DataBind();


                List<EstadoVenta> estadoVenta = ventaNegocio.ListarEstadosVenta();
                ListItem itemEstadoVenta;
                foreach (EstadoVenta estado in estadoVenta)
                {
                    itemEstadoVenta = new ListItem(estado.Estado, estado.IDEstado.ToString());
                    DDLEstadoVenta.Items.Add(itemEstadoVenta);
                }
            }

        }

        protected void BtnRestaurar_Click(object sender, EventArgs e)
        {
            ChkEstado.Checked = false;
            ChkMonto.Checked = false;
            ChkFecha.Checked = false;
            txtFechaInicio.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtMontoMin.Text = string.Empty;
            txtMontoMax.Text = string.Empty;
            ventas = ventaNegocio.ListarVentas();
            rptVentas.DataSource = ventas;
            rptVentas.DataBind();
        }

        protected void BtnFiltro_Click(object sender, EventArgs e)
        {
            string montoMin = txtMontoMin.Text;
            string montoMax = txtMontoMax.Text;
            string estado = DDLEstadoVenta.SelectedItem.Text;
            string fechaInicio = txtFechaInicio.Text;
            string fechaFin = txtFechaFin.Text;

            if (string.IsNullOrEmpty(montoMin))
            {
                montoMin = "0";
            }

            if (string.IsNullOrEmpty(montoMax))
            {
                montoMax = "100000000000";
            }

            if (string.IsNullOrEmpty(fechaInicio))
            {
                fechaInicio = "01/01/1900";
            }

            if (string.IsNullOrEmpty(fechaFin))
            {
                fechaFin = "01/01/2060";
            }


            if (ChkEstado.Checked && ChkFecha.Checked && ChkMonto.Checked)
            {
                if (!string.IsNullOrEmpty(estado))
                {
                    rptVentas.DataSource = ventaNegocio.FiltroVentas("Estado Monto Fecha", estado, montoMin, montoMax, fechaInicio, fechaFin);
                }
                else
                {
                    rptVentas.DataSource = ventaNegocio.FiltroVentas("Monto Fecha", montoMin, montoMax, fechaInicio, fechaFin);
                }

                rptVentas.DataBind();
            }
            else if(ChkEstado.Checked && ChkMonto.Checked)
            {
                if (!string.IsNullOrEmpty(estado))
                {
                    rptVentas.DataSource = ventaNegocio.FiltroVentas("Estado Monto", estado, montoMin, montoMax);
                }
                else
                {
                    rptVentas.DataSource = ventaNegocio.FiltroVentas("Monto", montoMin, montoMax);
                }
                rptVentas.DataBind();
            }
            else if(ChkEstado.Checked && ChkFecha.Checked)
            {
                if (!string.IsNullOrEmpty(estado))
                {
                    rptVentas.DataSource = ventaNegocio.FiltroVentas("Estado Fecha", estado, fechaInicio, fechaFin);
                }
                else
                {
                    rptVentas.DataSource = ventaNegocio.FiltroVentas("Fecha", fechaInicio, fechaFin);
                }   
                rptVentas.DataBind();
            }
            else if(ChkMonto.Checked && ChkFecha.Checked)
            {
                rptVentas.DataSource = ventaNegocio.FiltroVentas("Monto", montoMin, montoMax, fechaInicio, fechaFin);
                rptVentas.DataBind();
            }
            else if (ChkEstado.Checked)
            {
                if (!string.IsNullOrEmpty(estado))
                {
                    rptVentas.DataSource = ventaNegocio.FiltroVentas("Estado", estado);
                }
                else
                {
                    rptVentas.DataSource = ventaNegocio.FiltroVentas("Sin Filtro");
                }
    
                rptVentas.DataBind();
            }
            else if (ChkMonto.Checked)
            {
                rptVentas.DataSource = ventaNegocio.FiltroVentas("Monto", montoMin, montoMax);
                rptVentas.DataBind();
            }
            else if (ChkFecha.Checked)
            {
                rptVentas.DataSource = ventaNegocio.FiltroVentas("Fecha", fechaInicio, fechaFin);
                rptVentas.DataBind();
            }
        }
    }
}