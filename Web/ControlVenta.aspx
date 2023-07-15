<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ControlVenta.aspx.cs" Inherits="Web.ControlVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container min-vh-100">
        <div class="card">
            <div class="card-body">
                <h1 class="card-title">Compra ID <%= Compra.IDVenta %> - (<%= Compra.Fecha.ToShortDateString() %>)</h1>

                <div class="card mt-1 mb-1">
                    <div class="card-body">
                        <div class="row">

                            <div class="col-md-3 me-5">
                                <div id="carouselCompra<%= Compra.IDVenta %>" class="carousel slide">
                                    <div class="carousel-inner">
                                        <%for (int i = 0; i < Compra.Factura.Productos.Count; i++)
                                            { %>

                                        <div class="carousel-item <%= (i == 0) ? "active" : "" %>">
                                            <a href="#" data-bs-toggle="modal" data-bs-target="#modalImagen" data-bs-img='<%= Compra.Factura.Productos[i].Producto.Imagenes.FirstOrDefault().Url %>'>
                                                <img src="<%= Compra.Factura.Productos[i].Producto.Imagenes.FirstOrDefault().Url %>" class="d-block w-100" alt="imagen producto">
                                            </a>
                                        </div>
                                        <% }%>
                                    </div>
                                    <a class="carousel-control-prev" href="#carouselCompra<%= Compra.IDVenta %>" role="button" data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#carouselCompra<%= Compra.IDVenta %>" role="button" data-bs-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Next</span>
                                    </a>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <ul class="list-group">
                                    <li class="list-group-item">
                                        <h6>Productos</h6>
                                        <%foreach (Dominio.ElementoCarrito elemento in Compra.Factura.Productos)
                                            { %>
                                        <p><%= elemento.Producto.Nombre %></p>
                                        <%}  %>
                                    </li>
                                </ul>
                            </div>

                            <div class="col-md-4">
                                <ul class="list-group">
                                    <li class="list-group-item">
                                        <p><span class="fw-medium">Fecha: </span><%= Compra.Fecha.ToShortDateString() %></p>
                                        <p class="fw-bolder <%= (Compra.Estado.Estado == "ENVIADO" || Compra.Estado.Estado == "ENTREGADO") ? "bg-success" : (Compra.Estado.Estado == "PAGO PENDIENTE") ? "bg-danger bg-opacity-75" : (Compra.Estado.Estado == "CANCELADO") ? "bg-danger" : (Compra.Estado.Estado == "PAGADO") ? "bg-success-subtle" : "" %>"><span class="fw-medium">Estado: </span><%= Compra.Estado.Estado %></p>
                                        <p><span class="fw-medium">Destino: </span><%= Compra.Usuario.Domicilios[0].Calle  %> <%= Compra.Usuario.Domicilios[0].Altura  %></p>
                                        <p><span class="fw-medium">Precio Total: </span>$<%= Math.Round(Compra.Monto, 2) %></p>
                                    </li>
                                </ul>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>


        <%if (Compra.Estado.Estado == "CANCELADO")
            {  %>
        <div class="card bg-danger">
            <div class="card-body">
                <h2 class="card-title">PEDIDO CANCELADO</h2>
            </div>
        </div>
        <%} %>

        <%if (Compra.Estado.Estado == "PAGO PENDIENTE")
            {  %>
        <div class="card bg-danger bg-opacity-75">
            <div class="card-body">

                <h2 class="card-title text-white">NO HAS PAGADO TU PEDIDO</h2>
                <div class="card col-md-6 p-4 mb-2">
                    <p>No pierdas la oportunidad de adquirir nuestras ofertas!</p>
                </div>
                <asp:Button ID="btnPagar" runat="server" Text="Ir a Pagar" CssClass="btn btn-primary" OnClick="btnPagar_Click1" />
            </div>
        </div>
        <%} %>

        <%if (Compra.Estado.Estado == "PAGADO")
            {  %>
        <div class="card bg-success mt-2">
            <div class="card-body">
                <h2 class="card-title text-white">RECIBIMOS EL PAGO DE TU PEDIDO</h2>
                <div class="card col-md-6 p-4 mb-2">
                    <p>Te avisaremos cuando haya sido enviado</p>
                    <p><span class="fw-medium">Codigo Pago: </span><%= Compra.CodigoPago  %></p>
                </div>
            </div>
        </div>
        <%} %>

        <%if (Compra.Estado.Estado == "ENVIADO")
            {  %>
        <div class="card bg-success mt-2">
            <div class="card-body">
                <h2 class="card-title text-white">RECIBIMOS EL PAGO DE TU PEDIDO!</h2>
                <div class="card col-md-6 p-4 mb-2">
                    <p>Pagaste con <span class="fw-medium"><%= Compra.TipoPago  %></span></p>
                    <p><span class="fw-medium">Codigo Pago: </span><%= Compra.CodigoPago  %></p>

                </div>
            </div>
        </div>

        <div class="card bg-success mt-2">
            <div class="card-body">
                <h2 class="card-title text-white">TU PEDIDO YA HA SIDO ENVIADO!</h2>
                <div class="card col-md-6 p-4 mb-2">
                    <p><span class="fw-medium">Fecha de Envio: </span><%= Compra.FechaEnvio  %></p>
                    <p>Te lo enviamos a <span class="fw-medium"><%=Compra.Usuario.Domicilios[0].Calle  %> <%=Compra.Usuario.Domicilios[0].Altura  %>, <%=Compra.Usuario.Domicilios[0].Localidad  %> - <%=Compra.Usuario.Domicilios[0].Provincia  %></span></p>
                    <p><span class="fw-medium">Codigo de Seguimiento: </span><%= Compra.CodigoSeguimiento %></p>
                </div>
            </div>
        </div>
        <%} %>

        <%if (Compra.Estado.Estado == "ENTREGADO")
            {  %>
        <div class="card bg-success mt-2">
            <div class="card-body">
                <h2 class="card-title text-white">TU PEDIDO YA HA SIDO ENVIADO!</h2>
                <div class="card col-md-6 p-4 mb-2">

                    <p>Te lo enviamos a <span class="fw-medium"><%=Compra.Usuario.Domicilios[0].Calle  %> <%=Compra.Usuario.Domicilios[0].Altura  %>, <%=Compra.Usuario.Domicilios[0].Localidad  %> - <%=Compra.Usuario.Domicilios[0].Provincia  %></span></p>
                    <p><span class="fw-medium">Codigo de Seguimiento: </span><%= Compra.CodigoSeguimiento %></p>
                </div>
            </div>
        </div>
        <%} %>

        <div class="card mt-2 mb-5">
            <div class="row">
                <div class="col-md-6">
                    <div class="card-body">
                        <h4 class="card-title">Ayuda en línea</h4>
                        <div class="row mx-3">
                            <div class="col-md-12">
                                <div class="card-body">

                                    <div class="card mb-3 p-1 bg-dark">
                                        <% foreach (Dominio.Chat mensaje in Mensajes)
                                            { %>
                                        <div class="card mb-2 p-2">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <h5 class="card-title <%= mensaje.Remitente.TipoUser.Nombre == "Vendedor" || mensaje.Remitente.TipoUser.Nombre == "Admin" ? "bg-danger text-white fw-bold" : "" %>"><%= mensaje.Remitente.TipoUser.Nombre == "Usuario" ? "Tu" : $"Vendedor {mensaje.Remitente.Nombre}"%></h5>
                                                </div>
                                                <div class="col-md-6">
                                                    <p class="card-text"><small class="text-muted"><%= mensaje.Fecha %></small></p>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <p class="card-text"><%= mensaje.Mensaje %></p>
                                            </div>
                                        </div>

                                        <% }%>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <%if (Session["Usuario"] != null)
                            { %>
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-body">
                                    <h6 class="card-title">¿En que podemos ayudarte?</h6>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    </div>
                                    <div class="d-flex justify-content-between align-items-center">
                                        <div>
                                            <asp:Button ID="BtnComentar" runat="server" Text="Enviar" OnClick="BtnComentar_Click" CssClass="btn btn-primary mt-2" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%} %>
                    </div>
                </div>

                <div class="col-md-6 p-4">
                    <h6 class="card-title mx-4 mt-3">Estamos para ayudarte</h6>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
