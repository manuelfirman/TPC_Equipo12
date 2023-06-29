<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Vendedor.aspx.cs" Inherits="Web.Vendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["Usuario"] == null || ((((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre != "Vendedor" && (((Dominio.Usuario)Session["Usuario"])).TipoUser.Nombre != "Admin"))
                { %>
    <% Response.Redirect("404.aspx"); %> <!-- REDIRECCION SI NO TIENE PERMISOS -->
    <% }
        else
        { %>

    <h1>Panel de Administración - Vendedor</h1>

    <div class="container">
        <h2 class="mt-4">Agregar:</h2>

        <div class="row">
            <div class="col-md-4">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Marcas</h5>
                        <p class="card-text">Agrega una nueva marca</p>
                        <a href="Marcas.aspx?Tipo=Agregar" class="btn btn-primary">Agregar</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Categorías</h5>
                        <p class="card-text">Agrega una nueva categoría</p>
                        <a href="Categorias.aspx?Tipo=Agregar" class="btn btn-primary">Agregar</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Productos</h5>
                        <p class="card-text">Agrega un nuevo producto</p>
                        <a href="Productos.aspx?Tipo=Agregar" class="btn btn-primary">Agregar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-12 mb-5">
                <div class="form-group">
                    <h4>Modificar Marca</h4>
                    <label class="mb-1" for="ddlMarcas">Seleccionar Marca:</label>
                    <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-control mb-1">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="BtnModificarMarca" runat="server" Text="Seleccionar" CssClass="btn btn-primary mb-1" OnClick="BtnModificarMarca_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 mb-5">
                <div class="form-group">
                    <h4>Modificar Categoría</h4>
                    <label for="ddlCategorias">Seleccionar Categoría:</label>
                    <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="BtnModificarCategoria" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="BtnModificarCategoria_Click" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 mb-5">
                <div class="form-group">
                    <h4>Modificar Producto</h4>
                    <label for="ddlProductos">Seleccionar Producto:</label>
                    <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control">
                         <asp:ListItem Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="BtnModificarProducto" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="BtnModificarProducto_Click" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 mb-5">
                <div class="form-group">
                    <h4>Buscar Producto</h4>
                    <asp:TextBox placeholder="Ejemplo: Celular" CssClass="form-control me-2" ID="txtbusqueda" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnBusqueda" CssClass="btn btn-outline-info" runat="server" Text="Buscar" OnClick="BtnBusqueda_Click" />
                </div>
            </div>
        </div>

    </div>

    <% } %>

</asp:Content>
