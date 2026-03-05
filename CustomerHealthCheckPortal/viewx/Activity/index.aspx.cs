using System;
using System.Globalization;
using System.Linq;
using BLL.Controller;
using BLL.Controller.FACenter;
using BLL.Controller.HealthCheck;

namespace CustomerHealthCheck.viewx.Activity
{
    public partial class index : BasePage
    {
        private bool isHasApproch;
        private bool isHasDebt;
        private bool isHasEvents;
        private bool isHasItem;
        private bool isHasProfile;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindingHealthCheckHistory();
                //BindingApprochHistory();
                //BindingDebtHistory();
                //BindingEventHistory();

                //BindingScreen();
                //CheckProfile();
                //BindingMenu();
            }
        }

        private void BindingHealthCheckHistory()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var bufferItem = RegisterInfoCon.Instance.GetRegisInfoByUID(uid);
                    if (bufferItem.RESULT_STATUS == "OK" && bufferItem.RESULT_OBJ.Count > 0)
                    {
                        var firstItem = bufferItem.RESULT_OBJ.OrderByDescending(x => x.RegisterInfoID).FirstOrDefault();
                        var bufferHtmlItem =
                            TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateHealthCheckHistory(
                                firstItem.ScoreGroup.ToString(), "1",
                                "วันที่ " + firstItem.CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                                firstItem.GroupShortDesc);

                        if (bufferItem.RESULT_OBJ.Count > 1)
                            for (var i = 1; i < bufferItem.RESULT_OBJ.Count; i++)
                            {
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateHealthCheckHistory(
                                        bufferItem.RESULT_OBJ[i].ScoreGroup.ToString(), "1",
                                        "วันที่ " + bufferItem.RESULT_OBJ[i].CreateDate
                                            .ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                                        bufferItem.RESULT_OBJ[i].GroupShortDesc);
                            }

                        isHasItem = true;
                        //ltlHistoryItem.Text = bufferHtmlItem;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BindingApprochHistory()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var bufferItem = ApprochCon.Instance.GetUIDMapApproch(uid);
                    if (bufferItem.RESULT_STATUS == "OK" && bufferItem.RESULT_OBJ.Count > 0)
                    {
                        var bufferLstApproch = bufferItem.RESULT_OBJ.OrderByDescending(x => x.Createdate).ToList();
                        var firstItem = bufferLstApproch.FirstOrDefault();
                        var bufferHtmlItem =
                            TCG_HealthCheckTemplateManager.HealthCheckApproch.GenerateHealthCheckApprochHistory(
                                firstItem.ProductName,
                                "วันที่ " + firstItem.Createdate.ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                                firstItem.ID);

                        if (bufferItem.RESULT_OBJ.Count > 1)
                            for (var i = 1; i < bufferItem.RESULT_OBJ.Count; i++)
                            {
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.HealthCheckApproch.GenerateHealthCheckApprochHistory(
                                        bufferItem.RESULT_OBJ[i].ProductName,
                                        "วันที่ " + bufferItem.RESULT_OBJ[i].Createdate
                                            .ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                                        bufferItem.RESULT_OBJ[i].ID);
                            }

                        isHasApproch = true;
                        //ltlRegisterProductList.Text = bufferHtmlItem;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BindingDebtHistory()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var bufferItem = UIDMapFATransactionCon.Instance.GetUIDMapTransAndFormByID(uid);
                    if (bufferItem.RESULT_STATUS == "OK" && bufferItem.RESULT_OBJ.Count > 0)
                    {
                        var bufferLstApproch = bufferItem.RESULT_OBJ.OrderByDescending(x => x.FormID).ToList();
                        var firstItem = bufferLstApproch.FirstOrDefault();
                        var bufferHtmlItem = TCG_HealthCheckTemplateManager.FACenterDebt.GenerateFACenterDebtHistory(
                            "ลงทะเบียนประนอมหนี้",
                            "วันที่ " + firstItem.CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                            firstItem.Dept_Recon_ObjectId.ToString());

                        if (bufferItem.RESULT_OBJ.Count > 1)
                            for (var i = 1; i < bufferItem.RESULT_OBJ.Count; i++)
                            {
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.FACenterDebt.GenerateFACenterDebtHistory(
                                        "ลงทะเบียนประนอมหนี้",
                                        "วันที่ " + bufferItem.RESULT_OBJ[i].CreateDate
                                            .ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                                        bufferItem.RESULT_OBJ[i].Dept_Recon_ObjectId.ToString());
                            }

                        isHasDebt = true;
                        //ltlDebtItem.Text = bufferHtmlItem;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BindingEventHistory()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var bufferItem = UIDMapEventRegisterCon.Instance.GetFormRegisterWithGroupAndUID(uid);
                    if (bufferItem.RESULT_STATUS == "OK" && bufferItem.RESULT_OBJ.Count > 0)
                    {
                        var bufferLstApproch = bufferItem.RESULT_OBJ.OrderByDescending(x => x.CreateDate).ToList();
                        var firstItem = bufferLstApproch.FirstOrDefault();
                        var bufferHtmlItem = TCG_HealthCheckTemplateManager.RegisterEvent.GenerateRegisterEventHistory(
                            "ลงทะเบียนกิจกรรม " + firstItem.EventName,
                            "วันที่ " + firstItem.CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH")), "4",
                            firstItem.CallCenterStatus);

                        if (bufferItem.RESULT_OBJ.Count > 1)
                            for (var i = 1; i < bufferItem.RESULT_OBJ.Count; i++)
                            {
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                                bufferHtmlItem +=
                                    TCG_HealthCheckTemplateManager.RegisterEvent.GenerateRegisterEventHistory(
                                        "ลงทะเบียนกิจกรรม " + bufferItem.RESULT_OBJ[i].EventName,
                                        "วันที่ " + bufferItem.RESULT_OBJ[i].CreateDate
                                            .ToString("dd/MM/yyyy", new CultureInfo("th-TH")), "4",
                                        bufferItem.RESULT_OBJ[i].CallCenterStatus);
                            }

                        isHasEvents = true;
                        //ltlEventItem.Text = bufferHtmlItem;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void BindingScreen()
        {
            var isEnableHealthCheckFeatureStatus = GetAppsetting("IsShowTCGHealthCheckFeature");
            var isEnableProductFeatureStatus = GetAppsetting("IsShowTCGProductFeature");
            var isEnableDebtFeatureStatus = GetAppsetting("IsShowTCGDebtFeature");
            var isEnableEventFeatureStatus = GetAppsetting("IsShowEventFeature");

            if (isEnableHealthCheckFeatureStatus == "1")
                if (isHasItem)
                {
                    //pnlHasItem.Visible = true;
                    //pnlEmpty.Visible = false;
                }

            //pnlHasItem.Visible = false;
            //pnlEmpty.Visible = true;
            // pnlHasItem.Visible = false;
            // pnlEmpty.Visible = false;
            if (isEnableProductFeatureStatus == "1")
                if (isHasApproch)
                {
                    // pnlHasRegisterProduct.Visible = true;
                    // pnlEmptyRegisterProduct.Visible = false;
                }

            // pnlHasRegisterProduct.Visible = false;
            // pnlEmptyRegisterProduct.Visible = true;
            // pnlHasRegisterProduct.Visible = false;
            // pnlEmptyRegisterProduct.Visible = false;
            if (isEnableDebtFeatureStatus == "1")
                if (isHasDebt)
                {
                    //  pnlHasDebt.Visible = true;
                    //  pnlEmptyDept.Visible = false;
                }

            //  pnlHasDebt.Visible = false;
            //  pnlEmptyDept.Visible = true;
            // pnlHasDebt.Visible = false;
            // pnlEmptyDept.Visible = false;
            if (isEnableEventFeatureStatus == "1")
            {
                if (isHasEvents)
                {
                    //
                    // pnlHasEvent.Visible = true;
                    // pnlEmptyEvent.Visible = false;
                }
                //  pnlHasEvent.Visible = false;
                //  pnlEmptyEvent.Visible = true;
            }
            // pnlHasEvent.Visible = false;
            // pnlEmptyEvent.Visible = false;
        }

        private void BindingMenu()
        {
            if (isHasProfile == false) btnToProfile.Attributes.Add("Class", "disabledPanel");
        }

        private void CheckProfile()
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
                        if (bufferResult.Code != 0 && bufferResult.Code != 0) isHasProfile = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        #region CoreProcess

        private string GetUID()
        {
            var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            if (string.IsNullOrEmpty(uid)) RedirectToOriginLineURL();
            ;

            return uid;
        }

        #endregion
    }
}