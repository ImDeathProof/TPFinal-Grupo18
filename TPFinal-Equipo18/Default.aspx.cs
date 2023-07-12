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
                string rutaActual = Request.Url.AbsolutePath.ToString();
                if (rutaActual == "/Default.aspx/Importado")
                {
                    Session.Add("listaBebidas", negocio.ListarPorTipo("Importado"));
                    listaBebidas = (List<Bebida>)Session["listaBebidas"];
                }
                else if(rutaActual == "/Default.aspx/Alcoholica")
                {
                    Session.Add("listaBebidas", negocio.ListarPorTipo("Alcoholica"));
                    listaBebidas = (List<Bebida>)Session["listaBebidas"];
                }
                else if (rutaActual == "/Default.aspx/SinAlcohol")
                {
                    Session.Add("listaBebidas", negocio.ListarPorTipo("SinAlcohol"));
                    listaBebidas = (List<Bebida>)Session["listaBebidas"];
                }
                else
                {
                    Session.Add("listaBebidas", negocio.Listar());
                    listaBebidas = (List<Bebida>)Session["listaBebidas"];
                }
            }

            if (Request.QueryString["Id"] != null)
            {
                List<CarritoClase> carritoBebidas;
                BebidaNegocio negocio = new BebidaNegocio();
                Bebida seleccionado;
                CarritoClase carrito = new CarritoClase();

                if (Session["Bebidas"] == null)
                {
                    carritoBebidas = new List<CarritoClase>();
                }
                else
                {
                    carritoBebidas = (List<CarritoClase>)Session["Bebidas"];
                }
                string id = Request.QueryString["Id"];

                seleccionado = negocio.buscar(int.Parse(id));

                carrito.Bebida = seleccionado;

                carritoBebidas.Add(carrito);

                Session.Add("Bebidas", carritoBebidas);
            }

        }
    }
}