using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace TPFinal_Equipo18
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        public List<Usuario> listaUsuarios { get; set; }
        int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                UsuarioNegocio negocio = new UsuarioNegocio();

                listaUsuarios = negocio.Listar();
                dgvUsuarios.DataSource = listaUsuarios;

                dgvUsuarios.DataBind();
            }
        }
        protected string GetButtonText(object estado)
        {
            string nombreBoton = string.Empty;


            string estadoTexto = estado.ToString();

            // Asigna el nombre del botón según el valor de "Estado"
            if (estadoTexto == "True")
            {
                return "Bloquear";
            }
            else
            {
                return "Desbloquear";
            }

        }
        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id1 = dgvUsuarios.SelectedDataKey.Value.ToString();
            Id = int.Parse(Id1);
        }
        protected void dgvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accion")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvUsuarios.Rows[rowIndex];

                // Obtener la ID del usuario
                Id = int.Parse(row.Cells[0].Text);

                //Accion de bloquear o desbloquear
                UsuarioNegocio neg = new UsuarioNegocio();

                LinkButton linkButton = row.FindControl("btnAccion") as LinkButton;
                if (linkButton.Text == "Bloquear")
                {
                    neg.Bloquear(Id);
                }
                else
                {
                    neg.Desbloquear(Id);
                }
                Response.Redirect("GestionUsuarios.aspx", false);
            }
        }

    }
}