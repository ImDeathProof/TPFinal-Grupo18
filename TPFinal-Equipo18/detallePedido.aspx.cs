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
    public partial class detallePedido : System.Web.UI.Page
    {
        public List<DetallePedido> listaDetalle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (listaDetalle != null)
            {
                if (!IsPostBack)
                {
                    Pedido pedido = (Pedido)Session["VerDetalle"];
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    PedidoNegocio pedidoNegocio = new PedidoNegocio();

                    listaDetalle = pedidoNegocio.listarDetalle(pedido.Id);

                    Usuario usuario = usuarioNegocio.BuscarCompleto(pedido.usuario.Id);


                    lblFeha.Text = pedido.Fecha.ToString();
                    lblNumPedido.Text = pedido.Id.ToString();
                    if (usuario.Domicilio != null)
                        lblDomicilio.Text = usuario.Domicilio.ToString();
                    lblEmaul.Text = usuario.Email;
                    lblTotal.Text = pedido.Importe.ToString();


                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
    }
}