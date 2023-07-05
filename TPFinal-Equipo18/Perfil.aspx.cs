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
                ///CARGA DE USUARIO
                lbl_Usuario.InnerText = Usuario.NombreUsuario;
                lbl_Apellido.InnerText = Usuario.Apellido;
                lbl_Nombre.InnerText = Usuario.Nombre;
                lbl_DNI.InnerText = Usuario.DNI;
                lbl_Email.InnerText = Usuario.Email;
                lbl_Telefono.InnerText = Usuario.Telefono;
                lbl_FNacimiento.InnerText = Usuario.FechaNacimiento.ToString("d");
                lbl_Estado.InnerText = Usuario.Estado == true ? "Activo" : "Bloqueado";
                ///CARGA DE DOMICILIO
                ///HAY QUE AGREGAR LAS VERIFICACIONES EN CASO QUE NO TENGA DOMICILIO
                lbl_Calle.InnerText = Usuario.Domicilio.Calle;
                lbl_Numero.InnerText = Usuario.Domicilio.Numero;
                lbl_Provincia.InnerText = Usuario.Domicilio.Provincia;
                lbl_Partido.InnerText = Usuario.Domicilio.Partido;
                lbl_Localidad.InnerText = Usuario.Domicilio.Localidad;
                lbl_Departamento.InnerText = Usuario.Domicilio.Departamento;
                lbl_Piso.InnerText = Usuario.Domicilio.Piso;
            }
        }
    }
}