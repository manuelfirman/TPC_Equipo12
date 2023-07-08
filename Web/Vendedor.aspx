<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Vendedor.aspx.cs" Inherits="Web.Vendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["Usuario"] == null || ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre != "Vendedor" && (((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre != "Admin"))
        { %>
    <% Response.Redirect("404.aspx"); %>
    <!-- REDIRECCION SI NO TIENE PERMISOS -->
    <% }
        else
        { %>

    <main class="bg-dark">
        <div class="container-fluid">
            <h1 class="text-light">ADMINISTRAR TIENDA</h1>
        </div>

        <div class="container-fluid mt-5">
            <div class="row justify-content-center align-items-center d-flex">

                <div class="col-md-4">
                    <div class="card bg-success-subtle mb-5 p-3">
                        <div class="card-body">
                            <h2 class="text-dark mt-2">PRODUCTOS</h2>
                            <div class="row">
                                <div class="card mb-2">
                                    <div class="card-body">
                                        <h5 class="card-title">AGREGAR PRODUCTO</h5>
                                        <p class="card-text">Agrega un nuevo producto</p>
                                        <a href="Productos.aspx?Tipo=Agregar" class="btn btn-primary">Agregar</a>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">MODIFICAR PRODUCTO</h5>
                                        <div class="form-group">
                                            <label class="mb-3" for="ddlProductos">Seleccionar Producto:</label>
                                            <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control mb-3">
                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="BtnModificarProducto" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="BtnModificarProducto_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card bg-info mb-5 p-3">
                        <div class="card-body">
                            <h2 class="text-light mt-2">MARCAS</h2>
                            <div class="row">
                                <div class="card mb-2">
                                    <div class="card-body">
                                        <h5 class="card-title">AGREGAR MARCA</h5>
                                        <p class="card-text">Agrega una nueva marca</p>
                                        <a href="Marcas.aspx?Tipo=Agregar" class="btn btn-primary">Agregar</a>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">MODIFICAR MARCA</h5>
                                        <div class="form-group">
                                            <label class="mb-3" for="ddlMarcas">Seleccionar Marca:</label>
                                            <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-control mb-3">
                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="BtnModificarMarca" runat="server" Text="Seleccionar" CssClass="btn btn-primary mb-1" OnClick="BtnModificarMarca_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card bg-warning-subtle mb-5 p-3">
                        <div class="card-body">
                            <h2 class="text-dark mt-2">CATEGORÍAS</h2>
                            <div class="row">
                                <div class="card mb-2">
                                    <div class="card-body">
                                        <h5 class="card-title">AGREGAR CATEGORÍA</h5>
                                        <p class="card-text">Agrega una nueva categoría</p>
                                        <a href="Categorias.aspx?Tipo=Agregar" class="btn btn-primary">Agregar</a>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <h4>Modificar Categoría</h4>
                                            <label class="mb-3" for="ddlCategorias">Seleccionar Categoría:</label>
                                            <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control mb-3">
                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="BtnModificarCategoria" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="BtnModificarCategoria_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row justify-content-center align-items-center">
                    <div class="col-md-4 mb-5">
                        <div class="card p-3 bg-black">
                            <h2 class="text-light mt-2">GESTIONAR VENTAS</h2>
                            <div class="card-body mt-4">
                                <div class="form-group">
                                    <a href="Ventas.aspx" class="btn btn-outline-light mb-3">Ventas</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8 mb-5">
                        <div class="card p-1 bg-black">
                            <h2 class="text-light mt-3 ms-2">FILTRAR</h2>
                            <div class="card-body">
                                <div class="form-group">
                                    <asp:TextBox placeholder="Ejemplo: Remera" CssClass="form-control me-2 mb-3" ID="txtbusqueda" runat="server"></asp:TextBox>
                                    <asp:Button ID="BtnBusqueda" CssClass="btn btn-outline-light" runat="server" Text="Buscar" OnClick="BtnBusqueda_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>



            </div>
        </div>
        <% } %>
    </main>

</asp:Content>
