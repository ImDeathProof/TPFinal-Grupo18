<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EnvioMail.aspx.cs" Inherits="TPFinal_Equipo18.EnvioMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
        <div class="row">
         <div class="col-2"></div>
         <div class="col">
            <div class="mb-3">
           <%//<form class="form-label" action="/enviar-mensaje" method="POST">%>
                <label class="form-label" for="nombre">Nombre:</label>
                    <asp:textbox runat="server" ID="txtnombre" CssClass="form-control"/>
             </div>
             <div class="mb-3">
                 <label class="form-label" for="email">Email:</label>
                 <asp:textbox runat="server" ID="txtemail" CssClass="form-control"/>
              </div>
             <div class="mb-3">
                <label class="form-label" for="mensaje">Mensaje:</label>
                <asp:textbox TextMode="MultiLine" runat="server" ID="txtmensaje" CssClass="from-control"/>
             </div>
                <asp:Button Text="Aceptar" CssClass="btn btn-primary" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" />
            <%//</form>%>  
        </div>
         <div class="col"></div>
</div>

</asp:Content>
