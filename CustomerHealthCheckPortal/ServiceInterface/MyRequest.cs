using System.Collections.Generic;
using System.Configuration;
using System.Net;
using CoreUtility;
using DataModel.Models.LG;
using Newtonsoft.Json;

namespace CustomerHealthCheck.ServiceInterface
{
    public class MyRequest : Authentication
    {
        public static BaseTCGAPIModel<List<MyRequestModel>> GetRequestByCardID(MyRequestModel obj)
        {
            ServicePointManager
                    .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
            var url = ConfigurationManager.AppSettings["APICenterURL"] + "/api/internal/getMyRequestOnline";

            LocalLogManager.Logger("Backend Begin Call GetMyRequest API");
            var authObj = new Authentication().AuthTcgCenterApi();

            //LocalLogManager.Logger(jsonBody);
            var jsonText = JsonConvert.SerializeObject(obj);
            var buffer = HTTPManager.HttpPost(url,
                new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + authObj.data.tokenId },
                    { "X-Accountid", ConfigurationManager.AppSettings["APICenterXAccountID"] },
                    { "X-TokenAPIID", authObj.data.tokenAPIID }
                },
                jsonText);
            var result = JsonConvert.DeserializeObject<BaseTCGAPIModel<List<MyRequestModel>>>(buffer);
            LocalLogManager.Logger("Backend Get Result GetMyRequest API : " + buffer);
            return result;
        }

        public static List<MyRequestModel> GetRequestByCardID(string idCard, string projectType, string dateLimit)
        {
            ServicePointManager
                    .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
            var url = ConfigurationManager.AppSettings["APIIDURL"] + "/v1/request/new/" + idCard + "/" + projectType +
                      "/" + dateLimit;

            LocalLogManager.Logger("Backend Begin Call Request API : " + url);
            //LocalLogManager.Logger(jsonBody);

            var buffer = HTTPManager.HttpGet(url);
            var result = JsonConvert.DeserializeObject<List<MyRequestModel>>(buffer);

            LocalLogManager.Logger("Backend Finish Result Request API : " + buffer);

            return result;
        }
    }
}