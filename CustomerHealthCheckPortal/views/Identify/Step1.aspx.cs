using System;
using BLL.Controller.HealthCheck;
using DataModel.Models.SMEClinic;

namespace CustomerHealthCheck.views.Identify
{
    public partial class Step1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnSubmitKYCStep1_Click(object sender, EventArgs e)
        {
            var obj = GenerateObj();
            var bufferCon = IdentifiedProfileCon.Instance.InsertUIDMapApproch(obj);
            if (bufferCon.RESULT_STATUS == "OK" && bufferCon.RESULT_OBJ != null)
                CookieManager.SetEncryptCookie("lineoa", "identifiedid", bufferCon.RESULT_OBJ,
                    GetAppsetting("APIPartialCode"));
            Response.Redirect("~/views/Identify/Step2.aspx");
        }

        private IdentifiedProfileModel GenerateObj()
        {
            var bufferImage1 = hddImage1.Value;
            var bufferImage2 = hddImage2.Value;
            var bufferImage3 = hddImage3.Value;
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));

            var obj = new IdentifiedProfileModel();
            obj.UID = uid;
            obj.BinaryImg1 = bufferImage1;
            obj.BinaryImg2 = bufferImage2;
            obj.BinaryImg3 = bufferImage3;

            return obj;
        }
    }
}