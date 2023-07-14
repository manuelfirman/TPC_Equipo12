<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Web.DetalleProducto" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <asp:Label ID="lblError" CssClass="h1 d-flex justify-content-center text-white" runat="server" Text=""></asp:Label>



        <section>
            <div class="container">
                <div class="row my-5"></div>
                <div class="row my-5">
                    <%if ((Session["Usuario"] != null && (((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Admin") || ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Vendedor"))))
                        { %>
                    <div>
                        <asp:Button ID="BtnEditar" runat="server" CssClass="btn btn-sm btn-primary" Text='Editar' CommandName="Editar" CommandArgument='<%# Producto.IDProducto %>' OnCommand="BotonEditarProducto" />
                    </div>
                    <%} %>
                    
                    <div class="col-md-2">
                        <div class="thumbnail-gallery">
                            <asp:Repeater ID="rptMiniaturas" runat="server">
                                <ItemTemplate>
                                    <div class="thumbnail-item">
                                        <a href="#" data-bs-target="#modalImagen" data-bs-toggle="modal" data-bs-img='<%# Eval("Url") %>'>
                                            <asp:Image ID="imgMiniatura" runat="server" CssClass="img-thumbnail" ImageUrl='<%# Eval("Url") %>' />
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <!-- IMAGEN PRINCIPAL -->
                    <div class="col-md-6">
                        <div id="carouselProducto" class="carousel slide" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <asp:Repeater ID="rptImagenes" runat="server">
                                    <ItemTemplate>
                                        <div class="carousel-item <%# (Container.ItemIndex == 0) ? "active" : "" %>">
                                            <a href="#" data-bs-toggle="modal" data-bs-target="#modalImagen" data-bs-img='<%# Eval("Url") %>'>
                                                <asp:Image ID="imgProducto" runat="server" CssClass="d-block w-100" ImageUrl='<%# Eval("Url") %>' />
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
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


                    <!--CARD DETALLES PRODUCTO-->
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-body">
                                <h2 class="card-title"><%= Producto.Nombre %></h2>
                                <!-- Calificacion -->
                                <div class="rating mb-3">
                                    <i class="fa fa-star" style="color: lightblue"></i>
                                    <i class="fa fa-star" style="color: lightblue"></i>
                                    <i class="fa fa-star" style="color: lightblue"></i>
                                    <i class="fa fa-star" style="color: lightblue"></i>
                                    <i class="fa fa-star-half-o" style="color: lightblue"></i>
                                </div>
                                <!-- Info producto -->
                                <div class="card-body">
                                    <p class="letter-spacing display-4 text-success text-opacity-75 fw-lighter">$<%= Math.Round(Producto.Precio, 2) %></p>
                                    <p class="text-muted ms-4">o 12 cuotas de $<%= Math.Round(((Producto.Precio / 12) * (decimal)1.15), 2) %></p>
                                </div>
                                <div class="card-body">
                                    <asp:Button ID="BtnAgregarCarrito" CssClass="btn btn-outline-info" OnClick="BtnAgregarCarrito_Click"  runat="server" Text="Me lo llevo!" />
                                </div>

                                <div class="card-body product-info mb-3">
                                    <p class="card-text"><span class="fw-bold">Disponibilidad:</span> <%= Producto.Stock %> unidades</p>
                                </div>
                                <!-- Info envio -->
                                <div class="card-body shipping-info text-bg-light mb-3">
                                    <p><i class="fa fa-truck text-opacity-75 text-success-emphasis"></i><span class="ms-2"></span>Envío gratis</p>
                                    <p><i class="fa fa-clock-o"></i><span class="ms-2"></span>Entrega en 2-3 días</p>
                                </div>
                                <!-- Info metodos de pago -->
                                <div class="card-body payment-info text-bg-light mb-3">
                                    <p><i class="fa fa-credit-card"></i><span class="ms-2"></span>Aceptamos tarjetas de crédito</p>
                                    <p><i class="fa fa-paypal"></i><span class="ms-2"></span>Pago seguro con PayPal</p>
                                    <a href="#" class="payment-link text-small">Ver formas de pago</a>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
            </div>

            <div class="row my-5"></div>

            <!-- CARACTERISTICAS PRODUCTO -->
            <div class="container">
                <div class="row my-4">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-body">
                                <h3 class="card-title">Características del producto</h3>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item">
                                        <h5>Descripcion</h5>
                                        <p><%= Producto.Descripcion %></p>
                                    </li>
                                    <li class="list-group-item">
                                        <h5>Detalles producto</h5>
                                        <p>Marca: <%=Producto.Marca.Nombre %></p>
                                        <p>Categoria: <%=Producto.Categoria.Nombre %></p>
                                        <p>Codigo: <%=Producto.Codigo %></p>
                                    </li>

                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row my-2"></div>

            <!-- COMENTARIOS -->
            <div class="container my-4 bg-success-subtle p-4">
                <div class="row mx-3">
                    <div class="col-md-12">
                        <h3>Comentarios</h3>
                        <div class="card-body">
                            <asp:Repeater ID="rptComments" runat="server">
                                <ItemTemplate>
                                    <div class="card mb-3">
                                        <div class="card-body">

                                            <%--<div class="d-flex justify-content-between align-items-center">--%>
                                                <div class="row">
                                                <div class="col-md-2">
                                                    <h5 class="card-title"><%# Eval("NombreUsuario") %></h5>
                                                </div>
                                                <div class="col-md-2">
                                                    <p class="card-text"><small class="text-muted"><%# Eval("Fecha") %></small></p>
                                                </div>
                                                </div>
                                                <div class="row">
                                                    <p class="card-text"><%# Eval("TextoComentario") %></p>
                                                </div>
                                                <%if (((Dominio.Usuario)Session["Usuario"]) != null && ((Dominio.Usuario)Session["Usuario"]).TipoUser.IDTipo != 1 ) { %>
                                                <div>
                                                    <asp:Button ID="BtnBorrarComentario" runat="server" Text="x" OnClick="BtnBorrarComentario_Click" CssClass="btn btn-danger btn-sm"  CommandArgument='<%# ((Dominio.Comentario)Container.DataItem).IDComentario %>'/>
                                                </div>
                                                <%} %>
                                            <%--</div>--%>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <%if (Session["Usuario"] != null) { %>
                        <div class="col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <h3 class="card-title">Hacer un comentario:</h3>
                                <div class="form-group">
                                    <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                                <div class="d-flex justify-content-between align-items-center">
                                    <div>
                                        <asp:Button ID="BtnComentar" runat="server" Text="Enviar Comentario" OnClienClick="guardarPosicionVentana()" OnClick="BtnComentar_Click" CssClass="btn btn-primary mt-2" />
                                    </div>
                                    <div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                        <%} %>
                    </div>
                </div>
            </div>
        </section>
        <div class="row my-5"></div>
        
        <!--CARDS PRODUCTOS SUGERIDOS-->
        <section class="container section-productos">
            <div class="row">
                <div class="col">
                    <h2 class="section-title display-4 text-center text-muted letter-spacing">Otras sugerencias para vos</h2>
                </div>
            </div>
            <div class="row row-cols-1 row-cols-md-2 row-cols-lg-4 g-4">
                <asp:Repeater ID="rptProductos" runat="server">
                    <ItemTemplate>
                        <div class="col card-custom">
                            <div class="card mw-100 card-custom-img">
                                <a href="DetalleProducto.aspx?id=<%# ((Dominio.Producto)Container.DataItem).IDProducto %>">
                                    <asp:Image CssClass="card-img-top" ID="imgProducto" runat="server" ImageUrl="<%#CargarImagen(((Dominio.Producto)Container.DataItem)) %>" onerror="this.src'https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'" />
                                </a>
                            </div>
                            <div class="card-description text-center text-dark">
                                <h5 class="card-text text-muted"><%# ((Dominio.Producto)Container.DataItem).Nombre %></h5>
                                <p class="card-text text-muted">$<%# Math.Round(((Dominio.Producto)Container.DataItem).Precio, 2) %></p>
                                <p class="text-muted small">3 cuotas de $<%# Math.Round((((Dominio.Producto)Container.DataItem).Precio / 3), 2)  %></p>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="row my-5"></div>
        </section>



        <!-- MODAL DE IMAGEN -->
        <div class="modal fade" id="modalImagen" tabindex="-1" aria-labelledby="modalImagenLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-lg">
                <div class="modal-content">
                    <div class="modal-body">
                        <img id="imgModal" src="/" class="d-block mx-auto img-fluid" />
                    </div>
                </div>
            </div>
        </div>

        <script src="Scripts/modalDetalle.js"></script>
        <script src="Scripts/scrollPosition.js"></script>
    </main>
</asp:Content>
