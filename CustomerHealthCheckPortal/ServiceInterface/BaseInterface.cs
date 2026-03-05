using CoreUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using TCG_CORE_MODEL.Model;


namespace CustomerHealthCheck.ServiceInterface
{
    public class BaseInterface
    {

        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public BaseTCGAPIModel<TCGCenterAPIAuthModel> AuthenTcgCenterApi()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


            var input = new TCGCenterAPIAuthModel()
            {
                userName = GetAppSetting("APICenterUsername"),
                password = GetAppSetting("APICenterPassword")

            };
            var bufferInput = JsonConvert.SerializeObject(input);

            var result = new BaseTCGAPIModel<TCGCenterAPIAuthModel>();
            var url = GetAppSetting("TCGCenterAPIURL") + "/api/Account/login";

            LocalLogManager.Logger("Get Authen URL : " + url);
            var buffer = HTTPManager.HttpPost<BaseTCGAPIModel<TCGCenterAPIAuthModel>>(url, new Dictionary<string, string>(), bufferInput);

            LocalLogManager.Logger("Get Authen Data : " + JsonConvert.SerializeObject(buffer));
            return buffer;
        }


        public BaseTCGAPIModel<TCGCenterAPIAuthModel> AuthenTcgCenterApiProduction(string hostName = "")
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


            var input = new TCGCenterAPIAuthModel()
            {
                userName = GetAppSetting("APICenterUsername"),
                password = GetAppSetting("APICenterPassword")
            };
            var bufferInput = JsonConvert.SerializeObject(input);

            var result = new BaseTCGAPIModel<TCGCenterAPIAuthModel>();
            var url = (hostName != "" ? hostName : GetAppSetting("TCGCenterAPIURL")) + "/api/Account/login";
            var buffer = HTTPManager.HttpPost(url, new Dictionary<string, string>(), bufferInput);
            var obj = JsonConvert.DeserializeObject<BaseTCGAPIModel<TCGCenterAPIAuthModel>>(buffer);
            return obj;
        }

        public BaseTCGAPIModel<TCGCenterAPIAuthModel> AuthenTcgCenterApi(string username, string password)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


            var input = new TCGCenterAPIAuthModel()
            {
                userName = username,
                password = password
            };
            var bufferInput = JsonConvert.SerializeObject(input);

            var result = new BaseTCGAPIModel<TCGCenterAPIAuthModel>();
            var url = GetAppSetting("TCGCenterAPIURL") + "/api/Account/login";
            var buffer = HTTPManager.HttpPost<BaseTCGAPIModel<TCGCenterAPIAuthModel>>(url, new Dictionary<string, string>(), bufferInput);
            return buffer;
        }



    }
}
