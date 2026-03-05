using System;
using System.Configuration;
using System.Security.Cryptography;
using BLL.Controller;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.SMEClinic;

namespace CustomerHealthCheck.views.PDPA
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hddIsCheckPDPACookie.Value = GetAppsetting("isCheckPDPACookie");
            hddPDPACondsentPoint.Value = GetAppsetting("PdpaConsentPoint");

			SetAuthorizationToken();
			LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.PDPA_Load);
		}

        protected void btnSubmitConsent_Click(object sender, EventArgs e)
        {
            try
            {
                var step1Status = hddStep1Consent.Value;
                var step2Status = hddStep2Consent.Value;
                var step3Status = hddStep3Consent.Value;
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));


                var buffer = ConsentCon.Instance.UpdateUIDConsentWiteConsentStatus(
                    new UIDConsentModel
                    {
                        Uid = uid,
                        Consent1 = step1Status,
                        Consent2 = step2Status,
                        Consent3 = step3Status
                    });

                if (buffer.RESULT_STATUS == "OK") Response.Redirect("~/Landing.aspx",true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetAuthorizationToken()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            if (uid != null)
            {
                var bufferUid = CryptographyManager.Encrypt(uid, ConfigurationManager.AppSettings["SaltKey"]);
                if (bufferUid != null)
                    CookieManager.SetEncryptCookie("lineoa", "uidtoken", bufferUid, GetAppsetting("APIPartialCode"));
            }
        }
    }
}