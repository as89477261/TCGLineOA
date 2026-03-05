using System;
using System.Text;

namespace CustomerHealthCheck.MasterPage
{
    public partial class Site : BaseMaster
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) ConfigSite();
        }

        private void ConfigSite()
        {
            hddIsDebug.Value = GetAppsetting("IsDebug");
            hddIsHttpManagerDubug.Value = GetAppsetting("IsHttpManagerDebug");

            hddShowProfile.Value = GetAppsetting("IsShowProfile");
            hddLiffKey.Value = GetAppsetting("LiffKey");

            hddCustomerHealthCheckURL.Value = GetAppsetting("CustomerHealthCheckURL"); 
            hddCustomerHealthCheckPGS10URL.Value = GetAppsetting("PGS10HealthCheckURL");
            hddPromKhumHealthCheckURL.Value = GetAppsetting("PromKhumHealthCheckURL");
            hddSMEsPickUpHealthCheckUrl.Value = GetAppsetting("SMEsPickUpHealthCheckUrl");
            hddSMEsStimulateCampaign.Value = GetAppsetting("SMEsStimulateCampaign");

            hddProductURL.Value = GetAppsetting("ProductURL");
            hddDebtURL.Value = GetAppsetting("DebtURL");
            hddNDIDURL.Value = GetAppsetting("NDIDURL");
            hddIdentifyURL.Value = GetAppsetting("hddIdentifyURL");
            hddHomeUrl.Value = GetAppsetting("HomeUrl");
            hddEventURL.Value = GetAppsetting("EventURL");
            hddRegisterURL.Value = GetAppsetting("RegisterURL");
            hddQuestionaireURL.Value = GetAppsetting("QuestionaireURL");
            hddRegisterDebtFormURL.Value = GetAppsetting("RegisterDebtFormURL");
            hddRegisterEventFormURL.Value = GetAppsetting("RegisterEventFormURL");
            hddNDIDEFormURL.Value = GetAppsetting("NDIDEFormURL");
            hddAttentionURL.Value = GetAppsetting("AttentionURL");

            hddContactDoctorURL.Value = GetAppsetting("contactDoctorURL");
            hddIsCheckDopa.Value = GetAppsetting("IsCheckDopa");

            hddGoogleAnalyticCode.Value = GetAppsetting("GoogleAnalyticConfig");
            hddGoogleTagCode.Value = GetAppsetting("GoogleTagConfig");


			hddPDPAConsentPoint.Value = GetAppsetting("PdpaConsentPoint");

            hddDirectAppTcgOrURL.Value = GetAppsetting("DirectAppTcgOrURL");
            hddDirectAppTcgKorsoURL.Value = GetAppsetting("DirectAppTcgKorsoURL");
            hddDirectAppTcgRegisterRewardURL.Value = GetAppsetting("DirectAppTcgRegisterRewardURL");

            hddTcgRegisterDopa.Value = GetAppsetting("DirectAppTcgRegisterDopa");

            hddliffCampaignConfigUrl.Value = GetAppsetting("liffCampaignConfigUrl");

            hddNewTCGPortalURL.Value = GetAppsetting("NewTCGPortalURL");


            var plainTextBytes = Encoding.UTF8.GetBytes(GetAppsetting("APIPartialCode"));
            hddAPIPartialCode.Value = Convert.ToBase64String(plainTextBytes);
        }
    }
}