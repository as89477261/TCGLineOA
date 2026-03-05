using System;
using System.Linq;
using BLL.Controller;
using BLL.Controller.HealthCheck;

namespace CustomerHealthCheck.viewx.Questionaire
{
    public partial class Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingProvince();
                BindingCustomerProfile();
            }
        }

        private void BindingProvince()
        {
            var result = ProvinceCon.Instance.GetProvinceAll();
            ddlProvince.DataSource = result.RESULT_OBJ;
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "ProvinceCode";
            ddlProvince.DataBind();
        }

        private void BindingCustomerProfile()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var bufferUID = CustomerProfileCon.Instance.GetCustomerProfileHistoryByUID(uid);
            if (bufferUID.RESULT_CODE == "200")
            {
                var personal = bufferUID.RESULT_OBJ.Where(x => x.IdCardType == 1).FirstOrDefault();
                var juristic = bufferUID.RESULT_OBJ.Where(x => x.IdCardType == 2).FirstOrDefault();

                if (personal != null)
                {
                    CookieManager.SetEncryptCookie("lineoa", "pTitle", personal.TitleCode,
                        GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "pName", personal.Name, GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "pLastName", personal.SureName,
                        GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "pCompany", personal.CompanyName,
                        GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "pIDCard", personal.IdCard,
                        GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "pProvince", "", GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "pMobile", personal.MobileNumber,
                        GetAppsetting("APIPartialCode"));
                    pnlPersonal.Visible = true;
                }

                if (juristic != null)
                {
                    CookieManager.SetEncryptCookie("lineoa", "jTitle", juristic.TitleCode,
                        GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "jName", juristic.Name, GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "jLastName", juristic.SureName,
                        GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "jCompany", juristic.CompanyName,
                        GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "jIDCard", juristic.IdCard,
                        GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "jProvince", "", GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "jMobile", juristic.MobileNumber,
                        GetAppsetting("APIPartialCode"));
                    pnlJuristic.Visible = true;
                }
            }
        }
    }
}