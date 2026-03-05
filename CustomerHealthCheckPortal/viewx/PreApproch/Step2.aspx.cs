using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BLL.Controller;
using DataModel.Models.CustomerHealthModel;

namespace CustomerHealthCheck.viewx.PreApproch
{
    public partial class Step2 : BasePage
    {
        private bool isHasItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
                Binding();
            }
        }

        private void GetData()
        {
            try
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var bufferItem = RegisterInfoCon.Instance.GetRegisInfoByType(uid, "0", "1");
                    if (bufferItem.RESULT_STATUS == "OK" && bufferItem.RESULT_OBJ.Count > 0)
                        GenerateUserControl(bufferItem.RESULT_OBJ);
                }
            }
            catch (Exception)
            {
            }
        }

        private void GenerateUserControl(List<RegisterInfoModel> obj)
        {
            var firstItem = obj.OrderByDescending(x => x.RegisterInfoID).FirstOrDefault();
            var bufferHtmlItem =
                TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateHealthCheckHistoryWithJSFunctionKeepHCID(
                    firstItem.ScoreGroup.ToString(), "1",
                    "วันที่ " + firstItem.CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                    firstItem.GroupShortDesc, firstItem.RegisterInfoID.ToString());

            if (obj.Count > 1)
                for (var i = 1; i < obj.Count; i++)
                {
                    bufferHtmlItem += TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                    bufferHtmlItem +=
                        TCG_HealthCheckTemplateManager.HealthCheckHistory
                            .GenerateHealthCheckHistoryWithJSFunctionKeepHCID(obj[i].ScoreGroup.ToString(), "1",
                                "วันที่ " + obj[i].CreateDate.ToString("dd/MM/yyyy", new CultureInfo("th-TH")),
                                obj[i].GroupShortDesc, obj[i].RegisterInfoID.ToString());
                }

            isHasItem = true;
            ltlHistoryItem.Text = bufferHtmlItem;
        }

        private void Binding()
        {
            if (isHasItem)
            {
                pnlHasItem.Visible = true;
                pnlEmpty.Visible = false;
            }
            else
            {
                pnlHasItem.Visible = false;
                pnlEmpty.Visible = true;
            }
        }
    }
}