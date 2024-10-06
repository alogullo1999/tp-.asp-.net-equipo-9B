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
            // Crear una instancia de AccesoDatos o la clase ClientesNegocio para obtener los datos
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Establecer la consulta SQL para obtener los productos
                datos.setearConsulta("SELECT a.Id AS PremioID, a.Nombre, a.Descripcion, MIN(i.ImagenUrl) AS ImagenUrl FROM Articulos a INNER JOIN Imagenes i ON a.Id = i.IdArticulo GROUP BY a.Id, a.Nombre, a.Descripcion");

                // Ejecutar la lectura de datos
                SqlDataReader lector = datos.EjecutarLectura();

                // Cargar los datos al repeater
                rptPremios.DataSource = lector;
                rptPremios.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar errores
                Console.WriteLine("Error al cargar los productos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void btnSeleccionarPremio_Click(object sender, EventArgs e)
        {
            List<int> premiosSeleccionados = new List<int>();

            // Recorrer los ítems del Repeater
            foreach (RepeaterItem item in rptPremios.Items)
            {
                // Obtener el checkbox y el HiddenField del item actual
                CheckBox chkSeleccionar = (CheckBox)item.FindControl("chkSeleccionar");
                HiddenField hfPremioID = (HiddenField)item.FindControl("hfPremioID");

                // Verificar si el checkbox está marcado
                if (chkSeleccionar != null && chkSeleccionar.Checked)
                {
                    // Obtener el ID del premio y agregarlo a la lista
                    int premioID = int.Parse(hfPremioID.Value);
                    premiosSeleccionados.Add(premioID);
                }
            }

            // Verificar si se ha seleccionado algún premio
            if (premiosSeleccionados.Count > 0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Premios seleccionados: " + string.Join(", ", premiosSeleccionados);
                // Aquí podrías realizar la lógica adicional para procesar los premios seleccionados,
                // como guardar los premios en una base de datos o realizar alguna acción con ellos.
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No has seleccionado ningún premio.";
            }
        }
    }
}