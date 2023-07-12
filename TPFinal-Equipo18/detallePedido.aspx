<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="detallePedido.aspx.cs" Inherits="TPFinal_Equipo18.detallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Este es el detalle del pedido</h1>
    <asp:Label ID="lblDetalle" runat="server" Text="Label"></asp:Label>


    <%--    public int Id { get; set; }
        public Usuario usuario { get; set; }
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }
        public int MedioPago { get; set; }
        public string Entrega { get; set; }
        public EstadoPedido Estado { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }--%>

    <%--  fecha
        Numero de pedido 
        nombre de usurario
        domicilio del usuario
        emil de contacto 
        productos
            nombreprocuto cantidad precio
            nombreproducto cantidad precio

        precio total --%>

    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <%--Fecha--%>
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Fecha" CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblFeha" runat="server" Text="Fecha" CssClass="form-label"></asp:Label>
                </div>
                <%--Numero de pedido--%>
                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Numero de pedido: " CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblNumPedido" runat="server" Text="Label" CssClass="form-label"></asp:Label>
                </div>
                <%--Domicilio--%>
                <div class="mb-3">
                    <asp:Label ID="Label3" runat="server" Text="Domicilio del cliente: " CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblDomicilio" runat="server" Text="Label" CssClass="form-label"></asp:Label>
                </div>
                <%--Email de contacto--%>
                <div class="mb-3">
                    <asp:Label ID="Label4" runat="server" Text="Email de contacto: " CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblEmaul" runat="server" Text="Label" CssClass="form-label"></asp:Label>

                </div>
                <%--Produtos--%>
                <div class="mb-3 d-flex justify-aling-center">
                    <asp:Label ID="Label5" runat="server" Text="Productos: " CssClass="form-label"></asp:Label>
                </div>

                <%foreach (Dominio.DetallePedido item in listaDetalle)
                    {%>

                <div class="mb-3">
                     <label>Producto</label>
                     <label><%:item.IdPedido %></label>
                     <label>Cantidad</label>
                     <label><%:item.Cantidad %></label>
                    <label> Precio</label>
                    <label>:<%:item.Precio %></label>
                </div>

                <asp:Label ID="Label7" runat="server" Text="Producto: "></asp:Label>
                <asp:Label ID="lblProducto" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>


                <% } %>


                <%--Total--%>
                <div class="mb-3 ">
                    <asp:Label ID="Label6" runat="server" Text="Total" CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblTotal" runat="server" Text="Label" CssClass="form-label"></asp:Label>
                </div>

            </div>

        </div>

        <a href="GestionPedidos.aspx" class="btn btn-success">Volver</a>
    </div>


</asp:Content>
