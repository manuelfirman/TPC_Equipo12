<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Web.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />
    <h1>Checkout compra</h1>

    <hr />
    <div class="container min-vh-100">

        <div class="row">
            <div class="col-6">
                <div class="form-container-xl flex-wrap">
                    <h2 class="text-center mb-4">Datos de envio</h2>
                    <hr />
                    <div class="row">
                        <div class="col-6">
                            <label class="form-label" runat="server" id="lblDomicilio">Tus Domicilios</label>
                            <asp:DropDownList CssClass="form-select" ID="DRPDomicilios" runat="server" OnSelectedIndexChanged="DRPDomicilios_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <div class="mb-3">
                                <label for="txtCalle" class="form-label">Calle:</label>
                                <input type="text" class="form-control" id="txtCalle" runat="server" />
                            </div>

                            <div class="mb-3">
                                <label for="txtNumero" class="form-label">Numero:</label>
                                <input type="text" class="form-control" id="txtNumero" runat="server" />
                            </div>

                            <div class="mb-3">
                                <label for="txtLocalidad" class="form-label">Localidad:</label>
                                <input type="text" class="form-control" id="txtLocalidad" runat="server" />
                            </div>

                        </div>

                        <div class="col-6">
                            <div class="mb-3">
                                <label for="txtCodPos" class="form-label">Codigo Postal:</label>
                                <input type="text" class="form-control" id="txtCodPos" runat="server" />
                            </div>

                            <div class="mb-3">
                                <label for="txtPiso" class="form-label">Piso(Opcional):</label>
                                <input type="text" class="form-control" id="txtPiso" runat="server" />
                            </div>

                            <div class="mb-3">
                                <label for="txtReferencia" class="form-label">Referencia(Opcional):</label>
                                <textarea id="txtReferencia" class="form-control" rows="5" style="resize: none" runat="server"></textarea>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
            <div class="col-6">
                <div class="login-container mt-3">
                    <h2 class="text-center mb-4">Detalle de compra</h2>
                    <hr />
                    <asp:Repeater runat="server" ID="RPDetalle">
                        <ItemTemplate>
                            <div class="mb-3 d-flex">
                                <div class="mx-1">
                                    <asp:Label ID="lblNombre" runat="server" CssClass="text-uppercase fw-bolder" Text="<%#((Dominio.ElementoCarrito)Container.DataItem).Producto.Nombre.ToUpper()%>"></asp:Label>
                                    <asp:Label runat="server"> X<%#((Dominio.ElementoCarrito)Container.DataItem).Cantidad%> unidades</asp:Label>
                                </div>
                                <asp:Label ID="lblPrecio" runat="server" CssClass="fw-bold me-3  text-success"><%#Math.Round(((Dominio.ElementoCarrito)Container.DataItem).Producto.Precio * ((Dominio.ElementoCarrito)Container.DataItem).Cantidad)%>$</asp:Label>
                            </div>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                    <div class="text-center mt-2 mb-2">
                        <asp:Button ID="btnAceptar" runat="server" Text="Ir al pago" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
