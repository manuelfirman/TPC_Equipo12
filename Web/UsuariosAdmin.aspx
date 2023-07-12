<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UsuariosAdmin.aspx.cs" Inherits="Web.UsuariosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid min-vh-100">


        <div class="row">
            <div class="col-md-9">
                <div class="card">
                    <div class="card-body">
                        <h1 class="card-title">Usuarios</h1>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Nombre</th>
                                    <th>Email</th>
                                    <th>DNI</th>
                                    <th>Fecha Nacimiento</th>
                                    <th>Telefono</th>
                                    <th>Rol</th>
                                    <th>Estado</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptUsuarios" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("IDUsuario") %></td>
                                            <td><%# Eval("Nombre") %> <%# Eval("Apellido") %></td>
                                            <td><%# Eval("Email") %></td>
                                            <td><%# Eval("Dni") %></td>
                                            <td><%# Eval("FechaNacimiento") %></td>
                                            <td><%# Eval("Telefono") %></td>
                                            <td><%# Eval("TipoUser.Nombre") %></td>
                                            <td><%# Eval("Estado").ToString() == "True" ? "Activo" : "Inactivo" %></td>
                                            <td>
                                                <a href="PerfilUsuario.aspx?Id=<%# Eval("IDUsuario") %>" class="btn btn-primary"><i class="fas fa-pencil-alt"></i></a>
                                                <%--<a href="#" class="btn btn-danger"><i class="fas fa-times"></i></a>--%>
                                            </td>
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
                        <h1 class="card-title">Filtros</h1>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="card">
                                    <div class="card-body">

                                        <asp:Label ID="lblEstado" CssClass="form-label fw-bold" runat="server" Text="Estado"></asp:Label>
                                        <div class="form-check">
                                            <asp:CheckBox AutoPostBack="true" ID="CHKActivado" runat="server" Checked="false" Text="Activado" OnCheckedChanged="CHKActivado_CheckedChanged" />
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox AutoPostBack="true" ID="CHKDesactivado" runat="server" Checked="false" Text="Desactivado" OnCheckedChanged="CHKDesactivado_CheckedChanged" />
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="card">
                                    <div class="card-body">
                                        <asp:Label ID="lblRol" CssClass="form-label fw-bold" runat="server" Text="Rol"></asp:Label>
                                        <div class="form-check">
                                            <asp:CheckBox AutoPostBack="true" ID="CHKAdmin" runat="server" Checked="false" Text="Admin" OnCheckedChanged="CHKAdmin_CheckedChanged" />
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox AutoPostBack="true" ID="CHKVendedor" runat="server" Checked="false" Text="Vendedor" OnCheckedChanged="CHKVendedor_CheckedChanged" />
                                        </div>
                                        <div class="form-check">
                                            <asp:CheckBox AutoPostBack="true" ID="CHKUsuario" runat="server" Checked="false" Text="Usuario" OnCheckedChanged="CHKUsuario_CheckedChanged" />
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

