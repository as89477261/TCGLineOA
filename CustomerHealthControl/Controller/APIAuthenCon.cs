using CustomerHealthControl;
using CustomerHealthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controller.Middleware
{
    public class APIAuthenCon : BaseClass
    {
        private static APIAuthenCon instance = new APIAuthenCon();
        private APIAuthenCon() { }
        public static APIAuthenCon Instance
        {
            get
            {
                return instance;
            }
        }
        public APIResultMessage GetAuthenToken()
        {
            try
            {
                var header = new Dictionary<string, string>()
                {
                    {"Content-Type","application/json"}
                };

                var data = new Dictionary<string, string>()
                {
                    {"userName",GetAppsetting("apiUsername") },
                    {"password",GetAppsetting("apiPassword") }
                };
                var result = HTTPManager.HttpPost<APIResultMessage>(GetAppsetting("apiTCGOAuthen"), header, data);

                return result;

            }
            catch (Exception err)
            {
                return null;
                // Utility.Logs.WriteLog(new Utility.LogsInfo(Utility.LogsTypeInfo.Type.Error, err));
            }
        }

        public APIResultMessage GetOpenAPIAuthenToken()
        {
            try
            {
                var header = new Dictionary<string, string>()
                {
                    //{"Content-Type","application/json"},
                    {"X-AccountKeyId","11@tmb.com"},
                    {"X-TokenAPIId","Ln926dPC/UcSBvliH5jO/v2Bgh/cr599eI6UOMT5aZQ="}
                };

                var data = new Dictionary<string, string>()
                {
                    {"userName",GetAppsetting("apiOpenAPIUsername") },
                    {"password",GetAppsetting("apiOpenAPIPassword") }
                };
                var result = HTTPManager.HttpPost<APIResultMessage>(GetAppsetting("apiTCGBaseAPI") + "/users/authenticate", header, data);

                return result;

            }
            catch (Exception err)
            {
                return null;
                // Utility.Logs.WriteLog(new Utility.LogsInfo(Utility.LogsTypeInfo.Type.Error, err));
            }
        }
    }
}
