<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="Web.PerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Repeater ID="rptUsuario" runat="server">
            <ItemTemplate>
                <div class="row mt-3">
                    <div class="col-md-4">
                        <div class="card mb-4">
                            <div class="card-body text-center">
                                <h5 class="">Perfil</h5>
                                <img src="https://static.vecteezy.com/system/resources/thumbnails/002/318/271/small/user-profile-icon-free-vector.jpg" alt="Imagen de perfil" class="rounded-circle img-thumbnail">
                                <h4 class="mt-3"><%# ((Dominio.Usuario)Container.DataItem).Nombre.ToUpper() %></h4>
                            </div>
                        </div>
                        <div class="card mb-4">
                            <div class="card-body">

                                <!--DATOS DOMICILIO-->
                                <% if (UsuarioSession.Domicilios.Count > 0 && UsuarioSession.Domicilios != null)
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
                                    <button type="button" class="btn btn-sm btn-dark">Modificar Información</button>
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

                        <div class="card">
                            <div class="card-body">
                                <a href="MisCompras.aspx">
                                    <button type="button" class="btn btn-primary btn-lg">Mis compras</button>
                                </a>
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
                                    <button type="button" class="btn btn-sm btn-success mt-3 fw-bold">Actualizar datos personales</button>
                                </a>
                                <a href="CambiarContraseña.aspx<%# UsuarioSession.TipoUser.Nombre == "Admin" ? $"?Id={((Dominio.Usuario)Container.DataItem).IDUsuario}" : "" %>">
                                    <button type="button" class="btn btn-sm btn-primary mt-3 fw-bold">Cambiar contraseña</button>
                                </a>
                            </div>
                        </div>

                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Última Compra</h5>
                                <div class="row">
                                    <div class="col-4">
                                        <%if (UltimaCompra.Factura.Productos != null)
                                            { %>
                                        <div id="carouselProducto" class="carousel slide" data-bs-ride="carousel">
                                            <div class="carousel-inner">
                                                <%for (int i = 0; i < UltimaCompra.Factura.Productos.Count; i++)
                                                    { %>

                                                <div class="carousel-item <%= (i == 0) ? "active" : "" %>">
                                                    <a href="#" data-bs-toggle="modal" data-bs-target="#modalImagen" data-bs-img='<%=UltimaCompra.Factura.Productos[i].Producto.Imagenes.FirstOrDefault().Url %>'>
                                                        <img src="<%= UltimaCompra.Factura.Productos[i].Producto.Imagenes.FirstOrDefault().Url %>" class="d-block w-100" alt="imagen producto">
                                                    </a>
                                                </div>
                                                <% }%>
                                            </div>
                                            <a class="carousel-control-prev" href="#carouselProducto" role="button" data-bs-slide="prev">
                                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                                <span class="visually-hidden">Previous</span>
                                            </a>
                                            <a class="carousel-control-next" href="#carouselProducto" role="button" data-bs-slide="next">
                                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                                <span class="visually-hidden">Next</span>
                                            </a>
                                        </div>

                                    </div>

                                    <div class="col-4">
                                        <ul class="list-group">
                                            <li class="list-group-item">
                                                <h6>Productos</h6>
                                                <%foreach (Dominio.ElementoCarrito elemento in UltimaCompra.Factura.Productos)
                                                    { %>
                                                <p><%= elemento.Producto.Nombre %></p>
                                                <%}  %>
                                            </li>
                                        </ul>
                                    </div>

                                    <div class="col-4">
                                        <ul class="list-group">
                                            <li class="list-group-item">
                                                <p><span class="fw-medium">Fecha: </span><%= UltimaCompra.Fecha.ToShortDateString() %></p>
                                                <p><span class="fw-medium">Estado: </span><%= UltimaCompra.Estado.Estado %></p>
                                                <p><span class="fw-medium">Destino: </span><%= UltimaCompra.Usuario.Domicilios[0].Calle  %> <%= UltimaCompra.Usuario.Domicilios[0].Altura  %></p>
                                                <p><span class="fw-medium">Precio Total: </span>$<%= Math.Round(UltimaCompra.Monto, 2) %></p>
                                            </li>

                                        </ul>
                                        <div class="mt-2">
                                            <a href="MisCompras.aspx" class="btn btn-primary">Ver Detalle</a>
                                        </div>
                                    </div>

                                    <% }
                                        else
                                        { %>
                                    <p>No has realizado ninguna compra</p>
                                    <a href="Index.aspx" class="btn btn-primary">Ir a comprar</a>
                                    <% } %>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </ItemTemplate>
        </asp:Repeater>
        <div class="row my-5"></div>
    </div>

</asp:Content>
