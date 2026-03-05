using System.Collections.Generic;
using System.Configuration;
using System.Net;
using CoreUtility;
using DataModel.Models.Bill;
using Newtonsoft.Json;

namespace CustomerHealthCheck.ServiceInterface
{
    public class MyBill : Authentication
    {
        public static IEnumerable<BillModel> GetBillModels(string lgNumber)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var url = ConfigurationManager.AppSettings["APICenterURL"] + "/api/internal/getMyReceipt";

            LocalLogManager.Logger("Backend Begin Call getMyReceipt API");
            var authObj = new Authentication().AuthTcgCenterApi();

            //LocalLogManager.Logger(jsonBody);
            var jsonText = $@"{{ ""LGNumber"": ""{lgNumber}"" }}";
            var buffer = HTTPManager.HttpPost(url,
                new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + authObj.data.tokenId },
                    { "X-Accountid", ConfigurationManager.AppSettings["APICenterXAccountID"] },
                    { "X-TokenAPIID", authObj.data.tokenAPIID }
                },
                jsonText);
            var result = JsonConvert.DeserializeObject<BaseTCGAPIModel<IEnumerable<BillModel>>>(buffer);
            LocalLogManager.Logger("Backend Get Result getMyReceipt API : " + buffer);
            return result.data;
        }


        public static byte[] GetReceiptFile(string lgNumber, int receiptTypeId, string numberPay)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var url = ConfigurationManager.AppSettings["APICenterURL"] + "/api/internal/getReceiptFile";

            LocalLogManager.Logger("Backend Begin Call getReceiptFile API");
            var authObj = new Authentication().AuthTcgCenterApi();

            var jsonText = $@"{{ 
                ""LGNumber"": ""{lgNumber}"",
                ""ReceiptTypeId"": {receiptTypeId},
                ""NumberPay"": ""{numberPay}""
            }}";

            var buffer = HTTPManager.DownloadAFileViaPost(url,
                new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + authObj.data.tokenId },
                    { "X-Accountid", ConfigurationManager.AppSettings["APICenterXAccountID"] },
                    { "X-TokenAPIID", authObj.data.tokenAPIID }
                },
                jsonText);
            LocalLogManager.Logger("Backend Get Result getReceiptFile API");
            return buffer;
        }
    }
}