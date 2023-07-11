using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinal_Equipo18
{
    public partial class DetalleBebida : System.Web.UI.Page
    {
        public int Id { get; set; }
        public Bebida bebida { get; set; }
        public int cantProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Id = int.Parse(Request.QueryString["id"]);
                BebidaNegocio bebidaNegocio = new BebidaNegocio();
                bebida = bebidaNegocio.buscar(Id);
                Session.Add("DetalleProducto", bebida);

                lbl_Categoria.InnerText = bebida.Categoria.Nombre;
                lbl_Codigo.InnerText = bebida.Codigo;
                lbl_Marca.InnerText = bebida.Marca.Nombre;
                lbl_Precio.InnerText = bebida.Precio.ToString("C2");
                lbl_Stock.InnerText = bebida.Stock.ToString();
                lbl_Contenido.InnerText = bebida.ContenidoNeto.ToString("#,00") + "ml";
                lbl_Nombre.InnerText = bebida.Nombre;
                Lbl_Descripcion.InnerText = bebida.Descripcion;
                img_Producto.ImageUrl = bebida.UrlImg;

                cantProductos = 1;
                Session.Add("cantProductos", cantProductos);
                txt_Cantidad.Text = cantProductos.ToString();
            }
        }

        protected void btn_SumarCantidad_Click(object sender, EventArgs e)
        {
            cantProductos = (int)Session["cantProductos"];
            bebida = (Bebida)Session["DetalleProducto"];
            if (cantProductos < bebida.Stock)
            {
                cantProductos++;
                Session["cantProductos"] = cantProductos;
                txt_Cantidad.Text = cantProductos.ToString();
            }
        }

        protected void btn_RestarCantidad_Click(object sender, EventArgs e)
        {
            cantProductos = (int)Session["cantProductos"];
            bebida = (Bebida)Session["DetalleProducto"];
            if (cantProductos > 1)
            {
                cantProductos--;
                Session["cantProductos"] = cantProductos;
                txt_Cantidad.Text = cantProductos.ToString();
            }
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
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
            carrito.Cantidad = (int)Session["cantProductos"];

            carritoBebidas.Add(carrito);

            Session.Add("Bebidas", carritoBebidas);
        }
    }
}