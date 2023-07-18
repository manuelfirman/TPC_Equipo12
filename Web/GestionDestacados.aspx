<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionDestacados.aspx.cs" Inherits="Web.GestionDestacados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main class="bg-dark">
        <div class="container-fluid">
            <h1 class="text-light">GESTION DE DESTACADOS</h1>
        </div>

        <div class="container-fluid mt-5">
            <div class="row justify-content-center align-items-center d-flex">

                <div class="col-md-4">
                    <div class="card bg-success-subtle mb-5 p-3">
                        <div class="card-body">
                            <h2 class="text-dark mt-2">CARROUSEL DE IMAGENES</h2>
                            <div class="row">
                                <div class="card mb-2">
                                    <div class="card-body">
                                        <h5 class="card-title">AGREGAR IMAGEN</h5>
                                        <p class="card-text">Agrega una nueva imagen al carrousel</p>
                                        <a href="Banners.aspx?Tipo=Agregar" class="btn btn-primary">Agregar</a>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">MODIFICAR IMAGEN</h5>
                                        <div class="form-group">
                                            <label class="mb-3" for="dllImagenes">Seleccionar Imagen :</label>
                                            <asp:DropDownList ID="dllImagenes" runat="server" CssClass="form-control mb-3">
                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="BtnModificarImagen" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="BtnModificarImagen_Click" />
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
                            <h2 class="text-light mt-2">PRODUCTOS DESTACADOS</h2>
                            <div class="row">
                                <div class="card mb-2">
                                    <div class="card-body">
                                        <h5 class="card-title">AGREGAR PRODUCTO DESTACADOS</h5>
                                        <p class="card-text">Agrega un nuevo producto</p>
                                        <a href="Marcas.aspx?Tipo=Agregar" class="btn btn-primary">Agregar</a>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">MODIFICAR PRODUCTO DESTACADOS</h5>
                                        <div class="form-group">
                                            <label class="mb-3" for="ddlProductos">Seleccionar Producto:</label>
                                            <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control mb-3">
                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="BtnModificarProducto" runat="server" Text="Seleccionar" CssClass="btn btn-primary mb-1" OnClick="BtnModificarProducto_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
