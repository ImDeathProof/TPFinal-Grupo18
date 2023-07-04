<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionPedidos.aspx.cs" Inherits="TPFinal_Equipo18.GestionPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gestion de pedidos </h2>

    <asp:GridView ID="dgvPedidos" runat="server"></asp:GridView>

</asp:Content>
