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
        public List<EstadoPedido> listaEstados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            EstadoPedidoNegocio estadoNegocio= new EstadoPedidoNegocio();
            listaEstados = estadoNegocio.listar();
            
            if (!IsPostBack)
            {
                
                PedidoNegocio negocio= new PedidoNegocio();

                dgvPedidos.DataSource = negocio.Listar();
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
    }
}