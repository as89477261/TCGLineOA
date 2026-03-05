using DataModel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHealthControl
{
    public class TCGScoreCon
    {
        private static TCGScoreCon instance = new TCGScoreCon();
        private TCGScoreCon() { }
        public static TCGScoreCon Instance
        {
            get
            {
                return instance;
            }
        }

        public RegisterInfo calculateTCGScoreCorperate(RegisterInfo registerInfo)
        {
            var authObj = APIAuthenCon.Instance.GetOpenAPIAuthenToken();
            var bufferObj = registerInfo.ConvertToTCGScoreCorporateModel();
            var jsonObj = JsonConvert.SerializeObject(bufferObj);
            var headerObj = new Dictionary<string, string>() { 
                { "Authorization", "Bearer "+ authObj.data.token }
                //{ "X-AccountKeyId", "" },
                //{ "X-TokenAPIId", "" }
            };
            var urlObj = ConfigurationManager.AppSettings["apiTCGBaseAPI"] + "/v1/screeningsnoe/ScoringPGS_Corperate_BI7";
            var bufferResult = HTTPManager.HttpPost(urlObj, headerObj, jsonObj);

            if (bufferResult != null)
            {
                var result = JsonConvert.DeserializeObject<TCGScoreResponseModel>(bufferResult);
                registerInfo.BindingTCGScoreModel(result);
                return registerInfo;
            }
            else
            {
                return registerInfo;
            }
        }
        public RegisterInfo calculateTCGScorePersonal(RegisterInfo registerInfo)
        {
            var authObj = APIAuthenCon.Instance.GetOpenAPIAuthenToken();
            var bufferObj = registerInfo.ConvertToTCGScorePersonalModel();
            var jsonObj = JsonConvert.SerializeObject(bufferObj);
            var headerObj = new Dictionary<string, string>() {
                { "Authorization", "Bearer "+ authObj.data.token }
                //{ "X-AccountKeyId", "" },
                //{ "X-TokenAPIId", "" }
            };
            var urlObj = ConfigurationManager.AppSettings["apiTCGBaseAPI"] + "/v1/screeningsnoe/ScoringPGS_Personal_BI7";
            var bufferResult = HTTPManager.HttpPost(urlObj, headerObj, jsonObj);

            if (bufferResult != null)
            {
                var result = JsonConvert.DeserializeObject<TCGScoreResponseModel>(bufferResult);
                registerInfo.BindingTCGScoreModel(result);
                return registerInfo;
            }
            else
            {
                return registerInfo;
            }
        }

    }


}
