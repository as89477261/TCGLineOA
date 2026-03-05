using System.Collections.Generic;
using System.Configuration;
using System.Net;
using CoreUtility;
using DataModel.Models.LG;
using Newtonsoft.Json;

namespace CustomerHealthCheckService.ServiceInterface
{
    public class MyLG : Authentication
    {
        public static BaseTCGAPIModel<List<LGModel>> GetMyLGByCardID(string idCard)
        {
            ServicePointManager
                    .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
            var url = ConfigurationManager.AppSettings["APICenterURL"] + "/api/internal/getMyLG";

            LocalLogManager.Logger("Backend Begin Call getMyLG API");
            var authObj = new Authentication().AuthenTcgCenterApi();

            //LocalLogManager.Logger(jsonBody);
            var jsonText = $@"{{ ""idCard"": ""{idCard}"" }}";
            var buffer = HTTPManager.HttpPost(url,
                new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + authObj.data.tokenId },
                    { "X-Accountid", ConfigurationManager.AppSettings["APICenterXAccountID"] },
                    { "X-TokenAPIID", authObj.data.tokenAPIID }
                },
                jsonText);
            var result = JsonConvert.DeserializeObject<BaseTCGAPIModel<List<LGModel>>>(buffer);
            LocalLogManager.Logger("Backend Get Result GetMyRequest API : " + buffer);
            return result;
        }
    }
}