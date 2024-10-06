using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes cliente = new Clientes
                {
                    Documento = txtDNI.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Ciudad = txtCiudad.Text.Trim(),
                    CP = int.Parse(txtCP.Text.Trim())
                };

                ClientesNegocio negocio = new ClientesNegocio();
                negocio.AgregarClientes(cliente);

                lblMessage.Text = "El cliente ha sido dado de alta correctamente.";
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message;
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