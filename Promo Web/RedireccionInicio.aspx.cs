using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Promo_Web
{
    public partial class RedireccionInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string script = "<script type='text/javascript'>setTimeout(function() { window.location.href = 'Default.aspx'; }, 4000);</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script);
        }
    }
}