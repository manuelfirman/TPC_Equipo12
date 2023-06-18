<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="Web.Ingresar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/5.0.0/css/bootstrap.min.css" />--%>
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
<body>
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

        <div class="text-center">
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
        </div>

        <div class="text-center">
            <asp:Button ID="btnOlvidePass" runat="server" Text="Olvide mi contraseña" CssClass="nav-link" OnClick="btnLogin_Click" />
        </div>

        <div class="text-center mt-3">
            <asp:Literal ID="lblMessage" runat="server" Visible="false"></asp:Literal>
        </div>
    </div>

    <%--<script src="https://stackpath.bootstrapcdn.com/bootstrap/5.0.0/js/bootstrap.bundle.min.js"></script>--%>
</body>
</asp:Content>