<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Web.Productos" %>

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
            <h2 class="text-center mb-4" id="txtTitulo" runat="server"></h2>
            <hr />

            <div class="mb-3">
                <label for="txtNombre" class="form-label ">Nombre:</label>
                <input type="text" id="txtNombre" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo:</label>
                <input type="text" id="txtCodigo" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtDesc" class="form-label">Descripción:</label>
                <textarea id="txtDesc" runat="server" class="form-control" rows="8" style="resize:none"></textarea>
            </div>

            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio:</label>
                <input type="number" id="txtPrecio" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtStcok" class="form-label">Stock:</label>
                <input type="number" id="txtStock" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label class="form-label" runat="server" id="lblMarca"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPMarca" runat="server">
                </asp:DropDownList>
                
            </div>

            <div class="mb-3">
                <label class="form-label" runat="server" id="lblCategoria"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPCategoria" runat="server">
                </asp:DropDownList>
            </div>

            <div class="mb-3" >
                <label class="form-label" runat="server" id="lblEstado"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPEstado" runat="server">
                </asp:DropDownList>
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="" OnClick="btnAgregar_Click" />
            </div>

            <div class="text-center">
                <asp:Label ID="lblMessageError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageOk" runat="server" CssClass="text-succes" Visible="false"></asp:Label>
            </div>


        </div>
    </div>
</asp:Content>
