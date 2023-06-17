﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
    
        private int indice { get; set; }
        private bool hayParam { get; set; }
        public Producto producto { get; set; }
        private ProductoNegocio productoNegocio { get; set; }

        public DetalleProducto()
        {
            productoNegocio = new ProductoNegocio();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int IDProducto = int.Parse(Request.QueryString["id"]);
                    producto = productoNegocio.ProductoPorID(IDProducto);
                    Session.Add("producto", producto);
                    rptImagenes.DataSource = producto.Imagenes;
                    rptImagenes.DataBind();
                    rptMiniaturas.DataSource = producto.Imagenes;
                    rptMiniaturas.DataBind();
                    rptProductos.DataSource = productoNegocio.ProductosAlAzar(4);
                    rptProductos.DataBind();

                    List<Producto> comments = productoNegocio.ProductosAlAzar(4);
                    rptComments.DataSource = comments;
                    rptComments.DataBind();


                }
                else
                {
                    // TODO: REDIRECT PAGINA 404
                    lblError.Text = "NO SE RECIBIO NINGUN ARTICULO";
                }
            }

            if (producto != null)
            {
                cargarProducto();
            }
            else
            {
                // TODO: REDIRECT PAGINA 404
                lblError.Text = "NO EXISTE PRODUCTO CON ESE ID";
            }
        }

        public void cargarProducto()
        {

        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {

        }

        protected void btnComprarAhora_Click(object sender, EventArgs e)
        {

        }

        public string CargarImagen(object dataItem)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Producto producto = (Producto)dataItem;

            if (producto != null & producto.Imagenes != null & producto.Imagenes.Count > 0)
            {
                string url = producto.Imagenes.FirstOrDefault().Url;
                if (imagenNegocio.VerificarUrlImagen(url))
                {
                    return url;
                }
            }

            return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'";
        }

    }
}