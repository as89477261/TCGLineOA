using System;
using System.Collections.Generic;
using CoreUtility;
using DataModel.Models.Middleware;

namespace LineOASafeGuard
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
            }
        }

    }
}