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
    public partial class CrearCuenta : System.Web.UI.Page
    {

        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
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

            if(contrasena != confirmarContrasena)
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