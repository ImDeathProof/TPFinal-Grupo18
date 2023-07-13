<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="TPFinal_Equipo18.GestionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="container col-10 border p-3 text-bg-dark border-primary border-2 border-opacity-75">
            <h2>Gestion de usuarios </h2>

            <div class="row justify-content-center">
                <div>
                    <asp:GridView ID="dgvUsuarios" runat="server" CssClass="table table-dark table-striped border text-bg-dark border-primary border-2 border-opacity-75" AutoGenerateColumns="false"
                        DataKeyNames="Id" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" OnRowCommand="dgvUsuarios_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="Id" />
                            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                            <asp:BoundField HeaderText="E-mail" DataField="Email" />
                            <asp:BoundField HeaderText="Estado" DataField="Estado" />
                            <asp:TemplateField HeaderText="Acción">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnAccion" runat="server" Text='<%# GetButtonText(Eval("Estado")) %>'
                                        CommandName="Accion" CommandArgument=' <%#((GridViewRow)Container).RowIndex%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                    </asp:GridView>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
