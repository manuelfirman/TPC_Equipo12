<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Filtro.aspx.cs" Inherits="Web.Filtro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/home.css" rel="stylesheet" />

    <main class="bg-light">
        <h3 class="section-title display-4 text-center text-muted letter-spacing">
            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></h3>
        <section class="container-fluid mt-5">

            <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
                <asp:Repeater ID="RepFiltro" runat="server">
                    <ItemTemplate>
                        <div class="col card-custom">
                            <%if ((Session["Usuario"] != null && (((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Admin") || ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Vendedor"))))
                                { %>
                            <div>
                                <asp:Button ID="BtnEditar" runat="server" CssClass="btn btn-sm btn-primary" Text='Editar' CommandName="Editar" CommandArgument='<%# Eval("IDProducto") %>' OnCommand="BotonEditarProducto" />
                                <button type="button" class="btn btn-sm btn-danger" data-bs-toggle="modal" data-bs-target="#confirmarModal">Eliminar</button>


                                <!-- Modal de confirmación -->
                                <div class="modal fade" id="confirmarModal" tabindex="-1" role="dialog" aria-labelledby="confirmarModalLabel"
                                    aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="confirmarModalLabel">Confirmar eliminación</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                ¿Estás seguro de que deseas eliminar este producto?
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                                                <asp:Button ID="btnConfirmarEliminar" runat="server" CssClass="btn btn-danger"
                                                    Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# ((Dominio.Producto)Container.DataItem).IDProducto %>'
                                                    OnCommand="BotonEditarProducto" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%} %>

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
        <%if ((Session["Usuario"] == null || (((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre == "Usuario"))))
            { %>
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
        <% } %>

        <!-- Modal Eliminar -->
       

    </main>

</asp:Content>
