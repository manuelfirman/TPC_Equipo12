<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Imagenes.aspx.cs" Inherits="Web.Imagenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container min-vh-100">
        <div class="container login-container">
            <h2 class="text-center mb-4" id="txtTitulo" runat="server"></h2>
            <hr />
            <div class="text-center m-4">
                <asp:Label ID="lblMessageError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="mb-3" runat="server" id="contUrl" visible="false">
                <label for="txtUrl" class="form-label ">URL:</label>
                <input type="text" id="txtUrl" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtDesc" class="form-label ">Descripción:</label>
                <input type="text" id="txtDesc" runat="server" class="form-control" />
            </div>

            <div class="mb-3">
                <label class="form-label" runat="server" id="lblEstado"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPEstado" runat="server">
                </asp:DropDownList>
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="" OnClick="btnAceptar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
