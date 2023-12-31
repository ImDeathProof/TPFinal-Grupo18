﻿using Dominio;
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
        public Usuario usuario { get; set; }
        public decimal pagoTotal { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Session.Add("mensaje", "Debes loguearte para iniciar el pago ");
                Response.Redirect("Login.aspx", false);
            }
            else if (Session["MontoTotal"] != null)
            {

                if (!IsPostBack)
                {
                }
                    pagoTotal = (decimal)Session["MontoTotal"];
                    lblMontoTotal.Text = pagoTotal.ToString();
            }
        }






        protected void btnTerminar_Click(object sender, EventArgs e)
        {

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }


                List<CarritoClase> carritoClases = (List<CarritoClase>)Session["Bebidas"];
                BebidaNegocio bebidaNegocio = new BebidaNegocio();

                foreach (CarritoClase cc in carritoClases)
                {
                    bebidaNegocio.descontarStock(cc.Bebida.Id, cc.Cantidad);


                }


                PedidoNegocio negocio = new PedidoNegocio();
                Pedido pedido = new Pedido();
                UsuarioNegocio Usernegocio = new UsuarioNegocio();
                Usuario aux = (Usuario)Session["usuario"];
                usuario = Usernegocio.BuscarCompleto(aux.Id);
                Session["usuario"] = usuario;

                pedido.usuario = new Usuario();
                pedido.usuario.Id = usuario.Id;
                pedido.Importe = pagoTotal;
                pedido.MedioPago = 1;
                pedido.Estado = new EstadoPedido();
                pedido.Estado.Id = 1;
                pedido.NumOperacion = txtNumeroOperacion.Text;
                if (rblEntrega.SelectedValue == "1")
                {
                    pedido.Entrega = "Entrega a domicilio";
                }
                else
                {
                    pedido.Entrega = "Rertira por sucursal";
                }

                int idPedido = negocio.agregar(pedido);

                foreach (CarritoClase cc in carritoClases)
                {
                    negocio.guardarDetalle(idPedido, cc.Bebida.Id, cc.Cantidad, cc.Precio);

                }

                EmailService emailService = new EmailService();
                emailService.armarCorreo(usuario.Email, "Confirmación de pedido", "Gracias por tu compra, estamos preparando tu pedido");
                try
                {
                    emailService.enviarEmail();

                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                }
                carritoClases.Clear();
                Session["Bebidas"] = carritoClases;
                Response.Redirect("Default.aspx", false);

                //ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", "openModal();", true);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }


        }
    }
}