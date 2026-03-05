using System;
using System.Configuration;
using BLL.Controller.NDID;
using DataModel.Models.NDID;

namespace CustomerHealthCheck.views.Request
{
    public partial class Step1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigSite();
                Binding();
            }
        }

        protected void btnSubmitConditionStep1_Click(object sender, EventArgs e)
        {
            try
            {
                var message = "";
                if (Validate(out message))
                {
                    var transID = Guid.NewGuid().ToString();
                    var masterObj = GenerateMasterObject(transID);
                    var result = NDIDStepCon.Instance.InsertNDIDMasterStatus(masterObj);
                    if (result.RESULT_CODE == "200")
                    {
                        CookieManager.SetEncryptCookie("lineoa", "ndidtransid", transID,
                            GetAppsetting("APIPartialCode"));
                        CookieManager.SetEncryptCookie("lineoa", "ndididcard", txtNDIDIdCard.Text,
                            GetAppsetting("APIPartialCode"));
                        LocalLogManager.Logger("ndidtransid : " + transID + "| ndididcard : " + txtNDIDIdCard.Text);

                        var ndidConsentObj = GenerateNDIDConsentObject(transID);
                        var consentResult = NDIDStepCon.Instance.InsertCustomerConsentNDID(ndidConsentObj);

                        if (consentResult.RESULT_STATUS == "OK")
                        {
                            if (ConfigurationManager.AppSettings["IsByPassNCBTermAndCondition"] == "1")
                                Response.Redirect("~/views/NDID/Step3.aspx");
                            else
                                Response.Redirect("~/views/NDID/Step2.aspx");
                        }
                        else
                        {
                            throw new Exception("Error In KeepCustomerNDIDConsent Process");
                        }
                    }
                    else
                    {
                        throw new Exception("Error In KeepNDIDMaster Process");
                    }
                }
                else
                {
                    throw new Exception("Error In NDID Validation Process : " + message);
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
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var ndidtransid = transID;
            var buffer = new UIDMapNDIDStatusModel();
            buffer.UID = uid;
            buffer.TransactionID = ndidtransid;
            buffer.Status = true;
            buffer.Step1Status = "001";
            buffer.Step1Remark = "ยืนยันรับทราบ Consent NDID";
            buffer.CurrentStausCode = "001";
            buffer.CurrentStatusRemark = "ยืนยันรับทราบ Consent NDID";
            buffer.CreatedBy = "SYSTEM";
            buffer.UpdatedBy = "SYSTEM";

            return buffer;
        }

        private CustomerConsentNDIDModel GenerateNDIDConsentObject(string transID)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var ndidtransid = transID;
            var buffer = new CustomerConsentNDIDModel();
            buffer.TransactionID = ndidtransid;
            buffer.UID = uid;
            buffer.NDIDConsent1Status = true;
            buffer.NDIDConsent1Remark = "ผู้ใช้บริการยืนยันให้เข้าถึงข้อมูลส่วนบุคคล";
            buffer.Status = true;
            buffer.CreatedBy = "SYSTEM";
            buffer.UpdatedBy = "SYSTEM";
            return buffer;
        }
    }
}