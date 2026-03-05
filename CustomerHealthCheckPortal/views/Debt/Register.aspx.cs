using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Controller;
using BLL.Controller.HealthCheck;

namespace CustomerHealthCheck.views.Debt
{
    public partial class Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingProvince();
                BindingCustomerProfile();
                //BindingEventCode();
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

                var dictData = new Dictionary<string, string>();
                if (personal != null)
                {
                    dictData.Add("pTitle", personal.TitleCode);
                    dictData.Add("pName", personal.Name);
                    dictData.Add("pLastName", personal.SureName);
                    dictData.Add("pCompany", personal.CompanyName);
                    dictData.Add("pIDCard", personal.IdCard);
                    dictData.Add("pProvince", "");
                    dictData.Add("pMobile", personal.MobileNumber);
                    pnlPersonal.Visible = true;
                }

                if (juristic != null)
                {
                    dictData.Add("jTitle", juristic.TitleCode);
                    dictData.Add("jName", juristic.Name);
                    dictData.Add("jLastName", juristic.SureName);
                    dictData.Add("jCompany", juristic.CompanyName);
                    dictData.Add("jIDCard", juristic.IdCard);
                    dictData.Add("jProvince", "");
                    dictData.Add("jMobile", juristic.MobileNumber);
                    pnlJuristic.Visible = true;
                }


                CookieManager.SetEncryptListCookie("lineoa", dictData, GetAppsetting("APIPartialCode"));
            }
        }

        private void BindingEventCode()
        {
            var eventCode = Request.QueryString[""];
        }
    }
}