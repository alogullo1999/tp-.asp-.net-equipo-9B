using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class VouchersNegocio
    {
        public Vouchers obtenerVouchers(string CV)
        {
            AccesoDatos datos = new AccesoDatos();
            Vouchers vouchers = new Vouchers();

            try
            {
                datos.setearConsulta("SELECT CodigoVoucher,IdCliente,FechaCanje,IdArticulo FROM Vouchers WHERE CodigoVoucher LIKE @Codigo");
                datos.setearParametro("@Codigo","%"+ CV+"%");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    vouchers.CodigoVoucher = (string)datos.Lector["IdCliente"];

                    if (datos.Lector["IdCliente"] is DBNull)
                    {
                        vouchers.IdCliente = (int)datos.Lector["IdCliente"];
                        vouchers.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                        vouchers.IdArticulo = (int)datos.Lector["IdArticulo"];
                    }
                }
                return vouchers;
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
