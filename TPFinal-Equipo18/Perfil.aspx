<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinal_Equipo18.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border p-3">
        <h2>Mi Perfil</h2>
        <div class="row">
            <div class="col-6 container border">
                <div class="border p-3">
                    <h3>FOTO DE PERFIL</h3>
                </div>
            </div>
            <div class="col-6 container border">
                <div>
                    <label id="lbl_Usuario" text="" class="form-label" runat="server"></label>
                </div>
                <%--<div>
                    <label id="lbl_Estado" text="" class="form-label" runat="server">Activo/Inactivo</label>
                </div>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-6 container border">
                <h3>Datos Personales:</h3>
                <div>
                    <label>Nombre: </label>
                    <label id="lbl_Nombre" text="" class="form-label" runat="server">Nombre</label>
                </div>
                <div>
                    <label>Apellido: </label>
                    <label id="lbl_Apellido" text="" class="form-label" runat="server">Apellido</label>
                </div>
                <div>
                    <label>DNI: </label>
                    <label id="lbl_DNI" text="" class="form-label" runat="server">DNI</label>
                </div>
                <div>
                    <label>Fecha de Nacimiento: </label>
                    <label id="lbl_FNacimiento" text="" class="form-label" runat="server">Fecha de Nacimiento</label>
                </div>
                <div>
                    <label>Dirección de E-mail: </label>
                    <label id="lbl_Email" text="" class="form-label" runat="server">E-mail</label>
                </div>
                <div>
                    <label>Telefono: </label>
                    <label id="lbl_Telefono" text="" class="form-label" runat="server">Telefono</label>
                </div>
                <%--HAY QUE REVISAR PORQUE TIRA ERRORES CUANDO INTENTA MODIFICAR--%>
                <%--<div class="p-3">
                    <asp:Button ID="btnModificar" Text="Modificar" runat="server" OnClick="btnModificar_Click" />
                </div>--%>
            </div>
            <%--CUANDO TENGAMOS LO DEL DOMICILIO SE HABILITA--%>
            <%--<div class="col-6 container border">
                <h3>Domicilio: </h3>
                <div class="p-3">
                    <asp:Button Text="Agregar" runat="server" />
                    <asp:Button Text="Modificar" runat="server" />
                </div>
            </div>--%>
        </div>
    </div>
</asp:Content>
