<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EnvioMail.aspx.cs" Inherits="TPFinal_Equipo18.EnvioMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
        <div class="row">
         <div class="col-2"></div>
         <div class="col">
            <div class="mb-3">
           <%//<form class="form-label" action="/enviar-mensaje" method="POST">%>
                <label class="form-label">Nombre</label>
                    <asp:textbox runat="server" ID="txtNombre" CssClass="form-control"/>
             </div>
             <div class="mb-3">
                 <label class="form-label">Email</label>
                 <asp:textbox runat="server" ID="txtEmail" CssClass="form-control"/>
              </div>
             <div class="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:textbox TextMode="MultiLine" runat="server" ID="txtMensaje" CssClass="from-control"/>
             </div>
                <asp:Button Text="Aceptar" CssClass="btn btn-primary" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" />
            <%//</form>%>  
        </div>
         <div class="col"></div>
</div>

</asp:Content>
