using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using dominio;
using negocio;

namespace Promo_Web
{
    public partial class SeleccionarPremio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPremios();
            }
        }

        private void CargarPremios()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT a.Id AS PremioID, a.Nombre, a.Descripcion, a.Precio, i.ImagenUrl FROM Articulos a INNER JOIN Imagenes i ON a.Id = i.IdArticulo");

                using (SqlDataReader reader = datos.EjecutarLectura())
                {
                    List<Articulos> premios = new List<Articulos>();

                    while (reader.Read())
                    {
                        Articulos articulo = new Articulos
                        {
                            IdArticulo = Convert.ToInt32(reader["PremioID"]),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            precio = Convert.ToDecimal(reader["Precio"]),
                            imagen = reader["ImagenUrl"].ToString()
                        };
                        premios.Add(articulo);
                    }

                    rptPremios.DataSource = premios;
                    rptPremios.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage2.Text = "Ocurrió un error al cargar los premios: " + ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
