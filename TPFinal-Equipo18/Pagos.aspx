<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="TPFinal_Equipo18.Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Completa los ultimos pasos para terminar tu compra</h2>

    <div class="container">
        <div class="row">

            <h4>Formas de entrega </h4>
        </div>
        

       
                <div>

                    <asp:RadioButtonList ID="rblEntrega" runat="server" CssClass="form-check form-check-inline" AutoPostBack="true" >
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
                <div class="row">
                    <div class="mb-3">
                        <h3>Retira por sucursal </h3>

                        <p>Direccion: Av. Hipólito Yrigoyen 288, B1617 Gral. Pacheco, Provincia de Buenos Aires </p>

                    </div>
                </div>
                <%}%>
           



        <div class="row">

            <h4>Medios de pago </h4>
            <asp:ScriptManager runat="server" />

            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <asp:Label ID="lblMontoTotal" CssClass="form-label" runat="server" Text="El monto total a pagar es de <% pagoTotal %> $ "></asp:Label>

                    <div class="mb-3">
                        <asp:CheckBox ID="ckbMp" runat="server" Text="Mercado pago" AutoPostBack="true" />

                    </div>
                    <%if (ckbMp.Checked == true)
                        {  %>
                    <div class="mb-3">
                        <asp:Label ID="lblNumeroPago" runat="server" CssClass="form-label" Text="Ingrese el numero de operacion"></asp:Label>
                        <asp:TextBox ID="txtNumeroOperacion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%} %>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="row">
                <div class="col 12">
                    <asp:Button ID="btnTerminar" runat="server" CssClass="btn btn-success" Text="Terminar compra" OnClick="btnTerminar_Click" />
                    <a href="Carrito.aspx" class="btn btn-danger">Volver</a>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

