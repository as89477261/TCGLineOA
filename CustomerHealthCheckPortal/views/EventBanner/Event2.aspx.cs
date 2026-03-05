using BLL.Controller.HealthCheck;
using System;
using System.Web.UI;
using System.Configuration;
using System.Collections.Specialized;
using System.Configuration.Internal;
using BLL.Controller.FACenter;
using System.Linq;
using BLL.Controller;

namespace CustomerHealthCheck.views.EventBanner
{
    public partial class Event2 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingProvince();
                BindingProfile();
                BindingConfig();

                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Debt_HoldingCode21_Load);
            }
        }

        private void BindingConfig()
        {
            var dummyID = Guid.NewGuid().ToString();

            hddDummyID.Value = dummyID;
            hddAcceptCondition.Value = "0";
        }

        private void BindingProvince()
        {
            var result = ProvinceCon.Instance.GetProvinceAll();
            ddlProvince.DataSource = result.RESULT_OBJ;
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "ProvinceCode";
            ddlProvince.DataBind();
        }

        private void BindingProfile()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", ConfigurationManager.AppSettings["APIPartialCode"]);
            var lstObj = UIDMapDebtEventCon.Instance.GetUIDMapDebtEvent(uid, "001");
            
            if (lstObj.RESULT_STATUS == "OK" && lstObj.RESULT_OBJ.Count > 0)
            {
                var isRegisterSuccess = lstObj.RESULT_OBJ[0].IsRegisterSuccess;
                if (isRegisterSuccess == true) { 
                //BindingPanel(true);
                hddDataProfile.Value = "1";
                }
            }
            else
            {
                //BindingPanel(false);
                hddDataProfile.Value = "0";
            }
        }

        private void BindingPanel(bool isHaveEvent)
        {

            if (isHaveEvent)
            {
                hddDataProfile.Value = "1"; 
            }
            else
            {
                hddDataProfile.Value = "0";
            }
        }

    }
}