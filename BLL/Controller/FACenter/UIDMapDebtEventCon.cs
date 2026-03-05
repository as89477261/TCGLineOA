using DAL.Repos.FACenter;
using DataModel.Models.FACenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controller.FACenter
{
    public class UIDMapDebtEventCon
    {

        public static UIDMapDebtEventCon Instance { get; } = new UIDMapDebtEventCon();


        public BaseModel<List<UIDMapDeptModel>> GetUIDMapDebtEvent(string uid , string eventCode)
        {
            var result = new BaseModel<List<UIDMapDeptModel>>();
            try
            {
                var buffer = new UidMapFADeptRepo();
                var bufferResult = buffer.GetUIDMapDept(uid , eventCode).ToListof<UIDMapDeptModel>();
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

        public BaseModel<DataSet> InsertUIDMapDebtEvent(UIDMapDeptModel obj)
        {

            var result = new BaseModel<DataSet>();
            try
            {
                var buffer = new UidMapFADeptRepo();
                var bufferResult = buffer.InsertUIDMapDept(obj);
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

        public BaseModel<string> UpdateUidMapDebtCompleteTrans(UIDMapDeptModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new UidMapFADeptRepo();
                var bufferResult = buffer.UpdateUidMapDebtTrans(obj); 
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
