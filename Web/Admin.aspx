<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Web.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if ((((Dominio.Usuario)Session["Usuario"])).TipoUser.IDTipo != 3) { %>
        <% Response.Redirect("404.aspx"); %> <!-- REDIRECCION SI NO HAY USER -->
    <% } else { %>

        <!-- CONTENIDO PAGE -->
        <h1>Panel Administrador</h1>
       





    <% } %>
</asp:Content>
