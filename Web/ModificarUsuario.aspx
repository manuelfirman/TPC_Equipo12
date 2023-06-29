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
            <div class="text-center m-4">
                <asp:Label ID="lblMessageError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label ">Nombre:</label>
                <input type="text" id="txtNombre" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido:</label>
                <input type="text" id="txtApellido" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <input type="text" id="txtEmail" runat="server" class="form-control" />
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
                <label class="form-label" runat="server" id="lblEstadoUser"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPEstadoUser" runat="server">
                </asp:DropDownList>
            </div>
            <% } %>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAgregarDatos" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAgregarDatos_Click" />
            </div>
        </div>

        <div class="container login-container">
            <h2 class="text-center mb-4" runat="server">CAMBIAR CONTRASEÑA</h2>
            <div class="mb-3">
                <label for="txtContraseña1" class="form-label">Nueva Contraseña:</label>
                <input type="text" id="txtContraseña1" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtContraseña2" class="form-label">Repetir Nueva Contraseña:</label>
                <input type="text" id="txtContraseña2" runat="server" class="form-control" />
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnCambioContraseña" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnCambioContraseña_Click" />
            </div>
        </div>

        <div class="container login-container">
            <h2 class="text-center mb-4" runat="server">MODIFICAR DOMICILIO</h2>
            <div class="mb-3">
                <label class="form-label" runat="server" id="lblProvincia"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPProvincia" runat="server">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="txtLocalidad" class="form-label">Localidad:</label>
                <input type="text" id="txtLocalidad" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCalle" class="form-label">Calle:</label>
                <input type="text" id="txtCalle" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtAltura" class="form-label">Altura:</label>
                <input type="text" id="txtAltura" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigoPostal" class="form-label">Codigo Postal:</label>
                <input type="text" id="txtCodigoPostal" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPiso" class="form-label">Piso:</label>
                <input type="text" id="txtPiso" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtReferencia" class="form-label">Referencia:</label>
                <input type="text" id="txtReferencia" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtAlias" class="form-label">Alias:</label>
                <input type="text" id="txtAlias" runat="server" class="form-control" />
            </div>

            <%if (Session["Usuario"] != null && ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Vendedor" || (((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Admin"))
                { %>
            <div class="mb-3">
                <label class="form-label" runat="server" id="lblEstadoDomicilio"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPEstadoDomicilio" runat="server">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label" runat="server" id="lblTipoUsuario"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPTipoUsuario" runat="server">
                </asp:DropDownList>
            </div>
            <% } %>


            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAgregarDomicilio" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAgregarDomicilio_Click" />
            </div>
        </div>
    </div>
</asp:Content>
