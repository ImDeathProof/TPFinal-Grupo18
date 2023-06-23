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
            if(!IsPostBack)
            {
                ddlListado.Items.Insert(0, "Listado de bebidas");
                ddlListado.Items.Insert(1, "Listado de marcas");
                ddlListado.Items.Insert(2, "Listado de categorias");

                BebidaNegocio negocio= new BebidaNegocio();
                MarcaNegocio marcaNegocio= new MarcaNegocio();
                CategoriaNegocio categoriaNegocio=new CategoriaNegocio();

                dgvProductos.DataSource = negocio.Listar();
                dgvProductos.DataBind();

                dgvCategorias.DataSource= categoriaNegocio.listar();
                dgvCategorias.DataBind();

                dgvMarcas.DataSource= marcaNegocio.listar();
                dgvMarcas.DataBind();

                divAgregarMarca.Visible= false;
            }

        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarProducto.aspx?Id=" + Id);
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            divAgregarMarca.Visible = true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio negocio= new MarcaNegocio();
                Marca nueva=new Marca();
                nueva.Nombre=txtMarca.Text;

                negocio.agregar(nueva);
                Response.Redirect("GestionProductos.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}