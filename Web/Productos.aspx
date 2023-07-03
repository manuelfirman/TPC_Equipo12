<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Web.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />
    <div class="container min-vh-100 mb-5">
        <div class="container form-container">
            <h2 class="text-center mb-4" id="txtTitulo" runat="server"></h2>
            <hr />

            <div class="text-center m-4">
                <asp:Label ID="lblMessageError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>
            <div class="text-center m-4">
                <asp:Label ID="lblMessageRedirect" runat="server" CssClass="alert- alert-info" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="row">
                <div class="col-md-6 mb-2">
                    <div class="row">
                        <label for="txtNombre" class="form-label ">Nombre:</label>
                        <input type="text" id="txtNombre" runat="server" class="form-control" />
                    </div>
                    <div class="row">
                        <label for="txtCodigo" class="form-label">Codigo:</label>
                        <input type="text" id="txtCodigo" runat="server" class="form-control" />
                    </div>
                    <div class="row">
                        <label for="txtPrecio" class="form-label">Precio:</label>
                        <input type="number" id="txtPrecio" runat="server" class="form-control" />
                    </div>
                    <div class="row">
                        <label for="txtStcok" class="form-label">Stock:</label>
                        <input type="number" id="txtStock" runat="server" class="form-control" />
                    </div>
                </div>
                <div class="col-md-6 mb-2">
                    <label for="txtDesc" class="form-label">Descripción:</label>
                    <textarea id="txtDesc" runat="server" class="form-control" rows="10" style="resize: none"></textarea>

                </div>
            </div>
            <div class="row">
                <div class="col-md-6 mb-2">
                    <label class="form-label" runat="server" id="lblMarca"></label>
                    <asp:DropDownList CssClass="form-select" ID="DRPMarca" runat="server">
                    </asp:DropDownList>

                </div>
                <div class="col-md-6 mb-2">
                    <label class="form-label" runat="server" id="lblCategoria"></label>
                    <asp:DropDownList CssClass="form-select" ID="DRPCategoria" runat="server">
                    </asp:DropDownList>
                </div>
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
