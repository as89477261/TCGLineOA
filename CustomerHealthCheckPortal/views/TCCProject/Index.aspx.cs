using BLL.Controller;
using BLL.Controller.HealthCheck;
using CustomerHealthCheck.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Newtonsoft.Json;

namespace CustomerHealthCheck.views.TCCProject
{
    public partial class Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                BindingInfo();
                BindingProfile();
                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Events_TCCProject_Load);               
        }



        private void BindingInfo()
        {
            var resultDetail = ProvinceCon.Instance.GetProvinceDetail();

            ddlProvinceTH.DataSource = resultDetail.RESULT_OBJ.Select(o => new { o.ProvinceName }).Distinct().OrderBy(o => o.ProvinceName);
            ddlProvinceTH.DataTextField = "ProvinceName";
            ddlProvinceTH.DataValueField = "ProvinceName";
            ddlProvinceTH.DataBind();

            ddlZipcode.DataSource = resultDetail.RESULT_OBJ.Select(o=> new {o.Postcode}).Distinct().OrderBy(o=>o.Postcode);
            ddlZipcode.DataTextField = "Postcode";
            ddlZipcode.DataValueField = "Postcode";
            //ddlZipcode.DataBind();

            ddlTambolTH.DataSource = resultDetail.RESULT_OBJ.Select(o=>  new {o.Tumbol}).Distinct().OrderBy(o=>o.Tumbol);
            ddlTambolTH.DataTextField = "Tumbol";
            ddlTambolTH.DataValueField = "Tumbol";
            //ddlTambolTH.DataBind();

            ddlAmphurTH.DataSource = resultDetail.RESULT_OBJ.Select(o => new { o.Aumpur }).Distinct().OrderBy(o => o.Aumpur);
            ddlAmphurTH.DataTextField = "Aumpur";
            ddlAmphurTH.DataValueField = "Aumpur";
            //ddlAmphurTH.DataBind();

            var jsonAddresss = JsonConvert.SerializeObject(resultDetail.RESULT_OBJ);

            hddJsonAddress.Value = jsonAddresss; 
        }

        private void BindingProfile()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", ConfigurationManager.AppSettings["APIPartialCode"]);

            hddacceptCondition.Value = "0";

            if (uid != null)
            {
                var lstObj = TCCProjectCon.Instance.GetUidDataTCC(uid);

                if(lstObj.RESULT_STATUS == "OK" && lstObj.RESULT_OBJ.Count > 0)
                {
                    var isRegisterSuccess = lstObj.RESULT_OBJ[0].IsRegisterSuccess;
                    var profileInformation = lstObj.RESULT_OBJ[0].InformationId ?? "";
                    var registerNo = lstObj.RESULT_OBJ[0].registerNo ?? "";

                    
                    hddProfileInformation.Value = profileInformation.ToString();
                    hddProfileStatus.Value = "neverRegister";
                    hddProfileRegisterNo.Value = registerNo.ToString();

                    if (isRegisterSuccess == null && hddProfileInformation.Value != "") /* DOIT เพิ่ม เงื่อนไขอีก ฟิลด์ หลังยิง API เรียบร้อยในการสมัคร*/
                    {
                        hddProfileStatus.Value = "registerRepeatAPI";
                    }
                    if (isRegisterSuccess == false && hddProfileInformation.Value != "")
                    {
                        hddProfileStatus.Value = "registerRepeatAPI";
                    }
                    if(isRegisterSuccess == true && hddProfileInformation.Value != "")/* DOIT เพิ่ม เงื่อนไขอีก ฟิลด์ หลังยิง API เรียบร้อยในการสมัคร*/
                    {
                        hddProfileStatus.Value = "registerComplete";
                    }
                }
                else
                {
                    hddProfileStatus.Value = "neverRegister";
                }
            }
            else
            {
                RedirectToOriginLineURL(); 
            }

        }


    }
}