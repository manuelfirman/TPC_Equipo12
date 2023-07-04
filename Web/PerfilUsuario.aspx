<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="Web.PerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptUsuario" runat="server">
        <ItemTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <div class="card mb-4">
                            <div class="card-body text-center">
                                <img src="https://static.vecteezy.com/system/resources/thumbnails/002/318/271/small/user-profile-icon-free-vector.jpg" alt="Imagen de perfil" class="rounded-circle img-thumbnail">
                                <h4 class="mt-3"><%# ((Dominio.Usuario)Container.DataItem).Nombre.ToUpper() %></h4>
                            </div>
                        </div>
                        <div class="card mb-4">
                            <div class="card-body">

                                <!--DATOS DOMICILIO-->
                                <% if (UsuarioSession.Domicilios.Count > 0)
                                    { %>
                                <h5 class="card-title">Información de Envío</h5>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item">
                                        <span class="fw-bold">Alias:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Alias : "Casa" %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Dirección:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? $"{((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Calle} {((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Altura}, {((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Localidad}": "Sin cargar" %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Ubicacion:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? $"{((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Provincia}, Argentina." : "Sin cargar" %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Codigo Postal:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().CodigoPostal : "Sin cargar"%></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Piso:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Piso : "Sin cargar"%></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Referencia:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Domicilios.Any() ? ((Dominio.Usuario)Container.DataItem).Domicilios.FirstOrDefault().Referencia : "Sin cargar"%></span>
                                    </li>
                                </ul>
                                <a href="Domicilios.aspx<%# UsuarioSession.TipoUser.Nombre == "Admin" ? $"?Id={((Dominio.Usuario)Container.DataItem).IDUsuario}" : "" %>">
                                    <button type="button" class="btn btn-primary">Modificar dirección</button>
                                </a>

                                <%}
                                    else
                                    { %>
                                <h5 class="card-title">Información de Envío</h5>
                                <ul class="list-group list-group-flush mt-4">
                                    <span class="float-end mb-3">Aún no has cargado datos de tu direccion</span>
                                    <a href="Domicilios.aspx<%# UsuarioSession.TipoUser.Nombre == "Admin" ? $"?Id={((Dominio.Usuario)Container.DataItem).IDUsuario}" : "" %>">
                                        <button type="button" class="btn btn-primary">Agregar dirección</button>
                                    </a>
                                </ul>
                                <%} %>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="card mb-4">
                            <div class="card-body">
                                <h5 class="card-title">Datos Personales</h5>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item">
                                        <span class="fw-bold">Nombre:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Nombre %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Apellido:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Apellido %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Email:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Email %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">DNI:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).DNI %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Teléfono:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).Telefono %></span>
                                    </li>
                                    <li class="list-group-item">
                                        <span class="fw-bold">Fecha de Nacimiento:</span>
                                        <span class="float-end"><%# ((Dominio.Usuario)Container.DataItem).FechaNacimiento.ToShortDateString() %></span>
                                    </li>
                                </ul>
                                <a href="ModificarUsuario.aspx<%# UsuarioSession.TipoUser.Nombre == "Admin" ? $"?Id={((Dominio.Usuario)Container.DataItem).IDUsuario}" : "" %>">
                                    <button type="button" class="btn btn-primary mt-3">Actualizar datos personales</button>
                                </a>
                                <a href="CambiarContraseña.aspx<%# UsuarioSession.TipoUser.Nombre == "Admin" ? $"?Id={((Dominio.Usuario)Container.DataItem).IDUsuario}" : "" %>">
                                    <button type="button" class="btn btn-primary mt-3">Cambiar contraseña</button>
                                </a>
                            </div>
                        </div>
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Última Compra</h5>
                                <div class="row">
                                    <div class="col-4">
                                        <img src="ruta_imagen_producto.jpg" alt="Imagen del producto" class="img-thumbnail">
                                    </div>
                                    <div class="col-8">
                                        <h6>Nombre del Producto</h6>
                                        <p>Precio: $50.00</p>
                                        <p>Fecha: 01/05/2023</p>
                                        <a href="#" class="btn btn-primary">Ver Detalles</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
