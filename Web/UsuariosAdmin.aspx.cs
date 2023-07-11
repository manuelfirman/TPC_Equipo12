using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class UsuariosAdmin : System.Web.UI.Page
    {
        private UsuarioNegocio UsuarioNegocio { get; set; } = new UsuarioNegocio();
        protected List<Usuario> Usuarios { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuarios = UsuarioNegocio.ListarUsuarios("sinFiltro");
                rptUsuarios.DataSource = Usuarios;
                rptUsuarios.DataBind();
            }
            /*else
            {
                if (CHKActivado.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "1");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKDesactivado.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "0");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if(CHKAdmin.Checked && !CHKVendedor.Checked && !CHKUsuario.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Admin");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKVendedor.Checked && !CHKUsuario.Checked && !CHKAdmin.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Vendedor");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKUsuario.Checked && !CHKVendedor.Checked && !CHKAdmin.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Usuario");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
            }*/
        }
        //CHEKED ESTADO ACTIVADO
        protected void CHKActivado_CheckedChanged(object sender, EventArgs e)
        {
            CHKDesactivado.Checked = false;
            if (CHKActivado.Checked)
            {
                if (CHKAdmin.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "1", "Admin");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKVendedor.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "1", "Vendedor");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKUsuario.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "1", "Usuario");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "1");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();

                }
            }

            else
            {
                if (CHKAdmin.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Admin");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKVendedor.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Vendedor");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKUsuario.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Usuario");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("sinFiltro");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
            }
        }
        //CHEKED ESTADO DESACTIVADO
        protected void CHKDesactivado_CheckedChanged(object sender, EventArgs e)
        {
            CHKActivado.Checked = false;
            if (CHKDesactivado.Checked)
            {
                if (CHKAdmin.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "0", "Admin");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKVendedor.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "0", "Vendedor");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKUsuario.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "0", "Usuario");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "0");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();

                }
            }

            else
            {
                if (CHKAdmin.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Admin");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKVendedor.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Vendedor");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKUsuario.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Usuario");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("sinFiltro");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
            }
        }
        //CHEKED ADMIN
        protected void CHKAdmin_CheckedChanged(object sender, EventArgs e)
        {
            CHKUsuario.Checked = false;
            CHKVendedor.Checked = false;
            if (CHKAdmin.Checked)
            {
                if (CHKActivado.Checked)
                {

                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "1", "Admin");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();

                }
                else if (CHKDesactivado.Checked)
                {

                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "0", "Admin");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();

                }
                else
                {

                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Admin");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
            }
            else
            {
                if (CHKActivado.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "1");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKDesactivado.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "0");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("sinFiltro");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
            }
        }
        //CHEKED VENDEDOR
        protected void CHKVendedor_CheckedChanged(object sender, EventArgs e)
        {
            CHKAdmin.Checked = false;
            CHKUsuario.Checked = false;
            if (CHKVendedor.Checked)
            {

                if (CHKActivado.Checked)
                {

                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "1", "Vendedor");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();

                }
                else if (CHKDesactivado.Checked)
                {

                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "0", "Vendedor");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();

                }
                else
                {

                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Vendedor");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
            }

            else
            {
                if (CHKActivado.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "1");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKDesactivado.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "0");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("sinFiltro");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
            }

        }
        //CHEKED USUARIO
        protected void CHKUsuario_CheckedChanged(object sender, EventArgs e)
        {
            CHKAdmin.Checked = false;
            CHKVendedor.Checked = false;
            if (CHKUsuario.Checked)
            {
                if (CHKActivado.Checked)
                {

                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "1", "Usuario");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();

                }
                else if (CHKDesactivado.Checked)
                {

                    Usuarios = UsuarioNegocio.ListarUsuarios("EstadoYRol", "0", "Usuario");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();

                }
                else
                {

                    Usuarios = UsuarioNegocio.ListarUsuarios("Rol", "Usuario");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
            }

            else
            {
                if (CHKActivado.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "1");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else if (CHKDesactivado.Checked)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("Estado", "0");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios("sinFiltro");
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                }
            }
        }
    }
}