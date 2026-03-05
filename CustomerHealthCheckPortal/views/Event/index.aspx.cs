using System;
using System.Globalization;
using System.Linq;
using BLL.Controller;
using BLL.Controller.HealthCheck;
using CustomerHealthCheck.UserControl;
using DataModel.Models.CustomerHealthModel.EventsModel;

namespace CustomerHealthCheck.views.Event
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataEvent();
                GenerateRegisteredEvent();

                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Events_Load);
            }
        }

        private void GenerateUserControl(EventModel obj, bool isShowCollapse = false)
        {
            var uc = (UC_EventTitle)Page.LoadControl("~/UserControl/UC_EventTitle.ascx");
            uc.Title = obj.Title;
            uc.SubTitle = obj.SubTitle;
            uc.Body = obj.Body;
            uc.eventCode = obj.EventCode;
            uc.IsShowCollaps = isShowCollapse;
            uc.IsShowRegisterButton = obj.IsShowRegisterButton;
            uc.StartShowRegisterButton = obj.StartShowRegisterButton;
            uc.EndShowRegisterButton = obj.EndShowRegisterButton;
            uc.TitleIcon = obj.TitleIcon;
            uc.TitleIconColor = obj.TitleIconColor;
            uc.IsBodyPicture = obj.IsBodyPicture;
            uc.BodyPicturePath = obj.BodyPicturePath;
            uc.RegisterForm = obj.RegisterForm;
            uc.IsCheckDuplicateRegister = obj.IsCheckDuplicateRegister;
            pnlEvent.Controls.Add(uc);
        }

        private void GenerateRegisteredEvent()
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

                        //ltlEventItem.Text = bufferHtmlItem;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void GetDataEvent()
        {
            var lstObj = EventCon.Instance.GetEventByType("01");
            if (lstObj.RESULT_STATUS == "OK" && lstObj.RESULT_OBJ.Count > 0)
            {
                GenerateUserControl(lstObj.RESULT_OBJ[0], true);
                for (var i = 1; i < lstObj.RESULT_OBJ.Count; i++) GenerateUserControl(lstObj.RESULT_OBJ[i]);
                BindingPanel(true);
            }
            else
            {
                BindingPanel(false);
            }
        }

        private void GetDataRegisteredEvent(string code, string uid)
        {
            var lstObj = UIDMapEventRegisterCon.Instance.GetFormRegisterWithEventCodeAndUID(code, uid);
            if (lstObj.RESULT_STATUS == "OK" && lstObj.RESULT_OBJ.Count > 0)
            {
            }
        }

        private void BindingPanel(bool isHaveEvent)
        {
            if (isHaveEvent)
            {
                pnlEvent.Visible = true;
                pnlEmpty.Visible = false;
            }
            else
            {
                pnlEvent.Visible = false;
                pnlEmpty.Visible = true;
            }
        }
    }
}