using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPFinal_Equipo18
{
    public partial class GestionProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BebidaNegocio negocio= new BebidaNegocio();

                dgvProductos.DataSource = negocio.Listar();
                dgvProductos.DataBind();
            }
        }
    }
}