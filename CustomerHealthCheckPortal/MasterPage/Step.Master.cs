using System;
using System.Text;

namespace CustomerHealthCheck.MasterPage
{
    public partial class Step : BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) ConfigSite();
        }

        private void ConfigSite()
        {
            hddIsHttpManagerDubug.Value = GetAppsetting("IsHttpManagerDebug");
            hddIsDebug.Value = GetAppsetting("IsDebug");
            hddShowProfile.Value = GetAppsetting("IsShowProfile");
            hddLiffKey.Value = GetAppsetting("LiffKey");
            hddCustomerHealthCheckURL.Value = GetAppsetting("CustomerHealthCheckURL");
            hddProductURL.Value = GetAppsetting("ProductURL");
            hddNDIDURL.Value = GetAppsetting("NDIDURL");
            hddHomeUrl.Value = GetAppsetting("HomeUrl");

            hddIsCheckDopa.Value = GetAppsetting("IsCheckDopa");

            var plainTextBytes = Encoding.UTF8.GetBytes(GetAppsetting("APIPartialCode"));
            hddAPIPartialCode.Value = Convert.ToBase64String(plainTextBytes);
        }
    }
}