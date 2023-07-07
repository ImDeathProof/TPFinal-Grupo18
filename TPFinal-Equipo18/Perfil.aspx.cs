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
            string rutaActual = Request.Url.AbsolutePath.ToString();

            if (!IsPostBack && (Session["Usuario"] != null))
            {
                if (rutaActual == "/Perfil.aspx")
                {
                    divMisPedidos.Visible = false;
                    divDatosUsuario.Visible = true;
                    divDatosDomicilio.Visible = false;
                }
                else if (rutaActual == "/Perfil.aspx/Domicilio")
                {
                    divMisPedidos.Visible = false;
                    divDatosUsuario.Visible = false;
                    divDatosDomicilio.Visible = true;
                }
                else if (rutaActual == "/Perfil.aspx/Mis-Pedidos")
                {
                    divMisPedidos.Visible = true;
                    divDatosDomicilio.Visible = false;
                    divDatosUsuario.Visible = false;
                }
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario aux = (Usuario)Session["usuario"];
                Usuario = negocio.BuscarCompleto(aux);
                ///CARGA DE USUARIO
                lbl_Usuario.InnerText = Usuario.NombreUsuario;
                lbl_Estado.InnerText = Usuario.Estado == true ? "Activo" : "Bloqueado";
                
                txt_Apellido.Text = Usuario.Apellido;
                txt_Nombre.Text = Usuario.Nombre;
                txt_DNI.Text = Usuario.DNI;
                txt_Email.Text = Usuario.Email;
                txt_Telefono.Text = Usuario.Telefono;
                txt_FNacimiento.Text = Usuario.FechaNacimiento.ToString("yyyy-MM-dd");
                ///CARGA DE DOMICILIO
                ///HAY QUE AGREGAR LAS VERIFICACIONES EN CASO QUE NO TENGA DOMICILIO
                lbl_Calle.InnerText = Usuario.Domicilio.Calle;
                lbl_Numero.InnerText = Usuario.Domicilio.Numero;
                lbl_Provincia.InnerText = Usuario.Domicilio.Provincia;
                lbl_Partido.InnerText = Usuario.Domicilio.Partido;
                lbl_Localidad.InnerText = Usuario.Domicilio.Localidad;
                lbl_Departamento.InnerText = Usuario.Domicilio.Departamento;
                lbl_Piso.InnerText = Usuario.Domicilio.Piso;
                ///CARGA DE PEDIDOS
            }
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            Usuario Nuevo;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Nuevo = new Usuario();
                if (negocio.Buscar(lbl_Usuario.InnerText) == true)
                {
                    ///Cargamos los datos en el nuevo usuario
                    Nuevo.NombreUsuario = lbl_Usuario.InnerText;
                    Nuevo.Nombre = txt_Nombre.Text;
                    Nuevo.Apellido = txt_Apellido.Text;
                    Nuevo.Email = txt_Email.Text;
                    Nuevo.DNI = txt_DNI.Text;
                    Nuevo.Telefono = txt_Telefono.Text;
                    Nuevo.FechaNacimiento = DateTime.Parse(txt_FNacimiento.Text);
                    ///Lo cargamos a la base de datos
                    negocio.Modificar(Nuevo);
                    Response.Redirect("Perfil.aspx", false);

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