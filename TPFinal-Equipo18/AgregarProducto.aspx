<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPFinal_Equipo18.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Agregar Producto </h1>
    <%--   public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal ContenidoNeto { get; set; }
        public bool Estado { get; set; }
        public string UrlImg { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }--%>

    <div class="container">
        <div class="row">
             <%--Id--%>
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <%--Codigo--%>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <%--Nombre--%>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <%--Descripcion--%>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>

            </div>
            <%--Precio--%>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <%--Contenido neto--%>
            <div class="mb-3">
                <label for="txtContenido" class="form-label">Contenido neto</label>
                <asp:TextBox ID="txtContenido" CssClass="form-control" runat="server"></asp:TextBox>
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

            <%--Para usar Update panel--%>
            <asp:ScriptManager runat="server" />

            <%--Para que se actualice solo la imagen--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <asp:Label ID="lblImg" runat="server" Text="Url de la imagen"></asp:Label>
                        <asp:TextBox ID="txtImage" runat="server" AutoPostBack="true"
                            OnTextChanged="txtImage_TextChanged" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Image ID="imgProducto" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBSgPpbL1xA_L4GMvsPnsQ6WyEJnvg-l7IBfl2qreg&s" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <div class="row">
            <div class="6">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click"/>
                <a href="GestionProductos.aspx" class="btn btn-secondary">Cancelar</a>
            </div>

        </div>

    </div>


</asp:Content>
