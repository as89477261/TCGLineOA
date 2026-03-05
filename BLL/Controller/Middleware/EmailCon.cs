using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataModel.Models;
using DataModel.Models.Middleware;
using Newtonsoft.Json;

namespace BLL.Controller.Middleware
{
    public class EmailCon : BasePage
    {
        private EmailCon()
        {
        }

        public static EmailCon Instance { get; } = new EmailCon();

        public async Task<ResultAPIInfo> SendMailToConsult(int FA_TransectionsId, EmailInfo mail,
            APIResultMessage tokenObj)
        {
            //Utility.Logs.WriteLog(new Utility.LogsInfo(Utility.LogsTypeInfo.Type.Debug, "", "SendMail", mail.Subject));
            ServicePointManager.ServerCertificateValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;
            var dataResult = new ResultAPIInfo();
            try
            {
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) => { return true; };
                using (var client = new HttpClient(handler))
                {
                    var request = new HttpRequestMessage { Method = HttpMethod.Post };
                    using (var formData = new MultipartFormDataContent())
                    {
                        var tokenId = tokenObj.data.tokenId;
                        var accountId = tokenObj.data.accountId;
                        var tokenAPIId = tokenObj.data.tokenAPIID;
                        //StringContent YourAccount = new StringContent(mail.SendBy);
                        //formData.Add(YourAccount, "YourAccount");
                        var DestinationAccount = new StringContent(mail.Email);
                        formData.Add(DestinationAccount, "DestinationAccount");
                        var Subject = new StringContent(mail.Subject);
                        formData.Add(Subject, "Subject");
                        var Body = new StringContent(mail.Body);
                        formData.Add(Body, "Body");
                        if (!string.IsNullOrEmpty(mail.CCEmail))
                        {
                            var cc = new StringContent(mail.CCEmail);
                            formData.Add(cc, "CC_DestinationAccount");
                        }

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenId);
                        client.DefaultRequestHeaders.Add("X-AccountId", accountId);
                        client.DefaultRequestHeaders.Add("X-TokenAPIId", tokenAPIId);
                        var result = await client.PostAsync(GetAppsetting("ServiceURL") + "/MainService/sendMail",
                            formData);
                        var text = await result.Content.ReadAsStringAsync();
                        dataResult = JsonConvert.DeserializeObject<ResultAPIInfo>(text);
                        //InsertNotification(FA_TransectionsId, mail.Subject + " ->" + mail.Email + ";" + mail.CCEmail, DateTime.Now);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return dataResult;
        }

        public async Task<ResultAPIInfo> SendMail(EmailInfo mail, APIResultMessage tokenObj)
        {
            var finalResult = new ResultAPIInfo();
            try
            {
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;

                using (var client = new HttpClient(handler))
                {
                    var request = new HttpRequestMessage { Method = HttpMethod.Post };
                    using (var formData = new MultipartFormDataContent())
                    {
                        var tokenId = tokenObj.data.tokenId;
                        var accountId = tokenObj.data.accountId;
                        var tokenAPIId = tokenObj.data.tokenAPIID;
                        //StringContent YourAccount = new StringContent(mail.SendBy);
                        //formData.Add(YourAccount, "YourAccount");
                        var DestinationAccount = new StringContent(mail.Email);
                        formData.Add(DestinationAccount, "DestinationAccount");
                        var Subject = new StringContent(mail.Subject);
                        formData.Add(Subject, "Subject");
                        var Body = new StringContent(mail.Body);
                        formData.Add(Body, "Body");
                        var isRelayServer = new StringContent("true");
                        formData.Add(isRelayServer, "IsRelayServer");
                        var YourAccount = new StringContent("noreply@tcg.or.th");
                        formData.Add(YourAccount, "YourAccount");
                        if (!string.IsNullOrEmpty(mail.CCEmail))
                        {
                            var cc = new StringContent(mail.CCEmail);
                            formData.Add(cc, "CC_DestinationAccount");
                        }

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenId);
                        client.DefaultRequestHeaders.Add("X-AccountId", accountId);
                        client.DefaultRequestHeaders.Add("X-TokenAPIId", tokenAPIId);
                        var result = client.PostAsync(GetAppsetting("ServiceURL") + "/MainService/sendMail", formData);
                        var text = result.Result.Content.ToString();
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