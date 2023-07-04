﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;
using Microsoft.SqlServer.Server;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, NombreUsuario, Contraseña, IdTipoUsser from USUARIOS where NombreUsuario = @user AND Contraseña = @pass ");
                datos.setearParametros("@user", usuario.NombreUsuario);
                datos.setearParametros("@pass", usuario.Contraseña);
                datos.ejecutar

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.IdTipoUser = (int)(datos.Lector["IdTipoUsser"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;
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
        public void Registrar(Usuario Nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Usuarios values ('@NombreUsuario', '@Contraseña', @IdTipoUsser,'@Nombre', '@Apellido', '@Dni', '@Email', '@Telefono', @FechaNacimiento, @IdDomicilio)");

                datos.setearParametros("@NombreUsuario", Nuevo.NombreUsuario);
                datos.setearParametros("@Contraseña", Nuevo.Contraseña);
                datos.setearParametros("@IdTipoUsser", 2);
                datos.setearParametros("@Nombre", Nuevo.Nombre);
                datos.setearParametros("@Apellido", Nuevo.Apellido);
                datos.setearParametros("@Dni", Nuevo.DNI);
                datos.setearParametros("@Email", Nuevo.Email);
                datos.setearParametros("@Telefono", Nuevo.Telefono);
                datos.setearParametros("@FechaNacimiento", Nuevo.FechaNacimiento);
                datos.setearParametros("@IdDomicilio", 1);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public bool Buscar(string NUsuario)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Select NombreUsuario from Usuarios");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    if ((string)datos.Lector["NombreUsuario"] == NUsuario)
                    {
                        return true;
                    }
                }
                return false;
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
        public Usuario BuscarCompleto(Usuario us)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, NombreUsuario, Contraseña, IdTipoUsser, Nombre, Apellido, Dni, Email, Telefono, FechaNacimiento, IdDomicilio from Usuarios where Id = @Id");
                datos.setearParametros("@Id", us.Id);
                datos.ejecutarLectura();

                Usuario usuario = new Usuario();
                datos.Lector.Read();
                usuario.Id = (int)datos.Lector["Id"];
                usuario.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                usuario.Contraseña = (string)datos.Lector["Contraseña"];
                usuario.IdTipoUser = (int)(datos.Lector["IdTipoUsser"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                usuario.Nombre = (string)datos.Lector["Nombre"];
                usuario.Apellido = (string)datos.Lector["Apellido"];
                usuario.DNI = (string)datos.Lector["Dni"];
                usuario.Email = (string)datos.Lector["Email"];
                usuario.Telefono = (string)datos.Lector["Telefono"];
                usuario.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                if (datos.Lector["IdDomicilio"] != null)
                {
                    DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                    usuario.Domicilio = domicilioNegocio.Buscar(usuario);
                }

                return usuario;
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
        public void modificar(Usuario nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearConsulta("update Usuarios set NombreUsuario=@NombreUsuario, Contraseña=@Contraseña, IdTipoUsser=@IdTipoUsser, Nombre=@Nombre, Apellido=@Apellido, Dni=@Dni, Email=@Email, Telefono=@Telefono, "/*FechaNacimiento=@FechaNacimiento*/ + " IdDomicilio=@IdDomicilio where Id=@Id");
                datos.setearParametros("@NombreUsuario", nuevo.NombreUsuario);
                datos.setearParametros("@Contraseña", nuevo.Contraseña);
                int tipoUsuario = nuevo.IdTipoUser == TipoUsuario.ADMIN ? 1 : 2;
                datos.setearParametros("@IdTipoUsser", tipoUsuario);
                datos.setearParametros("@Apellido", nuevo.Apellido);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("Dni", nuevo.DNI);
                datos.setearParametros("Email", nuevo.Email);
                datos.setearParametros("@Telefono", nuevo.Telefono);
                //Esto tira error, hay que revisar
                //datos.setearParametros("@FechaNacimiento", nuevo.FechaNacimiento);
                datos.setearParametros("@IdDomicilio", 1);
                datos.setearParametros("@Id", nuevo.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
