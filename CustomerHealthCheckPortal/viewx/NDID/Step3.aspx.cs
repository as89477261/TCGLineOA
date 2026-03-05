using System;
using System.Web.UI;

namespace CustomerHealthCheck.viewx.NDID
{
    public partial class Step3 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void GenerateIDPList()
        {
            ltlIdpList.Text = "";
        }
    }
}