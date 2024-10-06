using System;
using System.Data.SqlClient;
using System.Configuration;
using negocio;

namespace Promo_Web
{
    public partial class Voucher : System.Web.UI.Page
    {
        protected void btnValidateVoucher_Click(object sender, EventArgs e)
        {
            string CodigoVoucher = txtCodigoVoucher.Text;

            if (string.IsNullOrEmpty(CodigoVoucher))
            {
                lblMessage.Text = "Por favor ingresa un código de voucher.";
                return;
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher ");
                datos.setearParametro("@CodigoVoucher", CodigoVoucher);

                int count = datos.ejecutarAccionScalar();

                if (count > 0)
                {
             
                    lblMessage.Text = "El código es valido. Serás redirigido en 5 segundos.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    string script = "<script type='text/javascript'>setTimeout(function() { window.location.href = 'FormularioClientes.aspx'; }, 5000);</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script);
                }
                else
                {
  
                    lblMessage.Text = "El código es inválido o ya ha sido utilizado.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Ocurrió un error: " + ex.Message;
            }
            finally
            {

                datos.cerrarConexion();
            }
        }
    }
}
