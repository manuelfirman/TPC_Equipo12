<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Web.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <h1>VENTAS</h1>
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
                                    <td><%# Eval("IDVenta") %></td>
                                    <td><%# Eval("Factura.IDFactura") %></td>
                                    <td><%# Eval("Usuario.Email") %></td>
                                    <td><%# Eval("Estado.Estado") %></td>
                                    <td>$<%# Eval("Monto") %></td>
                                    <td><%# Eval("Usuario.Domicilios[0].Calle") %>, <%# Eval("Usuario.Domicilios[0].Altura") %></td>
                                    <td><%# Eval("Fecha") %></td>
                                    <td><a href="GestionVenta.aspx?Id=<%# Eval("IDVenta") %>" class="btn btn-primary"><i class="fas fa-pencil-alt"></i></a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

    </div>
</asp:Content>
