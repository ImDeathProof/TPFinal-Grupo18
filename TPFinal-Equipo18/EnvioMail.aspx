<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EnvioMail.aspx.cs" Inherits="TPFinal_Equipo18.EnvioMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
        <div class="container col-8 border p-3 text-bg-dark border-primary border-2 border-opacity-75" id="">  
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:textbox runat="server" ID="txtNombre" onkeydown="return !(event.keyCode >= 48 && event.keyCode <= 57)" CssClass="form-control"/>
                <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtNombre" runat="server" />
             </div>
             <div class="mb-3">
                 <label class="form-label">Email</label>
                 <asp:textbox runat="server" ID="txtEmail" CssClass="form-control"/>
                 <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campor es obligatorio" ControlToValidate="txtEmail" runat="server" />
              </div>
             <div class="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:textbox TextMode="MultiLine" runat="server" ID="txtMensaje" CssClass="form-control" Rows="3"/>
             </div>
                <asp:Button Text="Enviar" CssClass="btn btn-outline-success mt-1" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" /> 
</div>

</asp:Content>
