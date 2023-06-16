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
            if(!IsPostBack)
            {
                BebidaNegocio negocio= new BebidaNegocio();

                listaBebidas = negocio.Listar();
            }

        }
    }
}