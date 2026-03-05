using System;
using BLL.Controller.NDID;
using DataModel.Models.NDID;

namespace CustomerHealthCheck.views.NDID
{
    public partial class Step2 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigSite();
                Binding();
            }
        }


        protected void btnCommitStep2_Click(object sender, EventArgs e)
        {
            try
            {
                var message = "";
                if (Validate(out message))
                {
                    var transID =
                        CookieManager.GetEncryptCookie("lineoa", "ndidtransid", GetAppsetting("APIPartialCode"));

                    var masterObj = GenerateMasterObject(transID);
                    var result = NDIDStepCon.Instance.UpdateNDIDMasterStatus(masterObj);
                    if (result.RESULT_CODE == "200")
                    {
                        var ncbConsentObj = GenerateNCBObject(transID);
                        var consentResult = NDIDStepCon.Instance.InsertCustomerConsentNCB(ncbConsentObj);

                        if (consentResult.RESULT_STATUS == "OK")
                            Response.Redirect("~/views/NDID/Step3.aspx");
                        else
                            throw new Exception("Error In KeepCustomerNCBConsent Process");
                    }
                    else
                    {
                        throw new Exception("Error In KeepNDIDMaster Process");
                    }
                }
                else
                {
                    throw new Exception("Error In NCB Validation Process : " + message);
                }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
            }
        }


        private void Binding()
        {
        }

        private void ConfigSite()
        {
        }

        private bool Validate(out string message)
        {
            var result = true;
            message = "";
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));

            if (uid.Length == 0)
            {
                result = false;
                message = "";
            }

            return result;
        }

        private UIDMapNDIDStatusModel GenerateMasterObject(string transID)
        {
            var ndidtransid = transID;
            var buffer = new UIDMapNDIDStatusModel();
            buffer.TransactionID = ndidtransid;
            buffer.Step2Status = "001";
            buffer.Step2Remark = "ยืนยันรับทราบ Consent NCB";
            buffer.CurrentStausCode = "002";
            buffer.CurrentStatusRemark = "ยืนยันรับทราบ Consent NCB";
            buffer.UpdatedBy = "SYSTEM";

            return buffer;
        }

        private CustomerConsentNCBModel GenerateNCBObject(string transID)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var ndidtransid = transID;
            var buffer = new CustomerConsentNCBModel();
            buffer.TransactionID = ndidtransid;
            buffer.UID = uid;
            buffer.NCBConsent1Status = true;
            buffer.NCBConsent1Remark = "ผู้ใช้บริการยืนยันให้เข้าถึงข้อมูลส่วนบุคคล";
            buffer.Status = true;
            buffer.CreatedBy = "SYSTEM";
            buffer.UpdatedBy = "SYSTEM";
            return buffer;
        }
    }
}