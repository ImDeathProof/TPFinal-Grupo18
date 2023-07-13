<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionPedidos.aspx.cs" Inherits="TPFinal_Equipo18.GestionPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="container col-10 border text-bg-dark border-primary border-2 border-opacity-75">
    <h2>Gestion de pedidos </h2>
        <div class="row">
            <div class="col 10">
                <asp:GridView ID="dgvPedidos" runat="server" CssClass="table table-dark table-striped border text-bg-dark border-primary border-2 border-opacity-75"
                    AutoGenerateColumns="false" OnRowDataBound="dgvPedidos_RowDataBound"
                    OnRowCommand="dgvPedidos_RowCommand"
                    >
                    <Columns>
                        
                        <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                        <asp:BoundField HeaderText="Contacto" DataField="Email" />
                        <asp:BoundField HeaderText="Importe" DataField="Importe" />
                        <asp:BoundField HeaderText="Fecha de compra" DataField="Fecha" />
                        <asp:BoundField HeaderText="Entrega" DataField="Entrega" />
                        <asp:BoundField HeaderText="Medio de pago" DataField="MedioPago" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
                        <asp:TemplateField  HeaderText="Cambiar estado">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlEstados" runat="server" 
                                    OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>      
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDetallePedido" runat="server" Text="Ver detalle"
                                 CommandName="VerDetalle" CommandArgument=' <%# ((GridViewRow)Container).RowIndex  %>' CssClass="btn btn-outline-info"   ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>

        </div>

    </div>



</asp:Content>
