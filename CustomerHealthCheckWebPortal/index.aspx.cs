using CoreUtility;
using DataModel.Models.Line;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerHealthCheck
{
    public partial class index : BasePage
    {
        string code = string.Empty;
        string state = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                GetQueryString();
                GetToken(code);

            }


        }

        private void GetQueryString()
        {
            code = Request.QueryString["code"];
            state = Request.QueryString["state"];
        }

        private void GetToken(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var dataForm = new NameValueCollection();
                dataForm["grant_type"] = "authorization_code";
                dataForm["code"] = code;
                dataForm["redirect_uri"] = GetAppsetting("redirectURL");
                dataForm["client_id"] = GetAppsetting("client_id");
                dataForm["client_secret"] = GetAppsetting("client_secret");

                var dataForm3 = new Dictionary<string, string>{
                                        {"grant_type","authorization_code" },
                                        {"code",code },
                                        {"redirect_uri", GetAppsetting("redirectURL") },
                                        {"client_id", GetAppsetting("client_id") },
                                        {"client_secret", GetAppsetting("client_secret") }
                                     };


                var headerForm = new Dictionary<string, string>();
                ;

                var bufferResult = HTTPManager.HttpPostWithForm3<LineOAuthToken>(
                                    GetAppsetting("lineOAuthURL"),
                                    headerForm,
                                   dataForm3
                                    ).Result;

                bufferResult.DecodeToRawData();
                var token = bufferResult.lineRawTokenObject.sub;
                lblUID.Text = token;


            }
        }

        private void GetUserID()
        {

        }
    }
}