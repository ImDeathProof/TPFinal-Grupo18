<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleBebida.aspx.cs" Inherits="TPFinal_Equipo18.DetalleBebida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row border">
            <div class="col-1 border">
                <h2>1</h2>
            </div>
            <div class="col-10 border">
                <div class="row">
                    <div class="col-5 border p-2">
                        <h2>5</h2>
                        <div class="text-center border bg-white">
                            <asp:Image CssClass="rounded img-container bg-white" runat="server" ID="img_Producto" ImageUrl="https://www.webempresa.com/foro/wp-content/uploads/wpforo/attachments/3200/318277=80538-Sin_imagen_disponible.jpg" alt="IMG Producto" />
                        </div>
                    </div>
                    <div class="col-7 border">
                        <div class="row border">
                            <label id="lbl_Nombre" text="" class="form-label fs-2 fw-bold" runat="server">Nombre de Producto</label>
                        </div>
                        <div class="row border">

                            <label id="lbl_Marca" text="" class="form-label fs-5" runat="server">Marca</label>

                        </div>
                        <div class="row border">
                            <div class="col-4">
                                <label id="lbl_Codigo" text="" class="form-label fs-5" runat="server">COD001</label>
                            </div>
                            <div class="col-4">
                                <label id="lbl_Categoria" text="" class="form-label fs-5" runat="server">Categoria</label>
                            </div>
                            <div class="col-4">
                                <label class="form-label fs-5">Contenido:</label>
                                <label id="lbl_Contenido" text="" class="form-label fs-5" runat="server">700ml</label>
                            </div>
                        </div>
                        <div class="row border">
                            <div class="col-6">
                                <label class="form-label fs-5">Stock:</label>
                                <label id="lbl_Stock" text="" class="form-label fs-5" runat="server">999 Unidades</label>
                            </div>
                        </div>
                        <div class="row border">
                            <label id="lbl_Precio" text="" class="form-label fs-5" runat="server">$11111,00</label>
                        </div>
                        <div class="row g-0 text-center">
                            <div class="col-6">
                                <div class="input-group">
                                    <asp:Button ID="btn_RestarCantidad" CssClass="btn btn-outline-secondary" runat="server" Text="-" OnClick="btn_RestarCantidad_Click"/>
                                    <asp:TextBox runat="server" id="txt_Cantidad" CssClass="form-control fw-bold" aria-label="Ingrese cantidad" />
                                    <asp:Button ID="btn_SumarCantidad" CssClass="btn btn-outline-secondary" runat="server" Text="+" OnClick="btn_SumarCantidad_Click"/>
                                </div>
                            </div>
                            <div class="col-6">
                                <asp:Button Id="btn_Agregar" OnClick="btn_Agregar_Click" Text="Agregar al carro" CssClass="btn btn-success fw-bold" runat="server" />
                            </div>
                        </div>
                        <div class="row border">
                            <label id="Lbl_Descripcion" text="" class="form-label fs-5" runat="server">Esta es la descripcion del producto</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-1 border">
                <h2>1</h2>
            </div>
        </div>
    </div>
</asp:Content>
