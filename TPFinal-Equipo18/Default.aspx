﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinal_Equipo18.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--CARRUSEL BANNERS--%>
    <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://img.freepik.com/vector-gratis/banner-horizontal-viernes-negro-moderno-fondo-trazo-pincel-blanco_1361-3703.jpg?w=2000" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="data:image/jpeg;base64,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" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAWQGs9dtFh16Mr4k4L0nAuL7tdzQG_OT9t5poFFBigmqNKVRM71gA2mcscqgYpnrLqg&usqp=CAU" class="d-block w-100" alt="...">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <div class="container p-3">
        <h2 class="p-3 fs-1">Nuestros Productos</h2>
        <div class="row row-cols-1 row-cols-md-3 g-4 border-top">

            <%-- Leo los articulos --%>
            <%if (listaBebidas == null)
                {
                    if (Session["artFiltrado"] != null)
                    {
                        listaBebidas = (List<Dominio.Bebida>)Session["artFiltrado"];
                    }
                    else
                    {
                        listaBebidas = (List<Dominio.Bebida>)Session["listaBebidas"];
                    }
                }  %>
            <% foreach (Dominio.Bebida bebida in listaBebidas)
                {
                    if (bebida.Estado == true)
                    {
            %>


            <div class="col">
                <%-- Cargo las tarjetas --%>
                <div class="card text-bg-dark text-center border-primary border-2 border-opacity-75 h-100">
                    <div class="img-container bg-white">
                        <img src="<%:bebida.UrlImg %>" id="img_Card" class="object-fit-scale" alt="img articulo">
                    </div>
                    <div class="card-body">
                        <h5 class="card-title fs-3"><%:bebida.Nombre%></h5>
                        <p class="card-text"><%: bebida.Descripcion %></p>
                        <a href="DetalleBebida.aspx?Id= <%: bebida.Id %>" class="btn btn-outline-primary">Ver detalle </a>
                        <%-- Redirecciono a la misma pagina para quedarme con el id --%>
                        <a href="Default.aspx?Id= <%: bebida.Id %>" class="btn btn-outline-success">Añadir al carrito </a>
                    </div>
                </div>
            </div>
            <%  }
                } %>
        </div>

    </div>


</asp:Content>
