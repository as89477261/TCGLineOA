using System;
using System.Configuration;
using BLL.Controller.NDID;
using DataModel.Models.NDID;

namespace CustomerHealthCheck.views.NDID
{
    public partial class Step1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            ConfigSite();
            Binding();
        }

        protected void BtnSubmitConditionStep1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate(out var message))
                {
                    var transId = Guid.NewGuid().ToString();
                    var masterObj = GenerateMasterObject(transId);
                    var result = NDIDStepCon.Instance.InsertNDIDMasterStatus(masterObj);
                    if (result.RESULT_CODE == "200")
                    {
                        CookieManager.SetEncryptCookie("lineoa", "ndidtransid", transId,
                            GetAppsetting("APIPartialCode"));
                        CookieManager.SetEncryptCookie("lineoa", "ndididcard", txtNDIDIdCard.Text,
                            GetAppsetting("APIPartialCode"));
                        LocalLogManager.Logger("ndidtransid : " + transId + "| ndididcard : " + txtNDIDIdCard.Text);

                        var ndidConsentObj = GenerateNdidConsentObject(transId);
                        var consentResult = NDIDStepCon.Instance.InsertCustomerConsentNDID(ndidConsentObj);

                        if (consentResult.RESULT_STATUS == "OK")
                        {
                            Response.Redirect(ConfigurationManager.AppSettings["IsByPassNCBTermAndCondition"] == "1"
                                ? "~/views/NDID/Step3.aspx"
                                : "~/views/NDID/Step2.aspx");
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

        private UIDMapNDIDStatusModel GenerateMasterObject(string transId)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var ndidtransid = transId;
            var buffer = new UIDMapNDIDStatusModel
            {
                UID = uid,
                TransactionID = ndidtransid,
                Status = true,
                Step1Status = "001",
                Step1Remark = "ยืนยันรับทราบ Consent NDID",
                CurrentStausCode = "001",
                CurrentStatusRemark = "ยืนยันรับทราบ Consent NDID",
                CreatedBy = "SYSTEM",
                UpdatedBy = "SYSTEM"
            };

            return buffer;
        }

        private CustomerConsentNDIDModel GenerateNdidConsentObject(string transId)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var ndidtransid = transId;
            var buffer = new CustomerConsentNDIDModel
            {
                TransactionID = ndidtransid,
                UID = uid,
                NDIDConsent1Status = true,
                NDIDConsent1Remark = "ผู้ใช้บริการยืนยันให้เข้าถึงข้อมูลส่วนบุคคล",
                Status = true,
                CreatedBy = "SYSTEM",
                UpdatedBy = "SYSTEM"
            };
            return buffer;
        }
    }
}