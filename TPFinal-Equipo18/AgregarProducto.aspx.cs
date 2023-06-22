using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Dominio;
using Negocio;

namespace TPFinal_Equipo18
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Visible= false;

            if (!IsPostBack)
            {
               //Cargo los desplegables de marca y categoria
                CategoriaNegocio categoria=new CategoriaNegocio();
                MarcaNegocio marca=new MarcaNegocio();

                List<Categoria> catLista = categoria.listar();
                List<Marca> marLista= marca.listar();

                ddlCategoria.DataSource= catLista;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField= "Nombre";
                ddlCategoria.DataBind();

                ddlMarca.DataSource= marLista;
                ddlMarca.DataValueField= "Id";
                ddlMarca.DataTextField= "Nombre";
                ddlMarca.DataBind();
            }

            if (Request.QueryString["Id"]!=null && !IsPostBack){

                BebidaNegocio negocio=new BebidaNegocio();
                Bebida seleccionada= negocio.buscar(int.Parse(Request.QueryString["Id"]));

                txtId.Visible = true;
                txtId.Enabled= false;
                txtId.Text = seleccionada.Id.ToString();
                txtCodigo.Text=seleccionada.Codigo;
                txtNombre.Text=seleccionada.Nombre;
                txtDescripcion.Text = seleccionada.Descripcion;
                txtContenido.Text= seleccionada.ContenidoNeto.ToString();
                txtPrecio.Text=seleccionada.Precio.ToString();
                txtImage.Text = seleccionada.UrlImg;

                ddlCategoria.DataValueField=seleccionada.Categoria.Id.ToString();
                ddlMarca.DataValueField=seleccionada.Marca.Id.ToString();

            }

        }

        protected void txtImage_TextChanged(object sender, EventArgs e)
        {
            imgProducto.ImageUrl = txtImage.Text;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            BebidaNegocio negocio=new BebidaNegocio();
            Bebida nuevo=new Bebida();
            try
            {
                nuevo.Codigo= txtCodigo.Text;
                nuevo.Nombre= txtNombre.Text;
                nuevo.Descripcion= txtDescripcion.Text;
                nuevo.ContenidoNeto= decimal.Parse(txtContenido.Text);
                nuevo.Precio=decimal.Parse(txtPrecio.Text);
                nuevo.UrlImg=txtImage.Text;
                
                nuevo.Marca=new Marca();
                nuevo.Marca.Id= int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id= int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);

                }

                Response.Redirect("GestionProductos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error");
            }
        }
    }
}