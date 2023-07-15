<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionVenta.aspx.cs" Inherits="Web.GestionVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />


    <div class="container">
        <div class="card">
            <div class="card-body">
                <h1 class="card-title">GESTION VENTA</h1>
                <div class="row">
                    <div class="col-md-6">
                        <div class="card mb-4">
                            <div class="card-body">
                                <h5 class="card-title">VENTA ID N° <%= Venta.IDVenta %></h5>
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
                                        <span class="fw-bold">Fecha:</span>
                                        <span class="float-end"><%= Venta.Fecha.ToShortDateString() %></span>
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

                <div class="row">
                    <div class="col-md-6">
                        <div class="card mb-4">
                            <div class="card-body">
                                <h5 class="card-title">GESTIONAR VENTA</h5>

                                    <label class="form-label" runat="server">Estado Venta:</label>
                                    <label class="form-label" runat="server"><%=Venta.Estado.Estado %></label>
                                <% if (Usuario.TipoUser.Nombre == "Vendedor")
                                    { %>
                                <% if (Venta.Estado.Estado == "PAGO PENDIENTE")
                                    { %>
                                <div class="card">
                                    <div class="card-body">
                                        <asp:Button ID="BtnCancelado" runat="server" CssClass="btn btn-danger" Text="Mover Estado a CANCELADO" OnClick="BtnCancelado_Click" />
                                    </div>
                                </div>
                                <% }%>

                                <% if (Venta.Estado.Estado == "PAGADO")
                                    { %>
                                <div class="card">
                                    <div class="card-body">
                                        <div class="mb-2">
                                            <asp:Button ID="BtnEnviado" runat="server" CssClass="btn btn-success" Text="Mover Estado a ENVIADO" OnClick="BtnEnviado_Click" />
                                        </div>
                                    </div>
                                </div>
                                <% }%>

                                <% if (Venta.Estado.Estado == "ENVIADO")
                                    { %>
                                <div class="card">
                                    <div class="card-body">
                                        <asp:Button ID="BtnEntregado2" runat="server" CssClass="btn btn-primary" Text="Mover Estado a ENTREGADO" OnClick="BtnEntregado_Click" />
                                    </div>
                                </div>
                                <% }%>
                                <% } else if (Usuario.TipoUser.Nombre == "Admin") {  %>
                                <div class="mb-3">
                                    <label class="form-label" runat="server">Estado Venta</label>
                                    <asp:DropDownList CssClass="form-select" ID="DDLEstadoVenta" runat="server">
                                    </asp:DropDownList>

                                    <asp:Button ID="BtnGestionarVenta" runat="server" CssClass="btn btn-primary mt-3" Text="Guardar" OnClick="BtnGestionarVenta_Click" />
                                </div>
                                <% } %>
                                <div>
                                    <a href="ControlVenta.aspx?Id=<%= Venta.IDVenta %>" class="btn btn-primary">Detalles de Venta</a>
                                </div>
                                <asp:Label ID="lblMessageError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                                <asp:Label ID="lblMessageOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <% if (Venta.Estado.Estado != "CANCELADO")
                            { %>
                        <div class="card mb-4">
                            <div class="card-body">
                                <h6 class="card-title">DATOS DE COMPRA-VENTA</h6>
                                <ul class="list-group list-group-flush">

                                    <li class="list-group-item">
                                        <span class="fw-bold">Fecha compra:</span>
                                        <span class="float-end"><%= Venta.Fecha %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Enviado:</span>
                                        <span class="float-end"><%= string.IsNullOrEmpty(Venta.FechaEnvio.ToString()) ? Venta.FechaEnvio.ToString() : "" %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Destino:</span>
                                        <span class="float-end"><%= Venta.Usuario.Domicilios[0].Calle %> <%= Venta.Usuario.Domicilios[0].Altura %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Codigo de Pago:</span>
                                        <span class="float-end"><%= Venta.CodigoPago %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Codigo de Seguimiento:</span>
                                        <span class="float-end"><%= Venta.CodigoSeguimiento %></span>
                                    </li>

                                </ul>
                            </div>
                        </div>
                        <% }%>
                    </div>
                </div>




            </div>
        </div>
    </div>
</asp:Content>
