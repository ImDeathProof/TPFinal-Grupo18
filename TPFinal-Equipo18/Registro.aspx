<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinal_Equipo18.LogIn.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border border-3 border-primary p-3" id="">
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" placeholder="Ingrese su Nombre" onkeydown="return !(event.keyCode >= 48 && event.keyCode <= 57)" CssClass="form-control" />
                    <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtNombre" runat="server" />
                    <label></label>
                </div>
                <div class="mb-3">
                    <label for="" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" placeholder="Ingrese su Apellido" onkeydown="return !(event.keyCode >= 48 && event.keyCode <= 57)" CssClass="form-control" />
                    <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtApellido" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label">DNI</label>
                    <asp:TextBox runat="server" ID="txtDNI" placeholder="Ingrese su DNI" onkeydown="return (event.keyCode >= 48 && event.keyCode <= 57)" CssClass="form-control" />
                    <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtDNI" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label">Telefono</label>
                    <asp:TextBox runat="server" ID="txtTelefono" placeholder="Ingrese su Telefono" onkeydown="return (event.keyCode >= 48 && event.keyCode <= 57)" CssClass="form-control" />
                    <div id="" class="form-text text-light">Puede ser un celular</div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="" class="form-label">Fecha de nacimiento</label>
                    <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" />
                    <label class="form-text text-light">Debes tener al menos 18 años</label>
                    <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campor es obligatorio" ControlToValidate="txtFechaNacimiento" runat="server" />

                </div>
                <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Dirección de Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" placeholder="Ingrese su Dirección de Email" CssClass="form-control" />
                    <asp:RegularExpressionValidator CssClass="validator" ErrorMessage="Debe ingresar un email valido" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
                    <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campor es obligatorio" ControlToValidate="txtEmail" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label">Nombre de Usuario</label>
                    <asp:TextBox runat="server" ID="txtUsuario" placeholder="Ingrese su nombre de usuario" CssClass="form-control" />
                    <asp:Label ID="lblAlertaUsuario" Text="El nombre de usuario ya existe, por favor elija otro" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" placeholder="Ingrese su contraseña" ID="txtPass" TextMode="Password" CssClass="form-control" />
                </div>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegistrar" Text="Registrar" CssClass="btn btn-success" OnClick="btnRegistrar_Click" runat="server" />
                <asp:HyperLink NavigateUrl="/LogIn.aspx" runat="server" CssClass="p-3">Ya tengo cuenta</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
