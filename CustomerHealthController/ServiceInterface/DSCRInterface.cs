using System.Collections.Generic;
using System.Configuration;
using CoreUtility;
using Newtonsoft.Json;

namespace CustomerHealthController.ServiceInterface
{
    public class DscrInterface
    {
        private DscrInterface()
        {
        }

        public static DscrInterface Instance { get; } = new DscrInterface();

        public RegisterInfo CalculateDscr(RegisterInfo registerInfo)
        {
            var jsonObj = JsonConvert.SerializeObject(registerInfo);
            var headerObj = new Dictionary<string, string> { { "Authorization", "" } };
            var urlObj = ConfigurationManager.AppSettings["apiDSCRURL"] + "/api/dscr/termloan";
            var bufferResult = HTTPManager.HttpPost(urlObj, headerObj, jsonObj);

            if (bufferResult == null) return registerInfo;
            var result = JsonConvert.DeserializeObject<RegisterInfo>(bufferResult);

            return result;

        }
    }
}