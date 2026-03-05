using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using CustomerHealthControl;
using CustomerHealthModel;
using DataModel.Models;
using Newtonsoft.Json;
using TCG_CORE_MODEL.Model.NDIDConnext;

namespace CustomerHealthController.ServiceInterface
{
    public class EmailInterface : BaseClass
    {
        private EmailInterface()
        {
        }

        public static EmailInterface Instance { get; } = new EmailInterface();

        public Task<ResultAPIInfo> SendMail(EmailInfo mail, APIResultMessage tokenObj)
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
                        var tokenApiId = tokenObj.data.tokenAPIID;
                        //StringContent YourAccount = new StringContent(mail.SendBy);
                        //formData.Add(YourAccount, "YourAccount");
                        var destinationAccount = new StringContent(mail.Email);
                        formData.Add(destinationAccount, "DestinationAccount");
                        var subject = new StringContent(mail.Subject);
                        formData.Add(subject, "Subject");
                        var body = new StringContent(mail.Body);
                        formData.Add(body, "Body");
                        var isRelayServer = new StringContent("true");
                        formData.Add(isRelayServer, "IsRelayServer");
                        var yourAccount = new StringContent("noreply@tcg.or.th");
                        formData.Add(yourAccount, "YourAccount");
                        if (!string.IsNullOrEmpty(mail.CCEmail))
                        {
                            var cc = new StringContent(mail.CCEmail);
                            formData.Add(cc, "CC_DestinationAccount");
                        }

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenId);
                        client.DefaultRequestHeaders.Add("X-AccountId", accountId);
                        client.DefaultRequestHeaders.Add("X-TokenAPIId", tokenApiId);
                        var result = client.PostAsync(GetAppsetting("apiTCGBaseApi") + "/MainService/sendMail",
                            formData);
                        var text = result.Result.Content.ToString();
                        finalResult = JsonConvert.DeserializeObject<ResultAPIInfo>(text);
                    }
                }
            }
            catch (Exception)
            {
            }

            return Task.FromResult(finalResult);
        }

        public async Task<ResultAPIInfo> SendMailPROMKHUM(EmailInfo mail, APIResultMessage tokenObj)
        {
            var finalResult = new ResultAPIInfo();
            try
            {
                //var handler = new HttpClientHandler();
                //handler.ClientCertificateOptions = ClientCertificateOption.Manual;

                //var client = new HttpClient();
                //var tokenId = tokenObj.data.tokenId;
                //var accountId = tokenObj.data.accountId;
                //var tokenApiId = tokenObj.data.tokenAPIID;
                //var urlAPISendEmail = GetAppsetting("apiBaseURL_TCGAPICenter") + "/MainService/sendMail";  //appconfig
                //var toEmailContact = GetAppsetting("toEmailContact");
                //var headEmailTittle = GetAppsetting("headEmailTittle");
                //var request = new HttpRequestMessage(HttpMethod.Post, urlAPISendEmail);

                //request.Headers.Add("X-AccountId", accountId);
                //request.Headers.Add("X-TokenAPIID", tokenApiId);
                //request.Headers.Add("Accept", "application/json");
                //request.Headers.Add("Authorization", "Bearer "+tokenId);

                //var content = new MultipartFormDataContent();
                //content.Add(new StringContent(toEmailContact), "DestinationAccount"); //appconfig
                //content.Add(new StringContent(mail.Subject), "Subject");
                //content.Add(new StringContent(mail.Body), "Body");
                //content.Add(new StringContent(headEmailTittle), "YourAccount"); //appconfig
                //content.Add(new StringContent("true"), "IsRelayServer");
                //request.Content = content;

                //LocalLogManager.Logger("SendMailPROMKHUM request : " + request);

                //var response = await client.SendAsync(request);
                //LocalLogManager.Logger("SendMailPROMKHUM response : " + response);

                //// Log Status Code
                //LocalLogManager.Logger("SendMailPROMKHUM StatusCode : " + response.StatusCode);

                //// Log Response Content
                //var responseBody = await response.Content.ReadAsStringAsync();
                //LocalLogManager.Logger("SendMailPROMKHUM responseBody : " + responseBody);

                //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    finalResult = JsonConvert.DeserializeObject<ResultAPIInfo>(responseBody);
                //}

                /*WAY 2*/

                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual
                };

                var client = new HttpClient
                {
                    Timeout = TimeSpan.FromMinutes(2) // ตั้งค่า Timeout เพิ่มเติม
                };

                var tokenId = tokenObj?.data?.tokenId;
                var accountId = tokenObj?.data?.accountId;
                var tokenApiId = tokenObj?.data?.tokenAPIID;

                if (string.IsNullOrEmpty(tokenId) || string.IsNullOrEmpty(accountId) || string.IsNullOrEmpty(tokenApiId))
                {
                    throw new ArgumentNullException("Token details are missing or null");
                }

                var urlAPISendEmail = GetAppsetting("apiBaseURL_TCGAPICenter");
                if (string.IsNullOrEmpty(urlAPISendEmail))
                {
                    throw new ArgumentNullException("apiBaseURL_TCGAPICenter", "The API base URL is null or empty");
                }
                urlAPISendEmail += "/MainService/sendMail";

                var toEmailContact = GetAppsetting("toEmailContact");
                var headEmailTittle = GetAppsetting("headEmailTittle");

                if (string.IsNullOrEmpty(toEmailContact) || string.IsNullOrEmpty(headEmailTittle))
                {
                    throw new ArgumentNullException("Email settings are missing or null");
                }

                var request = new HttpRequestMessage(HttpMethod.Post, urlAPISendEmail);

                request.Headers.Add("X-AccountId", accountId);
                request.Headers.Add("X-TokenAPIID", tokenApiId);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer " + tokenId);

                var content = new MultipartFormDataContent();
                content.Add(new StringContent(toEmailContact), "DestinationAccount");
                content.Add(new StringContent(mail.Subject), "Subject");
                content.Add(new StringContent(mail.Body), "Body");
                content.Add(new StringContent(headEmailTittle), "YourAccount");
                content.Add(new StringContent("true"), "IsRelayServer");
                request.Content = content;

                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request), "The request object is null");
                }

                var response = await client.SendAsync(request);
                LocalLogManager.Logger("SendMailPROMKHUM response : " + response);

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("SendMailPROMKHUM Exception :" + ex.Message );
            }

            return await Task.FromResult(finalResult);
            //return finalResult; 
            
        }
    }
}