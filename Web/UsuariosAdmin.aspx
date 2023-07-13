<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UsuariosAdmin.aspx.cs" Inherits="Web.UsuariosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <h1>USUARIOS</h1>
        <div class="row">
            <div class="col-md-9">
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
                                        <a href="#" class="btn btn-danger"><i class="fas fa-times"></i></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="col-md-3">

                <div class="m-4  d-flex justify-content-between align-items-center">
                    <asp:Label ID="lblEstado" CssClass="form-label" runat="server" Text="Estado"></asp:Label>
                    <div class="form-check">
                        <asp:CheckBox AutoPostBack="true" ID="CHKActivado" runat="server" Checked="false" Text="Activado" OnCheckedChanged="CHKActivado_CheckedChanged" />
                    </div>
                    <div class="form-check">
                        <asp:CheckBox AutoPostBack="true" ID="CHKDesactivado" runat="server" Checked="false" Text="Desactivado" OnCheckedChanged="CHKDesactivado_CheckedChanged" />
                    </div>
                </div>

                <div class="m-4 d-flex justify-content-between align-items-center">
                    <asp:Label ID="lblRol" CssClass="form-label" runat="server" Text="Rol"></asp:Label>
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
            </div>
        </div>
    </div>
</asp:Content>

