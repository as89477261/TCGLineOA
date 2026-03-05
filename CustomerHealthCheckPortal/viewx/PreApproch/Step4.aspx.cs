using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Controller.HealthCheck;
using DataModel.Models.MasterData;

namespace CustomerHealthCheck.viewx.PreApproch
{
    public partial class Step3 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) GetData();
        }

        private void GetData()
        {
            var pid = CookieManager.GetEncryptCookie("lineoa", "pid", GetAppsetting("APIPartialCode"));
            var buffer = MasterDataCon.Bank.Instance.GetBankByProductID(pid);

            if (buffer.RESULT_STATUS == "OK") GenerateUserControl(buffer.RESULT_OBJ);
        }

        private void GenerateUserControl(List<BankModel> lstObj)
        {
            var lstChkOption = string.Empty;
            if (lstObj != null && lstObj.Count > 0)
            {
                lstObj = lstObj.OrderByDescending(x => x.BankCode).ToList();

                var firstItem = lstObj.FirstOrDefault();
                var bufferHtmlItem = TCG_HealthCheckTemplateManager.HealthCheckBank.GenerateBankList(firstItem.BankName,
                    firstItem.BankLogo, firstItem.BankCode, firstItem.BankEmail);

                if (lstObj.Count > 1)
                    for (var i = 1; i < lstObj.Count; i++)
                    {
                        bufferHtmlItem += TCG_HealthCheckTemplateManager.HealthCheckHistory.GenerateDividerLine();
                        bufferHtmlItem += TCG_HealthCheckTemplateManager.HealthCheckBank.GenerateBankList(
                            lstObj[i].BankName, lstObj[i].BankLogo, lstObj[i].BankCode, lstObj[i].BankEmail);
                    }

                ltlBankList.Text = bufferHtmlItem;
            }
        }
    }
}