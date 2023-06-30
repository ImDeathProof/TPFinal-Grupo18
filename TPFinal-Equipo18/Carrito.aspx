<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPFinal_Equipo18.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Carrito de productos </h2>

    <div class="container">
        <%if (!(Session["Bebidas"] is null))
            {

        %>
        <div class="row">
            <div class="col-8">
                <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false"
                    CssClass="table  table-striped" 
                    OnRowCommand="dgvCarrito_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="Bebida.Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Bebida.Nombre" />
                        <asp:BoundField HeaderText="Codigo" DataField="Bebida.Precio" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnAgregar" runat="server" Text=" + "
                                    CommandName="Agregar" CommandArgument=' <%# ((GridViewRow)Container).RowIndex  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDescontar" runat="server" Text=" - "
                                    CommandName="Descontar" CommandArgument=' <%# ((GridViewRow)Container).RowIndex  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar"
                                    CommandName="Eliminar" CommandArgument=' <%# ((GridViewRow)Container).RowIndex  %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
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
                <a href="Pagos.aspx" class="btn btn-primary">Iniciar pago</a>

            </div>

        </div>
    </div>






</asp:Content>
