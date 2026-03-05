using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using BLL.Controller;
using BLL.Controller.FACenter;
using BLL.Controller.HealthCheck;
using BLL.Controller.NDID;
using CoreUtility;
using DataModel.Models.CustomerHealthModel;
using DataModel.Models.CustomerHealthModel.AppModel;
using DataModel.Models.CustomerHealthModel.EventsModel;
using DataModel.Models.FACenter;
using DataModel.Models.Line;
using DataModel.Models.SMEClinic;
using Newtonsoft.Json;
using Utiltiy;

namespace CustomerHealthCheck
{
    public partial class Register_KM : BasePage
    {
        private string code = string.Empty;
        private bool isHasItem;
        private bool isHasProfile;
        private LineOAuthTokenModel lineInfo;
        private string state = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ConfigSite();
            BindingInfo();
            SetAuthorizationToken();
            GetUserProfile();

            const string dtBannerEvent1 = "2023-05-11 00:00:00";
            var parseExactEvent1 = DateTime.ParseExact(dtBannerEvent1, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            const string dtBannerEvent1End = "2024-01-01 00:00:00";
            var paresExactEvent1End = DateTime.ParseExact(dtBannerEvent1End, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            hddBannerEvent1.Value = DateTime.Now > parseExactEvent1 && DateTime.Now < paresExactEvent1End ? "1" : "0";


            var bannerStartDate = GetAppsetting("BannerStartDate");
            //const string dtBannerEvent2 = "2023-05-29 00:00:00";
            var parseExactEvent2 = DateTime.ParseExact(bannerStartDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            var bannerEndDate = GetAppsetting("BannerEndDate");
            //const string dtBannerEvent2End = "2024-06-19 00:00:00";
            var parseExactEvent2End = DateTime.ParseExact(bannerEndDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            hddBannerEvent2.Value = DateTime.Now > parseExactEvent2 && DateTime.Now < parseExactEvent2End ? "1" : "0";

            LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Main_Load);
        }

        protected void ConfigSite()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            hddHomeUrl.Value = GetAppsetting("HomeUrl");
            hddContactDoctor.Value = GetAppsetting("ContactDoctorURL");
            hddSetThailandURL.Value = GetAppsetting("SetThailandURL");
        }

        private void BindingInfo()
        {
            BindingProfile();
            BindingTop5ItemHistory();
            BindingScreen();
            BindingMenuFeature();
            BindingMenuFeatureWithCondition();
        }

        private void BindingMenuFeature()
        {
            var IsShowDebtDoctorFeature = GetAppsetting("IsShowDebtDoctorFeature");
            var IsShowDebtRegisterFeature = GetAppsetting("IsShowDebtRegisterFeature");
            var IsShowHealthCheckFeature = GetAppsetting("IsShowHealthCheckFeature");
            var IsShowEventFeature = GetAppsetting("IsShowEventFeature");

            var IsShowRegister = GetAppsetting("IsShowRegister");
            var IsShowCheckRequest = GetAppsetting("IsShowCheckRequest");
            var IsShowCheckMyLG = GetAppsetting("IsShowCheckLG");
            var IsShowCheckMyBill = GetAppsetting("IsShowCheckMyBill");
            var IsShowCalculate = GetAppsetting("IsShowCalculate");
            var IsShowMyQR = GetAppsetting("IsShowCalculate");

            // Bar Menu
            pnlHealthCheckMenu.Visible = IsShowHealthCheckFeature == "1";
            pnlDebtDoctorMenu.Visible = IsShowDebtDoctorFeature == "1";
            pnlDebtRegisterMenu.Visible = IsShowDebtRegisterFeature == "1";
            pnlEventMenu.Visible = IsShowEventFeature == "1";
            pnlRegisterWithTCGDB.Visible = IsShowRegister == "1";

            // ListMenu
            pnlRegisterWithTCGDB.Visible = IsShowRegister == "1";
            pnlCheckRequestStatusMenu.Visible = (IsShowCheckRequest == "1" ? true : false);
            pnlCheckMyLGStatusMenu.Visible = IsShowCheckMyLG == "1";
            pnlCheckMyBillStatusMenu.Visible = IsShowCheckMyBill == "1";
            pnlCalculator.Visible = (IsShowCalculate == "1" ? true : false);
            btnPersonalQR.Visible = (IsShowMyQR == "1" ? true : false);
        }

        private void BindingMenuFeatureWithCondition()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var bufferEnrollObj = UIDMapEnrollmentCon.Instance().GetUIDMapEnrollment(uid);

            if (bufferEnrollObj.RESULT_STATUS == "OK" && bufferEnrollObj.RESULT_OBJ != null)
            {
                pnlRegisterWithTCGDB.Visible = false;
                pnlCheckRequestStatusMenu.Visible = true;
                pnlCheckMyLGStatusMenu.Visible = true;
                pnlCheckMyBillStatusMenu.Visible = true;
            }
            else
            {
                pnlRegisterWithTCGDB.Visible = true;
                pnlCheckRequestStatusMenu.Visible = false;
                pnlCheckMyLGStatusMenu.Visible = false;
                pnlCheckMyBillStatusMenu.Visible = false;
            }
        }

