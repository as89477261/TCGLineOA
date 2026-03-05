using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using CoreUtility;
using DataModel.Models.SetThailand;
using Newtonsoft.Json;

namespace CustomerHealthCheck.ServiceInterface
{
    public class Authentication
    {
        public BaseTCGAPIModel<TCGCenterAPIAuthModel> AuthTcgCenterApi()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var input = new TCGCenterAPIAuthModel
            {
                userName = ConfigurationManager.AppSettings["APICenterUsername"],
                password = ConfigurationManager.AppSettings["APICenterPassword"]
            };
            var bufferInput = JsonConvert.SerializeObject(input);
            var url = ConfigurationManager.AppSettings["APICenterURL"] + "/api/Account/login";
            LocalLogManager.Logger("Get Authen URL : " + url);
            var buffer = HTTPManager.HttpPost<BaseTCGAPIModel<TCGCenterAPIAuthModel>>(url, new Dictionary<string, string>(), bufferInput);

            LocalLogManager.Logger("Get Authen Data : " + JsonConvert.SerializeObject(buffer));
            return buffer;
        }

        public BaseTCGAPISetThailandModel<SetThailandAPIAuthUserProfileModel> AuthTCGNodeSetThailandAPI()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var input = new SetThailandAPIAuthUserProfileModel
            {
                user_profile = new SetThailandUserProfile
                {
                    id = "U32652a9f0a40d5beb06bafa55afe6e3c",
                    email = "",
                    firstname = "",
                    lastname = "",
                    gender = "",
                    phone_number = "",
                    company_name = "",
                    corporate_number = ""
                }
            };

            var bufferInput = JsonConvert.SerializeObject(input);

            var url = ConfigurationManager.AppSettings["SetThailandAPI"] + "/authenticate";
            //var url = "http://tcg-linux-uat-01:3000/authenticate";
            //LocalLogManager.Logger("Call API URL : " + url);
            var buffer = HTTPManager.HttpPost<BaseTCGAPISetThailandModel<SetThailandAPIAuthUserProfileModel>>(url, new Dictionary<string, string>(), bufferInput);
            //LocalLogManager.Logger("Call Authen Data : " + JsonConvert.SerializeObject(buffer));

            //var result = JsonConvert.DeserializeObject<BaseTCGAPISetThailandModel<List<SetThailandAPIAuthUserProfileModel>>>(bufferInput); 
            return buffer;
        }

        public BasePdpaApiModel<TcgPdpaApiAuthModel> AuthTcgPdpaApi()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            //var url = "http://localhost:3000/pdpa/Authentication";
            var url = ConfigurationManager.AppSettings["PdpaAuth"];
            var userName = ConfigurationManager.AppSettings["PdpaUsername"];
			var passWord = ConfigurationManager.AppSettings["PdpaPassword"];

			LocalLogManager.Logger("Get Authen URL : " + url);
            //var buffer = HTTPManager.HttpPost<BasePdpaApiModel<TcgPdpaApiAuthModel>>(url, new Dictionary<string, string>(), bufferInput);

            var header = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                };

            var data = new Dictionary<string, string>
                {
                    { "userNameOrEmailAddress", userName },
                    { "password", passWord }
                };

            var buffer = HTTPManager.HttpPost<BasePdpaApiModel<TcgPdpaApiAuthModel>>(url ,header, data);

            LocalLogManager.Logger("Get Authen Data : " + JsonConvert.SerializeObject(buffer));

            return buffer;

        }

		public static BasePdpaApiModel<TcgPdpaApiAuthModel> AuthTcgPdpaApiStatic()
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

			//var url = "http://localhost:3000/pdpa/Authentication";
			var url = ConfigurationManager.AppSettings["PdpaAuth"];
			var userName = ConfigurationManager.AppSettings["PdpaUsername"];
			var passWord = ConfigurationManager.AppSettings["PdpaPassword"];

			LocalLogManager.Logger("Get Authen URL : " + url);
			//var buffer = HTTPManager.HttpPost<BasePdpaApiModel<TcgPdpaApiAuthModel>>(url, new Dictionary<string, string>(), bufferInput);

			var header = new Dictionary<string, string>
				{
					{ "Content-Type", "application/json" }
				};

			var data = new Dictionary<string, string>
				{
					{ "userNameOrEmailAddress", userName },
					{ "password", passWord }
				};

			var buffer = HTTPManager.HttpPost<BasePdpaApiModel<TcgPdpaApiAuthModel>>(url, header, data);

			LocalLogManager.Logger("Get Authen Data : " + JsonConvert.SerializeObject(buffer));

			return buffer;

		}

	}

}