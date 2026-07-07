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
using CustomerHealthCheck.ServiceInterface;
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
    // Represents a promotional banner
    public class CampaignBanner
    {
        public string ID { get; set; }
        public string ImageUrl { get; set; }
        public string TargetUrl { get; set; }
        public string RedirectUrl { get; set; } = "#";
        public bool IsVisible { get; set; } = true;
        public string TrackEventId { get; set; } = null;
    }


    public class ServiceMenuItem
    {
        public string Title { get; set; }
        public string IconCssClass { get; set; }
        public string ClickAction { get; set; }
        public bool IsVisible { get; set; }
    }

    public class MainMenuAction
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconCssClass { get; set; }
        public string ClickAction { get; set; }
        public bool IsVisible { get; set; }
        public bool IsNew { get; set; } // To handle the "New" badge
    }

    public class ConfirmPromptKhumMenu
    {
        public string Title { get; set; }
        public string BtnTitle { get; set; }
        public string Description { get; set; }
        public string IconCssClass { get; set; }
        public string ClickAction { get; set; }
        public bool IsVisible { get; set; }
    }
    public partial class index : BasePage
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
            SetPersonalToken();
            GetUserProfile();
            //ConfigBanner();
            BindBanners();

            LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Main_Load);

        }

        // Helper function to centralize date checking from AppSettings
        private bool IsDateInRange(string startAppSetting, string endAppSetting)
        {
            try
            {
                var startDate = DateTime.ParseExact(GetAppsetting(startAppSetting), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                var endDate = DateTime.ParseExact(GetAppsetting(endAppSetting), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                return DateTime.Now > startDate && DateTime.Now < endDate;
            }
            catch
            {
                return false; // If settings are missing or invalid, don't show the banner
            }
        }


        // --- REFACTORED: Date logic for banners is now inside this method ---
        private void BindBanners()
        {
            var campaign = CampaignConfig.GetCampaignConfigActive().Result;

            var campaignConfigBanners = campaign.Select(banner =>
            {
                return new CampaignBanner
                {
                    ID = banner.Id,
                    ImageUrl = banner.Banner,
                    TargetUrl = $"redirectCampaignTo('{banner.Id}')",
                    IsVisible = GetAppsetting("EnableCampaignBanner") == "1" ? true : false
                };
            });

            var banners = new List<CampaignBanner>
            {
                 new CampaignBanner
                 {
                     ID = "TCGAllianceConnect",
                     ImageUrl = "~/images/Banner/TCGAllianceConnect.jpg",
                     TargetUrl = $"redirectCampaignTo('{GetAppsetting("TCGAllianceConnect")}')",
                     IsVisible = IsDateInRange("TCGAllianceConnectStart", "TCGAllianceConnectEnd")
                 },
                 new CampaignBanner {
                     ID = "TCGSupport01",
                     ImageUrl="~/images/Banner/Support01.jpg",
                     TargetUrl =  $"redirectCampaignTo('{GetAppsetting("TCGSupport01")}', 'EVENT_SPECIAL_EVENT', 'Flooding Campaign')",
                     IsVisible =  IsDateInRange("TCGSupport01Start", "TCGSupport01End"),
                  },
                 new CampaignBanner {
                     ID = "TCGSupport01",
                     ImageUrl="~/images/Banner/Support02.jpg",
                     TargetUrl =  $"redirectCampaignTo('{GetAppsetting("TCGSupport02")}', 'EVENT_SPECIAL_EVENT', 'Border Dispute Campaign')",
                     IsVisible =  IsDateInRange("TCGSupport02Start", "TCGSupport02End")
                 },
                 new CampaignBanner {
                    ID = "mainBannerSMEsGoodMoney",
                    ImageUrl = "~/images/Banner/Banner_good_money.jpg",
                    TargetUrl = $"redirectToExternal('{GetAppsetting("GoodMoneyCampaignUrl")}', 'EVENT_GOOD_MONEY_CAMPAIGN', 'Good Money Campaign')",
                    IsVisible = IsDateInRange("GoodMoneyCampaignStart", "GoodMoneyCampaignEnd"),
                },
                new CampaignBanner {
                    ID = "mainBannerSMEsStimulateCampaign", ImageUrl = "~/images/Banner/SMEs_Satimulate_Campaign.jpg", TargetUrl = "RedirectToPage('healthcheck_SMEsStimulateCampaign')",
                    IsVisible = IsDateInRange("SMEsStimulateCampaignStart", "SMEsStimulateCampaignEnd")
                },
                new CampaignBanner {
                    ID = "mainBannerSMEsPickUp", ImageUrl = "~/images/Banner/SmeSPickUp_1.jpg", TargetUrl = "RedirectToPage('healthcheck_SMEsPickUp')",
                    IsVisible = IsDateInRange("SMEsPickUpEventStart", "SMEsPickUpEventEnd")
                },
                new CampaignBanner {
                    ID = "bannerPROMKHUM", ImageUrl = "~/images/Banner/Banner_PromKhum_2.png", TargetUrl = "OpenConfirmPromKhumPromChue()",
                    IsVisible = IsDateInRange("PromKhumEventStart", "PromKhumEventEnd"),
                },
                // --- Static banners that are always visible ---
                new CampaignBanner { ID = "bannerTCGxCentral", ImageUrl = "~/images/Banner/BannerTCGxCentral_01.jpg", TargetUrl = "RedirectToPage('healthcheck')" },
                new CampaignBanner { ID = "bannerOR", ImageUrl = "~/images/Banner/BannerOR_1.png", TargetUrl = $"RedirectToPage('healthcheck')" },
                new CampaignBanner { ID = "bannerKORSO", ImageUrl = "~/images/Banner/KORSO_4.jpg", TargetUrl = "redirectToPreApporchKORSO()" },
                new CampaignBanner { ID = "bannerPGS11", ImageUrl = "~/images/Banner/PGS11_new.jpg", TargetUrl = "RedirectToPage('healthcheck_PGS11')" },
                new CampaignBanner {
                    ID = "bannerGSB",
                    ImageUrl = "~/images/Banner/GSBBannerPWIN.png",
                    TargetUrl = "redirectToExternal('https://www.gsb.or.th/gsb_govs/loan4idpc/', 'EVENT_TCGXGSB')",
                },

            };

            var allBanners = campaignConfigBanners.Concat(banners);

            rptBanners.DataSource = allBanners.Where(b => b.IsVisible); // Only bind visible banners
            rptModalBanner.DataSource = allBanners.Where(b => b.IsVisible);
            rptBanners.DataBind();
            rptModalBanner.DataBind();

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
            BindServiceMenu();
            BindMainMenu(isUserEnrolled());
            BindPromptKhumMenuModal();

        }


        private void BindServiceMenu()
        {
            // Create a list of all possible menu items
            var menuItems = new List<ServiceMenuItem>
    {
        new ServiceMenuItem {
            Title = "Health Check",
            IconCssClass = "has-bg1 gradient-blue shadow-bg shadow-bg-xs color-white rounded-s bi bi-prescription2 d-flex justify-content-center align-items-center",
            ClickAction = "RedirectToPage('healthcheck')",
            IsVisible = (GetAppsetting("IsShowHealthCheckFeature") == "1") // Your original logic here
        },
        new ServiceMenuItem {
            Title = "นัดหมายหมอหนี้",
            IconCssClass = "has-bg1 gradient-teal shadow-bg shadow-bg-xs color-white rounded-s bi bi-person-workspace d-flex justify-content-center align-items-center",
            ClickAction = "RedirectToPage('debtDoctor')",
            IsVisible = (GetAppsetting("IsShowDebtDoctorFeature") == "1") // Your original logic here
        },
        new ServiceMenuItem {
            Title = "แก้หนี้",
            IconCssClass = "has-bg1 gradient-orange shadow-bg shadow-bg-xs color-white rounded-s bi bi-capsule-pill d-flex justify-content-center align-items-center",
            ClickAction = "RedirectToPage('debt')",
            IsVisible = (GetAppsetting("IsShowDebtRegisterFeature") == "1") // Your original logic here
        },
        new ServiceMenuItem {
            Title = "กิจกรรม บสย.",
            IconCssClass = "has-bg1 gradient-mint shadow-bg shadow-bg-xs color-white rounded-s bi bi-calendar3 d-flex justify-content-center align-items-center",
            ClickAction = "RedirectToPage('event')",
            IsVisible = (GetAppsetting("IsShowEventFeature") == "1") // Your original logic here
        }
    };

            // Bind the list to the repeater.
            // The repeater will automatically loop through the items and only show the ones where IsVisible is true.
            rptServiceMenu.DataSource = menuItems.Where(i => i.IsVisible);
            rptServiceMenu.DataBind();
        }

        private void BindPromptKhumMenuModal()
        {
            var promptKhumOptions = new List<ConfirmPromptKhumMenu>
            {
                new ConfirmPromptKhumMenu
                {
                    Title = "พร้อมค้ำ - มีความต้องการวงเงินสินเชื่อ",
                    BtnTitle = "พร้อมค้ำ",
                    Description = "เพื่อรับสิทธิประโยชน์จากโครงการ",
                    IconCssClass = "btn btn-sm mx-3 gradient-blue shadow-bg shadow-bg-xs",
                    ClickAction = "RedirectToPage('healthcheck_PromKhum')",
                    IsVisible = IsDateInRange("PromptKhumOptionEventStart", "PromptKhumOptionEventEnd")
                },
                new ConfirmPromptKhumMenu
                {
                    Title = "พร้อมช่วย - ปรับปรุงโครงสร้างหนี้กับ บสย.",
                    BtnTitle = "พร้อมช่วย",
                    Description = "เพื่อรับสิทธิประโยชน์จากโครงการ",
                    IconCssClass = "btn btn-full mx-3 gradient-green shadow-bg shadow-bg-xs",
                    ClickAction = "RedirectToPage('event_Help')",
                    IsVisible = true // Always visible for this example
                }
            };

            rptPromptkhumOptions.DataSource = promptKhumOptions.Where(i => i.IsVisible);
            rptPromptkhumOptions.DataBind();
            rptPromptkhumActions.DataSource = promptKhumOptions.Where(i => i.IsVisible);
            rptPromptkhumActions.DataBind();

        }

        // This single method replaces both BindingMenuFeature and BindingMenuFeatureWithCondition for this menu.
        private void BindMainMenu(bool isUserEnrolled)
        {
            // Get all the feature flags from AppSettings once at the top
            bool showCheckRequest = (GetAppsetting("IsShowCheckRequest") == "1");
            bool showCheckMyLG = (GetAppsetting("IsShowCheckMyLG") == "1");
            bool showCheckMyBill = (GetAppsetting("IsShowCheckMyBill") == "1");
            bool showCalculator = (GetAppsetting("IsShowCalculate") == "1");
            bool showRegister = (GetAppsetting("IsShowRegister") == "1");

            // Create the complete list of menu items
            var mainMenuItems = new List<MainMenuAction>
    {
        new MainMenuAction {
            Title = "My Calculator",
            Description = "คำนวณค่างวดสินเชื่อและคํ้าประกัน",
            IconCssClass = "has-bg1 gradient-green shadow-bg shadow-bg-xs color-white rounded-s bi bi-calculator-fill p-0",
            ClickAction = "RedirectToPage('cal')",
            IsVisible = showCalculator, // Controlled by AppSetting
            IsNew = false
        },
        new MainMenuAction {
            Title = "ยืนยันตัวตนลูกค้า บสย.",
            Description = "เพื่อดูข้อมูลการคํ้าประกันสินเชื่อ (บุคคลธรรมดา)",
            IconCssClass = "has-bg1 gradient-yellow shadow-bg shadow-bg-xs color-white rounded-s bi bi-person-bounding-box p-0",
            ClickAction = "RedirectToPage('signUp')",
            // This is the logic from your 'else' block
            IsVisible = !isUserEnrolled && showRegister,
            IsNew = false
        },
        new MainMenuAction {
            Title = "คำขอคํ้าประกัน กับ บสย.",
            Description = "รายการคำขอเข้าร่วมผลิตภัณฑ์ บสย.",
            IconCssClass = "has-bg1 gradient-brown shadow-bg shadow-bg-xs color-white rounded-s bi bi-file-earmark-text p-0",
            ClickAction = "RedirectToPage('myrequest')",
            IsNew = true, // This item has the "New" badge
            // This is the logic from your 'if' block
            IsVisible = false //isUserEnrolled && showCheckRequest
        },
        new MainMenuAction {
            Title = "My LG",
            Description = "หนังสือสัญญาค้ำประกัน",
            IconCssClass = "has-bg1 gradient-pink shadow-bg shadow-bg-xs color-white rounded-s bi bi-file-text-fill p-0",
            ClickAction = "RedirectToPage('mylg')",
            // This is the logic from your 'if' block
            IsVisible = isUserEnrolled && showCheckMyLG,
            IsNew = false
        },
        new MainMenuAction {
            Title = "My Bill",
            Description = "ประวัติการชำระ",
            IconCssClass = "has-bg1 gradient-magenta shadow-bg shadow-bg-xs color-white rounded-s bi bi-receipt p-0",
            ClickAction = "RedirectToPage('mybill')",
            // This is the logic from your 'if' block
            IsVisible = isUserEnrolled && showCheckMyBill,
            IsNew = false
        },
        new MainMenuAction {
            Title = "My Privilege",
            Description = "สิทธิประโยชน์สำหรับเพื่อน บสย.",
            IconCssClass = "has-bg1 gradient-blue shadow-bg shadow-bg-xs color-white rounded-s bi bi-gift p-0",
            ClickAction = "RedirectToPage('reward')",
            IsVisible = true, // This item is always visible
            IsNew = false
        },
        new MainMenuAction {
            Title = "บัญชีรายรับรายจ่าย",
            Description = "บันทึกรายวัน สรุปรายเดือน ปลูกต้นไม้",
            IconCssClass = "has-bg1 gradient-green shadow-bg shadow-bg-xs color-white rounded-s bi bi-journal-bookmark-fill p-0",
            ClickAction = "window.location.href='views/accounting/index.aspx'",
            IsVisible = true,
            IsNew = true
        },
        new MainMenuAction
        {
            Title = "มาตรการพักชำระหนี้ตามนโยบายรัฐ Code 21",
            Description = "(เข้าร่วมคำขอพักชำระหนี้ กับบสย.)",
            IconCssClass = "has-bg1 gradient-teal shadow-bg shadow-bg-xs color-white rounded-s bi bi-virus p-0",
            ClickAction = "redirectToEventBanner2()",
            IsVisible = false,
            IsNew = false

        }
    };

            rptMainMenu.DataSource = mainMenuItems.Where(i => i.IsVisible);
            rptMainMenu.DataBind();
        }

        private bool isUserEnrolled()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            var bufferEnrollObj = UIDMapEnrollmentCon.Instance().GetUIDMapEnrollment(uid);
            var IsShowCheckRequest = GetAppsetting("IsShowCheckRequest"); // ยังไม่ได้ปรับปรุงเมนู ปิดเปิดตาม Config หลังลงทะเบียนและก่อนลงทะเบียน

            var isUserEnrolled = bufferEnrollObj.RESULT_STATUS == "OK" && bufferEnrollObj.RESULT_OBJ != null;

            return isUserEnrolled;

        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            UIDCon.Instance.DeleteDataByUID(uid);
            Response.Redirect("~/Landing.aspx");
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
                    RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", "HealthCheck", "HC_Scoring");
                var bufferFaDebt = UIDMapFATransactionCon.Instance.GetUIDMapTransAndFormByID(uid);
                var bufferEventItem = UIDMapEventRegisterCon.Instance.GetFormRegisterWithGroupAndUID(uid);
                var bufferRegisterPgs10Info =
                    RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", "HealthCheck", "PGS10");
                var bufferRegisterPgs11Info =
                    RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", "HealthCheck", "PGS11");
                var bufferRegisterPROMKHUMInfo =
                    RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", "HealthCheck", "PROMKHUM");
                var bufferRegisterSMEsPickUp =
                    RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", "HealthCheck", "SMEsPickUp");
                var bufferRegisterSMEsStimulate =
                    RegisterInfoCon.Instance.GetRegisInfoStatusByUIDWithType(uid, "", "", "HealthCheck", "SMEsStimulateCampaign");

                var lstActivityItem = ApproachItemToActivityItem(bufferApproach.RESULT_OBJ).ToList();
                lstActivityItem.AddRange(RegisterInfoToActivityItem(bufferRegisterInfo.RESULT_OBJ));
                lstActivityItem.AddRange(FaCenterDebtToActivityItem(bufferFaDebt.RESULT_OBJ));
                lstActivityItem.AddRange(EventRegisterToActivityItem(bufferEventItem.RESULT_OBJ));
                lstActivityItem.AddRange(RegisterInfoPgs10ToActivityItem(bufferRegisterPgs10Info.RESULT_OBJ));
                lstActivityItem.AddRange(RegisterInfoPgs11ToActivityItem(bufferRegisterPgs11Info.RESULT_OBJ));
                lstActivityItem.AddRange(RegisterInfoPromkhumToActivityItem(bufferRegisterPROMKHUMInfo.RESULT_OBJ));
                lstActivityItem.AddRange(RegisterInfoSMEsPickUpToActivityItem(bufferRegisterSMEsPickUp.RESULT_OBJ));
                lstActivityItem.AddRange(RegisterInfoSMEsPickUpToActivityItem(bufferRegisterSMEsStimulate.RESULT_OBJ));


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
                    Date = item.CreateDate,
                    ReduceLevel = 1,
                    Remark1 = "ลงทะเบียนโครงการ PGS 11 "
                });
        }
        private static IEnumerable<ActivityItem> RegisterInfoPromkhumToActivityItem(IReadOnlyCollection<RegisterInfoModel> lstObj)
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
                    Remark1 = "ลงทะเบียนโครงการ PROMKHUM"
                });
        }

        private static IEnumerable<ActivityItem> RegisterInfoSMEsPickUpToActivityItem(IReadOnlyCollection<RegisterInfoModel> lstObj)
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
                    Remark1 = "ลงทะเบียนโครงการ SMEs Pick-Up "
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
                CookieManager.SetEncryptCookie("lineoa", "rIDCard", personalProfile.IdCard ?? "", GetAppsetting("APIPartialCode"));


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


        private void SetPersonalToken()
        {
            try
            {
                LocalLogManager.Logger("Is Personal Token UID Is null");
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var mac = (HTTPManager.GetMACAddress1() != "" ? HTTPManager.GetMACAddress1() : HTTPManager.GetMACAddress2());
                    var persisToken = CryptographyManager.GetMd5Hash(mac + uid + GetAppsetting("APIPartialCode"));

                    hddLToken.Value = persisToken;
                    CookieManager.SetEncryptCookie("lineoa", "LToken", persisToken, GetAppsetting("APIPartialCode"));

                    LocalLogManager.Logger("LToken is : " + persisToken);
                }

                LocalLogManager.Logger("Error Gen LToken Personal : UID is Null");
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("Error Gen LToken Personal : " + ex.GetBaseException().Message);
            }
        }
        #endregion
    }
}