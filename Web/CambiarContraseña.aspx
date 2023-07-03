<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="Web.CambiarContraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />

    <div class="container min-vh-100 mb-5">
        <div class="container login-container">

            <h2 class="text-center mb-4" runat="server">CAMBIAR CONTRASEÑA</h2>
            <div class="mb-3">
                <label for="txtContraseña1" class="form-label">Nueva Contraseña:</label>
                <input type="password" id="txtContraseña1" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtContraseña2" class="form-label">Repetir Nueva Contraseña:</label>
                <input type="password" id="txtContraseña2" runat="server" class="form-control" />
            </div>

            <div class="text-center m-4">
                <asp:Label ID="lblMessageContraseñaError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageContraseñaOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>
            <div class="text-center m-4">
                <asp:Label ID="lblMessageContraseñaRedirect" runat="server" CssClass="alert- alert-info" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnCambioContraseña" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnCambioContraseña_Click" />
                <a href="PerfilUsuario.aspx" class="btn btn-secondary">Volver al perfil</a>
            </div>
        </div>

    </div>
</asp:Content>
