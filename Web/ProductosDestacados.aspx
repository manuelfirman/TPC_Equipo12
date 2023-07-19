<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProductosDestacados.aspx.cs" Inherits="Web.ProductosDestacados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />
    <div class="container mb-5">
        <div class="container form-container-xl">
            <h2 class="text-center mb-4">Productos Destacados</h2>
            <div class="text-center m-4">
                <asp:Label ID="lblMessageError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="mb-3">
                        <label class="form-label" for="ddlProductos" id="lblAgregar" runat="server" visible="false">Seleccionar Producto:</label>
                        <label class="form-label" for="ddlProductos" id="lblModificar" runat="server" visible="false">Seleccione el producto a destacar <span id="lblProd" runat="server" visible="false"></span></label>
                        <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control mb-3" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                    </div>

                    <div class="mb-3">
                        <label class="form-label" runat="server" id="lblEstado"></label>
                        <asp:DropDownList CssClass="form-select" ID="DRPEstado" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6">
                    <asp:Image CssClass="img-fluid" runat="server" ID="ImgUrl" />
                </div>
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="" OnClick="btnAceptar_Click" />
                <a href="GestionDestacados.aspx" class="btn btn-primary">Volver al panel</a>
            </div>
        </div>
    </div>
</asp:Content>
