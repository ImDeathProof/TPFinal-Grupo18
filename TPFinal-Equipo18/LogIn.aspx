<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinal_Equipo18.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border border-3 border-primary p-3" id="">
        <div class="mb-3">
            <label class="form-label">Usuario</label>
            <asp:TextBox runat="server" id="txtUser" placeholder="Ingrese su nombre de usuario" CssClass="form-control"/>
            <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="El usuario es obligatorio" ControlToValidate="txtUser" runat="server" />
        </div>
        <div class="mb-3">
            <label class="form-label">Contraseña</label>
            <asp:TextBox runat="server" placeholder="Ingrese su contraseña" id="txtPass"  TextMode="Password" CssClass="form-control"/>
            <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="La contraseña es obligatoria" ControlToValidate="txtPass" runat="server" />
        </div>
        <div class="mb-3"> 
            <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div class="mb-3">
             <asp:Button Text="Entrar"  runat="server" ID="btnIngresar" Onclick="btnIngresar_Click" class="btn btn-primary"/>
            <asp:HyperLink NavigateUrl="/Registro.aspx" runat="server" CssClass="p-3">Registrarme</asp:HyperLink>
        </div>
    </div>
</asp:Content>
