<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Web.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-9">
                <div class="card">
                    <div class="card-body">

                        <h1 class="card-title">VENTAS</h1>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Factura Nº</th>
                                    <th>Usuario</th>
                                    <th>Estado</th>
                                    <th>Monto</th>
                                    <th>Destino</th>
                                    <th>Fecha</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptVentas" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="<%# (Eval("Estado.Estado").ToString() == "ENVIADO" || (Eval("Estado.Estado").ToString()) == "ENTREGADO") ? "background-color: green;": ((Eval("Estado.Estado").ToString()) == "PAGO PENDIENTE") ? "background-color: ligthred;" : ((Eval("Estado.Estado").ToString()) == "CANCELADO") ? "background-color: red;" : ((Eval("Estado.Estado").ToString()) == "PAGADO") ? "background-color: lightgreen;" : "" %>"><%# Eval("IDVenta") %></td>
                                            <td style="<%# (Eval("Estado.Estado").ToString() == "ENVIADO" || (Eval("Estado.Estado").ToString()) == "ENTREGADO") ? "background-color: green;": ((Eval("Estado.Estado").ToString()) == "PAGO PENDIENTE") ? "background-color: ligthred;" : ((Eval("Estado.Estado").ToString()) == "CANCELADO") ? "background-color: red;" : ((Eval("Estado.Estado").ToString()) == "PAGADO") ? "background-color: lightgreen;" : "" %>"><%# Eval("Factura.IDFactura") %></td>
                                            <td style="<%# (Eval("Estado.Estado").ToString() == "ENVIADO" || (Eval("Estado.Estado").ToString()) == "ENTREGADO") ? "background-color: green;": ((Eval("Estado.Estado").ToString()) == "PAGO PENDIENTE") ? "background-color: ligthred;" : ((Eval("Estado.Estado").ToString()) == "CANCELADO") ? "background-color: red;" : ((Eval("Estado.Estado").ToString()) == "PAGADO") ? "background-color: lightgreen;" : "" %>"><%# Eval("Usuario.Email") %></td>
                                            <td style="<%# (Eval("Estado.Estado").ToString() == "ENVIADO" || (Eval("Estado.Estado").ToString()) == "ENTREGADO") ? "background-color: green;": ((Eval("Estado.Estado").ToString()) == "PAGO PENDIENTE") ? "background-color: ligthred;" : ((Eval("Estado.Estado").ToString()) == "CANCELADO") ? "background-color: red;" : ((Eval("Estado.Estado").ToString()) == "PAGADO") ? "background-color: lightgreen;" : "" %>"><%# Eval("Estado.Estado") %></td>
                                            <td style="<%# (Eval("Estado.Estado").ToString() == "ENVIADO" || (Eval("Estado.Estado").ToString()) == "ENTREGADO") ? "background-color: green;": ((Eval("Estado.Estado").ToString()) == "PAGO PENDIENTE") ? "background-color: ligthred;" : ((Eval("Estado.Estado").ToString()) == "CANCELADO") ? "background-color: red;" : ((Eval("Estado.Estado").ToString()) == "PAGADO") ? "background-color: lightgreen;" : "" %>">$<%# Eval("Monto") %></td>
                                            <td style="<%# (Eval("Estado.Estado").ToString() == "ENVIADO" || (Eval("Estado.Estado").ToString()) == "ENTREGADO") ? "background-color: green;": ((Eval("Estado.Estado").ToString()) == "PAGO PENDIENTE") ? "background-color: ligthred;" : ((Eval("Estado.Estado").ToString()) == "CANCELADO") ? "background-color: red;" : ((Eval("Estado.Estado").ToString()) == "PAGADO") ? "background-color: lightgreen;" : "" %>"><%# Eval("Usuario.Domicilios[0].Calle") %>, <%# Eval("Usuario.Domicilios[0].Altura") %></td>
                                            <td style="<%# (Eval("Estado.Estado").ToString() == "ENVIADO" || (Eval("Estado.Estado").ToString()) == "ENTREGADO") ? "background-color: green;": ((Eval("Estado.Estado").ToString()) == "PAGO PENDIENTE") ? "background-color: ligthred;" : ((Eval("Estado.Estado").ToString()) == "CANCELADO") ? "background-color: red;" : ((Eval("Estado.Estado").ToString()) == "PAGADO") ? "background-color: lightgreen;" : "" %>"><%# Eval("Fecha") %></td>
                                            <td style="<%# (Eval("Estado.Estado").ToString() == "ENVIADO" || (Eval("Estado.Estado").ToString()) == "ENTREGADO") ? "background-color: green;": ((Eval("Estado.Estado").ToString()) == "PAGO PENDIENTE") ? "background-color: ligthred;" : ((Eval("Estado.Estado").ToString()) == "CANCELADO") ? "background-color: red;" : ((Eval("Estado.Estado").ToString()) == "PAGADO") ? "background-color: lightgreen;" : "" %>"><a href="GestionVenta.aspx?Id=<%# Eval("IDVenta") %>" class="btn btn-primary"><i class="fas fa-pencil-alt"></i></a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card">
                    <div class="card-body">

                        <h1 class="card-title">FILTROS</h1>

                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Fecha</h5>
                                <div class="form-group">
                                    <label for="txtFechaInicio">Fecha de Inicio</label>
                                    <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <label for="txtFechaFin">Fecha de Fin</label>
                                    <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">Fecha</h5>
                                        <div class="form-group">
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
