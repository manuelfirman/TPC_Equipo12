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
    public partial class CrearCuenta : System.Web.UI.Page
    {

        private UsuarioNegocio usuarioNegocio { get; set; } = new UsuarioNegocio();
        private TipoUsuarioNegocio tipoUsuarioNegocio { get; set; } = new TipoUsuarioNegocio();
        protected Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["Usuario"] as Usuario;
            if (usuario != null )
            {
                if (usuario.TipoUser.Nombre != "Admin")
                {
                    Response.Redirect("Index.aspx");
                }
            }


            if (!IsPostBack)
            {
                if(usuario != null && usuario.TipoUser.Nombre == "Admin")
                {
                    ListItem itemEstado;
                    itemEstado = new ListItem("Activado", "1");
                    DRPEstado.Items.Add(itemEstado);
                    itemEstado = new ListItem("Desactivado", "0");
                    DRPEstado.Items.Add(itemEstado);

                    List<TipoUsuario> tipousuarios = tipoUsuarioNegocio.ListarTiposUsuario();
                    ListItem itemTipo;
                    foreach (TipoUsuario tipo in tipousuarios)
                    {
                        itemTipo = new ListItem(tipo.Nombre, tipo.IDTipo.ToString());
                        DRPTipoUsuario.Items.Add(itemTipo);
                    }
                    string nombreRol = usuario.TipoUser.Nombre;
                    ListItem rolUsuario = DRPTipoUsuario.Items.FindByText(nombreRol);
                    if (rolUsuario != null)
                    {
                        rolUsuario.Selected = true;
                    }
                }
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ingresar.aspx");
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Value;
            string apellido = txtApellido.Value;
            string email = txtEmail.Value;
            string contrasena = txtPassword.Value;
            string confirmarContrasena = txtConfirmarPassword.Value;
            string dni = txtDni.Value;
            lblMessage.Visible = false;
            if (nombre == "" || apellido == "" || email == "" || contrasena == "" || dni == "")
            {
                lblMessage.Text = "COMPLETE TODOS LOS CAMPOS";
                lblMessage.Visible = true;
                return;
            }

            if (contrasena.Length < 8)
            {
                lblMessage.Text = "Minimo 8 caracteres en la contraseña";
                lblMessage.Visible = true;
                return;
            }

            if (contrasena != confirmarContrasena)
            {
                lblMessage.Text = "Las contraseñas son distintas";
                lblMessage.Visible = true;
                return;
            }


            if (verificarEmail(email)){
                lblMessage.Text = "ESE EMAIL YA SE ENCUENTRA REGISTRADO";
                lblMessage.Visible = true;
                return;
            }
            else
            {
                if (verificarDni(dni))
                {
                    lblMessage.Text = "ESE DNI YA SE ENCUENTRA REGISTRADO";
                    lblMessage.Visible = true;
                    return;
                }
                else
                {
                    Usuario usuario = new Usuario();
                    TipoUsuario tipoUsuario = new TipoUsuario();
                    usuario.Email = email;
                    usuario.Nombre = nombre;
                    usuario.Apellido = apellido;
                    usuario.Contraseña = contrasena;
                    usuario.DNI = dni;
                    tipoUsuario.IDTipo = 1;
                    usuario.TipoUser = tipoUsuario;
                    if (usuarioNegocio.RegistroUsuario(usuario))
                    {
                        lblMessage.Text = "USUARIO CREADO CORRECTAMENTE";
                        lblMessage.Visible = true;
                        Session["Usuario"] = usuario;
                        EmailService emailService = new EmailService();
                        emailService.armarCorreo(usuario.Email, "REGISTRO DE CUENTA", $"<h1>HOLA {usuario.Nombre}</h1> <p>Tu cuenta se creo correctame, muchas gracias por confiar!</p>");
                        emailService.enviarEmail();
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "ERORR";
                        lblMessage.Visible = true;
                    }
                }
            }
        }


        protected bool verificarEmail(string email)
        {
            bool existe = usuarioNegocio.BuscarUsuario("Email", email).IDUsuario == 0 ? false : true;
            return existe;
        }

        protected bool verificarDni(string dni)
        {
            bool existe = usuarioNegocio.BuscarUsuario("Dni", dni).IDUsuario == 0 ? false : true;
            return existe;
        }
    }
}