<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="Web.Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />
    <h1>Checkout compra</h1>

    <hr />
    <div class="container min-vh-100">

        <div class="form-container">
            <h2 class="text-center mb-4">Medios de pago</h2>
            <asp:Label ID="lblError" CssClass="text-danger" runat="server" Text="" Visible="false"></asp:Label>
            <hr />
            <div class="mb-3 d-flex justify-content-between align-items-center">
                <asp:Label ID="lblEfectivo" CssClass="form-label" runat="server" Text="Efectivo"></asp:Label>
                <div class="form-check">
                    <asp:CheckBox AutoPostBack="true"  ID="CHKEfectivo" runat="server" CssClass="form-check-input" Checked="true" OnCheckedChanged="CHKEfectivo_CheckedChanged"/>
                </div>
            </div>

            <div class="mb-3 d-flex justify-content-between align-items-center">
                <asp:Label ID="lblTrans" CssClass="form-label" runat="server" Text="Transferencia"></asp:Label>
                <div class="form-check">
                    <asp:CheckBox AutoPostBack="true"  ID="CHKTransferencia" runat="server" CssClass="form-check-input" Checked="false" OnCheckedChanged="CHKTransferencia_CheckedChanged"/>
                </div>
            </div>

            <div class="mb-3  d-flex justify-content-between align-items-center">
                <asp:Label ID="lblTarejta" CssClass="form-label" runat="server" Text="Tarjeta de Credito/Debito"></asp:Label>
                <div class="form-check">
                    <asp:CheckBox AutoPostBack="true" ID="CHKTarjeta" runat="server" CssClass="form-check-input" Checked="false" OnCheckedChanged="CHKTarjeta_CheckedChanged"/>
                </div>
            </div>


            <div class="mb-3">
                <label for="txtNumero" class="form-label" id="lblNumero" runat="server" visible="false">Numero Tarjeta:</label>
                <input type="text" class="form-control" id="txtNumero" runat="server" visible="false"/>
            </div>

            <div class="mb-3" >
                <label for="txtFecha" visible="false" class="form-label" id="lblFecha" runat="server">Vencimiento:</label>
                <input type="text" visible="false" class="form-control" id="txtFecha" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtClave" visible="false" class="form-label" id="lblClave" runat="server">Codigo de Seguridad:</label>
                <input type="text" visible="false" class="form-control" id="txtClave" runat="server" />
            </div>

            <asp:Label runat="server" CssClass="text-center fw-bold text-success" ID="lblTotal"></asp:Label>
            <div class="text-center mt-2 mb-2">
                <asp:Button ID="btnAceptar" runat="server" Text="Ir al pago" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
