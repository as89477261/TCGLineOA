using CoreUtility;
using DataModel.Models.FACenter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CustomerHealthCheck.ServiceInterface
{
    public class FACenterAPI
    {
        public static BaseTCGAPIModel<string> SendEmailToConsult(string jsonbody)
        {
            var url = ConfigurationManager.AppSettings["APIIDURL"] + "/api/v1/FACenter/send-email-to-consult";

            LocalLogManager.Logger("Backend Begin Call FACenterSendEmail API");

            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), jsonbody);

            var result = JsonConvert.DeserializeObject<BaseTCGAPIModel<string>>(buffer);

            LocalLogManager.Logger("Backend Get Result FACenterSendEmail API : " + buffer);

            return result;
        }
    }
}