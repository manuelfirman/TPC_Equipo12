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
        private Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios = Session["ListaUsuarios"] as List<Usuario>;
            usuario = Session["Usuario"] as Usuario;
            if (usuario.TipoUser.Nombre == "Admin")
            {
                if (!IsPostBack)
                {
                    Usuarios = UsuarioNegocio.ListarUsuarios();
                    rptUsuarios.DataSource = Usuarios;
                    rptUsuarios.DataBind();
                    Session["ListaUsuarios"] = Usuarios;
                }
            }
            else
            {
                Response.Redirect("404.aspx");
                return;

            }

        }
        //CHEKED ESTADO ACTIVADO
        protected void CHKActivado_CheckedChanged(object sender, EventArgs e)
        {
            CHKDesactivado.Checked = false;

        }
        //CHEKED ESTADO DESACTIVADO
        protected void CHKDesactivado_CheckedChanged(object sender, EventArgs e)
        {
            CHKActivado.Checked = false;

        }
        //CHEKED ADMIN
        protected void CHKAdmin_CheckedChanged(object sender, EventArgs e)
        {
            CHKUsuario.Checked = false;
            CHKVendedor.Checked = false;

        }
        //CHEKED VENDEDOR
        protected void CHKVendedor_CheckedChanged(object sender, EventArgs e)
        {
            CHKAdmin.Checked = false;
            CHKUsuario.Checked = false;


        }
        //CHEKED USUARIO
        protected void CHKUsuario_CheckedChanged(object sender, EventArgs e)
        {
            CHKAdmin.Checked = false;
            CHKVendedor.Checked = false;

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<Usuario> auxUsuarios = new List<Usuario>();

            if (CHKActivado.Checked)
            {
                if (CHKAdmin.Checked)
                {
                    if (DRPTipo.SelectedValue == "Nombre")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Admin" && item.Estado && item.Nombre.Contains(filtro))
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else if (DRPTipo.SelectedValue == "DNI")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Admin" && item.Estado && item.DNI == filtro)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else
                    {
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Admin" && item.Estado)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }



                }
                else if (CHKVendedor.Checked)
                {
                    if (DRPTipo.SelectedValue == "Nombre")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Vendedor" && item.Estado && item.Nombre.Contains(filtro))
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else if (DRPTipo.SelectedValue == "DNI")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Vendedor" && item.Estado && item.DNI == filtro)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else
                    {
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Vendedor" && item.Estado)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }

                }
                else if (CHKUsuario.Checked)
                {
                    if (DRPTipo.SelectedValue == "Nombre")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Usuario" && item.Estado && item.Nombre.Contains(filtro))
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else if (DRPTipo.SelectedValue == "DNI")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Usuario" && item.Estado && item.DNI == filtro)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else
                    {
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Usuario" && item.Estado)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }

                }
                else if (DRPTipo.SelectedValue == "Nombre")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (item.Estado && item.Nombre.Contains(filtro))
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else if (DRPTipo.SelectedValue == "DNI")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (item.Estado && item.DNI == filtro)
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    foreach (var item in Usuarios)
                    {
                        if (item.Estado)
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
            }

            else if (CHKDesactivado.Checked)
            {
                if (CHKAdmin.Checked)
                {
                    if (DRPTipo.SelectedValue == "Nombre")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Admin" && !item.Estado && item.Nombre.Contains(filtro))
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else if (DRPTipo.SelectedValue == "DNI")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Admin" && !item.Estado && item.DNI == filtro)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else
                    {
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Admin" && !item.Estado)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }



                }
                else if (CHKVendedor.Checked)
                {
                    if (DRPTipo.SelectedValue == "Nombre")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Vendedor" && !item.Estado && item.Nombre.Contains(filtro))
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else if (DRPTipo.SelectedValue == "DNI")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Vendedor" && !item.Estado && item.DNI == filtro)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else
                    {
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Vendedor" && !item.Estado)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }

                }
                else if (CHKUsuario.Checked)
                {
                    if (DRPTipo.SelectedValue == "Nombre")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Usuario" && !item.Estado && item.Nombre.Contains(filtro))
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else if (DRPTipo.SelectedValue == "DNI")
                    {
                        string filtro = txtTipo.Text;
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Usuario" && !item.Estado && item.DNI == filtro)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }
                    else
                    {
                        foreach (var item in Usuarios)
                        {
                            if (item.TipoUser.Nombre == "Usuario" && !item.Estado)
                            {
                                auxUsuarios.Add(item);
                            }
                        }
                        rptUsuarios.DataSource = auxUsuarios;
                        rptUsuarios.DataBind();
                    }

                }
                else if (DRPTipo.SelectedValue == "Nombre")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (!item.Estado && item.Nombre.Contains(filtro))
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else if (DRPTipo.SelectedValue == "DNI")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (!item.Estado && item.DNI == filtro)
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    foreach (var item in Usuarios)
                    {
                        if (!item.Estado)
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
            }
            else if (CHKAdmin.Checked)
            {
                if (DRPTipo.SelectedValue == "Nombre")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (item.TipoUser.Nombre == "Admin" && item.Nombre.Contains(filtro))
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else if (DRPTipo.SelectedValue == "DNI")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (item.TipoUser.Nombre == "Admin" && item.DNI == filtro)
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    foreach (var item in Usuarios)
                    {
                        if (item.TipoUser.Nombre == "Admin")
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
            }
            else if (CHKVendedor.Checked)
            {
                if (DRPTipo.SelectedValue == "Nombre")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (item.TipoUser.Nombre == "Vendedor" && item.Nombre.Contains(filtro))
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else if (DRPTipo.SelectedValue == "DNI")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (item.TipoUser.Nombre == "Vendedor" && item.DNI == filtro)
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    foreach (var item in Usuarios)
                    {
                        if (item.TipoUser.Nombre == "Vendedor")
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
            }
            else if (CHKUsuario.Checked)
            {
                if (DRPTipo.SelectedValue == "Nombre")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (item.TipoUser.Nombre == "Usuario" && item.Nombre.Contains(filtro))
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else if (DRPTipo.SelectedValue == "DNI")
                {
                    string filtro = txtTipo.Text;
                    foreach (var item in Usuarios)
                    {
                        if (item.TipoUser.Nombre == "Usuario" && item.DNI == filtro)
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
                else
                {
                    foreach (var item in Usuarios)
                    {
                        if (item.TipoUser.Nombre == "Usuario")
                        {
                            auxUsuarios.Add(item);
                        }
                    }
                    rptUsuarios.DataSource = auxUsuarios;
                    rptUsuarios.DataBind();
                }
            }
            else if (DRPTipo.SelectedValue == "Nombre")
            {
                string filtro = txtTipo.Text;
                foreach (var item in Usuarios)
                {
                    if (item.Nombre.Contains(filtro))
                    {
                        auxUsuarios.Add(item);
                    }
                }
                rptUsuarios.DataSource = auxUsuarios;
                rptUsuarios.DataBind();
            }
            else if (DRPTipo.SelectedValue == "DNI")
            {
                string filtro = txtTipo.Text;
                foreach (var item in Usuarios)
                {
                    if (item.DNI == filtro)
                    {
                        auxUsuarios.Add(item);
                    }
                }
                rptUsuarios.DataSource = auxUsuarios;
                rptUsuarios.DataBind();
            }
            else
            {
                rptUsuarios.DataSource = Usuarios;
                rptUsuarios.DataBind();
            }
        }
    }
}