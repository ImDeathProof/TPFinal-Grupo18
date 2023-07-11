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
    public partial class Pagos : System.Web.UI.Page
    {
        public decimal pagoTotal { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null))
            {
                Session.Add("mensaje", "Debes loguearte para iniciar el pago ");
                Response.Redirect("Login.aspx", false);
            }

           
                pagoTotal =(decimal) Session["MontoTotal"];
                
            

        }

        protected void btnTerminar_Click(object sender, EventArgs e)
        {
           
            try
            {
                List<CarritoClase> carritoClases = (List<CarritoClase>)Session["Bebidas"];
                BebidaNegocio bebidaNegocio= new BebidaNegocio();

                foreach (CarritoClase cc in carritoClases)
                {
                    bebidaNegocio.descontarStock(cc.Bebida.Id, cc.Cantidad);
                    

                }



                PedidoNegocio negocio= new PedidoNegocio();
                Pedido pedido = new Pedido();
                Usuario usuario = (Usuario)Session["usuario"];

                pedido.usuario=new Usuario();
                pedido.usuario.Id = usuario.Id;
                pedido.Importe = pagoTotal;
                pedido.MedioPago = 1;
                pedido.Estado=new EstadoPedido();
                pedido.Estado.Id = 1;
                if (rblEntrega.SelectedValue == "1")
                {
                    pedido.Entrega = "Entrega a domicilio";
                }
                else
                {
                    pedido.Entrega = " Rertira por sucursal";
                }
                
                int idPedido=negocio.agregar(pedido);

                foreach (CarritoClase cc in carritoClases)
                {
                    negocio.guardarDetalle(idPedido,cc.Bebida.Id, cc.Cantidad, cc.Precio);

                }

                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx");
            }


        }
    }
}