
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoreUtility;
using DAL.Repos;
using DataModel.Models.CustomerHealthModel.PreRequest;

namespace BLL.Controller

{
    public class CyberRequestCon
    {
        private static CyberRequestCon instance;
        private CyberRequestCon() { }
        public static CyberRequestCon Instance()
        {
            if (instance == null)
            {
                instance = new CyberRequestCon();
            }

            return instance;
        }
            

        public BaseModel<string> UpdateNCBScoreToRequest(UIDMapPreRequestAndUpdateCyber obj)
        {
            BaseModel<string> result = new BaseModel<string>();
            try
            {
                var buffer = new CyberRequestRepo();
                var bufferResult = buffer.UpdateNCBScoreToRequest(obj);
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
                throw ex;
            }
        }
    }
}
