using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using BLL.Controller.NDID;
using DataModel.Models.NDID;
using DataModel.Models.NDID.RP;
using Newtonsoft.Json;

namespace CustomerHealthCheck.views.Request
{
    public partial class Step4 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) CallAPI();
        }

        private void CallAPI()
        {
            var obj = JsonConvert.SerializeObject(GenerateRPRequestObj());
            var ndidIDCard = CookieManager.GetEncryptCookie("lineoa", "ndididcard", GetAppsetting("APIPartialCode"));
            var transID = CookieManager.GetEncryptCookie("lineoa", "ndidtransid", GetAppsetting("APIPartialCode"));
            var task = new Task(() =>
            {
                var response = ServiceInterface.NDID.GetRPRequestByID(ndidIDCard, obj);
                if (response != null)
                {
                    var masterObj = GenerateMasterStep4Object(transID, response.request_id, response.initial_salt);
                    var masterResult = NDIDStepCon.Instance.UpdateNDIDMasterStatus(masterObj);
                }
            });
            task.Start();
        }

        private UIDMapNDIDStatusModel GenerateMasterStep4Object(string transID, string reqID, string salt)
        {
            var ndidtransid = transID;
            var buffer = new UIDMapNDIDStatusModel();
            buffer.TransactionID = ndidtransid;
            buffer.Step4Status = "001";
            buffer.Step4Remark = "NDID ตอบกลับ Request ID";
            buffer.CurrentStausCode = "004";
            buffer.CurrentStatusRemark = "NDID ตอบกลับ Request ID";
            buffer.UpdatedBy = "SYSTEM";
            buffer.NDIDRequestID = reqID;
            buffer.NDIDInitialSalt = salt;

            return buffer;
        }

        private RPRequestModel GenerateRPRequestObj()
        {
            var transID = CookieManager.GetEncryptCookie("lineoa", "ndidtransid", GetAppsetting("APIPartialCode"));

            var obj = new RPRequestModel();
            obj.node_id = "1";
            obj.mode = 2;
            obj.reference_id = transID;
            obj.idp_id_list = new List<string> { "idp1" };
            obj.callback_url = ConfigurationManager.AppSettings["NDIDURLCallback"] + transID;
            obj.data_request_list = GenerateRPRequestASParamObj();
            obj.request_message = "ประโยคที่อยากให้แสดงตอน Notification ขึ้นที่มือถือประชาชน";
            obj.min_ial = 2.3;
            obj.min_aal = 2.2;
            obj.min_idp = 1;
            obj.request_timeout = 60;
            obj.bypass_identity_check = true;

            return obj;
        }

        private List<RPRequestDataListModel> GenerateRPRequestASParamObj()
        {
            string[] lstService = { "001.cust_info_001", "002.credit_info_001" };
            var lstObj = new List<RPRequestDataListModel>();
            foreach (var service in lstService)
                switch (service)
                {
                    case "001.cust_info_001":
                        var obj1 = new RPRequestDataListModel();
                        obj1.service_id = "001.cust_info_001";
                        obj1.as_id_list = new List<string> { "as1" };
                        obj1.min_as = 1;
                        obj1.request_params = "";
                        lstObj.Add(obj1);
                        break;
                    case "002.credit_info_001":
                        var obj2 = new RPRequestDataListModel();
                        obj2.service_id = "002.credit_info_001";
                        obj2.as_id_list = new List<string> { "as1" };
                        obj2.min_as = 1;
                        obj2.request_params = GenerateNCBParamObj();
                        lstObj.Add(obj2);
                        break;
                }

            return lstObj;
        }

        private string GenerateNCBParamObj()
        {
            var obj = new RPRequestNCBParamModel();
            obj.uuid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
            obj.member_shortname = "XBANK";
            obj.citizen_id = CookieManager.GetEncryptCookie("lineoa", "ndididcard", GetAppsetting("APIPartialCode"));
            obj.firstname = "";
            obj.lastname = "";
            obj.dob = "";
            obj.mobile_no = "";
            obj.email = "";
            obj.product_code = "";
            obj.trn_type = "";
            obj.version = 2;


            var result = JsonConvert.SerializeObject(obj);
            return result;
        }
    }
}