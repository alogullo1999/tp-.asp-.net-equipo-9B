using System;
using System.Data.SqlClient;
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
                    lblMessage.Text = "Ya estás registrado!";

                    txtNombre.Text = lector["Nombre"].ToString();
                    txtApellido.Text = lector["Apellido"].ToString();
                    txtEmail.Text = lector["Email"].ToString();
                    txtDireccion.Text = lector["Direccion"].ToString();
                    txtCiudad.Text = lector["Ciudad"].ToString();
                    txtCP.Text = lector["CP"].ToString();

                    panelFormulario.Visible = true;
                    btnAceptar.Visible = true;
                }
                else
                {

                    btnAceptar.Visible = true;

                    panelFormulario.Visible = true;
                    lblMessage.Text = "El Documento NO está registrado, por favor completa tus datos!";

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
                datos.cerrarConexion();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el cliente existe
                if (!ClienteExiste(txtDNI.Text.Trim())) // Si no existe
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
                    lblMessage.Text = "Tus datos han sido cargados con exito! Ya estas participando";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "¡Ya estás participando!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

                string script = "<script type='text/javascript'>setTimeout(function() { window.location.href = 'RedireccionInicio.aspx'; }, 1000);</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script);
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message;
            }
        }

        private bool ClienteExiste(string documento)
        {
            bool existe = false;

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Clientes WHERE Documento = @Documento");
                datos.setearParametro("@Documento", documento);

                SqlDataReader lector = datos.EjecutarLectura();
                if (lector.Read())
                {
                    int count = (int)lector[0];
                    if (count > 0)
                    {
                        existe = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al verificar el cliente: " + ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return existe;
        }
    }
}
