<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--INICIO MAIN--%>
    <main>
        <div class="container-fluid" style="margin:0;padding:0">
            <div id="carouselMain" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <asp:Repeater ID="rptSlider" runat="server">
                        <ItemTemplate>
                            <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>" style="height: 100vh;margin-top:-7vh;">
                                <img src="<%# Eval("Url") %>" class="d-block w-100 img-fluid" alt="<%# Eval("Descripcion") %>">
                                <div class="carousel-caption d-none d-md-block">
                                    <h3><%# Eval("Descripcion") %></h3>
                                    <p><%# Eval("Descripcion") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselMain" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselMain" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </div>


        <div class="mt-5 text-light text-center">
            <%--CARDS PRODUCTOS--%>
            <div class="mt-5"></div>
            <asp:Label ID="llbTitulo" CssClass="h3 d-flex justify-content-center text-white" runat="server" Text="PRODUCTOS"></asp:Label>
            <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
                <asp:Repeater ID="rptProductos" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card mw-100">
                                <div class="card-body">
                                    <asp:Image CssClass="card-img-top" ID="imgProducto" runat="server" ImageUrl="<%# cargarImagen(((Dominio.Producto)Container.DataItem)) %>" onerror="this.src'https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'" />
                                    <h4 class="card-title"><%# ((Dominio.Producto)Container.DataItem).Nombre %></h4>
                                    <p class="card-text"><%# ((Dominio.Producto)Container.DataItem).Descripcion %></p>
                                    <p class="card-text fw-semibold text-success display-6">$<%# Math.Round(((Dominio.Producto)Container.DataItem).Precio, 2) %></p>
                                    <a href="Detalle.aspx?id=<%# ((Dominio.Producto)Container.DataItem).IDProducto %>" class="btn btn-primary w-100 mb-1">Ver más</a>
                                    <asp:Button ID="btnAgregar" CssClass="btn btn-success w-100 mt-1" runat="server" Text="Agregar Carrito" OnClick="btnAgregar_Click" CommandArgument='<%# ((Dominio.Producto)Container.DataItem).IDProducto.ToString() %>' />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>





    </main>

</asp:Content>
