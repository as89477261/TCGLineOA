using CoreUtility;
using DataModel.Models.LG;
using DataModel.Models.SignUp;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Runtime.Caching;

namespace CustomerHealthCheck.ServiceInterface
{
	public class PdpaApiInterface
	{
		public static BasePdpaApiModel<TcgPdpaApiAuthModel> authtoken = new BasePdpaApiModel<TcgPdpaApiAuthModel>();
        private static readonly MemoryCache _cache = MemoryCache.Default;
        private static readonly string AuthTokenCacheKey = "PdpaAuthToken";
        private static readonly int DefaultTokenTTLSeconds = 86400;
        private static readonly int RefreshBufferSeconds = 120;

        private static async Task<BasePdpaApiModel<TcgPdpaApiAuthModel>> GetAuthTokenAsync()
        {
            var cachedItem = _cache.Get(AuthTokenCacheKey) as BasePdpaApiModel<TcgPdpaApiAuthModel>;

            if (cachedItem != null)
            {
                return cachedItem;
            }

            var newAuth = new Authentication().AuthTcgPdpaApi();

            int ttlSeconds = DefaultTokenTTLSeconds;

            if (newAuth?.result?.expireInSeconds != null)
            {
                ttlSeconds = newAuth.result.expireInSeconds;
                if (ttlSeconds <= 0 || ttlSeconds > 7 * 86400)
                {
                    ttlSeconds = DefaultTokenTTLSeconds;
                }
            }

            ttlSeconds = Math.Max(ttlSeconds - RefreshBufferSeconds, 60);

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(ttlSeconds)
            };

            _cache.Set(AuthTokenCacheKey, newAuth, policy);

            LocalLogManager.Logger($"New auth token cached for {ttlSeconds} seconds.");

            return newAuth;
        }

        public static async Task<IAsyncEnumerable<BasePdpaApiModel<ActivePurposesConsent<ActivePurposesDetail>>>> GetActivePurposes(string uid)
		{
			try
			{
				ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
				var consentPoint = ConfigurationManager.AppSettings["PdpaConsentPoint"];
				//PdpaConsentPoint

				var url = ConfigurationManager.AppSettings["UrlPdpa"] + "/api/services/app/ConsentPoints/GetActivePurposes?consentPointId=" + consentPoint + "&identifier=" + uid;
				//var authObj = new Authentication().AuthTcgPdpaApi();
				var authObj = await GetAuthTokenAsync();

                var buffer = await HTTPManager.HttpGetHeaderAsync(url, "Bearer " + authObj.result.accessToken);

				var result = JsonConvert.SerializeObject(buffer);

				var resultData = new BasePdpaApiModel<ActivePurposesConsent<ActivePurposesDetail>>();

				LocalLogManager.Logger("Backend Begin Call getMyReceipt API");

				return (IAsyncEnumerable<BasePdpaApiModel<ActivePurposesConsent<ActivePurposesDetail>>>)resultData;

			}
			catch (Exception ex)
			{
				LocalLogManager.Logger("error DIPROM " + ex.Message);
				throw ex;

			}

		}

		public static async Task<String> GetActivePurposesAsync(string uid)
		{
			try
			{
				var url = ConfigurationManager.AppSettings["UrlPdpa"] + "/service/GetActivePurposes/" + uid + "/identifier";
				//var authObj = new Authentication().AuthTcgPdpaApi();
				var authObj = await GetAuthTokenAsync();

                var buffer = await HTTPManager.HttpGetHeaderAsync(url, "Bearer " + authObj.result.accessToken);

				return buffer;
			}
			catch (Exception ex)
			{

				LocalLogManager.Logger("error GetActivePurposesAsync " + ex.Message);
				throw;

			}
		}

		public static async Task<String> GetPorposeAll()
		{
			try
			{
				var url = ConfigurationManager.AppSettings["UrlPdpa"] + "/service/PurposesGetAll";
				//var authObj = new Authentication().AuthTcgPdpaApi();
				var authObj = await GetAuthTokenAsync();


                authtoken = authObj;

				var buffer = await HTTPManager.HttpGetHeaderAsync(url, "Bearer " + authObj.result.accessToken);

				return buffer;
			}
			catch (Exception ex)
			{

				LocalLogManager.Logger("error GetPorposeAll " + ex.Message);
				throw;

			}
		}

		public static  async Task<String> SubmitConsentAsync(SumbitConsentData consentData)  
		{
			var client = new HttpClient();

			//var authObj = new Authentication().AuthTcgPdpaApi();

			//var authObj = Authentication.AuthTcgPdpaApiStatic();

			var json = JsonConvert.SerializeObject(consentData); 
			var content = new StringContent(json,System.Text.Encoding.UTF8 ,"application/json");

			var url = ConfigurationManager.AppSettings["UrlPdpa"] + "/service/SubmitConsent";
			var request = new HttpRequestMessage(HttpMethod.Post,url);
			request.Content = content;
			request.Headers.Add("accept", "*/*");
			request.Headers.Add("Authorization", "Bearer " + authtoken.result.accessToken); 

			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			var responseBody = await response.Content.ReadAsStringAsync();
			Console.WriteLine(responseBody);

			return responseBody;
		}

		public static async Task<String> GetApprovedPurposeByIdentifier(string uid)
		{
			try
			{
				var url = ConfigurationManager.AppSettings["UrlPdpa"] + "/service/GetApprovedPurposeByIdentifier/" + uid + "/identifier";
				//var authObj = new Authentication().AuthTcgPdpaApi();
				var authObj = await GetAuthTokenAsync();

                var buffer = await HTTPManager.HttpGetHeaderAsync(url, "Bearer " + authObj.result.accessToken);

				return buffer;
			}
			catch (Exception ex)
			{

				LocalLogManager.Logger("error GetActivePurposesAsync " + ex.Message);
				throw;

			}
		}

	}
}