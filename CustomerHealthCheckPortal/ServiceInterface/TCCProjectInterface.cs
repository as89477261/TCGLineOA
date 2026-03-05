using CoreUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace CustomerHealthCheck.ServiceInterface
{
    public class TCCProjectInterface
    {
        public static RespondAPIMemberStatusBYSModel GetMemberStatus(string identityId)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var token = ConfigurationManager.AppSettings["AuthorizationTokenTCC"];

            var url = ConfigurationManager.AppSettings["TCCServiceURL"] + "getMemberStatusBYS";

            var obj = new RequestAPIMemberStatusBYSModel
            {
                memberRegisno = identityId
            };

            var jsonText = JsonConvert.SerializeObject(obj);
            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>
            {
                { "Authorization" , token }
            },
            jsonText) ;

            var result = JsonConvert.DeserializeObject<RespondAPIMemberStatusBYSModel>(buffer);

            return result;

        }

        public static ResponseModelAddMember AddMemberPeronalBYS(object obj)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var token = ConfigurationManager.AppSettings["AuthorizationTokenTCC"];

            var url = ConfigurationManager.AppSettings["TCCServiceURL"] + "addMemberPeronalBYS";

            var jsonText = JsonConvert.SerializeObject(obj);
            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>
            {
                { "Authorization" , token }
            },
            jsonText);

            var result = JsonConvert.DeserializeObject<ResponseModelAddMember>(buffer);

            return result;

        }

        public static ResponseModelAddMember AddMemberCorperateBYS(object obj)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var token = ConfigurationManager.AppSettings["AuthorizationTokenTCC"];

            var url = ConfigurationManager.AppSettings["TCCServiceURL"] + "addMemberCorperateBYS";

            var jsonText = JsonConvert.SerializeObject(obj);
            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>
            {
                { "Authorization" , token }
            },
            jsonText);

            var result = JsonConvert.DeserializeObject<ResponseModelAddMember>(buffer);

            return result;

        }

        //var url = ConfigurationManager.AppSettings["APIIDURL"] + "/api/v1/FACenter/send-email-to-consult";

        //LocalLogManager.Logger("Backend Begin Call FACenterSendEmail API");

        //var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), jsonbody);

        //var result = JsonConvert.DeserializeObject<BaseTCGAPIModel<string>>(buffer);

        //LocalLogManager.Logger("Backend Get Result FACenterSendEmail API : " + buffer);

        //    return result;
    }
}