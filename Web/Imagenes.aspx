<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Imagenes.aspx.cs" Inherits="Web.Imagenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />
    <div class="container mb-5">
        <div class="container form-container-xl">
            <h2 class="text-center mb-4" id="txtTitulo" runat="server"></h2>
            <hr />
            <div class="text-center m-4">
                <asp:Label ID="lblMessageError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="row">
                <div class="col-md-6">

                    <div class="mb-3">
                        <label class="form-label" runat="server" id="lblUrls" visible="false"></label>
                        <asp:DropDownList CssClass="form-select" ID="DRPUrls" visible="false" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DRPUrls_SelectedIndexChanged">
                        </asp:DropDownList>
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
                </div>
                <div class="col-md-6">
                    <asp:Image CssClass="img-fluid" runat="server" Visible="false" ID="ImgUrl"/>
                </div>
            </div>

            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="" OnClick="btnAceptar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
