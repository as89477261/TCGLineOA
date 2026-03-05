
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHealthController
{
    public class DSCRCon
    {
        private static DSCRCon instance = new DSCRCon();
        private DSCRCon() { }
        public static DSCRCon Instance
        {
            get
            {
                return instance;
            }
        }

        public RegisterInfo calculateDSCR(RegisterInfo registerInfo)
        {
            var jsonObj = JsonConvert.SerializeObject(registerInfo);
            var headerObj = new Dictionary<string, string>() { { "Authorization", "" } };
            var urlObj = ConfigurationManager.AppSettings["apiDSCRURL"] + "/api/dscr/termloan";
            var bufferResult = HTTPManager.HttpPost(urlObj, headerObj, jsonObj);

            if (bufferResult != null)
            {
                var result = JsonConvert.DeserializeObject<RegisterInfo>(bufferResult);

                return result;
            }
            else
            {
                return registerInfo;
            }

        }
    }
}
