<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionVenta.aspx.cs" Inherits="Web.GestionVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />
    <h1>GESTION VENTA</h1>

    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title">VENTA N° <%= Venta.IDVenta %></h5>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <span class="fw-bold">Estado:</span>
                                <span class="float-end"><%= Venta.Estado.Estado %></span>
                            </li>
                            <li class="list-group-item">
                                <span class="fw-bold">Monto:</span>
                                <span class="float-end">$<%= Venta.Monto %></span>
                            </li>
                            <li class="list-group-item">
                                <span class="fw-bold">Destino:</span>
                                <span class="float-end"><%=Venta.Usuario.Domicilios[0].Calle %> <%=Venta.Usuario.Domicilios[0].Altura %>, <%= Venta.Usuario.Domicilios[0].Localidad %>, <%= Venta.Usuario.Domicilios[0].Provincia %></span>
                            </li>
                            <li class="list-group-item">
                                <span class="fw-bold">Productos:</span>
                                <ul class="list-group list-group-flush">
                                    <%foreach (Dominio.ElementoCarrito elemento in Venta.Factura.Productos)
                                        { %>
                                    <li class="list-group-item">
                                        <span class="fw-semibold"><%= elemento.Producto.Nombre %></span>
                                        <span class="float-end"><%= elemento.Cantidad %> x $<%= elemento.Cantidad * elemento.Producto.Precio %></span>
                                    </li>
                                    <% } %>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Datos Usuario</h5>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <span class="fw-bold">Nombre:</span>
                                <span class="float-end"><%= Venta.Usuario.Nombre %> <%= Venta.Usuario.Apellido %></span>
                            </li>
                            <li class="list-group-item">
                                <span class="fw-bold">Email:</span>
                                <span class="float-end"><%= Venta.Usuario.Email %></span>
                            </li>
                            <li class="list-group-item">
                                <span class="fw-bold">DNI:</span>
                                <span class="float-end"><%= Venta.Usuario.DNI %></span>
                            </li>
                            <li class="list-group-item">
                                <span class="fw-bold">Telefono:</span>
                                <span class="float-end"><%= Venta.Usuario.Telefono %></span>
                            </li>

                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="card mb-4">
                <div class="card-body">
                    <h5 class="card-title">GESTIONAR VENTA</h5>
                    <div class="mb-3">
                        <label class="form-label" runat="server">Estado Venta</label>
                        <asp:DropDownList CssClass="form-select" ID="DDLEstadoVenta" runat="server">
                        </asp:DropDownList>
                    </div>
                    <asp:Button ID="BtnGestionarVenta" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="BtnGestionarVenta_Click" />
                    <asp:Label ID="lblMessageError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                    <asp:Label ID="lblMessageOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
                </div>
            </div>
        </div>



    </div>
</asp:Content>
