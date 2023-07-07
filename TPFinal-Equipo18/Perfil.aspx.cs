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
        public Usuario usuario { get; set; }
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
                usuario = negocio.BuscarCompleto(aux);
                Session["usuario"]= usuario;
                ///CARGA DE USUARIO
                lbl_Usuario.InnerText = usuario.NombreUsuario;
                lbl_Estado.InnerText = usuario.Estado == true ? "Activo" : "Bloqueado";

                avatarUsuario.ImageUrl = "~/Images/Profile/" + usuario.Avatar;

                txt_Apellido.Text = usuario.Apellido;
                txt_Nombre.Text = usuario.Nombre;
                txt_DNI.Text = usuario.DNI;
                txt_Email.Text = usuario.Email;
                txt_Telefono.Text = usuario.Telefono;
                txt_FNacimiento.Text = usuario.FechaNacimiento.ToString("yyyy-MM-dd");
                ///CARGA DE DOMICILIO
                ///HAY QUE AGREGAR LAS VERIFICACIONES EN CASO QUE NO TENGA DOMICILIO
                txt_Calle.Text = usuario.Domicilio.Calle;
                txt_Numero.Text = usuario.Domicilio.Numero;
                txt_Provincia.Text = usuario.Domicilio.Provincia;
                txt_Partido.Text = usuario.Domicilio.Partido;
                txt_Localidad.Text = usuario.Domicilio.Localidad;
                txt_Departamento.Text = usuario.Domicilio.Departamento;
                txt_Piso.Text = usuario.Domicilio.Piso;
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

        protected void btnGuardarImg_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio neg = new UsuarioNegocio();
                usuario = (Usuario)Session["usuario"];
                string ruta = Server.MapPath("./Images/Profile/");
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");

                usuario.Avatar = "perfil-" + usuario.Id + ".jpg";


                neg.CambiarAvatar(usuario);
                Session["usuario"] = usuario;
                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}