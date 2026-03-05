using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using BLL.Controller;
using CustomerHealthCheck.ServiceInterface;
using CustomerHealthCheck.UserControl.MyBill;
using DataModel.Models.Bill;

namespace CustomerHealthCheck.views.Bill
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetAppsetting("IsShowMockup") == "1")
                {
                    pnlMockupBill.Visible = true;
                    RepeaterMyBill.Visible = false;
                }
                else
                {
                    GetMyBillData();
                    pnlMockupBill.Visible = false;
                    RepeaterMyBill.Visible = true;
                }

                LogActivityCon.Instance.InsertFixObjAndMultitaskingLogActivity(BASE_UID, LogActivityCon.LogActivityEnum.MyBill_Load);
            }
        }

        private void GetMyBillData()
        {
            try
            {
                var idCard = CookieManager.GetEncryptCookie("lineoa", "rIDCard", GetAppsetting("APIPartialCode"));
                LocalLogManager.Logger("MY LG Get rIDCard : " + idCard);

                var debugCard = GetAppsetting("LgDebug");

                if (debugCard == "1")
                {
                    //idCard = "3331000430105";
                    idCard = GetAppsetting("LgDebugCardId");
                }

                var lgNumber = Request.QueryString["lg"];
                var list = new List<KeyValuePair<string, IEnumerable<BillModel>>>();
                if (string.IsNullOrEmpty(lgNumber))
                {
                    var lgs = MyLg.GetMyLgByCardId(idCard).OrderByDescending(o => o.LGNumber).ToList();

                    foreach (var lg in lgs)
                    {
                        var resultApi = MyBill.GetBillModels(lg.LGNumber);
                        list.Add(new KeyValuePair<string, IEnumerable<BillModel>>(lg.LGNumber,
                            resultApi.OrderByDescending(o => o.DatePay)));
                    }
                }
                else
                {
                    var resultApi = MyBill.GetBillModels(lgNumber);
                    list.Add(new KeyValuePair<string, IEnumerable<BillModel>>(lgNumber,
                        resultApi.OrderByDescending(o => o.DatePay)));
                }

                RepeaterMyBill.DataSource = list;
                RepeaterMyBill.DataBind();
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("My Bill info Error : " + ex.Message);
            }
        }

        protected void RepeaterMyBill_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                if (e.Item.DataItem is KeyValuePair<string, IEnumerable<BillModel>> item &&
                    e.Item.FindControl("UC_MyBill1") is UC_MyBill myBill1)
                {
                    myBill1.LgNo = item.Key;
                    myBill1.Bills = item.Value;
                }
        }
    }
}