using System;
using BLL.Controller;
using DataModel.Models.SMEClinic;

namespace CustomerHealthCheck.views.PDPA
{
    public partial class edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Ispostback คือการกดกิจกรรมต่างๆในหน้าที่ทำรายการ กรณีใส่ !เป็นการกลับ 
                CheckConsent();
        }

        protected void CheckConsent()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));

            if (!string.IsNullOrEmpty(uid))
            {
                var lstConsentInfo = ConsentCon.Instance.GetConsentByUID(uid);
                if (lstConsentInfo.RESULT_STATUS == "OK" && lstConsentInfo.RESULT_OBJ.Consent1 != null &&
                    lstConsentInfo.RESULT_OBJ.Consent2 != null && lstConsentInfo.RESULT_OBJ.Consent3 != null)
                {
                    var bufferResultConsent1 = lstConsentInfo.RESULT_OBJ.Consent1;
                    var bufferResultConsent2 = lstConsentInfo.RESULT_OBJ.Consent2;
                    var bufferResultConsent3 = lstConsentInfo.RESULT_OBJ.Consent3;

                    //ltlConsent1.Text = bufferResultConsent1;
                    //ltlConsent2.Text = bufferResultConsent2;
                    //ltlConsent3.Text = bufferResultConsent3;
                    hddConsent1.Value = bufferResultConsent1;
                    hddConsent2.Value = bufferResultConsent2;
                    hddConsent3.Value = bufferResultConsent3;
                }
                else
                {
                    Response.Redirect("~/views/PDPA/info");
                }
            }
        }

        //protected void btnSubmitUpdateConsent_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var step1Status = hddConsentUpdate1.Value;
        //        var step2Status = hddConsentUpdate2.Value;
        //        var step3Status = hddConsentUpdate3.Value;
        //        var uid = CookieManager.GetEncryptCookie("lineoa", "uid",
        //            GetAppsetting("APIPartialCode")); // Request.Cookies["uid"].Value;


        //        var buffer = ConsentCon.Instance.UpdateUIDConsentWiteConsentStatus(
        //            new UIDConsentModel
        //            {
        //                Uid = uid,
        //                Consent1 = step1Status,
        //                Consent2 = step2Status,
        //                Consent3 = step3Status
        //            });

        //        if (buffer.RESULT_STATUS == "OK") Response.Redirect("~/index.aspx");

        //        // FOR TEST 

        //        //if (buffer.RESULT_STATUS == "OK") Console.WriteLine("STOPPAGE"); 
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}