using System;
using System.Collections.Generic;
using DAL.Repos.NDIDInfo;
using DataModel.Models.NCB;
using DataModel.Models.NDID;
using DataModel.Models.NDID.Personal;

namespace BLL.Controller.NDID
{
    public class NCBTransactionLogCon : BasePage
    {
        private NCBTransactionLogCon()
        {
        }

        public static NCBTransactionLogCon Instance { get; } = new NCBTransactionLogCon();

        public BaseModel<NCBTransactionDataModel> GETNCBScoreHistroyByIDCard(string idcard, bool isHaveScore)
        {
            var result = new BaseModel<NCBTransactionDataModel>();
            try
            {
                var limitDate = GetAppsetting("LimitNCBReuseDate");
                var buffer = new NCBTransactionLogRepo();
                var bufferResult = buffer.GETNCBScoreHistroyByIDCard(idcard, isHaveScore, limitDate).To<NCBTransactionDataModel>();
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