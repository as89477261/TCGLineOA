using System;
using System.Web.UI;

namespace CustomerHealthCheck.views.NDID
{
    public partial class Landing : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) GetRefNo();
        }

        private void GetRefNo()
        {
            var refNo = Request.QueryString[""];
        }
    }
}