<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Web.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/formulario.css" rel="stylesheet" />

    <div class="container min-vh-100 mb-5">
        <div class="container form-container-xl">
            <h2 class="text-center mb-1" id="txtTitulo" runat="server"></h2>
            <div class="text-center m-4">
                <asp:Label ID="lblMessageError" runat="server" CssClass="alert alert-danger" role="alert" Visible="false"></asp:Label>
                <asp:Label ID="lblMessageOk" runat="server" CssClass="alert alert-success" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="text-center m-4">
                <asp:Label ID="lblMessageRedirect" runat="server" CssClass="alert- alert-info" role="alert" Visible="false"></asp:Label>
            </div>

            <div class="row">
                <div class="col-md-5 me-5">
                    <div class="row">
                        <label for="txtNombre" class="form-label ">Nombre:</label>
                        <input type="text" id="txtNombre" runat="server" class="form-control" />
                    </div>
                    <div class="row">
                        <label for="txtCodigo" class="form-label">Codigo:</label>
                        <input type="text" id="txtCodigo" runat="server" class="form-control" />
                    </div>
                    <div class="row">
                        <label for="txtPrecio" class="form-label">Precio:</label>
                        <input type="number" id="txtPrecio" runat="server" class="form-control" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="text-center mb-2" visible="false">
                            <label for="txtDesc" class="form-label">Descripción:</label>
                            <textarea id="txtDesc" runat="server" class="form-control" rows="7" style="resize: none"></textarea>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-5 me-5">
                    <div class="row mb-1">
                        <label for="txtStcok" class="form-label">Stock:</label>
                        <input type="number" id="txtStock" runat="server" class="form-control" />
                    </div>
                    <div class="row mb-1">
                        <label class="form-label" runat="server" id="lblMarca"></label>
                        <asp:DropDownList CssClass="form-select" ID="DRPMarca" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="row mb-1">
                        <label class="form-label" runat="server" id="lblCategoria"></label>
                        <asp:DropDownList CssClass="form-select" ID="DRPCategoria" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="row">
                        <label class="form-label" runat="server" id="lblEstado"></label>
                        <asp:DropDownList CssClass="form-select" ID="DRPEstado" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="row mt-3">
                        <div class="ms-4 col-md-5">
                            <asp:Button ID="BtnAgrearImagen" Visible="false" runat="server" CssClass="btn btn-primary" Text="Agregar Imagenes" OnClick="BtnAgrearImagen_Click" />
                        </div>
                        <div class="col-md-5">
                            <asp:Button ID="BtnModificarImagen" Visible="false" runat="server" CssClass="btn btn-primary" Text="Modificar Imagenes" OnClick="BtnModificarImagen_Click" />
                        </div>
                    </div>

                </div>
                <div class="col-md-5 ms-5">
                    <div id="carouselProducto" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <%for (int i = 0; i < producto.Imagenes.Count; i++)
                                { %>

                            <div class="carousel-item <%= (i == 0) ? "active" : "" %>">
                                <a href="#" data-bs-toggle="modal" data-bs-target="#modalImagen" data-bs-img='<%=producto.Imagenes[i].Url %>'>
                                    <img src="<%= producto.Imagenes[i].Url %>" class="d-block w-100" alt="imagen producto">
                                </a>
                            </div>
                            <% }%>
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
            </div>


            <div class="col-md-3 mb-2">
                <div class="row">
                    <div class="text-center mt-2 mb-2">
                        <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success me-3" Text="" OnClick="btnAgregar_Click" />
                        <a href="Vendedor.aspx" class="btn btn-danger">Cancelar</a>
                    </div>
                </div>
            </div>
            <div class="col-md-6 mb-2">
                <div class="text-center mb-2" visible="false">


                    <label for="txtUrl" id="lblUrl" visible="false" class="form-label" runat="server">Url Imagen:</label>
                    <textarea id="txtUrl" visible="false" class="form-control" rows="5" style="resize: none" runat="server"></textarea>
                    <span id="txtInfo" visible="false" class="text-info" runat="server">*Para agregar más de una imagen separar por coma</span>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
