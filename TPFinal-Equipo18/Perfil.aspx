<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinal_Equipo18.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["usuario"] != null)
        {

    %>

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
                        <asp:Image ID="avatarUsuario" ImageUrl="https://www.mendozapost.com/files/image/7/7142/54b6f4c45797b.jpg"
                            runat="server" CssClass="img-fluid mb-3" />
                    </div>
                    <label class="form-label">Avatar</label>
                    <input type="file" id="txtImagen" class="form-control" runat="server" />
                    <asp:Button ID="btnGuardarImg" Text="Guardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardarImg_Click" />
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
                        <asp:Button ID="btnModificarUsuario" Text="Modificar" CssClass="btn btn-primary" runat="server" OnClick="btnModificarUsuario_Click" />
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
                                    <asp:TextBox ID="txt_Calle" Text=" " CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="col-6">
                                <label>Numero: </label>
                                <div>
                                    <asp:TextBox ID="txt_Numero" Text=" " CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>Provincia: </label>
                                <div>
                                    <asp:TextBox ID="txt_Provincia" Text=" " CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="col-6">
                                <label>Partido: </label>
                                <div>
                                    <asp:TextBox ID="txt_Partido" Text=" " CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <label>Localidad: </label>
                                <div>
                                    <asp:TextBox ID="txt_Localidad" Text=" " CssClass="form-control" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div>
                            <div class="row">

                                <div class="col-6">
                                    <label>Departamento: </label>
                                    <div>
                                        <asp:TextBox ID="txt_Departamento" Text=" " CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <div class="col-6">
                                    <label>Piso: </label>
                                    <div>
                                        <asp:TextBox ID="txt_Piso" Text=" " CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="p-3">
                                <%  Dominio.Usuario user = (Dominio.Usuario)Session["usuario"];
                                    Dominio.Domicilio dom = user.Domicilio;
                                    if (dom == null)

                                    {%>
                                <asp:Button ID="btnAgregarDomicilio" OnClick="btnAgregarDomicilio_Click" Text="Agregar" CssClass="btn btn-success" runat="server" />

                                <%}
                                    else
                                    {%>
                                <asp:Button ID="btnModificarDomicilio" OnClick="btnModificarDomicilio_Click" Text="Modificar" CssClass="btn btn-primary" runat="server" />

                                <%} %>
                            </div>
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
    <%}
        else
        {%>
    <div>
        <h2>Debes estar logueado para acceder a esta pagina</h2>
        <a href="/Default.aspx">Volver al inicio</a>
        <a href="/Login.aspx">Iniciar sesión</a>
    </div>
    <%} %>
</asp:Content>
