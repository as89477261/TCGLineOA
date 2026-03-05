using System.Collections.Generic;
using System.Configuration;
using System.Net;
using CoreUtility;
using DataModel.Models.LG;
using Newtonsoft.Json;

namespace CustomerHealthCheck.ServiceInterface
{
    public class MyLg : Authentication
    {
        public static IEnumerable<LGModel> GetMyLgByCardId(string idCard)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var url = ConfigurationManager.AppSettings["APILINEOAURL"] + "/v1/mylg/infos/" + idCard + "/idcard";

            LocalLogManager.Logger("Backend Begin Call getMyLG API");

            //LocalLogManager.Logger(jsonBody);
            //var jsonText = $@"{{ ""idCard"": ""{idCard}"" }}";
            var buffer = HTTPManager.HttpGet(url);
            var result = JsonConvert.DeserializeObject<IEnumerable<LGModel>>(buffer);
            LocalLogManager.Logger("Backend Get Result GetMyRequest API : " + buffer);
            return result;
        }
    }
}