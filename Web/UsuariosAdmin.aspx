<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UsuariosAdmin.aspx.cs" Inherits="Web.UsuariosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container">
        <h1>USUARIOS</h1>
                <table class="table">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>Email</th>
                            <th>DNI</th>
                            <th>Fecha Nacimiento</th>
                            <th>Telefono</th>
                            <th>Rol</th>
                            <th>Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptUsuarios" runat="server">
                            <ItemTemplate>
                                <tr>
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

</asp:Content>
