using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;
using negocio;

namespace negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(" SELECT  a.Id AS PremioID,  a.Nombre,  a.Descripcion, a.Precio, i.ImagenUrl   FROM Articulos a INNER JOIN Imagenes i ON a.Id = i.IdArticulo");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdArticulo = (int)datos.Lector["PremioID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.imagen = (string)datos.Lector["ImagenUrl"];
                    

                    lista.Add(aux);
                }

                return lista;
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



        public void agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS ( Codigo, Nombre, Descripcion, Precio) " +
                                     "values (@Codigo, @Nombre, @Descripcion, @Precio)");

                //datos.setearParametro("@Id", nuevo.IdArticulo);
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
               // datos.setearParametro("@IdMarca", nuevo.IdMarca);
               // datos.setearParametro("@IdCategoria", nuevo.IdCategoria);
                datos.setearParametro("@Precio", nuevo.precio);

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
        public void modificar(Articulos art)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio Where Id = @id");

                //datos.setearParametro("@Id", nuevo.IdArticulo);
                datos.setearParametro("@Codigo", art.Codigo);
                datos.setearParametro("@Nombre", art.Nombre);
                datos.setearParametro("@Descripcion", art.Descripcion);
                // datos.setearParametro("@IdMarca", nuevo.IdMarca);
                // datos.setearParametro("@IdCategoria", nuevo.IdCategoria);
                datos.setearParametro("@Precio", art.precio);

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


        public List<Articulos> listarConSP()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Descripcion, Precio, ImagenUrl FROM Articulos");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos articulo = new Articulos
                    {
                        IdArticulo = (int)datos.Lector["Id"],
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        precio = (decimal)datos.Lector["Precio"],
                        imagen = datos.Lector["ImagenUrl"].ToString()
                    };

                    lista.Add(articulo);
                }

                return lista;
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
    }
}


