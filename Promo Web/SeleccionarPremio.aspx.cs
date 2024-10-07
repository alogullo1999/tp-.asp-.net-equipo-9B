using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using negocio; 
using dominio;
using System.Collections.Generic;

namespace Promo_Web
{
    public partial class SeleccionarPremio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("SELECT a.Id AS PremioID, a.Nombre, a.Descripcion, MIN(i.ImagenUrl) AS ImagenUrl FROM Articulos a INNER JOIN Imagenes i ON a.Id = i.IdArticulo GROUP BY a.Id, a.Nombre, a.Descripcion");

                SqlDataReader lector = datos.EjecutarLectura();

                rptPremios.DataSource = lector;
                rptPremios.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void btnQuieroEste_Click(object sender, EventArgs e)
        {
 
            Button btnQuieroEste = (Button)sender;

            RepeaterItem item = (RepeaterItem)btnQuieroEste.NamingContainer;

            HiddenField hfPremioNombre = (HiddenField)item.FindControl("hfPremioNombre");

  
            string nombrePremio = hfPremioNombre.Value;

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Has seleccionado el premio: " + nombrePremio + " Te enviaremos para que completes tus datos";

            string script = "<script type='text/javascript'>setTimeout(function() { window.location.href = 'FormularioClientes.aspx'; }, 3000);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script);


        }
    }
}