        #region Process 2 : KeepTokenToTCGDatabase

        private void InsertOrUpdateUID()
        {
            // IF Exist Process will update uid in uidTable 
            // IF New player process will insert new row in UidTable for keep all information and consent for dummy info

            try
            {
                if (lineInfo?.lineRawTokenObject == null) return;
                var result = UIDCon.Instance.InsertUIDAndDummyConsent(lineInfo.lineRawTokenObject);
                if (result.RESULT_STATUS == "OK")
                {
                    //LogSuccess;
                }
            }
            catch (Exception)
            {
                // Log Error
            }
        }

        #endregion

        #region Process 3 : CheckUserConsent

        private void CheckUserConsent()
        {
            try
            {
                var uid = GetUid();
                if (string.IsNullOrEmpty(uid)) return;
                var bufferConsent = ConsentCon.Instance.GetConsentByUID(uid);
                if (bufferConsent.RESULT_OBJ != null
                    && bufferConsent.RESULT_OBJ.Consent1 == null
                    && bufferConsent.RESULT_OBJ.Consent2 == null
                    && bufferConsent.RESULT_OBJ.Consent3 == null
                   )
                    Response.Redirect("~/views/PDPA/info");
            }
            catch (Exception)
            {
            }
        }

        #endregion

        protected void btnReset_Click(object sender, EventArgs e)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            UIDCon.Instance.DeleteDataByUID(uid);
            Response.Redirect("~/Landing.aspx");
        }

        #region Process 1 : GetKeyTokenFromLineOAuthen2

        private void GetQueryString()
        {
            code = Request.QueryString["code"];
            state = Request.QueryString["state"];
        }

