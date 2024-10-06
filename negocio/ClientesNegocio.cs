using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                datos.setearConsulta("SELECT Id,Documento,Nombre,Email,Direccion,Ciudad,CP FROM Clientes WHERE Id=@id ");
                datos.setearParametro("@id", id);

                SqlDataReader lector = datos.EjecutarLectura();

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
            catch (Exception ex)
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

            if (string.IsNullOrWhiteSpace(clientes.Documento))
                throw new ArgumentException("El DNI del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clientes.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clientes.Apellido))
                throw new ArgumentException("El apellido del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clientes.Email))
                throw new ArgumentException("El email del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clientes.Direccion))
                throw new ArgumentException("La dirección del cliente es obligatoria.");

            if (string.IsNullOrWhiteSpace(clientes.Ciudad))
                throw new ArgumentException("La ciudad del cliente es obligatoria.");

            if (clientes.CP <= 0)
                throw new ArgumentException("El código postal del cliente es obligatorio.");

            // Insertar cliente en la base de datos
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Consulta de inserción
                datos.setearConsulta(@"INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)
                               VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");

                // Asignar parámetros
                datos.setearParametro("@Documento", clientes.Documento);
                datos.setearParametro("@Nombre", clientes.Nombre);
                datos.setearParametro("@Apellido", clientes.Apellido);
                datos.setearParametro("@Email", clientes.Email);
                datos.setearParametro("@Direccion", clientes.Direccion);
                datos.setearParametro("@Ciudad", clientes.Ciudad);
                datos.setearParametro("@CP", clientes.CP);

                // Ejecutar la consulta
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Cerrar la conexión
                datos.cerrarConexion();
            }
        }
    }
}
