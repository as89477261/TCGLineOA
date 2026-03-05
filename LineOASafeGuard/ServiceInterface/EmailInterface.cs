
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using DataModel.Models;
using DataModel.Models.Middleware;


namespace LineOASafeGuard
{
    public class EmailInterface : BaseClass
    {
        private EmailInterface()
        { }
        public static EmailInterface Instance { get; } = new EmailInterface();



        public async Task<ResultAPIInfo> SendMail(EmailInfo mail, APIResultMessage tokenObj)
        {
            var finalResult = new ResultAPIInfo();
            try
            {
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

                var urlAPISendEmail = GetAppsetting("apiTCGBaseAPI");
                if (string.IsNullOrEmpty(urlAPISendEmail))
                {
                    throw new ArgumentNullException("apiTCGBaseAPI", "The API base URL is null or empty");
                }
                urlAPISendEmail += "/MainService/sendMail";
                

                var request = new HttpRequestMessage(HttpMethod.Post, urlAPISendEmail);

                request.Headers.Add("X-AccountId", accountId);
                request.Headers.Add("X-TokenAPIID", tokenApiId);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer " + tokenId);

                var content = new MultipartFormDataContent();
                content.Add(new StringContent(mail.Email), "DestinationAccount");
                content.Add(new StringContent(mail.Subject), "Subject");
                content.Add(new StringContent(mail.Body), "Body");
                content.Add(new StringContent(mail.Sender), "YourAccount");
                content.Add(new StringContent("true"), "IsRelayServer");
                request.Content = content;

                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request), "The request object is null");
                }

                var response = await client.SendAsync(request);
                LocalLogManager.Logger("SendMail response : " + response);

            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("SendMail Exception :" + ex.Message);
            }

            return await Task.FromResult(finalResult);

        }
    }
}