<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="Web.ModificarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />

    <div class="container min-vh-100 mb-5">
        <div class="container form-container">
            <h2 class="text-center mb-4" id="txtTitulo" runat="server">MODIFICAR DATOS PERSONALES</h2>
            <hr />
            <div class="row">
                <div class="col-md-6 mb-2">
                    <label for="txtNombre" class="form-label fw-bold">* Nombre:</label>
                    <input type="text" id="txtNombre" runat="server" class="form-control" />
                </div>
                <div class="col-md-6 mb-2">
                    <label for="txtFechaNacimiento" class="form-label fw-bold">Fecha de Nacimiento:</label>
                    <input type="date" id="txtFechaNacimiento" runat="server" class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-2">
                    <label for="txtApellido" class="form-label fw-bold">* Apellido:</label>
                    <input type="text" id="txtApellido" runat="server" class="form-control" />
                </div>
                <div class="col-md-6 mb-2">
                    <label for="txtTelefono" class="form-label fw-bold">Telefono:</label>
                    <input type="text" id="txtTelefono" runat="server" class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-2">
                    <label for="txtDni" class="form-label fw-bold">* DNI:</label>
                    <input type="text" id="txtDni" runat="server" class="form-control" />
                </div>
                <div class="col-md-6 mb-2">
                    <label class="form-label fw-bold">Domicilio:</label>
                    <asp:Label ID="txtDomicilio" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-2">
                    <label for="txtDni" class="form-label fw-bold">Contraseña:</label>
                    <a href="CambiarContraseña.aspx" class="btn btn-primary">Cambiar Contraseña</a>
                </div>
                <div class="col-md-6 mb-2">
                    <a href="Domicilios.aspx" class="btn btn-primary">Editar Domicilio</a>
                </div>
            </div>

            <%if (Session["Usuario"] != null && ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Vendedor" || (((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Admin"))
                { %>
            <div class="col-md-12 mb-2">
                <label for="txtEmail" class="form-label fw-bold">* Email:</label>
                <input type="text" id="txtEmail" runat="server" class="form-control" />
            </div>

            <div class="row">
                <div class="col-md-6 mb-2">
                    <label class="form-label fw-bold" runat="server" id="lblEstadoUser"></label>
                    <asp:DropDownList CssClass="form-select" ID="DRPEstadoUser" runat="server">
                    </asp:DropDownList>
                </div>

                <div class="col-md-6 mb-2">
                    <label class="form-label fw-bold" runat="server" id="lblTipoUsuario"></label>
                    <asp:DropDownList CssClass="form-select" ID="DRPTipoUsuario" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <% } %>

            <div class="text-center m-4">
                <asp:Label ID="lblMessageDatosError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageDatosOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>
            <div class="text-center m-4">
                <asp:Label ID="lblMessageDatosRedirect" runat="server" CssClass="alert- alert-info" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAgregarDatos" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnAgregarDatos_Click" />
                <a href="PerfilUsuario.aspx" class="btn btn-secondary">Volver al perfil</a>
            </div>
        </div>
    </div>
</asp:Content>
