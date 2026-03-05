using System;
using System.Collections.Generic;
using CoreUtility;
using CustomerHealthControl;
using CustomerHealthModel;

namespace CustomerHealthController.ServiceInterface
{
    public class ApiAuthInterface : BaseClass
    {
        private ApiAuthInterface()
        {
        }
        public static ApiAuthInterface Instance { get; } = new ApiAuthInterface();

        public APIResultMessage GetAuthToken()
        {
            try
            {
                var header = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                };

                var data = new Dictionary<string, string>
                {
                    { "userName", GetAppsetting("apiUsername") },
                    { "password", GetAppsetting("apiPassword") }
                };
                var result = HTTPManager.HttpPost<APIResultMessage>(GetAppsetting("apiTCGOAuthen"), header, data);

                return result;
            }
            catch (Exception)
            {
                return null;
                // Utility.Logs.WriteLog(new Utility.LogsInfo(Utility.LogsTypeInfo.Type.Error, err));
            }
        }
        public APIResultMessage GetOpenApiAuthToken()
        {
            try
            {
                var header = new Dictionary<string, string>
                {
                    //{"Content-Type","application/json"},
                    { "X-AccountKeyId", "11@tmb.com" },
                    { "X-TokenAPIId", "Ln926dPC/UcSBvliH5jO/v2Bgh/cr599eI6UOMT5aZQ=" }
                };

                var data = new Dictionary<string, string>
                {
                    { "userName", GetAppsetting("apiOpenAPIUsername") },
                    { "password", GetAppsetting("apiOpenAPIPassword") }
                };
                var result =
                    HTTPManager.HttpPost<APIResultMessage>(GetAppsetting("apiTCGBaseApi") + "/users/authenticate",
                        header, data);

                return result;
            }
            catch (Exception)
            {
                return null;
                // Utility.Logs.WriteLog(new Utility.LogsInfo(Utility.LogsTypeInfo.Type.Error, err));
            }
        }
    }
}