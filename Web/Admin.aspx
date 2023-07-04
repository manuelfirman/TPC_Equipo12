<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Web.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["Usuario"] == null || ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre != "Admin"))
        { %>
    <% Response.Redirect("404.aspx"); %> <!-- REDIRECCION SI NO TIENE PERMISOS -->
    <% }
    else
    { %>

    <!-- CONTENIDO PAGE -->
    <h1>Panel Administrador</h1>
            <div class="text-center mt-2 mb-2">
                <a href="UsuariosAdmin.aspx" class="btn btn-danger">Usuarios</a>
            </div>



    <% } %>
</asp:Content>
