using System.Collections.Generic;
using System.Configuration;
using System.Net;
using CoreUtility;
using Newtonsoft.Json;

namespace CustomerHealthCheckService.ServiceInterface
{
    public class Authentication
    {
        public BaseTCGAPIModel<TCGCenterAPIAuthModel> AuthenTcgCenterApi()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


            var input = new TCGCenterAPIAuthModel
            {
                userName = ConfigurationManager.AppSettings["APICenterUsername"],
                password = ConfigurationManager.AppSettings["APICenterPassword"]
            };
            var bufferInput = JsonConvert.SerializeObject(input);

            var result = new BaseTCGAPIModel<TCGCenterAPIAuthModel>();
            var url = ConfigurationManager.AppSettings["APICenterURL"] + "/api/Account/login";

            LocalLogManager.Logger("Get Authen URL : " + url);
            var buffer =
                HTTPManager.HttpPost<BaseTCGAPIModel<TCGCenterAPIAuthModel>>(url, new Dictionary<string, string>(),
                    bufferInput);

            LocalLogManager.Logger("Get Authen Data : " + JsonConvert.SerializeObject(buffer));
            return buffer;
        }

        public BaseTCGAPIModel<TCGCenterAPIAuthModel> AuthenTcgCenterApiProduction(string hostName = "")
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


            var input = new TCGCenterAPIAuthModel
            {
                userName = ConfigurationManager.AppSettings["APICenterUsername"],
                password = ConfigurationManager.AppSettings["APICenterPassword"]
            };
            var bufferInput = JsonConvert.SerializeObject(input);

            var result = new BaseTCGAPIModel<TCGCenterAPIAuthModel>();
            var url = (hostName != "" ? hostName : ConfigurationManager.AppSettings["TCGCenterAPIURLProd"]) +
                      "/api/Account/login";
            var buffer =
                HTTPManager.HttpPost<BaseTCGAPIModel<TCGCenterAPIAuthModel>>(url, new Dictionary<string, string>(),
                    bufferInput);
            return buffer;
        }

        public BaseTCGAPIModel<TCGCenterAPIAuthModel> AuthenTcgCenterApi(string username, string password)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


            var input = new TCGCenterAPIAuthModel
            {
                userName = username,
                password = password
            };
            var bufferInput = JsonConvert.SerializeObject(input);

            var result = new BaseTCGAPIModel<TCGCenterAPIAuthModel>();
            var url = ConfigurationManager.AppSettings["APICenterURL"] + "/api/Account/login";
            var buffer =
                HTTPManager.HttpPost<BaseTCGAPIModel<TCGCenterAPIAuthModel>>(url, new Dictionary<string, string>(),
                    bufferInput);
            return buffer;
        }
    }
}