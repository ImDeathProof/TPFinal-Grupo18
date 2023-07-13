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
    public partial class GestionBanners : System.Web.UI.Page
    {
        public List<Banner> ListaBanners { get; set; }
        public Banner seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BannerNegocio negocio = new BannerNegocio();
                ListaBanners = negocio.listar();

                dgvBanners.DataSource = ListaBanners;
                dgvBanners.DataBind();

                if (Request.QueryString["Id"] != null && !IsPostBack)
                {
                    seleccionado = negocio.Buscar(int.Parse(Request.QueryString["Id"]));
                    txtFecha.Text = seleccionado.Fecha.ToString(); ;
                    txtID.Text = seleccionado.Id.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtLink.Text = seleccionado.UrlImg;
                }
            }

        }

        protected void dgvBanners_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvBanners.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionBanners.aspx?Id=" + Id);
        }

        protected void dgvBanners_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void tbnModificar_Click(object sender, EventArgs e)
        {
            Banner modificado = new Banner();
            BannerNegocio negocio = new BannerNegocio();
            modificado = negocio.Buscar(int.Parse(Request.QueryString["Id"]));


            try
            {
                modificado.Nombre = txtNombre.Text;
                modificado.UrlImg = txtLink.Text;
                negocio.Modificar(modificado);
                Response.Redirect("GestionBanners.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }
    }
}