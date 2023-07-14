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
                else if (rutaActual == "/Default.aspx/Alcoholica")
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

                BannerNegocio bnegocio = new BannerNegocio();
                List<Banner> listaBanners = new List<Banner>();

                listaBanners = bnegocio.listar();
                if (listaBanners != null)
                {
                    divCarouselBanners.Visible = true;
                    Image1.ImageUrl = listaBanners[0].UrlImg;
                    if (listaBanners.Count>1)
                    {
                        Image2.ImageUrl = listaBanners[1].UrlImg;
                    }
                    else
                    {
                        carousel_2.Visible = false;
                        Image2.Visible = false;
                    }
                    if (listaBanners.Count > 2)
                    {
                        Image3.ImageUrl = listaBanners[2].UrlImg;
                    }
                    else
                    {
                        carousel_3.Visible = false;
                        Image3.Visible = false;
                    }
                    if (listaBanners.Count > 3)
                    {
                        Image4.ImageUrl = listaBanners[3].UrlImg;
                    }
                    else
                    {
                        carousel_4.Visible = false;
                        Image4.Visible = false;
                    }
                    if (listaBanners.Count > 4)
                    {
                        Image5.ImageUrl = listaBanners[4].UrlImg;
                    }
                    else
                    {
                        carousel_5.Visible = false;
                        Image5.Visible = false;
                    }


                }
                else
                {
                    divCarouselBanners.Visible = false;
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