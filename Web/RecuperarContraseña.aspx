<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="Web.RecuperarContraseña" %>
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
            <h2 class="text-center mb-4">Cambiar Contraseña</h2>
            <hr />
            <h5 class="text-center mb-4 text-secondary" >Vamos a enviarte un email para que puedas cambiar tu contraseña.</h5>
            <div class="mb-3" runat="server" id="contEmail" visible="false">
                <label for="txtEmail" class="form-label" runat="server" id="txtTitulo">Email:</label>
                <input type="text" class="form-control" id="txtEmail" runat="server" />
            </div>

            <div class="mb-3" runat="server" id="contCodigo" visible="false">
                <label for="txtCodigo" class="form-label" runat="server" id="Label1">Codigo:</label>
                <input type="text" class="form-control" id="txtCodigo" runat="server" />
            </div>

            <div class="mb-3" runat="server" id="contContraseña" visible="false">
                <label for="txtContra" class="form-label" runat="server" id="lblcon">Contraseña nueva:</label>
                <input type="password" class="form-control" id="txtContra" runat="server" />
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnEmail" runat="server" Text="Enviar Email" Visible="false" CssClass="btn btn-primary" OnClick="btnEmail_Click" />
                <asp:Button ID="btnCodigo" runat="server" Text="Aceptar" Visible="false" CssClass="btn btn-primary" OnClick="btnCodigo_Click" />
                <asp:Button ID="btnCont" runat="server" Text="Cambiar contraseña" Visible="false" CssClass="btn btn-primary" OnClick="btnCont_Click" />
            </div>

            <div class="text-center">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
