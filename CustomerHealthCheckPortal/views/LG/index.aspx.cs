using System;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BLL.Controller;
using CustomerHealthCheck.ServiceInterface;
using CustomerHealthCheck.UserControl.MyLg;
using DataModel.Models.LG;

namespace CustomerHealthCheck.views.LG
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetAppsetting("IsShowMockup") == "1")
                {
                    pnlMockupLG.Visible = true;
                    carouselCardLGNew.Visible = false;
                }
                else
                {
                    GetMyLgData();
                    pnlMockupLG.Visible = false;
                    carouselCardLGNew.Visible = true;
                }
                
                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.MyLG_Load);
            }
        }

        private void GetMyLgData()
        {
            try
            {
                var idCard = CookieManager.GetEncryptCookie("lineoa", "rIDCard", GetAppsetting("APIPartialCode"));
                LocalLogManager.Logger("MY LG Get rIDCard : " + idCard);

                var debugCard = GetAppsetting("LgDebug");

                if (debugCard == "1")
                {
                    idCard = GetAppsetting("LgDebugCardId");
                }

                if (!string.IsNullOrEmpty(idCard))
                {
                    var resultApi = MyLg.GetMyLgByCardId(idCard).ToList();

                    RepeaterMyLg.DataSource = resultApi;
                    RepeaterMyLg.DataBind();

                    if (resultApi != null && resultApi.Count > 0)
                    {
                        RepeaterBtnLgCard.DataSource = resultApi;
                        RepeaterBtnLgCard.DataBind();

                        pnlMyLGWaitingItemA.Visible = true;
                        pnlMyLGTabItemA.Visible = true;
                        pnlEmptyWaitingItemA.Visible = false;
                    }
                    else
                    {
                        pnlMyLGWaitingItemA.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("MyLG info Error : " + ex.Message);
            }
        }

        protected void RepeaterMyLg_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = e.Item.DataItem as LGModel;

                var control = e.Item.FindControl("UC_MyLgItem1") as UC_MyLgItem;
                if (control != null)
                {
                    control.CustomerName = item.customerName;
                    control.BankName = item.bankName;
                    control.IsHaveCustomerJoin = item.isHaveCustomerJoin;
                    control.ProjectTypeName = item.projectTypeName;
                    control.SubProjectTypeName = item.subProjectTypeName;
                    control.LgNumber = item.LGNumber;
                    control.Outstanding = item.outstanding;
                    control.LgEndDate = item.lgEndDate;
                }
            }
        }

        protected void RepeaterBtnLgCard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var control = e.Item.FindControl("btnLgCard") as HtmlButton;
                if (control != null && e.Item.ItemIndex == 0) control.Attributes["class"] = "active";
            }
        }
    }
}