<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="Web.PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <asp:Repeater ID="rptUsuario" runat="server">
            <ItemTemplate>
                <h2 class="text-bg-primary text-center">PERFIL DE <%# ((Dominio.Usuario)Container.DataItem).Nombre.ToUpper() %></h2>
                <div class="row">
                    <div class="col-md-6 mt-5">
                        <div class="card card-body bg-dark text-light mb-1 mx-1">
                            <h4 class="text-primary">Datos Personales</h4>
                            <div class="form-group">
                                <label>Nombre:</label>
                                <span id="spnNombre" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Nombre %> <%# ((Dominio.Usuario)Container.DataItem).Apellido %></span>
                            </div>
                            <div class="form-group">
                                <label>Email:</label>
                                <span id="spnEmail" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Email %></span>
                            </div>
                            <div class="form-group">
                                <label>Telefono:</label>
                                <span id="spnTelefono" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Telefono %></span>
                            </div>
                            <div class="form-group">
                                <label>DNI:</label>
                                <span id="spnDni" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).DNI %></span>
                            </div>
                        </div>

                        <!--DATOS DOMICILIO-->
                        <div class="card card-body bg-dark text-light mb-1 mx-1">
                            <h4 class="text-primary">Dirección - <%# ((Dominio.Usuario)Container.DataItem).Domicilio.Alias %></h4>
                            <div class="form-group">
                                <label>Provincia:</label>
                                <span id="spnProvincia" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilio.Provincia.Nombre %></span>
                            </div>
                            <div class="form-group">
                                <label>Localidad:</label>
                                <span id="spnLocalidad" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilio.Localidad%></span>
                            </div>
                            <div class="form-group">
                                <label>Código Postal:</label>
                                <span id="spnCP" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilio.CodigoPostal%></span>
                            </div>
                            <div class="form-group">
                                <label>Piso:</label>
                                <span id="spnPiso" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilio.Piso%></span>
                            </div>
                            <div class="form-group">
                                <label>Referencia:</label>
                                <span id="spnReferencia" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilio.Referencia%></span>
                            </div>
                            <div class="form-group">
                                <label>Domicilio:</label>
                                <span id="spnCalle" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilio.Calle %> <%# ((Dominio.Usuario)Container.DataItem).Domicilio.Altura %></span>
                            </div>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>


        <div class="col-md-6 mt-lg-5">
            <h3>Historial de Compras</h3>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Fecha</th>
                        <th>Producto</th>
                        <th>Precio</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>01/05/2023</td>
                        <td>Producto 1</td>
                        <td>$50.00</td>
                    </tr>
                    <tr>
                        <td>02/05/2023</td>
                        <td>Producto 2</td>
                        <td>$35.00</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
