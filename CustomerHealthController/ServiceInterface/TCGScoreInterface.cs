using System.Collections.Generic;
using System.Configuration;
using CoreUtility;
using Newtonsoft.Json;

namespace CustomerHealthController.ServiceInterface
{
    public class TcgScoreInterface
    {
        private TcgScoreInterface()
        {
        }

        public static TcgScoreInterface Instance { get; } = new TcgScoreInterface();

        public RegisterInfo CalculateTcgScoreCorperate(RegisterInfo registerInfo)
        {
            var authObj = ApiAuthInterface.Instance.GetOpenApiAuthToken();
            var bufferObj = registerInfo.ConvertToTcgScoreCorporateModel();
            var jsonObj = JsonConvert.SerializeObject(bufferObj);
            var headerObj = new Dictionary<string, string>
            {
                { "Authorization", "Bearer " + authObj.data.token }
                //{ "X-AccountKeyId", "" },
                //{ "X-TokenAPIId", "" }
            };
            var urlObj = ConfigurationManager.AppSettings["apiTCGBaseApi"] +
                         "/v1/screeningsnoe/ScoringPGS_Corperate_BI7";
            var bufferResult = HTTPManager.HttpPost(urlObj, headerObj, jsonObj);

            if (bufferResult != null)
            {
                var result = JsonConvert.DeserializeObject<TCGScoreResponseModel>(bufferResult);
                registerInfo.BindTcgScoreModel(result);
                return registerInfo;
            }

            return registerInfo;
        }

        public RegisterInfo CalculateTcgScorePersonal(RegisterInfo registerInfo)
        {
            var authObj = ApiAuthInterface.Instance.GetOpenApiAuthToken();
            var bufferObj = registerInfo.ConvertToTCGScorePersonalModel();
            var jsonObj = JsonConvert.SerializeObject(bufferObj);
            var headerObj = new Dictionary<string, string>
            {
                { "Authorization", "Bearer " + authObj.data.token }
                //{ "X-AccountKeyId", "" },
                //{ "X-TokenAPIId", "" }
            };
            var urlObj = ConfigurationManager.AppSettings["apiTCGBaseApi"] +
                         "/v1/screeningsnoe/ScoringPGS_Personal_BI7";
            var bufferResult = HTTPManager.HttpPost(urlObj, headerObj, jsonObj);

            if (bufferResult != null)
            {
                var result = JsonConvert.DeserializeObject<TCGScoreResponseModel>(bufferResult);
                registerInfo.BindTcgScoreModel(result);
                return registerInfo;
            }

            return registerInfo;
        }
    }
}