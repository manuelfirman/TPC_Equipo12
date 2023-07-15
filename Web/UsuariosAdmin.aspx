<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UsuariosAdmin.aspx.cs" Inherits="Web.UsuariosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid min-vh-100">
        <h1>USUARIOS</h1>
        <div class="row">
            <div class="col-md-9">
                <div class="card">
                    <div class="card-body">
                        <table class="table">
                            <thead>
                                <tr class="text-center">
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
                                        <tr class="text-center">
                                            <td><%# Eval("IDUsuario") %></td>
                                            <td><%# Eval("Nombre") %> <%# Eval("Apellido") %></td>
                                            <td><%# Eval("Email") %></td>
                                            <td><%# Eval("Dni") %></td>
                                            <td><%# Eval("FechaNacimiento") %></td>
                                            <td><%# Eval("Telefono") %></td>
                                            <td>
                                                <div style="<%# ((Eval("TipoUser.Nombre").ToString() == "Admin") ? "background-color: rgba(255, 0, 0, 0.7);": (Eval("TipoUser.Nombre").ToString() == "Usuario") ? "background-color: rgba(0, 0, 255, 0.7);" : "background-color: rgba(0, 255, 0, 0.7);") %>">
                                                    <%# Eval("TipoUser.Nombre") %>
                                                </div>
                                            </td>
                                            <td>
                                                <div style="<%# Eval("Estado").ToString() == "True" ? "background-color: rgba(45, 150, 44, 0.8);": "Inactivo" %>">
                                                    <%# Eval("Estado").ToString() == "True" ? "Activo" : "Inactivo" %>
                                                </div>
                                            </td>
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

                        <div class="m-4  d-flex justify-content-between align-items-center">
                            <asp:Label ID="lblEstado" CssClass="form-label fw-bold" runat="server" Text="Estado"></asp:Label>
                            <div class="form-check">
                                <asp:CheckBox AutoPostBack="true" ID="CHKActivado" runat="server" Checked="false" Text="Activado" OnCheckedChanged="CHKActivado_CheckedChanged" />
                            </div>
                            <div class="form-check">
                                <asp:CheckBox AutoPostBack="true" ID="CHKDesactivado" runat="server" Checked="false" Text="Desactivado" OnCheckedChanged="CHKDesactivado_CheckedChanged" />
                            </div>
                        </div>

                        <div class="m-4 d-flex justify-content-between align-items-center">
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

                        <div class="m-4">
                            <asp:DropDownList CssClass="form-select" ID="DRPTipo" runat="server">
                                <asp:ListItem Value="Sinfiltro">Elija una opción</asp:ListItem>
                                <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
                                <asp:ListItem Value="DNI">DNI</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control mt-4"></asp:TextBox>
                        </div>

                        <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" Text="Aplicar Filtros" OnClick="btnFiltrar_Click" />
                        <asp:Button ID="BtnRestaurar" runat="server" CssClass="btn btn-primary" Text="Restaurar Filtros" OnClick="BtnRestaurar_Click" />

                    </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>
