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
            <hr />
            <div class="mb-3 d-flex justify-content-between align-items-center">
                <asp:Label ID="lblEfectivo" CssClass="form-label" runat="server" Text="Efectivo"></asp:Label>
                <div class="form-check">
                    <asp:CheckBox AutoPostBack="true"  ID="CHKEfectivo" runat="server" CssClass="form-check-input" Checked="true" OnCheckedChanged="CHKEfectivo_CheckedChanged"/>
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
                <%--<button class="btn btn-primary" onclick="pagar(<%= total %>, <%= IDVenta %>)">Realizar pago</button>--%>
                <asp:Button ID="btnAceptar" runat="server" Text="Ir al pago" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
            </div>
        </div>
    </div>

    <script src="Scripts/jquery-3.7.0.min.js"></script>
    <script>
        function pagar(total, IDVenta) {
            var body = {
                precio: total,
                producto: "Compra E-Commerce12" 
            }

            jQuery.ajax({
                url: 'WebService1.asmx/PaypalFunction',
                type: "POST",
                data: JSON.stringify(body),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.status) {
                        var jsonresult = JSON.parse(data.respuesta);
                        console.log(jsonresult);

                        var links = jsonresult.links;
                        var resultado = links.find(item => item.rel === "approved")
                        window.location.href = resultado.href;
                    }
                    else {
                        alert("Vuelva a intentarlo mas tarde");
                    }
                }
            })
        }
    </script>
</asp:Content>
