<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="Web.ModificarUsuario" %>

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

    <div class="container min-vh-100 mb-5">
        <div class="container login-container">
            <h2 class="text-center mb-4" id="txtTitulo" runat="server">MODIFICAR DATOS PERSONALES</h2>
            <hr />

            <div class="mb-3">
                <label for="txtNombre" class="form-label ">* Nombre:</label>
                <input type="text" id="txtNombre" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtApellido" class="form-label">* Apellido:</label>
                <input type="text" id="txtApellido" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtTelefono" class="form-label">Telefono:</label>
                <input type="text" id="txtTelefono" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento:</label>
                <input type="date" id="txtFechaNacimiento" runat="server" class="form-control" />
            </div>

            <%if (Session["Usuario"] != null && ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Vendedor" || (((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Admin"))
                { %>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">* Email:</label>
                <input type="text" id="txtEmail" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtDni" class="form-label">* DNI:</label>
                <input type="text" id="txtDni" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label class="form-label" runat="server" id="lblEstadoUser"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPEstadoUser" runat="server">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label" runat="server" id="lblTipoUsuario"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPTipoUsuario" runat="server">
                </asp:DropDownList>
            </div>
            <% } %>

            <div class="text-center m-4">
                <asp:Label ID="lblMessageDatosError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageDatosOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAgregarDatos" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAgregarDatos_Click" />
            </div>
        </div>
    </div>
</asp:Content>
