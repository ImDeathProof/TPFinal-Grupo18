using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinal_Equipo18
{
    public partial class GestionPedidos : System.Web.UI.Page
    {
        public List<Pedido> listaPedidos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario.IdTipoUser == Dominio.TipoUsuario.ADMIN)
                {
                    PedidoNegocio negocio = new PedidoNegocio();

                    listaPedidos = negocio.Listar();
                    if (!IsPostBack)
                    {

                        dgvPedidos.DataSource = listaPedidos;

                        dgvPedidos.DataBind();

                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void dgvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlEstados = (DropDownList)e.Row.FindControl("ddlEstados");


                    EstadoPedidoNegocio negocio = new EstadoPedidoNegocio();
                    List<EstadoPedido> estados = negocio.listar();


                    ddlEstados.DataSource = estados;
                    ddlEstados.DataTextField = "Descripcion";
                    ddlEstados.DataValueField = "Id";
                    ddlEstados.DataBind();


                    ddlEstados.Items.Insert(0, new ListItem("Cambiar estado"));
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PedidoNegocio negocio = new PedidoNegocio();
                listaPedidos = negocio.Listar();

                DropDownList ddlEstados = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddlEstados.NamingContainer;

                int index = row.RowIndex;

                string idEstado = ddlEstados.SelectedValue.ToString();

                int id = listaPedidos[index].Id;

                negocio.cambiarEstado(id, int.Parse(idEstado));

                Response.Redirect("GestionPedidos.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        

        protected void dgvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "VerDetalle")
                {
                    int index = Convert.ToInt32(e.CommandArgument);

                    Pedido aux = listaPedidos[index];

                    Session.Add("VerDetalle", aux);

                    Response.Redirect("detallePedido.aspx", false);

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}