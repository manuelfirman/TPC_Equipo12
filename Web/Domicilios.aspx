﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Domicilios.aspx.cs" Inherits="Web.Domicilios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container min-vh-100 mb-5">
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

            <div class="text-center m-4">
                <asp:Label ID="lblMessageDomicilioError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageDomicilioOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>

            <%if (Session["Usuario"] != null && ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Vendedor" || (((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Admin"))
                { %>
            <div class="mb-3">
                <label class="form-label" runat="server" id="lblEstadoDomicilio"></label>
                <asp:DropDownList CssClass="form-select" ID="DRPEstadoDomicilio" runat="server">
                </asp:DropDownList>
            </div>
            <% } %>


            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAgregarDomicilio" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAgregarDomicilio_Click" />
            </div>
        </div>
    </div>

</asp:Content>
