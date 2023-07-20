<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="Web.MisCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container min-vh-100">
        <div class="card">
            <div class="card-body">
                <h1 class="card-title mb-3">Mis compras</h1>
                <% if (Compras.Count != 0)
                    { %>
                <% foreach (Dominio.Venta venta in Compras)
                    { %>

                <div class="row">
                    <div class="card mb-1 <%= (venta.Estado.Estado == "ENVIADO" || venta.Estado.Estado == "ENTREGADO") ? "bg-success" : (venta.Estado.Estado == "PAGO PENDIENTE") ? "bg-danger bg-opacity-75" : (venta.Estado.Estado == "CANCELADO") ? "bg-danger" : (venta.Estado.Estado == "PAGADO") ? "bg-success-subtle" : "" %>">
                        <div class="card mt-1 mb-1">
                            <div class="card-body">
                                <h5 class="card-title">Compra ID <%= venta.IDVenta %> (<%= venta.Fecha.ToShortDateString() %>)</h5>
                                <div class="row">

                                    <div class="col-md-2 me-5">
                                        <div id="carouselCompra<%= venta.IDVenta %>" class="carousel slide">
                                            <div class="carousel-inner">
                                                <%for (int i = 0; i < venta.Factura.Productos.Count; i++)
                                                    { %>

                                                <div class="carousel-item <%= (i == 0) ? "active" : "" %>">
                                                    <a href="#" data-bs-toggle="modal" data-bs-target="#modalImagen" data-bs-img='<%= venta.Factura.Productos[i].Producto.Imagenes.FirstOrDefault().Url %>'>
                                                        <img src="<%= venta.Factura.Productos[i].Producto.Imagenes.FirstOrDefault().Url %>" class="d-block w-100" alt="imagen producto">
                                                    </a>
                                                </div>
                                                <% }%>
                                            </div>
                                            <a class="carousel-control-prev" href="#carouselCompra<%= venta.IDVenta %>" role="button" data-bs-slide="prev">
                                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                                <span class="visually-hidden">Previous</span>
                                            </a>
                                            <a class="carousel-control-next" href="#carouselCompra<%= venta.IDVenta %>" role="button" data-bs-slide="next">
                                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                                <span class="visually-hidden">Next</span>
                                            </a>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <ul class="list-group">
                                            <li class="list-group-item">
                                                <h6>Productos</h6>
                                                <%foreach (Dominio.ElementoCarrito elemento in venta.Factura.Productos)
                                                    { %>
                                                <p><%= elemento.Producto.Nombre %></p>
                                                <%}  %>
                                            </li>
                                        </ul>
                                    </div>

                                    <div class="col-md-4">
                                        <ul class="list-group">
                                            <li class="list-group-item">
                                                <p><span class="fw-medium">Fecha: </span><%= venta.Fecha.ToShortDateString() %></p>
                                                <p class="fw-bolder <%= (venta.Estado.Estado == "ENVIADO" || venta.Estado.Estado == "ENTREGADO") ? "bg-success" : (venta.Estado.Estado == "PAGO PENDIENTE") ? "bg-danger bg-opacity-75" : (venta.Estado.Estado == "CANCELADO") ? "bg-danger" : (venta.Estado.Estado == "PAGADO") ? "bg-success-subtle" : "" %>"><span class="fw-medium">Estado: </span><%= venta.Estado.Estado %></p>
                                                <% if (venta.Estado.Estado == "PAGADO")
                                                    {  %>
                                                <p><span class="fw-medium">Codigo Pago: </span><%= venta.CodigoPago  %></p>
                                                <% }
                                                    else if (venta.Estado.Estado == "ENVIADO")
                                                    { %>
                                                <p><span class="fw-medium">Codigo Pago: </span><%= venta.CodigoPago  %></p>
                                                <p><span class="fw-medium">Codigo Seguimiento: </span><%= venta.CodigoSeguimiento %></p>
                                                <% } %>


                                                <p><span class="fw-medium">Destino: </span><%= venta.Usuario.Domicilios[0].Calle  %> <%= venta.Usuario.Domicilios[0].Altura  %></p>
                                                <p><span class="fw-medium">Precio Total: </span>$<%= Math.Round(venta.Monto, 2) %></p>
                                            </li>
                                        </ul>
                                    </div>

                                    <div class="col-md-2">
                                        <a href="ControlVenta.aspx?Id=<%= venta.IDVenta %>" class="btn btn-primary"><%= venta.Estado.Estado == "CANCELADO" || venta.Estado.Estado == "ENTREGADO" ? "Detalle" : venta.Estado.Estado == "PAGO PENDIENTE" ? "Pagar" : "Seguimiento" %></a>
                                        <a href="ControlVenta.aspx?Id=<%= venta.IDVenta %>" class="btn btn-primary mt-2">Ayuda en linea</a
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>



                <% }%>
                <% }
                    else
                    { %>
                <p>No has realizado ninguna compra</p>
                <a href="Index.aspx" class="btn btn-primary">Ir a comprar</a>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>
