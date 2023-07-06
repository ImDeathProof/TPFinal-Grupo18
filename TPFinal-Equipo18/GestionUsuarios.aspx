<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="TPFinal_Equipo18.GestionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container border p-3">
        <h2>Gestion de pedidos </h2>

        <div class="row">
            <div class="col 10">
                <asp:GridView ID="dgvUsuarios" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false"
                    DataKeyNames="Id" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" OnRowCommand="dgvUsuarios_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                        <asp:BoundField HeaderText="E-mail" DataField="Email" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:LinkButton id="btnAccion" runat="server" Text='<%# GetButtonText(Eval("Estado")) %>'
                                    CommandName="Accion" CommandArgument=' <%#((GridViewRow)Container).RowIndex%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>

        </div>

    </div>
</asp:Content>
