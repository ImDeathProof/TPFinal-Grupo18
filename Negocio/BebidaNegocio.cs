using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Net;

namespace Negocio
{
    public class BebidaNegocio
    {
        public List<Bebida> Listar()
        {
            List<Bebida> lista = new List<Bebida>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Select B.Id, B.Codigo, B.Nombre, B.Precio, B.Descripcion, B.ContenidoNeto, B.Estado, B.UrlImg, M.Nombre Marca, C.Nombre Categoria from Bebidas B inner JOIN MARCAS M on M.Id=B.IdMarca inner join CATEGORIAS C on C.Id=B.idCategoria");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Bebida aux = new Bebida();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ContenidoNeto = (decimal)datos.Lector["ContenidoNeto"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.UrlImg = (string)datos.Lector["UrlImg"];
                    aux.Marca = new Marca();
                    if (datos.Lector["Marca"] is DBNull)
                    {
                        aux.Marca.Nombre = " ";
                    }
                    else
                    {
                        aux.Marca.Nombre = (string)datos.Lector["Categoria"];
                    }
                    aux.Categoria = new Categoria();
                    if (datos.Lector["Categoria"] is DBNull)
                    {
                        aux.Categoria.Nombre = " ";
                    }
                    else
                    {
                        aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    }
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

