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
    public partial class Carrito : System.Web.UI.Page
    {
        public decimal precioTotal { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)

            {
                if (Session["Bebidas"] != null)
                {
                    List<Bebida> aux = new List<Bebida>();
                    aux = (List<Bebida>)Session["Bebidas"];

                    dgvCarrito.DataSource = aux;
                    dgvCarrito.DataBind();

                    precioTotal = aux.Sum(x => x.Precio);

                    lblTotal.Text = precioTotal.ToString();
                }
            }
                   

        }
        //No funciona
        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse( dgvCarrito.SelectedDataKey.Value.ToString());

            List<Bebida> aux = (List <Bebida>) Session["Bebidas"];
            
            foreach (Bebida b in aux)
            {
                if (b.Id == id)
                {
                    aux.Remove(b);
                }
            }

            Session.Add("Bebidas", aux);

            Response.Redirect("Carrito.aspx", false);
        }
    }
}