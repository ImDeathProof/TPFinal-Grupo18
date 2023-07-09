﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPFinal_Equipo18.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container carrito ">
        <%if (!(Session["Bebidas"] is null))
            {

        %>
        <h2 >Carrito de productos </h2>
        <div class="row">

            <div class="col-10">
                <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-dark table-hover table-striped table-bordered tabla-carrito"
                    OnRowCommand="dgvCarrito_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="Bebida.Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Bebida.Nombre" />
                        <asp:BoundField HeaderText="Codigo" DataField="Bebida.Precio" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Stock Disponibe" DataField="Bebida.Stock" />

                        <asp:TemplateField HeaderText="Agregar">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnAgregar" runat="server" Text=" + "
                                    CommandName="Agregar" CommandArgument=' <%# ((GridViewRow)Container).RowIndex  %>' CssClass="btn btn-outline-info"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descontar">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDescontar" runat="server" Text=" - "
                                    CommandName="Descontar" CommandArgument=' <%# ((GridViewRow)Container).RowIndex  %>' CssClass="btn btn-outline-info"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar"
                                    CommandName="Eliminar" CommandArgument=' <%# ((GridViewRow)Container).RowIndex  %>' CssClass="btn btn-outline-danger"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:Label ID="lblTotal" CssClass="bs-info" runat="server" Text=""></asp:Label>
            </div>

        </div>
        <div>
            <%}

                else
                {%>
            <h3>¡El carrito está vacío!</h3>
            <a href="Default.aspx">Volver al listado</a>
            <%} %>
        </div>

        <div class="row">
            <div class="col-6">
                <%--<a href="Pagos.aspx" class="btn btn-primary">Iniciar pago</a>--%>
                <asp:Button ID="btnIniciarPago" runat="server" CssClass=" btn btn-success" OnClick="btnIniciarPago_Click" Text="Iniciar pago" />
                <a href="Default.aspx">Volver</a>
            </div>

        </div>
    </div>






</asp:Content>
