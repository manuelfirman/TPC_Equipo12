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
    public partial class Master : System.Web.UI.MasterPage
    {
        private List<Categoria> categorias { get; set; }
        private List<Marca> marcas{ get; set; }
        private CategoriaNegocio categoriaNegocio { get; set; }
        private MarcaNegocio marcaNegocio { get; set; }

        public Master()
        {
            categoriaNegocio = new CategoriaNegocio();
            marcaNegocio = new MarcaNegocio();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                categorias = categoriaNegocio.listarCategoria();
                marcas = marcaNegocio.listarMarcas();
                repCategorias.DataSource = categorias;
                repCategorias.DataBind();

                repMarcas.DataSource = marcas;
                repMarcas.DataBind();

            }
        }
    }
}