        private void GetJWT()
        {
            try
            {
                if (string.IsNullOrEmpty(code)) return;
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
            catch (Exception)
            {
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
            catch (Exception)
            {
            }
        }

        #endregion

        #region Process 4 : BindingInfo

        private void BindingProfile()
        {
            try
            {
                var uid = GetUid();
                if (string.IsNullOrEmpty(uid)) return;
                var bufferProfile = CustomerProfileCon.Instance.GetCustomerProfileHistoryByUID(uid);
                if (bufferProfile.RESULT_STATUS != "OK" || bufferProfile.RESULT_OBJ.Count <= 0) return;
                var bufferResult = bufferProfile.RESULT_OBJ.FirstOrDefault();
                if (bufferResult?.Code != null && bufferResult.Code != 0)
                {
                    isHasProfile = true;
                    hddIshaveProfile.Value = "true";
                }
                else
                {
                    hddIshaveProfile.Value = "false";
                }

                BindingNdidStatus(bufferResult);
            }
            catch (Exception)
            {
            }
        }

        private static void BindingNdidStatus(CustomerProfileHistoryModel obj)
        {
            if (obj.IsSuccess)
            {
            }
        }

        private void BindingTop5ItemHistory()
        {
            try
            {
                var uid = GetUid();
                if (uid == null) return;
                var bufferApproach = ApprochCon.Instance.GetUIDMapApproch(uid);
                var bufferRegisterInfo =
                    RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", "HealthCheck", "HC");
                var bufferFaDebt = UIDMapFATransactionCon.Instance.GetUIDMapTransAndFormByID(uid);
                var bufferEventItem = UIDMapEventRegisterCon.Instance.GetFormRegisterWithGroupAndUID(uid);
                var bufferRegisterPgs10Info =
                    RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", "HealthCheck", "PGS10");
                var bufferRegisterPgs11Info =
                    RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", "HealthCheck", "PGS11");

                var lstActivityItem = ApproachItemToActivityItem(bufferApproach.RESULT_OBJ).ToList();
                lstActivityItem.AddRange(RegisterInfoToActivityItem(bufferRegisterInfo.RESULT_OBJ));
                lstActivityItem.AddRange(FaCenterDebtToActivityItem(bufferFaDebt.RESULT_OBJ));
                lstActivityItem.AddRange(EventRegisterToActivityItem(bufferEventItem.RESULT_OBJ));
                lstActivityItem.AddRange(RegisterInfoPgs10ToActivityItem(bufferRegisterPgs10Info.RESULT_OBJ));
                lstActivityItem.AddRange(RegisterInfoPgs11ToActivityItem(bufferRegisterPgs11Info.RESULT_OBJ));


                if (lstActivityItem.Count <= 0) return;
                var orderedLst = lstActivityItem.OrderByDescending(x => x.Date).Take(5).ToList();
                var firstItem = orderedLst.FirstOrDefault();
                var bufferHtmlItem =
                    TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateHealthCheckHistoryWithReduce(
                        firstItem.LeveL, firstItem.Type,
                        "วันที่ " + firstItem.Date.ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                        firstItem.Status, 1, firstItem.Remark1); //, firstItem.RegisterInfoID.ToString());

                if (orderedLst.Count > 1)
                    for (var i = 1; i < orderedLst.Count; i++)
                    {
                        bufferHtmlItem +=
                            TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                        bufferHtmlItem +=
                            TCG_HealthCheckTemplateManager.HealthCheckHistory
                                .GenerateHealthCheckHistoryWithReduce(orderedLst[i].LeveL, orderedLst[i].Type,
                                    "วันที่ " + orderedLst[i].Date
                                        .ToString("dd/MM/yyyy", new CultureInfo("th-TH")), orderedLst[i].Status,
                                    1, orderedLst[i].Remark1); //, firstItem.RegisterInfoID.ToString());
                    }

                isHasItem = true;
                ltlHistoryItem.Text = bufferHtmlItem;
            }
            catch (Exception)
            {
            }
        }

        private static IEnumerable<ActivityItem> ApproachItemToActivityItem(IReadOnlyCollection<UIDMapApprochModel> lstObj)
        {
            return lstObj == null || lstObj.Count == 0
                ? new List<ActivityItem>()
                : lstObj.Select(item => new ActivityItem
                {
                    LeveL = "4",
                    Type = "2",
                    Status = "",
                    Date = item.Createdate,
                    ReduceLevel = 1,
                    Remark1 = item.ProductName
                });
        }

        private static IEnumerable<ActivityItem> RegisterInfoToActivityItem(IReadOnlyCollection<RegisterInfoModel> lstObj)
        {
            return lstObj == null || lstObj.Count == 0
                ? new List<ActivityItem>()
                : lstObj.Select(item => new ActivityItem
                {
                    LeveL = item.ScoreGroup.ToString(),
                    Type = "1",
                    Status = item.GroupShortDesc,
                    Date = item.CreateDate,
                    ReduceLevel = 1,
                    Remark1 = "1"
                });
        }

        private static IEnumerable<ActivityItem> FaCenterDebtToActivityItem(IReadOnlyCollection<UIDMapTransAndFormRegisModel> lstObj)
        {
            return lstObj == null || lstObj.Count == 0
                ? new List<ActivityItem>()
                : lstObj.Select(item => new ActivityItem
                {
                    LeveL = item.Dept_Recon_ObjectId.ToString(),
                    Type = "3",
                    Status = "มาตรการที่ " + item.Dept_Recon_ObjectId,
                    Date = item.CreateDate,
                    ReduceLevel = 1,
                    Remark1 = "ลงทะเบียนประนอมหนี้"
                });
        }

        private static IEnumerable<ActivityItem> EventRegisterToActivityItem(IReadOnlyCollection<FormEventRegisterOutputModel> lstObj)
        {
            return lstObj == null || lstObj.Count == 0
                ? new List<ActivityItem>()
                : lstObj.Select(item => new ActivityItem
                {
                    LeveL = item.CallCenterStatus,
                    Type = "4",
                    Status = GenString(item.CallCenterStatus),
                    Date = item.CreateDate,
                    ReduceLevel = 1,
                    Remark1 = "ลงทะเบียนกิจกรรม " + item.EventName
                });
        }

        private static IEnumerable<ActivityItem> RegisterInfoPgs10ToActivityItem(IReadOnlyCollection<RegisterInfoModel> lstObj)
        {
            return lstObj == null || lstObj.Count == 0
                ? new List<ActivityItem>()
                : lstObj.Select(item => new ActivityItem
                {
                    LeveL = item.ScoreGroup.ToString(),
                    Type = "5",
                    Status = "", // item.GroupShortDesc;
                    Date = item.CreateDate,
                    ReduceLevel = 1,
                    Remark1 = "ลงทะเบียนโครงการ PGS 10"
                });
        }

        private static IEnumerable<ActivityItem> RegisterInfoPgs11ToActivityItem(IReadOnlyCollection<RegisterInfoModel> lstObj)
        {
            return lstObj == null || lstObj.Count == 0
                ? new List<ActivityItem>()
                : lstObj.Select(item => new ActivityItem
                {
                    LeveL = item.ScoreGroup.ToString(),
                    Type = "5",
                    Status = "", // item.GroupShortDesc;
                    Date = item.CreateDate ,
                    ReduceLevel = 1,
                    Remark1 = "ลงทะเบียนโครงการ PGS 11 "
                });
        }

        private static string GenString(string status)
        {
            switch (status)
            {
                case "1":
                    return "รอติดตาม";
                case "2":
                    return "ติดตามแล้ว";
                default:
                    return "";
            }
        }

        private void BindingScreen()
        {
            pnlHistoryItem.Visible = isHasItem;

            if (!isHasProfile) btnToProfile.Attributes.Add("Class", "disabledPanel");

            pnlTestCommand.Visible = ConfigurationManager.AppSettings["IsShowResetButton"] == "1";
        }

        #endregion

        #region CoreProcess

        private string GetUid()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            SessionHelper.UID = uid;
            if (string.IsNullOrEmpty(uid)) RedirectToOriginLineURL();

            return uid;
        }

        private void GetUserProfile()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid == null) return;

