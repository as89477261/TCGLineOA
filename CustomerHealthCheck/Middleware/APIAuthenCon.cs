using CoreUtility;
using DataModel.Models.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controller.Middleware
{
    public class APIAuthenCon
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
                    {"userName","Service_RestCAPI_UserDOTNET" },
                    {"password","Tcg@2020" }
                };
                var result = HTTPManager.HttpPost<APIResultMessage>("https://tcg-api.sbcg.or.th/tcg_api_center/api/Account/Login", header, data);

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
