using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPFinal_Equipo18
{
    public partial class GestionProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlListado.Items.Insert(0, "Listado de bebidas");
                ddlListado.Items.Insert(1, "Listado de marcas");
                ddlListado.Items.Insert(2, "Listado de categorias");

                BebidaNegocio negocio = new BebidaNegocio();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                dgvProductos.DataSource = negocio.Listar();
                dgvProductos.DataBind();

                dgvCategorias.DataSource = categoriaNegocio.listar();
                dgvCategorias.DataBind();

                dgvMarcas.DataSource = marcaNegocio.listar();
                dgvMarcas.DataBind();

                divAgregarMarca.Visible = false;
                divAgregarCategoria.Visible = false;
            }

        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarProducto.aspx?Id=" + Id);
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (divAgregarCategoria.Visible == true)
            {
                divAgregarCategoria.Visible = false;
                divAgregarMarca.Visible = true;
            }
            else
            {
                divAgregarMarca.Visible = true;
            }
        }
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (divAgregarMarca.Visible == true)
            {
                divAgregarMarca.Visible=false;
                divAgregarCategoria.Visible = true;
            }
            else
            {
                divAgregarCategoria.Visible = true;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (divAgregarMarca.Visible == true)
            {
                divAgregarMarca.Visible = false;
            }
            else
            {
                divAgregarCategoria.Visible=false;
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (divAgregarMarca.Visible == true)
            {
                try
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca nueva = new Marca();
                    nueva.Nombre = txtMarca.Text;

                    negocio.agregar(nueva);
                    Response.Redirect("GestionProductos.aspx", false);

                }
                catch (Exception ex)
                {

                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }
            else if (divAgregarCategoria.Visible == true)
            {
                try
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Categoria nueva = new Categoria();
                    nueva.Nombre = txtCategoria.Text;

                    negocio.agregar(nueva);
                    Response.Redirect("GestionProductos.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                    throw;
                }
            }
        }
    }
}