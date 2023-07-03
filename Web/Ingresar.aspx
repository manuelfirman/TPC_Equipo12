<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="Web.Ingresar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />

    <div class="container min-vh-100">
        <div class="container login-container">
            <h2 class="text-center mb-4">Iniciar Sesión</h2>
            <hr />

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <input type="text" class="form-control" id="txtEmail" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña:</label>
                <input type="password" class="form-control" id="txtPassword" runat="server" />
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>

            <div class="text-center">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>

            <div class="text-center">
                <asp:Button ID="btnOlvidePass" runat="server" Text="Olvide mi contraseña" CssClass="nav-link text-primary" OnClick="btnOlvidePass_Click" />
                <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="nav-link text-primary" OnClick="btnRegistrarse_Click" />
            </div>


        </div>
    </div>

</asp:Content>