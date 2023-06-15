<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card-custom {
            border: none;
            transition: box-shadow 0.3s ease;
        }

        .card-custom-img {
            border: none;
        }

        .card-custom:hover {
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
        }

    </style>
    <%--INICIO MAIN--%>
    <main>

        <%--BANNER SLIDER--%>
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
                    <span class="carousel-control-prev-icon"  aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselMain" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </div>

         <div class="mb-4"></div> <!-- Márgen inferior entre secciones -->

        <%--CARDS PRODUCTOS--%>
        <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            <asp:Repeater ID="rptProductos" runat="server">
                <ItemTemplate>
                    <div class="col card-custom">
                        <div class="card mw-100 card-custom-img">
                            <a href="DetalleProducto.aspx?id=<%# ((Dominio.Producto)Container.DataItem).IDProducto %>">
                                <asp:Image CssClass="card-img-top" ID="imgProducto" runat="server" ImageUrl="<%#cargarImagen(((Dominio.Producto)Container.DataItem)) %>" onerror="this.src'https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'" />
                            </a>
                        </div>
                        <div class="card-description text-start text-dark">
                            <h5 class="card-text text-muted"><%# ((Dominio.Producto)Container.DataItem).Nombre %></h5>
                            <p class="text-muted small">$<%# Math.Round(((Dominio.Producto)Container.DataItem).Precio, 2) %></p>
                            <p class="text-muted small">3 cuotas de $<%# Math.Round((((Dominio.Producto)Container.DataItem).Precio / 3), 2)  %></p>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

         <div class="mb-4"></div> <!-- Márgen inferior entre secciones -->

        <%--CARDS CATEGORIAS--%>
        <div class="row row-cols-4">
            <asp:Repeater ID="rptCategorias" runat="server">
                <ItemTemplate>
                    <div class="col card-custom">
                        <div class="card mw-100 card-custom-img">
                            <div class="card-custom-img">
                                <asp:Image CssClass="card-img-top" ID="imgCategoria" runat="server" ImageUrl="<%# cargarImagenRandomCategoria(((Dominio.Categoria)Container.DataItem).ToString()) %>" onerror="this.src'https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'" />
                                <div class="card-text">
                                    <h4 class="card-title"><%# ((Dominio.Categoria)Container.DataItem).Nombre.ToUpper() %></h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
         <%--CARDS MARCAS--%>
        <div class="row row-cols-4">
            <asp:Repeater ID="rptMarcas" runat="server">
                <ItemTemplate>
                    <div class="col card-custom">
                        <div class="card mw-100 card-custom-img">
                            <div class="card-custom-img">
                                <asp:Image CssClass="card-img-top" ID="imgCategoria" runat="server" ImageUrl="<%# cargarImagenRandomCategoria(((Dominio.Marca)Container.DataItem).ToString()) %>" onerror="this.src'https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg'" />
                                <div class="card-text">
                                    <h4 class="card-title"><%# ((Dominio.Marca)Container.DataItem).Nombre.ToUpper() %></h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>



        <div class="mb-4"></div> <!-- Márgen inferior entre secciones -->


      





    </main>

</asp:Content>
