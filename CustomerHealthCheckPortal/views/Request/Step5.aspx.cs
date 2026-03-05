using System;
using System.Configuration;
using DataModel.Models.NDID.NCB;
using DataModel.Models.NDID.Personal;
using Newtonsoft.Json;

namespace CustomerHealthCheck.views.Request
{
    public partial class Step5 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) GetData();
        }

        private void GetData()
        {
            try
            {
                var ndidreqid = CookieManager.GetEncryptCookie("lineoa", "ndidreqid", GetAppsetting("APIPartialCode"));
                var isShowData = ConfigurationManager.AppSettings["IsShowDataCallBack"];

                if (isShowData == "1")
                {
                    var bufferData = ServiceInterface.NDID.GetDataByRequestID(ndidreqid);
                    if (bufferData != null && bufferData.Count > 0)
                        foreach (var item in bufferData)
                            switch (item.service_id)
                            {
                                case "001.cust_info_001":
                                    LocalLogManager.Logger(item.data);
                                    var bufferObj =
                                        JsonConvert.DeserializeObject<NDIDWrapPersonalGroupModel>(item.data);

                                    ltlShowDataCallBack.Text += "ชื่อจาก NDID ตัวทดสอบ : " +
                                                                bufferObj.customer_info_th.thai_full_name + "<br />";

                                    break;
                                case "002.credit_info_001":
                                    LocalLogManager.Logger(item.data);
                                    var bufferNCBObj = JsonConvert.DeserializeObject<NDIDWrapNCBModel>(item.data);

                                    ltlShowDataCallBack.Text +=
                                        "E-Consent NCB : " + bufferNCBObj.e_consent_reference + "<br />";
                                    break;
                            }
                }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.Message);
            }
        }
    }
}