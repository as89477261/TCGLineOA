using CoreUtility;
using CustomerHealthCheck.ServiceInterface;
using DataModel.Models.NDID;
using System.Collections.Generic;
using System.Net;

namespace TCG_NDID_API.ServiceInterface
{
    public class OTPInterface : BaseInterface
    {
        private static OTPInterface instance = new OTPInterface();
        private OTPInterface() { }
        public static OTPInterface Instance
        {
            get
            {
                return instance;
            }
        }

        public BaseTCGAPIModel<TCGCenterAPIOTPModel> SendOTP(string keyID, string mobileOfGroup, string mobileNumber, string msg) //string customerType, string idCard, string searchMobile, string SearchBirthDate)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            //var bufferInput = JsonConvert.SerializeObject(obj);
            var tcgAPICenterURL = GetAppSetting("TCGCenterAPIURL_SMS");
            var token = AuthenTcgCenterApiProduction(tcgAPICenterURL); ///TODO : แก้การดึง Config จาก AppSetting 
            var url = tcgAPICenterURL + "/api/MainService/sendSMSOTP"; ///TODO : แก้การดึง Config จาก AppSetting 
            var bufferResulq = HTTPManager.HttpPostFormData<BaseTCGAPIModel<TCGCenterAPIOTPModel>>(
                url,
                new Dictionary<string, string>() {
                        {"Authorization","Bearer " + token.data.tokenId },
                        { "X-Accountid",GetAppSetting("OTPAPIXAccountID")},
                        { "X-TokenAPIID",token.data.tokenAPIID}
                    },
                    new Dictionary<string, string>() {
                        {"keyId",keyID },
                        { "mobileOfGroup",mobileOfGroup},
                        { "mobileNumber",mobileNumber},
                        { "msg",msg}
                    }
                );


            return bufferResulq;

        }





    }
}
