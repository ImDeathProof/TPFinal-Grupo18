<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinal_Equipo18.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="container col-3 border p-3">
            <nav class="nav flex-column">
                <a class="nav-link active" href="/Perfil.aspx">Perfil</a>
                <a class="nav-link" href="/Perfil.aspx/Domicilio">Domicilio</a>
                <a class="nav-link" href="/Perfil.aspx/Mis-Pedidos">Mis Pedidos</a>
            </nav>
        </div>
        <div class="container col-9 border p-3">
            <div class="row">
                <div class="col-6 container border">
                    <div class="border p-3">
                        <h3>FOTO DE PERFIL</h3>
                    </div>
                </div>
                <div class="col-6 container border">
                    <div>
                        <label id="lbl_Usuario" text="" class="form-label" runat="server"></label>
                    </div>
                    <div>
                        <label id="lbl_Estado" text="" class="form-label" runat="server"></label>
                    </div>
                </div>
            </div>
            <%--DIV DATOS DEL USUARIO--%>
            <div class="row" id="divDatosUsuario" runat="server">
                <div class="col-9 container border">
                    <div class="p-3">

                        <h3>Datos Personales:</h3>
                        <div class="row">
                            <div class="col-6">
                                <label>Nombre: </label>
                                <div>
                                    <asp:TextBox ID="txt_Nombre" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="col-6">
                                <label>Apellido: </label>
                                <div>
                                    <asp:TextBox ID="txt_Apellido" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>DNI: </label>
                                <div>
                                    <asp:TextBox ID="txt_DNI" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="col-6">
                                <label>Fecha de Nacimiento: </label>
                                <div>
                                    <asp:TextBox ID="txt_FNacimiento" CssClass="form-control" runat="server" TextMode="Date" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>Dirección de E-mail: </label>
                                <div>
                                    <asp:TextBox ID="txt_Email" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="col-6">
                                <label>Telefono: </label>
                                <div>
                                    <asp:TextBox ID="txt_Telefono" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="p-3">
                        <%--HAY QUE REVISAR PORQUE TIRA ERRORES CUANDO INTENTA MODIFICAR--%>
                        <asp:Button ID="btnModificarUsuario" Text="Modificar" runat="server" OnClick="btnModificarUsuario_Click" />
                    </div>
                </div>
            </div>
            <%--DIV DATOS DEL DOMICILIO--%>
            <div class="row" id="divDatosDomicilio" runat="server">
                <div class="col-9 container border">
                    <div class="p-3">
                        <h3>Domicilio: </h3>
                        <div class="row">
                            <div class="col-6">
                                <label>Calle: </label>
                                <div>
                                    <label id="lbl_Calle" text=" " class="form-label" runat="server"></label>
                                </div>
                            </div>
                            <div class="col-6">
                                <label>Numero: </label>
                                <div>
                                    <label id="lbl_Numero" text=" " class="form-label" runat="server"></label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>Provincia: </label>
                                <div>
                                    <label id="lbl_Provincia" text=" " class="form-label" runat="server"></label>
                                </div>
                            </div>
                            <div class="col-6">
                                <label>Partido: </label>
                                <div>
                                    <label id="lbl_Partido" text=" " class="form-label" runat="server"></label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <label>Localidad: </label>
                                <div>
                                    <label id="lbl_Localidad" text=" " class="form-label" runat="server"></label>
                                </div>
                            </div>
                        </div>

                        <div>
                            <div class="row">

                                <div class="col-6">
                                    <label>Departamento: </label>
                                    <div>
                                        <label id="lbl_Departamento" text=" " class="form-label" runat="server"></label>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <label>Piso: </label>
                                    <div>
                                        <label id="lbl_Piso" text=" " class="form-label" runat="server"></label>
                                    </div>
                                </div>
                            </div>
                            <%if (Usuario.Domicilio != null)

                                {%>
                            <asp:Button Text="Modificar" CssClass="btn btn-primary" runat="server" />
                            <%}
                                else
                                {%>
                            <asp:Button Text="Agregar" CssClass="btn btn-success" runat="server" />

                            <%} %>
                        </div>
                    </div>
                </div>
            </div>
            <%--DIV MIS PEDIDOS--%>
            <div class="row" id="divMisPedidos" runat="server">
                <div class="col-9 container border">
                    <div class="p-3">
                        <h3>Mis Pedidos: </h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
