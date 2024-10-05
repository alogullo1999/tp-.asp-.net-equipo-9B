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

        public void AgregarClientes(Clientes clientes)
        {
            
                if (string.IsNullOrWhiteSpace(clientes.Documento.ToString()))
                    throw new ArgumentException("EL DNI DEL CLIENTE ES OBLIGATORIA");

                if (string.IsNullOrWhiteSpace(clientes.Nombre))
                    throw new ArgumentException("EL NOMBRE DEL CLIENTE ES OBLIGATORIA");

                if (string.IsNullOrWhiteSpace(clientes.Apellido))
                    throw new ArgumentException("EL APELLIDO DEL CLIENTE ES OBLIGATORIA");

                if (string.IsNullOrWhiteSpace(clientes.Email))
                    throw new ArgumentException("EL EMAIL DEL CLIENTE ES OBLIGATORIA");

                if (string.IsNullOrWhiteSpace(clientes.Direccion))
                    throw new ArgumentException("LA DIRECCIÓN DEL CLIENTE ES OBLIGATORIA.");

                if (string.IsNullOrWhiteSpace(clientes.Ciudad))
                    throw new ArgumentException("LA CIUDAD DEL CLIENTE ES OBLIGATORIA");

                if (string.IsNullOrWhiteSpace(clientes.CP.ToString()))
                    throw new ArgumentException("EL CÓDIGO POSTAL DEL CLIENTE ES OBLIGATORIA");
        }
    }
}
