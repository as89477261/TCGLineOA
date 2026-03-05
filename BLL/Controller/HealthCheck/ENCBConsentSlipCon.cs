using CoreUtility;
using DAL.Repos.CustomerHealthCheck;
using DAL.Repos.NDIDInfo;
using DataModel.Models.CustomerHealthModel.ENCBConsent;
using DataModel.Models.MasterData;
using DataModel.Models.NCB;
using DataModel.Models.TCGCenterAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.Controller.HealthCheck
{
    public class ENCBConsentSlipCon : BasePage
    {
        private ENCBConsentSlipCon()
        {
        }

        public static ENCBConsentSlipCon Instance { get; } = new ENCBConsentSlipCon();

        public BaseModel<string> Step1InsertENCBConsentSlipInfo(NCBConsumerConsentSlipModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                obj.RequestEConsentSlipDate = DateTime.Now;                

                var buffer = new NCBConsumerSonsentSlipRepo();
                var bufferResult = buffer.InsertENCBConsentSlipData(obj);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult;
                    result.SetSuccess();
                }
                else
                {
                    result.SetNotfound();
                }

                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<string> Step2UpdateENCBConsentSlipData(NCBConsumerConsentSlipModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NCBConsumerSonsentSlipRepo();
                var bufferResult = buffer.UpdateENCBConsentSlipData(obj);
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult;
                    result.SetSuccess();
                }
                else
                {
                    result.SetNotfound();
                }

                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
        public BaseModel<ENCBConsentDocumentModel> GetNCBConsentSlipInfo(string transID)
        {
            var result = new BaseModel<ENCBConsentDocumentModel>();
            try
            {
                var bufferResult = HTTPManager.HttpPost<BaseNCBConsentModel>(
                    GetAppsetting("ENCBConsentSlipInternalAPI") + transID,
                    new Dictionary<string, string>() { { "Authorization", "Bearer " + GetAppsetting("ENCBConsentSlipToken") } },
                    ""); ;

                if (bufferResult.statusCode == 200 && bufferResult.data != null)
                {
                 
                    result.RESULT_OBJ = bufferResult.data;
                    result.SetSuccess();
                }
                else
                {
                    result.SetNotfound();
                }

                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }

        public BaseModel<NCBTransactionDataModel> GETCheckNCBHistory(string idCard)
        {
            var result = new BaseModel<NCBTransactionDataModel>();
            try
            {
                var buffer = new NCBConsumerSonsentSlipRepo();
                var bufferResult = buffer.GETCheckNCBHistory(idCard).To<NCBTransactionDataModel>(); ;
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult;
                    result.SetSuccess();
                }
                else
                {
                    result.SetNotfound();
                }

                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
    }
}
