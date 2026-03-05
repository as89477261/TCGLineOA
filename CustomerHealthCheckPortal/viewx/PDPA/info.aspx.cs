using System;
using BLL.Controller;
using DataModel.Models.SMEClinic;

namespace CustomerHealthCheck.viewx.PDPA
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hddIsCheckPDPACookie.Value = GetAppsetting("isCheckPDPACookie");
        }

        protected void btnSubmitConsent_Click(object sender, EventArgs e)
        {
            try
            {
                var step1Status = hddStep1Consent.Value;
                var step2Status = hddStep2Consent.Value;
                var step3Status = hddStep3Consent.Value;
                var uid = Request.Cookies["uid"].Value;


                var buffer = ConsentCon.Instance.UpdateUIDConsentWiteConsentStatus(
                    new UIDConsentModel
                    {
                        Uid = uid,
                        Consent1 = step1Status,
                        Consent2 = step2Status,
                        Consent3 = step3Status
                    });

                if (buffer.RESULT_STATUS == "OK") Response.Redirect("~/index.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}