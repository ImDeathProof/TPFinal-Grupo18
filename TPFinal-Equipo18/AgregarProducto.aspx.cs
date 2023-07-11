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
        public Bebida Seleccionada { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Visible = false;
            lblId.Visible = false;
            txtEstado.Visible = false;
            lblEstado.Visible = false;

            if (!IsPostBack)
            {
                //Cargo los desplegables de marca y categoria
                CategoriaNegocio categoria = new CategoriaNegocio();
                MarcaNegocio marca = new MarcaNegocio();

                List<Categoria> catLista = categoria.listar();
                List<Marca> marLista = marca.listar();

                ddlCategoria.DataSource = catLista;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataBind();

                ddlMarca.DataSource = marLista;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Nombre";
                ddlMarca.DataBind();

                txtEstado.Text = "True";
                txtEstado.Enabled = false;
            }

            if (Request.QueryString["Id"] != null && !IsPostBack)
            {

                BebidaNegocio negocio = new BebidaNegocio();
                Seleccionada = negocio.buscar(int.Parse(Request.QueryString["Id"]));

                lblId.Visible = true;
                txtId.Visible = true;
                txtId.Enabled = false;
                txtId.Text = Seleccionada.Id.ToString();
                //txtEstado.Visible = true;
                //txtEstado.Enabled = false;
                txtEstado.Text = Seleccionada.Estado.ToString();
                txtCodigo.Text = Seleccionada.Codigo;
                txtNombre.Text = Seleccionada.Nombre;
                txtDescripcion.Text = Seleccionada.Descripcion;
                txtContenido.Text = Seleccionada.ContenidoNeto.ToString();
                txtPrecio.Text = Seleccionada.Precio.ToString();
                txtImage.Text = Seleccionada.UrlImg;
                txtStock.Text = Seleccionada.Stock.ToString();

                ddlCategoria.DataValueField = Seleccionada.Categoria.Id.ToString();
                ddlMarca.DataValueField = Seleccionada.Marca.Id.ToString();

            }

        }

        protected void txtImage_TextChanged(object sender, EventArgs e)
        {
            imgProducto.ImageUrl = txtImage.Text;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            BebidaNegocio negocio = new BebidaNegocio();
            Bebida nuevo = new Bebida();
            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ContenidoNeto = decimal.Parse(txtContenido.Text);
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.UrlImg = txtImage.Text;
                nuevo.Stock = int.Parse(txtStock.Text);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);


                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
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

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                BebidaNegocio negocio = new BebidaNegocio();
                negocio.bajaLogica(int.Parse(txtId.Text));
                Response.Redirect("GestionProductos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }

        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                BebidaNegocio negocio = new BebidaNegocio();
                negocio.altaLogica(int.Parse(txtId.Text));
                Response.Redirect("GestionProductos.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BebidaNegocio negocio = new BebidaNegocio();
                negocio.eliminar(int.Parse(txtId.Text));
                Response.Redirect("GestionProductos.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }

        }
    }
}