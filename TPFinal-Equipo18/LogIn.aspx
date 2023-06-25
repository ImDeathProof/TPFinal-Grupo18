<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinal_Equipo18.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border border-3 border-primary p-3" id="">
        <div class="mb-3">
            <label class="form-label">E-Mail</label>
            <asp:TextBox runat="server" id="txtUser" placeholder="e-mail" CssClass="form-control"/>
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox runat="server" placeholder="*********" id="txtPass" CssClass="form-control" />
        </div>
        <div class="mb-3">
             <asp:Button Text="Entar"  runat="server" ID="btnIngresar" Onclick="btnIngresar_Click" class="btn btn-primary"/>
            <asp:HyperLink NavigateUrl="/Registro.aspx" runat="server" CssClass="p-3">Registrarme</asp:HyperLink>
        </div>
    </div>
</asp:Content>
