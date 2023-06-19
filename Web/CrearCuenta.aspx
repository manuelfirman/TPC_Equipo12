<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CrearCuenta.aspx.cs" Inherits="Web.CrearCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .login-container {
            max-width: 400px;
            margin: 0 auto;
            margin-top: 100px;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #fff;
        }
    </style>
    <div class="container min-vh-100">
        <div class="container login-container">
            <h2 class="text-center mb-4">Crear Cuenta</h2>
            <hr />

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <input type="text" class="form-control" id="txtNombre" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido:</label>
                <input type="text" class="form-control" id="txtApellido" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtDni" class="form-label">DNI:</label>
                <input type="text" class="form-control" id="txtDni" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <input type="text" class="form-control" id="txtEmail" runat="server" />
            </div>


            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña:</label>
                <input type="password" class="form-control" id="txtPassword" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtConfirmarPassword" class="form-label">Confirmar Contraseña</label>
                <input type="password" class="form-control" id="txtConfirmarPassword" runat="server" />
            </div>



            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnCrear" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnCrear_Click" />
            </div>

            <div class="text-center">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>

            <div class="text-center">
                <asp:Button ID="btnIniciarSesion" runat="server" Text="Ya tengo cuenta" CssClass="nav-link text-primary" OnClick="btnIniciarSesion_Click"/>
            </div>


        </div>
    </div>
</asp:Content>