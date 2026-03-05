using System;

namespace CustomerHealthCheck.MasterPage
{
    public partial class Identify : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hddHomeUrl.Value = GetAppsetting("HomeUrl");
        }
    }
}