using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ClientesNegocio
    {
        public Clientes ObtenerClientes(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Clientes clientes = new Clientes();

            try
            {
                datos.setearConsulta("SELECT Id,Documento,Nombre,Email,Direccion,Ciudad,CP FROM CLIENTES WHERE Id=@id ");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

                if (datos.Lector.Read())
                {
                    clientes.IdCliente = (int)datos.Lector["Id"];
                    clientes.Documento = (string)datos.Lector["Documento"];
                    clientes.Nombre = (string)datos.Lector["Nombre"];
                    clientes.Apellido = (string)datos.Lector["Apellido"];
                    clientes.Direccion = (string)datos.Lector["Direccion"];
                    clientes.Ciudad = (string)datos.Lector["Ciudad"];
                    clientes.CP = (int)datos.Lector["CP"];
                }
                return clientes;
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
    }
}
