using System;

namespace CustomerHealthCheck.MasterPage
{
    public partial class PDPA : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hddHomeUrl.Value = GetAppsetting("HomeUrl");
        }
    }
}