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
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        public List<Usuario> listaUsuarios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                UsuarioNegocio negocio = new UsuarioNegocio();

                listaUsuarios = negocio.Listar();
                dgvPedidos.DataSource = listaUsuarios;

                dgvPedidos.DataBind();
            }
        }

        protected void cbEstado_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void cbEstado_CheckedChanged1(object sender, EventArgs e)
        {

        }
    }
}