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
                    txtFecha.Text = seleccionado.Fecha.ToString();
                    txtID.Text = seleccionado.Id.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtLink.Text = seleccionado.UrlImg;
                }
                txtID.Visible = true;
                txtID.Enabled = false;
                txtFecha.Visible = true;
                txtFecha.Enabled = false;
                txtFecha.Text = DateTime.Now.ToString();

                BannerNegocio neg = new BannerNegocio();
                List<Banner> listaBanners = neg.listar();
                if (listaBanners.Count < 5)
                {
                    btnModificar.Text = "Agregar";
                }
                else
                {
                    btnModificar.Text = "Modificar";
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Banner banner = new Banner();
            BannerNegocio negocio = new BannerNegocio();
            if (btnModificar.Text == "Agregar")
            {
                try
                {
                    banner.Nombre = txtNombre.Text;
                    banner.UrlImg = txtLink.Text;
                    negocio.Guardar(banner);
                    Response.Redirect("GestionBanners.aspx", false);
                }
                catch (Exception ex)
                {
                    //Session.Add("Error", ex);
                    throw ex;
                }
            }
            else if (btnModificar.Text == "Modificar")
            {
                banner = negocio.Buscar(int.Parse(Request.QueryString["Id"]));
                try
                {
                    banner.Nombre = txtNombre.Text;
                    banner.UrlImg = txtLink.Text;
                    negocio.Modificar(banner);
                    Response.Redirect("GestionBanners.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                }

            }
        }
        //protected string GetButtonText()
        //{
        //    string nombreBoton = string.Empty;
        //    BannerNegocio neg = new BannerNegocio();
        //    List<Banner> listaBanners = neg.listar();
        //    if (listaBanners.Count < 5)
        //    {
        //        return "Agregar";
        //    }
        //    else
        //    {
        //        return "Modificar";
        //    }
        //}
    }
}