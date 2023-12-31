﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Net;
using System.Security.Policy;

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
                datos.setearConsulta("Select B.Id, B.Codigo, B.Nombre, B.Precio, B.Descripcion, B.ContenidoNeto, B.Estado, B.UrlImg, M.Nombre Marca, C.Nombre Categoria, B.Stock from Bebidas B inner JOIN MARCAS M on M.Id=B.IdMarca inner join CATEGORIAS C on C.Id=B.idCategoria");
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
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Marca = new Marca();
                    if (datos.Lector["Marca"] is DBNull)
                    {
                        aux.Marca.Nombre = " ";
                    }
                    else
                    {
                        aux.Marca.Nombre = (string)datos.Lector["Marca"];
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

        public void agregar(Bebida nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                //codigo - nombre.precio - descripcion - contenido - estado - url - idmarca - idcat
                datos.setearConsulta("insert into Bebidas values(@Codigo,@Nombre,@Precio,@Descripcion,@Contenido,1,@Url,@Marca,@Categoria,@Stock)");
                datos.setearParametros("@Codigo", nuevo.Codigo);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Precio", nuevo.Precio);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@Contenido", nuevo.ContenidoNeto);
                datos.setearParametros("Url", nuevo.UrlImg);
                datos.setearParametros("Stock", nuevo.Stock);
                datos.setearParametros("Marca", nuevo.Marca.Id);
                datos.setearParametros("@Categoria", nuevo.Categoria.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Bebida buscar(int Id)
        {
            Bebida bebida = new Bebida();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("select Id,Codigo,Nombre,Precio,Descripcion,ContenidoNeto,Estado,UrlImg,IdMarca,IdCategoria,Stock from Bebidas where Id=@Id");
                datos.setearParametros("Id", Id);
                datos.ejecutarLectura();

                datos.Lector.Read();
                bebida.Id = (int)datos.Lector["Id"];
                bebida.Codigo = (string)datos.Lector["Codigo"];
                bebida.Nombre = (string)datos.Lector["Nombre"];
                bebida.Precio = (decimal)datos.Lector["Precio"];
                bebida.Descripcion = (string)datos.Lector["Descripcion"];
                bebida.ContenidoNeto = (decimal)datos.Lector["ContenidoNeto"];
                bebida.Estado = (bool)datos.Lector["Estado"];
                bebida.Stock = (int)datos.Lector["Stock"];
                bebida.UrlImg = (string)datos.Lector["UrlImg"];
                bebida.Marca = new Marca();
                MarcaNegocio mnegocio = new MarcaNegocio();
                bebida.Marca = mnegocio.Buscar((int)datos.Lector["IdMarca"]);
                bebida.Categoria = new Categoria();
                CategoriaNegocio catnegocio = new CategoriaNegocio();
                bebida.Categoria = catnegocio.Buscar((int)datos.Lector["IdCategoria"]);

                return bebida;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificar(Bebida nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("update Bebidas set Codigo=@Codigo,Nombre=@Nombre,Precio=@Precio,Descripcion=@Descripcion,ContenidoNeto=@Contenido,Estado=1,UrlImg=@Url,IdMarca=@Marca,IdCategoria=@Categoria,Stock=@Stock where Id=@Id");
                datos.setearParametros("@Codigo", nuevo.Codigo);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Precio", nuevo.Precio);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@Contenido", nuevo.ContenidoNeto);
                datos.setearParametros("Url", nuevo.UrlImg);
                datos.setearParametros("Marca", nuevo.Marca.Id);
                datos.setearParametros("@Categoria", nuevo.Categoria.Id);
                datos.setearParametros("Id", nuevo.Id);
                datos.setearParametros("Stock", nuevo.Stock);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void eliminar(int id)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("delete from bebidas where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void bajaLogica(int id)
        {
            try
            {
                AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
                datos.setearConsulta("update bebidas set Estado = 0 where id = @id");
                datos.setearParametros("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void altaLogica(int id)
        {
            try
            {
                AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
                datos.setearConsulta("update bebidas set Estado = 1 where id = @id");
                datos.setearParametros("id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Bebida> Filtrar(string campo, string criterio, string filtro)
        {
            List<Bebida> lista = new List<Bebida>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                string consulta = "SELECT A.Id, A.Precio, A.Codigo,A.Nombre, A.Descripcion, M.Descripcion Marca ,C.Descripcion Categoria from ARTICULOS A inner join MARCAS M on M.Id=A.IdMarca inner join CATEGORIAS C on C.Id=A.IdCategoria and ";

                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a: ":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a: ":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }

                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con: ":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con: ":
                                consulta += "Nombre like '%" + filtro + "' ";
                                break;
                            case "Contiene: ":
                                consulta += "Nombre like '%" + filtro + "%' ";
                                break;

                        }

                        break;
                    default:
                        switch (criterio)
                        {
                            case "Comienza con: ":
                                consulta += "A.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con: ":
                                consulta += "A.Descripcion like '%" + filtro + "' ";
                                break;
                            case "Contiene: ":
                                consulta += "A.Descripcion like '%" + filtro + "%' ";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Bebida aux = new Bebida();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    //aux.imagen = new Imagen();
                    //aux.imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Categoria = new Categoria();
                    /*if (datos.Lector["Categoria"] is DBNull)
                    {
                        aux.categoria.Descripcion = " ";
                    }
                    else
                    {
                        aux.categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    aux.marca = new Marca();
                    aux.marca.Descripcion = (string)datos.Lector["Marca"];*/ ///MARCAS Y CATEGORIA NO TIENEN DESCRIPCIÓN POR ESO 

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void descontarStock(int Id, int Cantidad)
        {
            try
            {
                AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

                datos.setearConsulta("update Bebidas set Stock=Stock-@Cantidad where id=@Id");
                datos.setearParametros("@Id", Id);
                datos.setearParametros("@Cantidad", Cantidad);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Bebida> ListarPorTipo(string criterio)
        {
            List<Bebida> lista = new List<Bebida>();
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                string consulta = "Select B.Id, B.Codigo, B.Nombre, B.Precio, B.Descripcion, B.ContenidoNeto, B.Estado, B.UrlImg, M.Nombre Marca, C.Nombre Categoria, B.Stock from Bebidas B inner JOIN MARCAS M on M.Id=B.IdMarca inner join CATEGORIAS C on C.Id=B.idCategoria where";
                if(criterio == "Importado")
                {
                    consulta += " M.Importado = 'true'";
                }else if(criterio == "Alcoholica")
                {
                    consulta += " C.Alcoholica = 'true'";
                }else
                {
                    consulta += " C.Alcoholica = 'false'";
                }
                datos.setearConsulta(consulta);
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
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Marca = new Marca();
                    if (datos.Lector["Marca"] is DBNull)
                    {
                        aux.Marca.Nombre = " ";
                    }
                    else
                    {
                        aux.Marca.Nombre = (string)datos.Lector["Marca"];
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

