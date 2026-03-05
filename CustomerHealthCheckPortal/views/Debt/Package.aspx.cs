using BLL.Controller;
using BLL.Controller.FACenter;
using BLL.Controller.HealthCheck;
using CustomerHealthCheck.UserControl.Debt;
using DataModel.Models.CustomerHealthModel.EventsModel;
using DataModel.Models.FACenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerHealthCheck.views.Debt
{
    public partial class Package : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingPackage();
                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.Debt_3Color_Load);
            }
        }

        private void BindingUserControl(EventModel EventModel, bool IsCanRegister, string uid, bool IsBeforeCondition)
        {
            try
            {
                if (EventModel != null)
                {
                    var uc = (UC_DebtPackage_Ads)Page.LoadControl("~/UserControl/Debt/UC_DebtPackage_Ads.ascx");
                    var resultRegisterTopUp = UIDMapFAEventCon.Instance.GetUIDMapFAEvent(uid, EventModel.EventCode);

                    uc.PaddingEventsHeader = "5px 30px 30px 30px;";
                    uc.EventCode = EventModel.EventCode;
                    uc.EventTitle = EventModel.Title;
                    uc.EventImageBody = EventModel.BodyPicturePath;
                    uc.IsShowBodyImage = EventModel.IsBodyPicture;
                    uc.EventTextBody = EventModel.Body;
                    uc.EventCondition = EventModel.Condition;
                    uc.IsShowRegisterButton = EventModel.IsShowRegisterButton;
                    uc.StartShowRegisterButton = EventModel.StartShowRegisterButton;
                    uc.EndShowRegisterButton = EventModel.EndShowRegisterButton;
                    uc.ISChoosedDebtPackage = IsCanRegister;
                    uc.IsRegisterBeforeCondition = IsBeforeCondition;

                    if (EventModel != null)
                    {
                        pnlChoosePackageTopUp.Visible = true;
                        pnlChooseNotShowChoiceTopUp.Visible = true;
                    }
                    else
                    {
                        pnlChoosePackageTopUp.Visible = false;
                        pnlChooseNotShowChoiceTopUp.Visible = false;
                    }


                    if (IsCanRegister)
                    {
                        pnlChooseNotShowChoiceTopUp.Controls.Add(uc);
                    }
                    else
                    {
                        pnlChoosePackageTopUp.Controls.Add(uc);
                    }


                    if (resultRegisterTopUp.RESULT_CODE == "200" && resultRegisterTopUp.RESULT_OBJ.Count > 0)
                    {
                        uc.ISRegisteredTopUp = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BindingPackage()
        {
            var uid = BASE_UID;
            var result = UIDMapFATransactionCon.Instance.GetUIDMapTransAndFormByID(uid);
            var bufferEvent = EventCon.Instance.GetEventByType("02").RESULT_OBJ.FirstOrDefault();

            if (result.RESULT_CODE == "200" && result.RESULT_OBJ.Count > 0)
            {
                pnlChoosedNotShowChoice.Visible = true;
                pnlChoosePackage.Visible = false;

                var data = result.RESULT_OBJ.OrderByDescending(x => x.CreateDate).FirstOrDefault();
                switch (data.Dept_Recon_ObjectId)
                {
                    case 1:
                        divPackage1.Visible = true;
                        break;
                    case 2:
                        divPackage2.Visible = true;
                        break;
                    case 3:
                        divPackage3.Visible = true;
                        break;
                    default:
                        break;
                }

                var isBefore = false;
                if (bufferEvent != null && data != null)
                {
                    isBefore = (data.CreateDate < bufferEvent.StartShowRegisterButton);
                }

                ltlDebtStatus.Text = GenerateDebtStatus(data);
                BindingUserControl(bufferEvent, true, uid, isBefore);
            }
            else
            {
                pnlChoosedNotShowChoice.Visible = false;
                pnlChoosePackage.Visible = true;

                BindingUserControl(bufferEvent, false, uid, false);
            }
        }

        private string GenerateDebtStatus(UIDMapTransAndFormRegisModel obj)
        {
            var statusText = "<span ";
            if (obj.CurrentStatusId == 84)
            {
                statusText += "style='color:black;' >";
            }
            else
            {
                switch (obj.GroupStatusID)
                {
                    case 3:
                        statusText += "style='color:green;' >";
                        break;
                    case 2:
                        statusText += "style='color:gold;' >";
                        break;
                    case 1:
                        statusText += "style='color:orange;' >";
                        break;
                    default:
                        break;
                }
            }

            if (obj.CurrentStatusId == 99)
            {
                statusText += "ยังเป็นลูกค้าธนาคารอยู่ และบสย. ยังไม่จ่ายเคลม สถานะกับ บสย. เป็นลูกค้าค้ำประกันปกติ จึงยังไม่สามารถดำเนินการในฐานะลูกหนี้ของ บสย. ได้";
            }
            else
            {
                statusText += obj.CurrentStatusName;
            }

            statusText += "</span>";
            return statusText;
        }

    }
}