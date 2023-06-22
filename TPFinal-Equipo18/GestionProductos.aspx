<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="TPFinal_Equipo18.GestionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Listado de productos </h1>

    <%--Grilla con bebidas--%>
    <div class="container">
        <div class="row">
            <div class="col-8">
                <a href="AgregarProducto.aspx" class="btn btn-primary">Agregar producto </a>
                <asp:GridView ID="dgvProductos" runat="server" AutoGenerateColumns="false" 
                    CssClass="table table-dark table-striped" DataKeyNames="Id" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                        <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" />
                        <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="Eliminar" />

                    </Columns>
                </asp:GridView>
            </div>

        </div>

    </div>

</asp:Content>
