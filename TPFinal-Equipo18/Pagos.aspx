<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="TPFinal_Equipo18.Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container col-10 border p-3 text-bg-dark border-primary border-2 border-opacity-75">
        <h2>Completa los ultimos pasos para terminar tu compra</h2>
        <div class="row">

            <h4>Formas de entrega </h4>
            <asp:ScriptManager runat="server" ID="script" />

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-md-6">

                        <asp:RadioButtonList ID="rblEntrega" runat="server" CssClass="form-select" AutoPostBack="true">
                            <asp:ListItem Text="Entrega a domicilio" Value="1" />
                            <asp:ListItem Text="Retira por sucursal" Value="2" />
                        </asp:RadioButtonList>


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
                        <%}%>
                    </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="row ">
                <div class="col-md-8">

                    <h4>Medio de pago disponible </h4>
                    <asp:Label ID="lblMonto" CssClass="form-label" runat="server" Text="El monto total a pagar es de $ "></asp:Label>
                    <asp:Label ID="lblMontoTotal" runat="server" Text=""></asp:Label>

                    <div class="mb-3">
                        <asp:CheckBox ID="ckbMp" runat="server" Text="Mercado pago" Checked="true" />
                        <img src="~/Images/Icons/MP" alt="Mercado Pago" />

                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblNumeroPago" runat="server" CssClass="form-label" Text="Ingrese el numero de operacion"></asp:Label>
                        <asp:TextBox ID="txtNumeroOperacion" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="Este campo es obligatorio" ControlToValidate="txtNumeroOperacion" runat="server" />
                    </div>

                </div>


                <div class="row">
                    <div class="col-12">
                        <asp:Button ID="btnTerminar" runat="server" CssClass="btn btn-outline-success" Text="Terminar compra" OnClick="btnTerminar_Click" />
                        <a href="Carrito.aspx" class="btn btn-outline-danger">Volver</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

