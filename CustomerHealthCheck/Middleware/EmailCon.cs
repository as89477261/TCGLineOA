using DataModel.Models;
using DataModel.Models.Middleware;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controller.Middleware
{
    public class EmailCon : BasePage
    {
        private static EmailCon instance = new EmailCon();
        private EmailCon() { }
        public static EmailCon Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<ResultAPIInfo> SendMail(EmailInfo mail, APIResultMessage tokenObj)
        {
            var finalResult = new ResultAPIInfo();
            try
            {
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                    {
                        return true;
                    };
                using (var client = new HttpClient(handler))
                {
                    HttpRequestMessage request = new HttpRequestMessage { Method = HttpMethod.Post };
                    using (var formData = new MultipartFormDataContent())
                    {
                        string tokenId = tokenObj.data.tokenId;
                        string accountId = tokenObj.data.accountId;
                        string tokenAPIId = tokenObj.data.tokenAPIID;
                        //StringContent YourAccount = new StringContent(mail.SendBy);
                        //formData.Add(YourAccount, "YourAccount");
                        StringContent DestinationAccount = new StringContent(mail.Email);
                        formData.Add(DestinationAccount, "DestinationAccount");
                        StringContent Subject = new StringContent(mail.Subject);
                        formData.Add(Subject, "Subject");
                        StringContent Body = new StringContent(mail.Body);
                        formData.Add(Body, "Body");
                        if (!string.IsNullOrEmpty(mail.CCEmail))
                        {
                            StringContent cc = new StringContent(mail.CCEmail);
                            formData.Add(cc, "CC_DestinationAccount");
                        }
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenId);
                        client.DefaultRequestHeaders.Add("X-AccountId", accountId);
                        client.DefaultRequestHeaders.Add("X-TokenAPIId", tokenAPIId);
                        var result = await client.PostAsync(GetAppsetting("ServiceURL") + "/MainService/sendMail", formData);
                        string text = await result.Content.ReadAsStringAsync();
                        finalResult = JsonConvert.DeserializeObject<ResultAPIInfo>(text);

                    }
                }
            }
            catch (Exception ex)
            {


            }
            return finalResult;
        }


        public class ResultAPIInfo
        {
            public int code { get; set; }
            public string message { get; set; }
        }
    }
}
