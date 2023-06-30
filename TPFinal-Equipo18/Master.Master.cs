using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinal_Equipo18
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public Usuario user = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    user = (Usuario)Session["usuario"];
                    btnLogout.Visible = true;
                    linkPerfil.Visible = true;
                    linkRegistro.Visible = false;
                    linkLogIn.Visible = false;
                }
                else
                {
                    btnLogout.Visible = false;
                    linkPerfil.Visible = false;
                    linkLogIn.Visible = true;
                    linkRegistro.Visible = true;
                }
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    Session.Remove("usuario");
                    Response.Redirect("/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}