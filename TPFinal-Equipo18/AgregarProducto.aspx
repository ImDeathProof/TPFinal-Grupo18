﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPFinal_Equipo18.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-10 border p-3 text-bg-dark border-primary border-2 border-opacity-75">

        <h1>Agregar Producto </h1>

        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <%--Id--%>
                    <div class="mb-3">
                        <asp:Label ID="lblId" runat="server" Text="Id" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%--Estado--%>
                    <div class="mb-3">
                        <label id="lblEstado" runat="server" for="txtEstado" class="form-label">Estado</label>
                        <asp:TextBox ID="txtEstado" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%--Codigo--%>
                    <div class="mb-3">
                        <label for="txtCodigo" class="form-label">Codigo</label>
                        <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtCodigo" runat="server" />
                    </div>
                    <%--Nombre--%>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtNombre" runat="server" />
                    </div>
                    <%--Descripcion--%>
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripcion</label>
                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtDescripcion" runat="server" />
                    </div>
                    <%--Precio--%>
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <div class="input-group mb-3">
                        <span class="input-group-text">$</span>
                        <asp:TextBox ID="txtPrecio" CssClass="form-control" onkeydown="return (event.keyCode >= 48 && event.keyCode <= 57)" runat="server" aria-label="Amount (to the nearest dollar)"></asp:TextBox>
                        <span class="input-group-text">.00</span>
                        <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtPrecio" runat="server" />
                    </div>
                    <%--Contenido neto--%>
                    <div class="mb-3">
                        <label for="txtContenido" class="form-label">Contenido neto</label>
                        <asp:TextBox ID="txtContenido" CssClass="form-control" onkeydown="return (event.keyCode >= 48 && event.keyCode <= 57)" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtContenido" runat="server" />
                    </div>

                </div>

                <div class="col-md-6">
                    <%--Stock--%>
                    <div class="mb-3">
                        <label for="txtStock" class="form-label">Stock</label>
                        <asp:TextBox ID="txtStock" CssClass="form-control" runat="server" onkeydown="return (event.keyCode >= 48 && event.keyCode <= 57)"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtPrecio" runat="server" />
                    </div>
                    <%--Marca--%>
                    <div class="mb-3">
                        <asp:Label ID="lblMarca" runat="server" Text="Marca" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <%--Categoria--%>
                    <div class="mb-3">
                        <asp:Label ID="lblCategoria" runat="server" Text="Categoria" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>

                    <%--Imagen--%>
                    <div class="mb-3">
                        <label class="form-label">Imagen de la bebida</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtImage" />
                        <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtImage" runat="server" />
                        <asp:Image ID="imgProducto" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBSgPpbL1xA_L4GMvsPnsQ6WyEJnvg-l7IBfl2qreg&s"
                            CssClass="img-fluid mb-3" runat="server" />
                    </div>



                    <%--Para usar Update panel--%>
                    <asp:ScriptManager runat="server" />

                    <%--Para que se actualice solo la imagen--%>
                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div>
                                <asp:Label ID="lblImg" runat="server" Text="Url de la imagen"></asp:Label>
                                <asp:TextBox ID="txtImage" runat="server" AutoPostBack="true"
                                    OnTextChanged="txtImage_TextChanged" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:Image ID="imgProducto" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBSgPpbL1xA_L4GMvsPnsQ6WyEJnvg-l7IBfl2qreg&s" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>



            </div>

            <div class="row">
                <div class="6">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-outline-primary" OnClick="btnAceptar_Click" />
                    <a href="GestionProductos.aspx" class="btn btn-outline-secondary">Cancelar</a>
                    <%if (txtEstado.Text == "True")
                        {
                    %>
                    <asp:Button ID="btnDesactivar" Text="Desactivar" runat="server" CssClass="btn btn-outline-warning" OnClick="btnDesactivar_Click" />
                    <%}
                        else
                        {%>
                    <asp:Button ID="btnActivar" Text="Activar" runat="server" CssClass="btn btn-outline-success" OnClick="btnActivar_Click" />
                    <%}%>
                    <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" />
                </div>

            </div>

        </div>
    </div>


</asp:Content>
