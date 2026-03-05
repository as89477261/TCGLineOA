using BLL.Controller;
using BLL.Controller.FACenter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerHealthCheck.views.DIPROM
{
    public partial class Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindingConfig();
            BindingProfile();
            LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Events_DIPROM_Load);
        }

        private void BindingConfig()
        {
            var transDummyID = Guid.NewGuid().ToString();
            hddtransDummyID.Value = transDummyID;
            hddacceptCondition.Value = "0";
        }

        private void BindingProfile()
        {
            
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", ConfigurationManager.AppSettings["APIPartialCode"]);
            var lstObj = UIDMapDIPROMCon.Instance.GetUIDMapDIPROMEvent(uid, "001" ,"");


            //API CheckRegister

            if (lstObj.RESULT_STATUS == "OK" && lstObj.RESULT_OBJ.Count > 0)
            {
                var isRegisterSuccess = lstObj.RESULT_OBJ[0].IsRegisterSuccess;

                if (isRegisterSuccess == true)
                {
                    //BindingPanel(true);
                    hddprofileRegister.Value = "1";
                    hddCreditStatus.Value = lstObj.RESULT_OBJ[0].CreditStatus.ToString();
                    hddHealthCheckStatus.Value = lstObj.RESULT_OBJ[0].HealthCheckStatus.ToString();
                    hddIsRegisterSuccess.Value = lstObj.RESULT_OBJ[0].Req_IsRegisterSuccess.ToString();
                    hddIsApprove.Value = lstObj.RESULT_OBJ[0].IsApprove.ToString();
                    hddSendEmailStatus.Value = lstObj.RESULT_OBJ[0].SendEmailStatus.ToString();
                }
            }

            else
            {
                hddprofileRegister.Value = "0";
            }

            var lstObjConsult = UIDMapDIPROMCon.Instance.GetProfileDiprom(uid);

            if (lstObjConsult.RESULT_STATUS == "OK" && lstObjConsult.RESULT_OBJ.Count > 0)
            {
                var isConsultFA = lstObjConsult.RESULT_OBJ[0].IsContactFA;
                var isConsultClinic = lstObjConsult.RESULT_OBJ[0].IsContactClinic;  

                if (isConsultFA == true)
                {
                    hddIsConsultFASuccess.Value = "1";                 
                }
                if(isConsultClinic == true)
                {
                    hddIsConsultClinicSuccess.Value = "1";
                }
            }
            else
            {
                hddIsConsultFASuccess.Value = "0";
                hddIsConsultClinicSuccess.Value = "0";
            }

        }
    }
}