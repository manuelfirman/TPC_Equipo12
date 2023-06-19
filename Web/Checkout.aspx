<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Web.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if ((((Dominio.Usuario)Session["Usuario"])).TipoUser == null) { %>
      <% Response.Redirect("404.aspx"); %>
    <% } else { %>
    <h1>Checkout compra</h1>

       
    <% } %>
</asp:Content>
