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
                <div class="p-3">
                    <%--HAY QUE REVISAR PORQUE TIRA ERRORES CUANDO INTENTA MODIFICAR--%>
                    <label>Todavia no tienen funcionalidad</label>
                    <button class="btn btn-primary" href="/Registro.aspx">Modificar</button>
                </div>
            </div>
            <%--<%--CUANDO TENGAMOS LO DEL DOMICILIO SE HABILITA--%>
            <div class="col-6 container border">
                <div class="p-3">
                    <h3>Domicilio: </h3>
                    <div>
                        <label>Calle: </label>
                        <label id="lbl_Calle" text=" " class="form-label" runat="server"></label>
                    </div>
                    <div>
                        <label>Numero: </label>
                        <label id="lbl_Numero" text=" " class="form-label" runat="server"></label>
                    </div>
                    <div>
                        <label>Provincia: </label>
                        <label id="lbl_Provincia" text=" " class="form-label" runat="server"></label>
                    </div>
                    <div>
                        <label>Partido: </label>
                        <label id="lbl_Partido" text=" " class="form-label" runat="server"></label>
                    </div>
                    <div>
                        <label>Localidad: </label>
                        <label id="lbl_Localidad" text=" " class="form-label" runat="server"></label>
                    </div>
                    <div>
                        <label>Departamento: </label>
                        <label id="lbl_Departamento" text=" " class="form-label" runat="server"></label>
                    </div>
                    <div>
                        <label>Piso: </label>
                        <label id="lbl_Piso" text=" " class="form-label" runat="server"></label>
                    </div>
                    <label>Todavia no tienen funcionalidad</label>
                    <%if (Usuario.Domicilio != null)
                        {%>
                    <asp:Button Text="Modificar" CssClass="btn btn-primary" runat="server" />
                    <%}
                        else
                        {%>
                    <asp:Button Text="Agregar" CssClass="btn btn-success" runat="server" />

                    <%} %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
