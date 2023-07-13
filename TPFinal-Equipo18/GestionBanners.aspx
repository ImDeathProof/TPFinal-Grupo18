<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionBanners.aspx.cs" Inherits="TPFinal_Equipo18.GestionBanners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-1">
        <div class="container col-1">
        </div>
        <div class="container col-10 border p-3 text-bg-dark border-primary border-2 border-opacity-75">
            <div class="row">
                <h3>Gestión de Banners</h3>
                <h5>Solo se pueden agregar 5 banners por el momento</h5>
            </div>
            <div class="row">
                <div class="container col-10 border p-3 text-bg-dark border-primary border-2 border-opacity-75">
                    <asp:GridView ID="dgvBanners" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false"
                        DataKeyNames="Id" OnSelectedIndexChanged="dgvBanners_SelectedIndexChanged" OnRowCommand="dgvBanners_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="Id" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                            <asp:BoundField HeaderText="Link" DataField="UrlImg" />
                            <asp:CommandField HeaderText=" " ShowSelectButton="true" SelectText="Seleccionar" />


                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row m-1">
                <div class="col-3">
                    <label>ID</label>
                    <asp:TextBox ID="txtID" runat="server" placeholder="ID" CssClass="form-control" />
                </div>

                <div class="col-3">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" CssClass="form-control" />
                </div>

                <div class="col-3">
                    <label>Fecha</label>
                    <asp:TextBox ID="txtFecha" runat="server" placeholder="Fecha" CssClass="form-control" />
                </div>

                <div class="col-3">
                    <label>Link</label>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="txtLink" type="text" CssClass="form-control" placeholder="Link de la Imagen" aria-label="Example text with button addon" aria-describedby="button-addon1" runat="server"></asp:TextBox>
                        <asp:Button CssClass="btn btn-outline-secondary" type="button" ID="tbnModificar" OnClick="tbnModificar_Click" runat="server" Text="Modificar"></asp:Button>
                    </div>
                </div>
            </div>

        </div>
        <div class="container col-1">
        </div>
    </div>
</asp:Content>
