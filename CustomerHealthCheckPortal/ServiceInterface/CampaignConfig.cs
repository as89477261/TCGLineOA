using CoreUtility;
using DataModel.Models.CampaignConfig;
using DataModel.Models.LG;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace CustomerHealthCheck.ServiceInterface
{
    public class CampaignConfig
    {

        public class LineCampaign 
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("url")]
            public string Url { get; set; }
            [JsonProperty("lineOAStatus")]
            public string LineOAStatus { get; set; }
            [JsonProperty("banner")]
            public string Banner { get; set; }
            [JsonProperty("status")]
            public string Status { get; set; }
            [JsonProperty("endDate")]
            public DateTime? EndDate { get; set; } = null;

        }


        public static async Task<List<LineCampaign>> GetCampaignConfigActive()
        {
            try
            {
                var urlCampaignConfig = ConfigurationManager.AppSettings["UrlAPICampaignConfig"];

                if(urlCampaignConfig == null)
                {
                    return new List<LineCampaign>();
                }

                var uri = urlCampaignConfig + "/v1/campaigns/line-oa";

                var headers = new Dictionary<string, string>
                    {
                        { "x-api-key", "gl0cwyq4ekz12096wj2ff7ln" },
                        { "accept", "application/json" }
                    };

                string response = await HTTPManager.HttpGetWithHeadersAsync(uri, headers);
                var result = JsonConvert.DeserializeObject<List<LineCampaign>>(response);
                return result;
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("error GetPorposeAll " + ex.Message);
                throw;

            }
        }

        public static async Task<List<CampaignRegister>> GetRegisterUserByUID(string uid)
        {
            try
            {
                var uri = ConfigurationManager.AppSettings["UrlAPICampaignConfig"] + ConfigurationManager.AppSettings["CampaignConfigURL_GetRegisterUIDAPI"] + uid;
                var headers = new Dictionary<string, string>
                    {
                        { "x-api-key", "gl0cwyq4ekz12096wj2ff7ln" },
                        { "accept", "*/*" }
                    };

                string response = await HTTPManager.HttpGetWithHeadersAsync(uri, headers);
                var result = JsonConvert.DeserializeObject<List<CampaignRegister>>(response);

                return result;
            }
            catch (Exception ex)
            {

                LocalLogManager.Logger("error GetPorposeAll " + ex.Message);
                throw;

            }
        }
    }
}