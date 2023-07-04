<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Web.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["Usuario"] == null || ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre != "Admin"))
        { %>
    <% Response.Redirect("404.aspx"); %>
    <!-- REDIRECCION SI NO TIENE PERMISOS -->
    <% }
        else
        { %>

    <!-- CONTENIDO PAGE -->
    <h1>Panel Administrador</h1>
    <div class="text-center mt-2 mb-2">
        <a href="UsuariosAdmin.aspx" class="btn btn-danger">Usuarios</a>
    </div>

    <main class="bg-dark">
        <div class="container-fluid">
            <h1 class="text-light">ADMINISTRAR TIENDA</h1>
        </div>

        <div class="container-fluid mt-5">

            <div class="row justify-content-center align-items-center d-flex">

                <div class="col-md-4">
                    <div class="card bg-success-subtle mb-5 p-3">
                        <div class="card-body">
                            <h2 class="text-dark mt-2">ADMINISTRAR USUARIOS</h2>
                            <div class="row">
                                <div class="card mb-2">
                                    <div class="card-body">
                                        <h5 class="card-title">VER USUARIOS</h5>
                                        <a href="UsuariosAdmin.aspx" class="btn btn-primary">Usuarios</a>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">CREAR USUARIO</h5>
                                        <a href="CrearCuenta.aspx" class="btn btn-primary">Crear</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>




    <% } %>
</asp:Content>
