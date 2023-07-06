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

            if (estado != null)
            {
                string estadoTexto = estado.ToString();

                // Asigna el nombre del botón según el valor de "Estado"
                if (estadoTexto == "True")
                {
                    nombreBoton = "Bloquear";
                }
                else
                {
                    nombreBoton = "Desbloquear";
                }
            }

            return nombreBoton;
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

                // Obtener la ID del pedido
                string idUsuario = row.Cells[0].Text; // Suponiendo que la columna "ID" es la primera (índice 0)
                Id = int.Parse(idUsuario);
                // Realizar acciones con la ID obtenida
                // ...
            }
        }
        protected void btnAccion_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            UsuarioNegocio neg = new UsuarioNegocio();
            

            if (btn.Text.ToString() == "Bloquear")
            {
                neg.Bloquear(Id);
            }
            else
            {
                neg.Desbloquear(Id);
            }
            listaUsuarios = neg.Listar();
            dgvUsuarios.DataSource = listaUsuarios;

            dgvUsuarios.DataBind();
            
        }
    }
}