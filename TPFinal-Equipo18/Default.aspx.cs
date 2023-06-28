using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPFinal_Equipo18
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Bebida> listaBebidas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BebidaNegocio negocio = new BebidaNegocio();
                listaBebidas = negocio.Listar();
            }

            if (Request.QueryString["Id"] != null)
            {
                List<Bebida> carritoBebidas;
                BebidaNegocio negocio = new BebidaNegocio();
                Bebida seleccionado;

                if (Session["Bebidas"] == null)
                {
                    carritoBebidas = new List<Bebida>();
                }
                else
                {
                    carritoBebidas = (List<Bebida>)Session["Bebidas"];
                }
                string id = Request.QueryString["Id"];

                seleccionado = negocio.buscar(int.Parse(id));

                carritoBebidas.Add(seleccionado);

                Session.Add("Bebidas", carritoBebidas);
            }

        }
    }
}