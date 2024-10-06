using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Promo_Web
{
    public partial class FormularioClientes : System.Web.UI.Page
    {

     protected void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            string Documento = txtDNI.Text.Trim();

            AccesoDatos datos = new AccesoDatos();
            {
                datos.setearConsulta("SELECT Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @Documento");
                datos.setearParametro("@Documento", Documento);

                SqlDataReader lector = datos.EjecutarLectura();
                if (lector.Read())
                {
                    Console.WriteLine("Datos obtenidos: " + lector["Nombre"].ToString());
                    lblMessage.Text = "Ya estas registrado!!!";
                    txtNombre.Text = lector["Nombre"].ToString();
                    txtApellido.Text = lector["Apellido"].ToString();
                    txtEmail.Text = lector["Email"].ToString();
                    txtDireccion.Text = lector["Direccion"].ToString();
                    txtCiudad.Text = lector["Ciudad"].ToString();
                    txtCP.Text = lector["CP"].ToString();


                    panelFormulario.Visible = true;
                }
                else
                {
                    panelFormulario.Visible = true;
                    Console.WriteLine("No se encontraron resultados para el Documento ingresado.");
                    lblMessage.Text = "El Documento NO esta registrado por favor completa tus datos!";
                }
                datos.cerrarConexion();
            }
        }






        protected void btnAceptar_Click(object sender,EventArgs e)
        {
            if (!chkTerminos.Checked)
            {
                lblError.Text = "Se debe aceptar los términos y las condiciones impuestas";
                return;
            }

            try
            {
                Clientes clientes = new Clientes();

                if (!int.TryParse(txtDNI.Text,out int dni))
                {
                    lblError.Text = "EL DNI DEBE SER CON NÚMEROS";
                    return;
                }
               
                

                clientes.Nombre = txtNombre.Text.Trim();
                if (string.IsNullOrWhiteSpace(clientes.Nombre))
                {
                    lblError.Text = "EL NOMBRE DEL CLIENTE ES OBLIGATORIO";
                    return;
                }

                if (clientes.Nombre.Any(char.IsDigit))
                {
                    lblError.Text = "EL NOMBRE DEL CLIENTE NO PUEDE CONTENER NÚMEROS....";
                    return;
                }

                
                clientes.Apellido = txtApellido.Text.Trim();
                if (string.IsNullOrWhiteSpace(clientes.Apellido))
                {
                    lblError.Text = "EL APELLIDO DEL CLIENTE ES OBLIGATORIO";
                    return;
                }

                if (clientes.Apellido.Any(char.IsDigit))
                {
                    lblError.Text = "El apellido del cliente no puede contener números.";
                    return;
                }

             
                clientes.Email = txtEmail.Text.Trim();
                if (string.IsNullOrWhiteSpace(clientes.Email))
                {
                    lblError.Text = "EL EMAIL DEL CLIENTE ES OBLIGATORIO INGRESARLO";
                    return;
                }

        
                if (!EmailValido(clientes.Email))
                {
                    lblError.Text = "El email del cliente no tiene un formato válido.";
                    return;
                }

                // Validar Dirección
                clientes.Direccion = txtDireccion.Text.Trim();
                if (string.IsNullOrWhiteSpace(clientes.Direccion))
                {
                    lblError.Text = "LA DIRECCION DEL CLIENTE ES OBLIGATORIO INGRESARLA.";
                    return;
                }

                
                clientes.Ciudad = txtCiudad.Text.Trim();
                if (string.IsNullOrWhiteSpace(clientes.Ciudad))
                {
                    lblError.Text = "LA CIUDAD DEL CLIENTE ES OBLIGATORIA.";
                    return;
                }

                if (clientes.Ciudad.Any(char.IsDigit))
                {
                    lblError.Text = "LA CIUDAD DEL CLIENTE NO DEBE CONTENER NÚMEROS.";
                    return;
                }

                
                if (!int.TryParse(txtCP.Text, out int cp))
                {
                    lblError.Text = "EL CÓDIGO POSTAL DEBE SER CON NÚMEROS VÁLIDOS";
                    return;
                }
                clientes.CP = cp;

                ClientesNegocio negocio = new ClientesNegocio();
                
                negocio.AgregarClientes(clientes);
                lblSuceso.Text = "Cliente agregado exitosamente.";
                lblError.Text = "";

                
            }
            catch(Exception ex)
            {
                lblError.Text = "HUBO ERROR A LA HORA DE CARGAR EL CLIENTE";
                throw ex;
            }
        } 

        public bool EmailValido(string email)
        {
            return email.Contains("@") && email.Contains(".") && email.IndexOf("@") < email.LastIndexOf(".");
        }

        public void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtDNI.Text, out int dni))
            {
                ClientesNegocio clientes = new ClientesNegocio();
                var cliente = clientes.ObtenerClientes(dni);
                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEmail.Text = cliente.Email;
                    txtDireccion.Text = cliente.Direccion;
                    txtCiudad.Text = cliente.Ciudad;
                    txtCP.Text = cliente.CP.ToString();
                }
                else
                {
                    lblError.Text = "Cliente no encontrado.";
                }
            }
        }

        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            
            txtDNI.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCP.Text = string.Empty;
            chkTerminos.Checked = false;

            
            lblError.Text = string.Empty;
            lblSuceso.Text = string.Empty;
        }

    }

}