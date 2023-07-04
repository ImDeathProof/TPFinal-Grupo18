<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionPedidos.aspx.cs" Inherits="TPFinal_Equipo18.GestionPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <h2>Gestion de pedidos </h2>
    <div class="container">
        <div class="row">
            <div class="col 10">
                <asp:GridView ID="dgvPedidos" runat="server" CssClass="table table-dark table-striped"
                    AutoGenerateColumns="false" OnRowDataBound="dgvPedidos_RowDataBound">
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
                                <asp:DropDownList ID="ddlEstados" runat="server"   >
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>                

                    </Columns>
                </asp:GridView>
            </div>

        </div>

    </div>



</asp:Content>
