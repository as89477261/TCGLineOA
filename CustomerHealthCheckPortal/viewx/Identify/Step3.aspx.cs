using System;
using System.Web.UI;

namespace CustomerHealthCheck.viewx.Identify
{
    public partial class Step3 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnConfirmOtp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }
    }
}