                LocalLogManager.Logger("Main Index Get UID : " + uid);

                var bufferProfile = CustomerProfileCon.Instance.GetCustomerProfileHistoryByUID(uid);
                if (bufferProfile.RESULT_STATUS != "OK" || bufferProfile.RESULT_OBJ.Count <= 0) return;

                LocalLogManager.Logger("Main Index Get Profile : " + JsonConvert.SerializeObject(bufferProfile));

                // not complete 
                var dataListObj = bufferProfile.RESULT_OBJ.OrderByDescending(x => x.CreateDateTime).ToList();

                var personalProfile = dataListObj.FirstOrDefault(x => x.IdCardType == 1);
               
                LocalLogManager.Logger("Main Index Get Profile : " + JsonConvert.SerializeObject(personalProfile));
                CookieManager.SetEncryptCookie("lineoa", "rIDCard", personalProfile.IdCard,
                    GetAppsetting("APIPartialCode"));


                var idCard = CookieManager.GetEncryptCookie("lineoa", "rIDCard", GetAppsetting("APIPartialCode"));
                LocalLogManager.Logger("Main Index Get rIDCard : " + idCard);



            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("Main Index Get Profile Error : " + ex.GetBaseException().Message);
            }
        }

        private void SetAuthorizationToken()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            if (uid == null) return;
            var bufferUid = CryptographyManager.Encrypt(uid);
            // bufferUid = CryptographyManager.Base64Encode(bufferUid);
            if (bufferUid != null)
                CookieManager.SetEncryptCookie("lineoa", "uidtoken", bufferUid, GetAppsetting("APIPartialCode"));
        }

        #endregion
    }
}