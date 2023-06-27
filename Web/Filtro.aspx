<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Filtro.aspx.cs" Inherits="Web.Filtro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/home.css" rel="stylesheet" />

    <main class="bg-light">
        <h3 class="section-title display-4 text-center text-muted letter-spacing"><asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></h3>
        <section class="container-fluid mt-5">

            <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
                <asp:Repeater ID="RepFiltro" runat="server">
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
        </section>

        <div class="row my-5"></div>
                <!--CARDS PRODUCTOS SUGERIDOS-->
        <section class="container-fluid section-productos">
            <div class="row">
                <div class="col">
                    <h2 class="section-title display-5 text-center text-muted letter-spacing">Otras sugerencias para vos</h2>
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
    </main>

</asp:Content>
