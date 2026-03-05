using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LineOABackend
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fixUsername = ConfigurationManager.AppSettings["Username"];
            var fixPassword = ConfigurationManager.AppSettings["Password"];

            if (fixUsername == txtUsername.Value && fixPassword == txtPassword.Value)
            {
                Response.Redirect("~/views/CouponManager.aspx");
            }
        }
    }
}