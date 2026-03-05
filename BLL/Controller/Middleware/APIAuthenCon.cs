using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Principal;
using System.Web.UI.WebControls;
using CoreUtility;
using DataModel.Models.Middleware;

namespace BLL.Controller.Middleware
{
    public class APIAuthenCon
    {
        private APIAuthenCon()
        {
        }

        public static APIAuthenCon Instance { get; } = new APIAuthenCon();

        public APIResultMessage GetAuthenToken()
        {
            try
            {
                var header = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                };

                var _userName = ConfigurationManager.AppSettings["APICenterUsername"];
                var _passWord = ConfigurationManager.AppSettings["APICenterPassword"];
                var _urlApi = ConfigurationManager.AppSettings["ServiceURL"] + "/Account/Login";

                var data = new Dictionary<string, string>
                {
                    { "userName", _userName},
                    { "password", _passWord }
                };
                var result =
                    HTTPManager.HttpPost<APIResultMessage>(_urlApi, header, data);
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