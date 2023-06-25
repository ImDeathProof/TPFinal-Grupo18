<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="TPFinal_Equipo18.GestionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container p-3 border">
        <h1>Gestion de Ecommerce </h1>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <%--Grilla con bebidas--%>
                <div class="container p-3">
                    <div class="row">
                        <div class="col-6 pt-3">
                            <a href="AgregarProducto.aspx" class="btn btn-primary">Agregar producto </a>
                            <asp:Button ID="btnAgregarMarca" runat="server" Text="Agregar marca" CssClass="btn btn-primary" OnClick="btnAgregarMarca_Click" />
                            <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar Categoria" CssClass="btn btn-primary" OnClick="btnAgregarCategoria_Click" />
                            <%--<a href="AgregarCategoria.aspx" class="btn btn-primary">Agregar categoria </a>--%>
                        </div>
                    </div>
                    <%--Agregar una marca--%>
                    <div class="row">
                        <div class="col-6 pt-3" id="divAgregarMarca" runat="server">
                            <asp:Label ID="lblMarca" runat="server" CssClass="label-control" Text="Ingresar nombre de la Marca"></asp:Label>
                            <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblAlertaNombreMarca" CssClass="label-control" Text="Debe ingresar un nombre!" runat="server"></asp:Label>
                            <div class="pt-1">
                                <asp:Button ID="btnAgregar_Marca" CssClass="btn btn-secondary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                                <asp:Button ID="btnCancelar_Marca" CssClass="btn brn-secondary" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                    </div>
                    <%--Agregar una categoria--%>
                    <div class="row">
                        <div class="col-6 pt-3" id="divAgregarCategoria" runat="server">
                            <asp:Label ID="Label1" runat="server" CssClass="label-control" Text="Ingresar nombre de la Categoria"></asp:Label>
                            <asp:TextBox ID="txtCategoria" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblAlertaNombreCategoria" CssClass="label-control" Text="Debe ingresar un nombre!" runat="server"></asp:Label>
                            <div class="pt-1">
                                <asp:Button ID="btnAgregar_Categoria" CssClass="btn btn-secondary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                                <asp:Button ID="btnCancelar_Categoria" CssClass="btn brn-secondary" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                    </div>

                    <%--Desplegable de bebidas,marcas y categorias--%>
                    <div class="row">
                        <div class="col-6 pt-3 pb-3">
                            <asp:DropDownList ID="ddlListado" runat="server" CssClass="form-control" AutoPostBack="true">
                                <%--   <asp:ListItem Text="Listado de bebidas" />
                    <asp:ListItem Text="Listado de marcas" />
                    <asp:ListItem Text="Listado de categorias" />--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--Grilla de bebidas--%>

                    <%--Pregunto que esta seleccionado en el desplegable--%>
                    <%if (ddlListado.Text == "Listado de bebidas")

                        {

                    %>
                    <div class="row">
                        <div class="col-8">

                            <asp:GridView ID="dgvProductos" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-dark table-striped" DataKeyNames="Id" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
                                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
                                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar" />
                                    <asp:BoundField HeaderText="Activo" DataField="Estado" />
                                    <%--LINKBUTTON PARA ELIMINAR, IGUAL QUE LA FUNCION LO REVISO DESPUES--%>
                                    <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="Eliminar" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                    <%}
                        else
            if (ddlListado.Text == "Listado de categorias")
                        {

                    %>
                    <%--Grillas de categorias--%>
                    <div class="row">
                        <div class="col-8">
                            <asp:GridView ID="dgvCategorias" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-dark table-striped" DataKeyNames="Id">
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="Eliminar" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>

                    <%}
                        else

                        {  %>
                    <%--grilla de marcas--%>
                    <div class="row">
                        <div class="col-8">
                            <asp:GridView ID="dgvMarcas" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-dark table-striped" DataKeyNames="Id">
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="Eliminar" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>

                    <%} %>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
