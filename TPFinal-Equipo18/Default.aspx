<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinal_Equipo18.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--CARRUSEL BANNERS--%>
    <div id="divCarouselBanners" runat="server" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <asp:Image ID="Image1" runat="server" ImageUrl="" class="d-block w-100" alt="..."/>
            </div>
            <div class="carousel-item">
                <asp:Image ID="Image2" runat="server" ImageUrl="" class="d-block w-100" alt="..."/>
            </div>
            <div class="carousel-item">
                <asp:Image ID="Image3" runat="server" ImageUrl="" class="d-block w-100" alt="..."/>
            </div>
            <div class="carousel-item">
                <asp:Image ID="Image4" runat="server" ImageUrl="" class="d-block w-100" alt="..."/>
            </div>
            <div class="carousel-item">
                <asp:Image ID="Image5" runat="server" ImageUrl="" class="d-block w-100" alt="..."/>
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
