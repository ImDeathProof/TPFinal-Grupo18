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
    public partial class Perfil : System.Web.UI.Page
    {
        public Usuario Usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && (Session["Usuario"] != null))
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario aux = (Usuario)Session["usuario"];
                Usuario = negocio.BuscarCompleto(aux);

                lbl_Usuario.InnerText = Usuario.NombreUsuario;
                lbl_Apellido.InnerText = Usuario.Apellido;
                lbl_Nombre.InnerText=Usuario.Nombre;
                lbl_DNI.InnerText=Usuario.DNI;
                lbl_Email.InnerText=Usuario.Email;
                lbl_Telefono.InnerText=Usuario.Telefono;
                lbl_FNacimiento.InnerText = Usuario.FechaNacimiento.ToString("d");

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio=new UsuarioNegocio();
            try
            {
                negocio.modificar(Usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}