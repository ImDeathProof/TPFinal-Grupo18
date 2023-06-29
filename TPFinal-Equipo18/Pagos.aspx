<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="TPFinal_Equipo18.Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Esta es la pantalla de pagos  </h1>

    <div class="container">
        <div class="row">
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Entrega</label>
            </div>

        </div>
        <div>

            <asp:RadioButtonList ID="rblEntrega" runat="server" CssClass="form-check form-check-inline" AutoPostBack="true">
                <asp:ListItem Text="Entrega a domicilio" Value="1" />
                <asp:ListItem Text="Retira por sucursal" Value="2" />
            </asp:RadioButtonList>
        </div>

        <%if (rblEntrega.SelectedValue == "1")
            {  %>
        <%--Entrega a domicilio--%>
        <div class="mb-3">
            <label for="exampleFormControlInput1" class="form-label">Datos del destinatario</label>
            <div class="mb-3">
                <asp:TextBox ID="txtNombre" runat="server" Text="Nombre" ForeColor="#999999"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtApellido" runat="server" Text="Apellido" ForeColor="#999999"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtTelefono" runat="server" Text="Telefono" ForeColor="#999999"></asp:TextBox>
            </div>
        </div>
      



        <%}
            else if (rblEntrega.SelectedValue == "2")
            { %>
        <label>retira por sucursal</label>
        <%} %>
    </div>






</asp:Content>
