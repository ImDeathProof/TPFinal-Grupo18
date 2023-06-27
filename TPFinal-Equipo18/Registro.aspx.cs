using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinal_Equipo18.LogIn
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblAlertaUsuario.Visible = false;
            }
        }
        public void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario Nuevo;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Nuevo = new Usuario();
                if (negocio.Buscar(txtUsuario.Text)==false)
                {
                    ///Cargamos los datos en el nuevo usuario
                    Nuevo.NombreUsuario = txtUsuario.Text;
                    Nuevo.Nombre = txtNombre.Text;
                    Nuevo.Apellido = txtApellido.Text;
                    Nuevo.Contraseña = txtPass.Text;
                    Nuevo.Email = txtEmail.Text;
                    Nuevo.DNI = int.Parse(txtDNI.Text);
                    Nuevo.Telefono = txtTelefono.Text;
                    Nuevo.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                    ///Lo cargamos a la base de datos
                    negocio.Registrar(Nuevo);
                    negocio.Loguear(Nuevo);
                    Session.Add("usuario", Nuevo);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblAlertaUsuario.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                //throw ex;
            }
        }
    }
}