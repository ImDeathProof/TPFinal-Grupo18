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
                    List<CarritoClase> aux = new List<CarritoClase>();
                    aux = (List<CarritoClase>)Session["Bebidas"];

                    foreach (CarritoClase c in aux)
                    {
                        c.Precio = c.Bebida.Precio * c.Cantidad;
                    }

                    dgvCarrito.DataSource = aux;
                    dgvCarrito.DataBind();

                    precioTotal = aux.Sum(x => x.Bebida.Precio *(x.Cantidad));

                    lblTotal.Text = precioTotal.ToString();
                }

            }
                   

        }

        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                List<CarritoClase> aux = (List<CarritoClase>)Session["Bebidas"];

                aux.RemoveAt(index);
                Session["Bebidas"] = aux;

                dgvCarrito.DataSource = aux;
                dgvCarrito.DataBind();

                Response.Redirect("Carrito.aspx", false);

            }
            else if (e.CommandName == "Agregar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                List<CarritoClase> aux = (List<CarritoClase>)Session["Bebidas"];

                if (aux[index].Cantidad< aux[index].Bebida.Stock)
                {
                    aux[index].Cantidad++;
                    Session["Bebidas"] = aux;

                    dgvCarrito.DataSource = aux;
                    dgvCarrito.DataBind();

                    Response.Redirect("Carrito.aspx", false);

                }

               

            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument);

                List<CarritoClase> aux = (List<CarritoClase>)Session["Bebidas"];

                if (aux[index].Cantidad >1)
                {
                    aux[index].Cantidad--;
                    Session["Bebidas"] = aux;

                    dgvCarrito.DataSource = aux;
                    dgvCarrito.DataBind();

                    Response.Redirect("Carrito.aspx", false);
                }

            }
        }

        protected void btnIniciarPago_Click(object sender, EventArgs e)
        {
            decimal monto= decimal.Parse( lblTotal.Text);
            if (monto > 0)
            {
                Session.Add("MontoTotal", monto);
                Response.Redirect("Pagos.aspx");

            }

        }
        //No funciona
        //    protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        //    {
        //        int id = int.Parse( dgvCarrito.SelectedDataKey.Value.ToString());

        //        Bebida eliminado= new Bebida();
        //        BebidaNegocio negocio= new BebidaNegocio();

        //        eliminado = negocio.buscar(id);

        //        List<Bebida> aux = (List<Bebida>)Session["Bebidas"];



        //        foreach (Bebida b in aux)
        //        {
        //            if (b.Id == id)
        //            {
        //                aux.Remove(b);
        //            }
        //        }

        //        Session.Add("Bebidas", aux);

        //        Response.Redirect("Carrito.aspx", false);
        //    }
    }
}