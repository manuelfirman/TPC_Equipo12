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
                                <label>DNI:</label>
                                <span id="spnDni" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).DNI %></span>
                            </div>
                             <div class="form-group">
                                <label>Telefono:</label>
                                <span id="spnTelefono" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Telefono %></span>
                            </div> 
                             <div class="form-group">
                                <label>Fecha de Nacimiento:</label>
                                <span id="spnNacimiento" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).FechaNacimiento.ToString() %></span>
                            </div>
                            <div class="form-group">
                                <a href="ModificarUsuario.aspx?Id=<%# ((Dominio.Usuario)Container.DataItem).IDUsuario %>">
                                    <button type="button" class="btn btn-primary">Actualizar datos personales</button>
                                </a>
                            </div>
                            <div class="form-group">
                                <a href="CambiarContraseña.aspx?Id=<%# ((Dominio.Usuario)Container.DataItem).IDUsuario %>">
                                    <button type="button" class="btn btn-primary">Cambiar contraseña</button>
                                </a>
                            </div>
                        </div>

                        <!--DATOS DOMICILIO-->
                        <% if (Usuario.Domicilios.Count > 0)
                            { %>
                        
                        <div class="card card-body bg-dark text-light mb-1 mx-1">
                            <h4 class="text-primary">Dirección - <%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Alias : "Predeterminada" %></h4>
                            <div class="form-group">
                                <label>Provincia:</label>
                                <span id="spnProvincia" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Provincia.Nombre : "Sin cargar" %></span>
                            </div>
                            <div class="form-group">
                                <label>Localidad:</label>
                                <span id="spnLocalidad" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Localidad: "Sin cargar"%></span>
                            </div>
                            <div class="form-group">
                                <label>Código Postal:</label>
                                <span id="spnCP" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().CodigoPostal : "Sin cargar"%></span>
                            </div>
                            <div class="form-group">
                                <label>Piso:</label>
                                <span id="spnPiso" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Piso : "Sin cargar"%></span>
                            </div>
                            <div class="form-group">
                                <label>Referencia:</label>
                                <span id="spnReferencia" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Referencia : "Sin cargar"%></span>
                            </div>
                            <div class="form-group">
                                <label>Domicilio:</label>
                                <span id="spnCalle" class="form-control-static"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? (((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Calle + " " + ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Altura) : "Sin cargar" %></span>
                            </div>
                            <div class="form-group">
                                <a href="Domicilios.aspx?Id=<%# ((Dominio.Usuario)Container.DataItem).IDUsuario %>">
                                    <button type="button" class="btn btn-primary">Modificar dirección</button>
                                </a>
                            </div>
                        </div>


                        <%}
                            else
                            { %>
                        <div class="card card-body bg-dark text-light mb-1 mx-1">
                            <h4 class="text-primary">Direccion</h4>
                            <div class="form-group">
                                <label>Aun no has cargado datos de tu direccion</label>
                            </div>
                            <a href="Domicilios.aspx?Id=<%# ((Dominio.Usuario)Container.DataItem).IDUsuario %>">
                                <button type="button" class="btn btn-primary">Agregar dirección</button>
                            </a>

                        </div>
                        <%} %>
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
