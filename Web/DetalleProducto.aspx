﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Web.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .thumbnail-gallery {
            display: flex;
            flex-direction: column;
            align-items: flex-start;
            max-height: 100%; /* altura maxima galeria de miniaturas */
            overflow-y: auto; /* desplazamiento vertical si las miniaturas exceden la altura maxima*/
        }

        .thumbnail-item {
            margin-bottom: 10px; /* espacio entre miniaturas */
        }

        .img-thumbnail {
            max-height: 100px; /* altura máxima para las miniaturas */
            object-fit: contain; /* ajusta imagen dentro del contenedor */
        }
    </style>
    
    <main>
        <asp:Label ID="lblError" CssClass="h1 d-flex justify-content-center text-white" runat="server" Text=""></asp:Label>



        <section>
            <div class="container">
                <div class="row my-5"></div>
                <div class="row my-5"></div>
                <div class="row my-5">

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

                    <!-- Imagen principal -->
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
                                <h2 class="card-title"><%= producto.Nombre %></h2>
                                <!-- Calificacion -->
                                <div class="rating mb-3">
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star-half-o"></i>
                                </div>
                                <!-- Info producto -->
                                <div class="card-body">
                                    <p class="letter-spacing display-4 text-success text-opacity-75 fw-lighter">$<%= producto.Precio %></p>
                                    <p class="text-muted ms-4">o 12 cuotas de $<%= Math.Round(((producto.Precio / 12) * (decimal)1.15), 2) %></p>
                                </div>
                                <div class="card-body product-info mb-3">
                                    <p class="card-text"><span class="fw-bold">Disponibilidad:</span> <%= producto.Stock %> unidades</p>
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
                                        <p><%= producto.Descripcion %></p>
                                    </li>
                                    <li class="list-group-item">
                                        <h5>Detalles producto</h5>
                                        <p>Marca: <%=producto.Marca.Nombre %></p>
                                        <p>Categoria: <%=producto.Categoria.Nombre %></p>
                                        <p>Codigo: <%=producto.Codigo %></p>
                                    </li>
                                    <li class="list-group-item">
                                        <h5>Característica 3</h5>
                                        <p>Descripción de la característica 3</p>
                                    </li>
                                    <!-- agregar -->
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row my-5"></div>

            <!-- COMENTARIOS -->
            <div class="container-fluid my-4">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Comentarios</h3>
                        <div class="card-body">
                            <asp:Repeater ID="rptComments" runat="server">
                                <ItemTemplate>
                                    <div class="bg-dark bg-opacity-25">
                                        <h5><%# Eval("Nombre") %></h5>
                                        <p><%# Eval("Descripcion") %></p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>


                        <div class="card-body">
                            <h3>Hacer un comentario:</h3>
                            <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                            <%--<asp:Button ID="" runat="server" Text="Enviar Comentario" OnClick="" CssClass="btn btn-primary" />--%>
                        </div>
                    </div>
                </div>
            </div>


        </section>


        <!-- Modal de imagen -->
        <div class="modal fade" id="modalImagen" tabindex="-1" aria-labelledby="modalImagenLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-lg">
                <div class="modal-content">
                    <div class="modal-body">
                        <img id="imgModal" class="d-block mx-auto img-fluid" />
                    </div>
                </div>
            </div>
        </div>
        <script>
            // Obtener la imagen seleccionada y mostrarla en el modal
            var modalImagen = document.getElementById('modalImagen');
            var imgModal = document.getElementById('imgModal');

            modalImagen.addEventListener('show.bs.modal', function (event) {
                var trigger = event.relatedTarget; // Elemento que activó el modal
                var imgUrl = trigger.getAttribute('data-bs-img'); // Obtener la URL de la imagen

                // Mostrar la imagen en el modal
                imgModal.src = imgUrl;
            });

        </script>






    </main>



</asp:Content>
