<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="Web.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />

    <div class="container min-vh-100 mb-5">
        <div class="container login-container">
            <h2 class="text-center mb-4" id="txtTitulo" runat="server"></h2>
            <hr />
            <div class="text-center m-4">
                <asp:Label ID="lblMessageError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>
            <div class="text-center m-4">
                <asp:Label ID="lblMessageRedirect" runat="server" CssClass="alert- alert-info" role="alert" Visible="false"></asp:Label>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre Marca:</label>
                <input type="text" id="txtNombre" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label class="form-label" runat="server" id="lblEstado"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPEstado" runat="server">
                </asp:DropDownList>
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="" OnClick="btnAgregar_Click" />
                <a href="Vendedor.aspx" class="btn btn-danger">Cancelar</a>
            </div>


        </div>
    </div>
</asp:Content>
