<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Web.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row mt-2">
            <div class="col-md-9">
                <div class="card">
                    <div class="card-body">

                        <h1 class="card-title">VENTAS</h1>
                        <table class="table">
                            <thead>
                                <tr class="text-center">
                                    <th class="text-white" style="background-color: black">ID</th>
                                    <th class="text-white" style="background-color: black">Estado</th>
                                    <th class="text-white" style="background-color: black">Factura Nº</th>
                                    <th class="text-white" style="background-color: black">Usuario</th>
                                    <th class="text-white" style="background-color: black">Monto</th>
                                    <th class="text-white" style="background-color: black">Destino</th>
                                    <th class="text-white" style="background-color: black">Fecha</th>
                                    <th class="text-white" style="background-color: black"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptVentas" runat="server">
                                    <ItemTemplate>
                                        <tr class="text-center">
                                            <td><%# Eval("IDVenta") %></td>
                                            <td>
                                                <div style="<%# ((Eval("Estado.Estado").ToString()) == "ENVIADO" || (Eval("Estado.Estado").ToString()) == "ENTREGADO") ? "background-color: rgba(45, 150, 44, 0.8);": ((Eval("Estado.Estado").ToString()) == "EN PROCESO") ? "background-color: rgba(0, 0, 150, 0.6);" : ((Eval("Estado.Estado").ToString()) == "PAGO PENDIENTE") ? "background-color: rgba(230, 0, 50, 0.5);" : ((Eval("Estado.Estado").ToString()) == "CANCELADO") ? "background-color: rgba(255, 0, 0, 0.7);" : ((Eval("Estado.Estado").ToString()) == "PAGADO") ? "background-color: rgba(0, 200, 0, 0.5);" : "" %>"><%# Eval("Estado.Estado") %></div>
                                            </td>
                                            <td><%# Eval("Factura.IDFactura") %></td>
                                            <td><%# Eval("Usuario.Email") %></td>
                                            <td>$<%# Math.Round(decimal.Parse(Eval("Monto").ToString()), 2) %></td>
                                            <td><%# Eval("Usuario.Domicilios[0].Calle") %>, <%# Eval("Usuario.Domicilios[0].Altura") %></td>
                                            <td><%# Eval("Fecha") %></td>
                                            <td><a href="GestionVenta.aspx?Id=<%# Eval("IDVenta") %>" class="btn btn-primary"><i class="fas fa-pencil-alt"></i></a></td>
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

                        <div class="card mb-2">
                            <div class="card-body">
                                <h5 class="card-title">Fecha</h5>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label for="txtFechaInicio">Fecha de Inicio</label>
                                            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>

                                        <div class="col-md-6">
                                            <label for="txtFechaFin">Fecha de Fin</label>
                                            <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        <div class="form-check mt-1">
                                            <asp:CheckBox ID="ChkFecha" runat="server" Checked="false" Text="Filtrar por fecha" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="card mb-2">
                            <div class="card-body">
                                <h5 class="card-title">Estado</h5>
                                <div class="form-group">
                                    <div class="row">
                                        <label class="form-label" runat="server">Estado Venta</label>
                                        <asp:DropDownList CssClass="form-select" ID="DDLEstadoVenta" runat="server">
                                            <asp:ListItem></asp:ListItem>
                                        </asp:DropDownList>
                                        <div class="form-check mt-1">
                                            <asp:CheckBox ID="ChkEstado" runat="server" Checked="false" Text="Filtrar por monto" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="card mb-2">
                            <div class="card-body">
                                <h5 class="card-title">Monto</h5>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label for="txtMontoMin">Desde</label>
                                            <asp:TextBox ID="txtMontoMin" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtMontoMax">Hasta</label>
                                            <asp:TextBox ID="txtMontoMax" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-check mt-1">
                                            <asp:CheckBox ID="ChkMonto" runat="server" Checked="false" Text="Filtrar por monto" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <asp:Button ID="BtnFiltro" runat="server" CssClass="btn btn-primary" Text="Filtrar" OnClick="BtnFiltro_Click" />
                        <asp:Button ID="BtnRestaurar" runat="server" CssClass="btn btn-primary" Text="Restaurar Filtros" OnClick="BtnRestaurar_Click" />
            </div>
        </div>
    </div>

    </div>
    </div>

</asp:Content>
