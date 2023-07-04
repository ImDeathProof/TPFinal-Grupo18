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
            
            
            
            if (!IsPostBack)
            {
                
                PedidoNegocio negocio= new PedidoNegocio();

                listaPedidos= negocio.Listar();
                dgvPedidos.DataSource = listaPedidos;

                dgvPedidos.DataBind();
                
                
                
            }
        }

        protected void dgvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            PedidoNegocio negocio= new PedidoNegocio();
            listaPedidos=negocio.Listar();

            DropDownList ddlEstados = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlEstados.NamingContainer;

            int index = row.RowIndex;

            string idEstado= ddlEstados.SelectedValue.ToString();

            int id = listaPedidos[index].Id;

            negocio.cambiarEstado(id,int.Parse(idEstado));

            Response.Redirect("GestionPedidos.aspx");

        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPedidos.SelectedDataKey.Values.ToString();

            //string idEstado = ddlEstados.SelectedValue.ToString();
        }
    }
}