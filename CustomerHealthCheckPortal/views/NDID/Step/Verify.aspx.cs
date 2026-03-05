using System;
using System.Web.UI;

namespace CustomerHealthCheck.views.NDID
{
    public partial class Verify : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetEFormURL();
            }
        }

        private void GetEFormURL()
        {
            iframeeForm.Attributes["src"] = "http://www.tcg.or.th";
        }
    }
}