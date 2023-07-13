<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinal_Equipo18.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="container col-6 border text-bg-dark border-primary border-2 border-opacity-75" id="">
            <div class="row justify-content-center">
                <div class="col-4">
                    <div>
                        <label class="form-label">Usuario:</label>
                    </div>
                    <asp:TextBox runat="server" ID="txtUser" placeholder="Ingrese su usuario" CssClass="btn btn-outline-primary" />
                    <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="El usuario es obligatorio" ControlToValidate="txtUser" runat="server" />
                </div>
            </div>
            <div class="row justify-content-center">

                <div class="col-4">
                    <div>
                        <label class="form-label">Contraseña:</label>
                    </div>
                    <asp:TextBox runat="server" placeholder="Ingrese su contraseña" ID="txtPass" TextMode="Password" CssClass="btn btn-outline-primary mt-1" />
                    <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="La contraseña es obligatoria" ControlToValidate="txtPass" runat="server" />
                </div>
            </div>

            <div class="row justify-content-center">
                <div class="col-4">
                    <div class="mb-3">
                        <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="mb-3">
                        <asp:Button Text="Entrar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" class="btn btn-outline-primary mt-1" />
                        <asp:HyperLink NavigateUrl="/Registro.aspx" runat="server" CssClass="p-3">Registrarme</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
