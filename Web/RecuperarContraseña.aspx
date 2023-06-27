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
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <input type="text" class="form-control" id="txtEmail" runat="server" />
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnEmail" runat="server" Text="Enviar Email" CssClass="btn btn-primary" OnClick="btnEmail_Click" />
            </div>

            <div class="text-center">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
