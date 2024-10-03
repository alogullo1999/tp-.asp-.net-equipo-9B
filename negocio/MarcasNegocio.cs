using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class MarcasNegocio
    {
        public List<Marcas> listar() {
            List<Marcas> lista = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id,Descripcion from MARCAS");
                datos.ejecutarAccion();

                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
                    aux.IdMarca = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        
        }

        public void Agregar(Marcas nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into MARCAS (Descripcion) values (@Descripcion)");
                datos.setearParametro("@nombre", nuevo.Nombre);
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

        public void Modificar(Marcas modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE MARCAS set Descripcion = @nombre where Id=@id");
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@id", modificar.IdMarca);

                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE from MARCAS where Id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally{
                datos.cerrarConexion();
            }
        }
    }
}
