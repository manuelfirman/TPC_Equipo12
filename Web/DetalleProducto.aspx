<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Web.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <asp:Label ID="lblError" CssClass="h1 d-flex justify-content-center text-white" runat="server" Text=""></asp:Label>

        <section>
            <div class="container">
                <div class="row">
                    <div class="col-md-8">

                        <%--CARRUSEL--%>
                        <div id="carouselProducto" class="carousel slide" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <asp:Repeater ID="rptImagenes" runat="server">
                                    <ItemTemplate>
                                        <div class="carousel-item <%# (Container.ItemIndex == 0) ? "active" : "" %>">
                                            <asp:Image ID="imgProducto" runat="server" CssClass="d-block w-100" ImageUrl='<%# Eval("Url") %>' />
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
                    <%--DETALLES PRODUCTO--%>
                    <div class="col-md-4">
                        <div class="product-details">
                            <h2><%= producto.Nombre %></h2>
                            <div class="product-info">
                                <p>Precio: $<%= producto.Precio %></p>
                                <p>Disponibilidad: <%= producto.Stock %> unidades</p>
                                <!-- Otras especificaciones -->
                            </div>
                            <p class="description"><%= producto.Descripcion %></p>
                            <div class="product-actions">
                                <asp:Button ID="Button1" runat="server" Text="Me lo llevo!" OnClick="btnAgregarCarrito_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>

                    <%--<div class="col-md-4">
                        <div class="col-md-4">
                            <h2>Nombre del Producto</h2>
                            <p>Descripción del producto</p>
                            <p>Precio: $XX</p>
                            <p>Disponibilidad: XX unidades</p>

                            <!-- Agrega aquí otros detalles del producto, como características, especificaciones, etc. -->

                            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al Carrito" OnClick="btnAgregarCarrito_Click" CssClass="btn btn-primary" />
                            <asp:Button ID="btnComprarAhora" runat="server" Text="Comprar Ahora" OnClick="btnComprarAhora_Click" CssClass="btn btn-success" />
                        </div>
                    </div>--%>
                </div>
            </div>
        </section>











    </main>



</asp:Content>
