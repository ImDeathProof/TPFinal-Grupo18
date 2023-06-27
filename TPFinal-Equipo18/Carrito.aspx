<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPFinal_Equipo18.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Carrito de productos </h2>

    <div class="container">
        <div class="row">
            <div class="col-8">
                <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false" 
                    CssClass="table table-dark table-striped" DataKeyNames="Id" 
                    OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged"
                    onse>
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Codigo" DataField="Precio" />
                        <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="Eliminar" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>






</asp:Content>
