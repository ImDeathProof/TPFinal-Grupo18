using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Diagnostics.Eventing.Reader;

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


                List<Bebida> list = negocio.Listar();
                dgvProductos.DataSource = list;
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
                lblAlertaNombreCategoria.Visible = false;
                divAgregarMarca.Visible = true;
                lblAlertaNombreMarca.Visible = false;
            }
            else
            {
                divAgregarMarca.Visible = true;
                lblAlertaNombreMarca.Visible = false;
            }
        }
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (divAgregarMarca.Visible == true)
            {
                divAgregarMarca.Visible = false;
                lblAlertaNombreMarca.Visible = false;
                divAgregarCategoria.Visible = true;
                lblAlertaNombreCategoria.Visible = false;
            }
            else
            {
                divAgregarCategoria.Visible = true;
                lblAlertaNombreCategoria.Visible = false;

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
                divAgregarCategoria.Visible = false;
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (divAgregarMarca.Visible == true)
            {
                if (string.IsNullOrWhiteSpace(txtMarca.Text))
                {
                    lblAlertaNombreMarca.Visible = true;
                }
                else
                    try
                    {
                        MarcaNegocio negocio = new MarcaNegocio();
                        Marca nueva = new Marca();
                        nueva.Nombre = txtMarca.Text;
                        if (Chb_Tipo.Checked == true)
                        {
                            nueva.Tipo = true;
                        }

                        negocio.agregar(nueva);
                        Response.Redirect("GestionProductos.aspx", false);

                    }
                    catch (Exception ex)
                    {

                        Session.Add("Error", ex.ToString());
                        Response.Redirect("Error.aspx", false);
                    }
                {
                }
            }
            else if (divAgregarCategoria.Visible == true)
            {
                if (string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    lblAlertaNombreCategoria.Visible = true;
                }
                else
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
        //FUNCION PARA ELIMINAR USANDO EL LINKBUTTON PERO NO FUNCIONA, LO REVISO DESPUES
        //protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = dgvProductos.Rows[index];

            //        BebidaNegocio negocio = new BebidaNegocio();
            //        List<Bebida> lista = new List<Bebida>();
            //        lista = negocio.Listar();
            //        negocio.eliminar(13);

            //        dgvProductos.DataSource = lista;
            //        dgvProductos.DataBind();
            //        Response.Redirect("GestionProductos.aspx", false);
            //    }
            //    catch (Exception ex)
            //    {
            //        Session.Add("Error", ex);
            //    }
            //}

    }
}