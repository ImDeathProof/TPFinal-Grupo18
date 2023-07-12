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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mensaje"] != null)
            {
                lblMsj.Text =(string) Session["mensaje"];
            }
            else
            {
                lblMsj.Visible= false;
            }

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario = new Usuario(txtUser.Text, txtPass.Text, false);
                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session.Add("error", "Mail o Pass incorrecta");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }

        }
    }
}