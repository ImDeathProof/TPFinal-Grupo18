<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="TPFinal_Equipo18.GestionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border p-3">
        <h2>Gestion de pedidos </h2>
        <div class="row">
            <div class="col 10">
                <asp:GridView ID="dgvPedidos" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                        <asp:BoundField HeaderText="E-mail" DataField="Email" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>

    </div>
</asp:Content>
