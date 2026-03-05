using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using BLL.Controller;
using BLL.Controller.FACenter;
using BLL.Controller.HealthCheck;
using CoreUtility;
using DataModel.Models.CustomerHealthModel;
using DataModel.Models.CustomerHealthModel.AppModel;
using DataModel.Models.CustomerHealthModel.EventsModel;
using DataModel.Models.FACenter;
using DataModel.Models.Line;
using Utiltiy;

namespace CustomerHealthCheck
{
    public partial class index_inno : BasePage
    {
        private string code = string.Empty;
        private bool isHasItem;
        private bool isHasProfile;
        private LineOAuthTokenModel lineInfo;
        private string state = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ConfigSite();
                //GetKeyTokenFromLineOAuthen2();
                //KeepTokenToTCGDatabase();
                //ValidateFirstCondition();
                //BindingInfo();
            }
        }

        protected void ConfigSite()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            hddHomeUrl.Value = GetAppsetting("HomeUrl");
        }

        private void BindingInfo()
        {
            BindingProfile();
            bindingTop5ItemHistory();
            BindingScreen();

            BindingMenuFeature();
        }

        private void BindingMenuFeature()
        {
            var IsShowTCGProductFeature = GetAppsetting("IsShowTCGProductFeature");
            var IsShowTCGDebtFeature = GetAppsetting("IsShowTCGDebtFeature");
            var IsShowTCGHealthCheckFeature = GetAppsetting("IsShowTCGHealthCheckFeature");
            var IsShowTCGNDIDFeature = GetAppsetting("IsShowTCGNDIDFeature");
            var IsShowEventFeature = GetAppsetting("IsShowEventFeature");

            //btnProductFeature.Visible = (IsShowTCGProductFeature == "1" ? true : false);
            //btnDebtFeature.Visible = (IsShowTCGDebtFeature == "1" ? true : false);
            //btnHealthCheckFeature.Visible = (IsShowTCGHealthCheckFeature == "1" ? true : false);
            //btnEventFeature.Visible = (IsShowEventFeature == "1" ? true : false);
            //btnProductFeature.Visible = (IsShowTCGNDIDFeature == "1" ? true : false);
        }

        #region Process 2 : KeepTokenToTCGDatabase

        private void InsertOrUpdateUID()
        {
            // IF Exist Process will update uid in uidTable 
            // IF New player process will insert new row in UidTable for keep all information and consent for dummy info

            try
            {
                if (lineInfo != null && lineInfo.lineRawTokenObject != null)
                {
                    var result = UIDCon.Instance.InsertUIDAndDummyConsent(lineInfo.lineRawTokenObject);
                    if (result.RESULT_STATUS == "OK")
                    {
                        //LogSuccess;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Process 3 : CheckUserConsent

        private void CheckUserConsent()
        {
            try
            {
                var uid = GetUID();
                if (!string.IsNullOrEmpty(uid))
                {
                    var bufferConsent = ConsentCon.Instance.GetConsentByUID(uid);
                    if (bufferConsent.RESULT_OBJ != null
                        && bufferConsent.RESULT_OBJ.Consent1 == null
                        && bufferConsent.RESULT_OBJ.Consent2 == null
                        && bufferConsent.RESULT_OBJ.Consent3 == null
                       )
                        Response.Redirect("~/views/PDPA/info");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region CoreProcess

        private string GetUID()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            SessionHelper.UID = uid;
            if (string.IsNullOrEmpty(uid)) RedirectToOriginLineURL();
            ;

            return uid;
        }

        #endregion

        #region Process 1 : GetKeyTokenFromLineOAuthen2 ด

        private void GetQueryString()
        {
            code = Request.QueryString["code"];
            state = Request.QueryString["state"];
        }

        private void GetJWT()
        {
            try
            {
                if (!string.IsNullOrEmpty(code))
                {
                    var dataForm3 = new Dictionary<string, string>
                    {
                        { "grant_type", "authorization_code" },
                        { "code", code },
                        { "redirect_uri", GetAppsetting("redirectURL") },
                        { "client_id", GetAppsetting("client_id") },
                        { "client_secret", GetAppsetting("client_secret") }
                    };

                    var headerForm = new Dictionary<string, string>();

                    lineInfo = HTTPManager.HttpPostWithForm3<LineOAuthTokenModel>(
                        GetAppsetting("lineOAuthURL"),
                        headerForm,
                        dataForm3
                    ).Result;

                    lineInfo.DecodeToRawData();

                    if (GetAppsetting("IsKeepRawData") == "1")
                    {
                    }

                    //Binding(lineInfo.lineRawTokenObject);
                    lblUID1.Text = lineInfo.lineRawTokenObject.sub;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void KeepCookieToClient()
        {
            try
            {
                if (lineInfo != null)
                {
                    CookieManager.SetEncryptCookie("lineoa", "uid", lineInfo.lineRawTokenObject.sub,
                        GetAppsetting("APIPartialCode"));
                    CookieManager.SetEncryptCookie("lineoa", "pic", lineInfo.lineRawTokenObject.picture,
                        GetAppsetting("APIPartialCode"));
                }
                else
                {
                    var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                    if (string.IsNullOrEmpty(uid)) RedirectToOriginLineURL();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Process 4 : BindingInfo

        private void BindingProfile()
        {
            try
            {
                var uid = GetUID();
                if (!string.IsNullOrEmpty(uid))
                {
                    var bufferProfile = CustomerProfileCon.Instance.GetCustomerProfileHistoryByUID(uid);
                    if (bufferProfile.RESULT_STATUS == "OK" && bufferProfile.RESULT_OBJ.Count > 0)
                    {
                        var bufferResult = bufferProfile.RESULT_OBJ.FirstOrDefault();
                        if (bufferResult.Code != 0 && bufferResult.Code != 0)
                        {
                            isHasProfile = true;
                            hddIshaveProfile.Value = "true";
                        }
                        else
                        {
                            hddIshaveProfile.Value = "false";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void bindingTop5ItemHistory()
        {
            try
            {
                LocalLogManager.Logger("Get history");
                var uid = GetUID();
                if (uid != null)
                {
                    var bufferApproch = ApprochCon.Instance.GetUIDMapApproch(uid);
                    var bufferRegisterInfo = RegisterInfoCon.Instance.GetTop5RegisInfoByUID(uid);
                    var bufferFADebt = UIDMapFATransactionCon.Instance.GetUIDMapTransAndFormByID(uid);
                    var bufferEventItem = UIDMapEventRegisterCon.Instance.GetFormRegisterWithGroupAndUID(uid);

                    var lstActivityItem = ApprochItemToActivityItem(bufferApproch.RESULT_OBJ);
                    lstActivityItem.AddRange(RegisterInnfoToActivityItem(bufferRegisterInfo.RESULT_OBJ));
                    lstActivityItem.AddRange(FACenterDebtToActivityItem(bufferFADebt.RESULT_OBJ));
                    lstActivityItem.AddRange(EventRegisterToActivityItem(bufferEventItem.RESULT_OBJ));

                    if (lstActivityItem.Count > 0)
                    {
                        var OrderedLst = lstActivityItem.OrderByDescending(x => x.Date).Take(5).ToList();
                        var firstItem = OrderedLst.FirstOrDefault();
                        var bufferHtmlItem =
                            TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateHealthCheckHistoryWithReduce(
                                firstItem.LeveL, firstItem.Type,
                                "วันที่ " + firstItem.Date.ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                                firstItem.Status, 1, firstItem.Remark1); //, firstItem.RegisterInfoID.ToString());

                        if (OrderedLst.Count > 1)
                            for (var i = 1; i < OrderedLst.Count; i++)
                            {
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.HealthCheckHistory
                                        .GenerateHealthCheckHistoryWithReduce(OrderedLst[i].LeveL, OrderedLst[i].Type,
                                            "วันที่ " + OrderedLst[i].Date
                                                .ToString("dd/MM/yyyy", new CultureInfo("th-TH")), OrderedLst[i].Status,
                                            1, OrderedLst[i].Remark1); //, firstItem.RegisterInfoID.ToString());
                            }

                        isHasItem = true;
                        //ltlHistoryItem.Text = bufferHtmlItem;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private List<ActivityItem> ApprochItemToActivityItem(List<UIDMapApprochModel> lstObj)
        {
            if (lstObj != null && lstObj.Count > 0)
            {
                var obj = new List<ActivityItem>();
                foreach (var item in lstObj)
                {
                    var buffer = new ActivityItem();
                    buffer.LeveL = "4";
                    buffer.Type = "2";
                    buffer.Status = "";
                    buffer.Date = item.Createdate;
                    buffer.ReduceLevel = 1;
                    buffer.Remark1 = item.ProductName;
                    obj.Add(buffer);
                }

                return obj;
            }

            return new List<ActivityItem>();
        }

        private List<ActivityItem> RegisterInnfoToActivityItem(List<RegisterInfoModel> lstObj)
        {
            if (lstObj != null && lstObj.Count > 0)
            {
                var obj = new List<ActivityItem>();
                foreach (var item in lstObj)
                {
                    var buffer = new ActivityItem();
                    buffer.LeveL = item.ScoreGroup.ToString();
                    buffer.Type = "1";
                    buffer.Status = item.GroupShortDesc;
                    buffer.Date = item.CreateDate;
                    buffer.ReduceLevel = 1;
                    buffer.Remark1 = "";
                    obj.Add(buffer);
                }

                return obj;
            }

            return new List<ActivityItem>();
        }

        private List<ActivityItem> FACenterDebtToActivityItem(List<UIDMapTransAndFormRegisModel> lstObj)
        {
            if (lstObj != null && lstObj.Count > 0)
            {
                var obj = new List<ActivityItem>();
                foreach (var item in lstObj)
                {
                    var buffer = new ActivityItem();
                    buffer.LeveL = item.Dept_Recon_ObjectId.ToString();
                    buffer.Type = "3";
                    buffer.Status = "มาตรการที่ " + item.Dept_Recon_ObjectId;
                    buffer.Date = item.CreateDate;
                    buffer.ReduceLevel = 1;
                    buffer.Remark1 = "ลงทะเบียนประนอมหนี้";
                    obj.Add(buffer);
                }

                return obj;
            }

            return new List<ActivityItem>();
        }

        private List<ActivityItem> EventRegisterToActivityItem(List<FormEventRegisterOutputModel> lstObj)
        {
            if (lstObj != null && lstObj.Count > 0)
            {
                var obj = new List<ActivityItem>();
                foreach (var item in lstObj)
                {
                    var buffer = new ActivityItem();
                    buffer.LeveL = "ลงทะเบียนกิจกรรม " + item.EventName;
                    buffer.Type = "4";
                    buffer.Status = "";
                    buffer.Date = item.CreateDate;
                    buffer.ReduceLevel = 1;
                    buffer.Remark1 = "ลงทะเบียนกิจกรรม " + item.EventName;
                    obj.Add(buffer);
                }

                return obj;
            }

            return new List<ActivityItem>();
        }

        private void BindingScreen()
        {
            if (isHasItem == false)
            {
                // pnlHistoryItem.Visible = false;
                btnToActivity.Attributes.Add("Class", "disabledPanel");
            }

            //pnlHistoryItem.Visible = true;
            if (isHasProfile == false) btnToProfile.Attributes.Add("Class", "disabledPanel");
        }

        #endregion
    }
}