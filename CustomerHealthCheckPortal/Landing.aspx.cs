using CoreUtility;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace CustomerHealthCheck
{
    public partial class Landing : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigSite();
                //ConfigPersonalData();
            }
        }

        protected void ConfigSite()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            hddIsDebug.Value = GetAppsetting("IsDebug");
            hddShowProfile.Value = GetAppsetting("IsShowProfile");
            hddLiffKey.Value = GetAppsetting("LiffKey");
            hddHomeUrl.Value = GetAppsetting("HomeUrl");
            hddIsHttpManagerDubug.Value = GetAppsetting("IsHttpManagerDebug");

			hddPDPAConsentPoint.Value = GetAppsetting("PdpaConsentPoint");

			var plainTextBytes = Encoding.UTF8.GetBytes(GetAppsetting("APIPartialCode"));
            hddAPIPartialCode.Value = Convert.ToBase64String(plainTextBytes);

            //CookieManager.SetEncryptCookie("lineoa", "apiHost", GetAppSetting("APIHost"), GetAppSetting("APIPartialCode"));
        }

        private void ConfigPersonalData()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var mac = (HTTPManager.GetMACAddress1() != "" ? HTTPManager.GetMACAddress1() : HTTPManager.GetMACAddress2());
                    var persisToken = CryptographyManager.GetMd5Hash(mac + uid + GetAppsetting("APIPartialCode"));

                    CookieManager.SetEncryptCookie("lineoa", "LToken", persisToken, GetAppsetting("APIPartialCode"));
                }
            }
            catch (Exception ex)
            {
               

            }
        }
    }
}