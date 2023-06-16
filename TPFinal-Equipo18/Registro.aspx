<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinal_Equipo18.LogIn.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border border-3 border-primary p-3" id="">
        <div class="mb-3">
            <label for="" class="form-label">Nombre</label>
            <input type="email" class="form-control" id="" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="" class="form-label">Apellido</label>
            <input type="email" class="form-control" id="" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="" class="form-label">DNI</label>
            <input type="email" class="form-control" id="" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="" class="form-label">Telefono</label>
            <input type="email" class="form-control" id="" aria-describedby="emailHelp">
            <div id="" class="form-text">Puede ser un celular</div>
        </div>
        <div class="mb-3">
            <label for="" class="form-label">Fecha de nacimiento</label>
            <input type="email" class="form-control" id="" aria-describedby="emailHelp">
            <div id="" class="form-text">Debes tener al menos 18 años</div>
        </div>
        <div class="mb-3">
            <label for="" class="form-label">Nombre de Usuario</label>
            <input type="email" class="form-control" id="" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Dirección de Email</label>
            <input type="email" class="form-control" id="" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputPassword1" class="form-label">Contraseña</label>
            <input type="password" class="form-control" id="">
        </div>
        <div class="mb-3">
            <button type="submit" class="btn btn-primary">Registrar</button>
            <asp:HyperLink NavigateUrl="/LogIn.aspx" runat="server" CssClass="p-3">Ya tengo cuenta</asp:HyperLink>
        </div>
    </div>
</asp:Content>
