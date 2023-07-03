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
        public float pagoTotal { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null))
            {
                Session.Add("mensaje", "Debes loguearte para iniciar el pago ");
                Response.Redirect("Login.aspx", false);
            }

            if (!IsPostBack)
            {
                pagoTotal =(float) Session["MontoTotal"];
            }

        }

        protected void btnTerminar_Click(object sender, EventArgs e)
        {

        }
    }
}