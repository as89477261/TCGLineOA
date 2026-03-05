using System;
using System.Collections.Generic;
using DAL.FACenter;
using DataModels.FACenter;

namespace BLL.Controller.FACenter
{
    public class TransactionFACon : BasePage
    {
        private TransactionFACon()
        {
        }

        public static TransactionFACon Instance { get; } = new TransactionFACon();

        public BaseModel<List<MainTransectionInfo>> GetFATransections(string FATransID)
        {
            var result = new BaseModel<List<MainTransectionInfo>>();
            try
            {
                var buffer = new TransactionFARepo();
                var bufferResult = buffer.GetFATransections(FATransID).DataTableToList<MainTransectionInfo>();
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

        public BaseModel<string> UpdateFA_Transections_Dept(int FAID, int ConsultID, string FA_Ref, string LG,
            int SystemStatusID)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new TransactionFARepo();
                var bufferResult = buffer.UpdateFA_Transections_Dept(FAID, ConsultID, FA_Ref, LG, SystemStatusID);
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