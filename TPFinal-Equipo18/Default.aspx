<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinal_Equipo18.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Listado de bebidas</h2>

    <div class="container">
        <div class="row row-cols-1 row-cols-md-3 g-4">

            <% foreach (Dominio.Bebida bebida in listaBebidas)
                {
                %>
                

             <div class="col">
                <%-- Cargo las tarjetas --%>
                <div class="card h-100">
                    <img src="<%:bebida.UrlImg %>" class="card-img-top" alt="img articulo">
                    <div class="card-body">
                        <h5 class="card-title"><%:bebida.Nombre%></h5>
                        <p class="card-text"><%: bebida.Descripcion %></p>
                        <a href="#" class="btn btn-secondary">Ver detalle </a>
                        <%-- Redirecciono a la misma pagina para quedarme con el id --%>
                        <a href="#" class="btn btn-secondary">Añadir al carrito </a>
                    </div>
                </div>
            </div>
          <%  } %>
        </div>

    </div>


</asp:Content>
