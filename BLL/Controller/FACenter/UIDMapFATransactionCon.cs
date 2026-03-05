using System;
using System.Collections.Generic;
using DAL.FACenter;
using DataModel.Models.FACenter;

namespace BLL.Controller.FACenter
{
    public class UIDMapFATransactionCon
    {
        private UIDMapFATransactionCon()
        {
        }

        public static UIDMapFATransactionCon Instance { get; } = new UIDMapFATransactionCon();

        public BaseModel<string> InsertUIDMapTransaction(UIDMapTransactionModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new UIDMapFATransactionRepo();
                var bufferResult = buffer.InsertUIDMapTransaction(obj);
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

        public BaseModel<List<UIDMapTransAndFormRegisModel>> GetUIDMapTransAndFormByID(string uid)
        {
            var result = new BaseModel<List<UIDMapTransAndFormRegisModel>>();
            try
            {
                var buffer = new UIDMapFATransactionRepo();
                var bufferResult = buffer.GetUIDMapTransAndFormByID(uid).ToListof<UIDMapTransAndFormRegisModel>();
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