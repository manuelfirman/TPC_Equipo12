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
                                <%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalModificarUsuario">Actualizar datos personales</button>--%>
                            </div>
                        </div>

                        <!--DATOS DOMICILIO-->
                        <% if (Usuario.Domicilio != null) { %>
                        
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
                            <div class="form-group">
                                <%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalModificarDomicilio">Actualizar Domicilio</button>--%>
                            </div>
                        </div>

                        <%} %>
                    </div>
            </ItemTemplate>
        </asp:Repeater>



       <%-- <!-- MODAL DATOS PERSONALES -->
        <div class="modal fade" id="modalModificarUsuario" tabindex="-1" aria-labelledby="modalModificarUsuarioLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalModificarUsuarioLabel">Modificar Usuario</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkNombre" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el nombre" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkApellido" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese el apellido" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkDNI" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese el DNI" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkTelefono" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblTelefono" runat="server" Text="Telefono:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese el Telefono" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkNacimiento" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblNacimiento" runat="server" Text="Fecha de nacimiento:" CssClass="form-label me-2"></asp:Label>
                            <asp:Calendar ID="calFechaNacimiento" runat="server"></asp:Calendar>
                        </div>
                       
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BtnGuardarDatosPersonales" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardarDatosPersonales_Click" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- MODAL DOMICILIO -->
        <div class="modal fade" id="modalModificarDomicilio" tabindex="-1" aria-labelledby="modalModificarUsuarioLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalModificarDomicilioLabel">Modificar Usuario</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkCalle" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblCalle" runat="server" Text="Calle:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="Ingrese la Calle" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkAltura" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblAltura" runat="server" Text="Altura:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control" placeholder="Ingrese la Altura" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkPiso" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblPiso" runat="server" Text="Piso:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtPiso" runat="server" CssClass="form-control" placeholder="Ingrese el Piso" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkReferencia" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblReferencia" runat="server" Text="Referencia:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control" placeholder="Ingrese la Referencia" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkProvincia" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" placeholder="Ingrese la provincia" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkLocalidad" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" placeholder="Ingrese la Localidad" />
                        </div>
                        <div class="form-check  flex-row align-items-center">
                            <asp:CheckBox ID="chkCodigoPostal" runat="server" Text="" CssClass="" onchange="" />
                            <asp:Label ID="lblCodigoPostal" runat="server" Text="Localidad:" CssClass="form-label me-2"></asp:Label>
                            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" placeholder="Ingrese el CodigoPostal" />
                        </div>

                       
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BtnGuardarDomicilio" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardarDomicilio_Click" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>--%>





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
