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
        public float pagoTotal { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null))
            {
                Session.Add("mensaje", "Debes loguearte para iniciar el pago ");
                Response.Redirect("Login.aspx", false);
            }

            if (!IsPostBack)
            {
                pagoTotal =(float) Session["MontoTotal"];
                
            }

        }

        protected void btnTerminar_Click(object sender, EventArgs e)
        {
           
            try
            {
                PedidoNegocio negocio= new PedidoNegocio();
                Pedido pedido = new Pedido();
                Usuario usuario = (Usuario)Session["usuario"];

                pedido.usuario.Id = usuario.Id;
                pedido.Importe = pagoTotal;
                pedido.MedioPago = 1;
                if (rblEntrega.SelectedValue == "1")
                {
                    pedido.Entrega = "Entrega a domicilio";
                }
                else
                {
                    pedido.Entrega = " Rertira por sucursal";
                }
                pedido.Estado.Id = 1;


                //Falta desarrollar
                negocio.agregar(pedido);


            }
            catch (Exception ex)
            {
                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx");
            }


        }
    }
}