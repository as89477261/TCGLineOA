using System;
using System.Collections.Generic;
using DAL.FACenter;
using DataModel.Models.FACenter;

namespace BLL.Controller.FACenter
{
    public class UIDMapFAEventCon
    {
        private UIDMapFAEventCon()
        {
        }

        public static UIDMapFAEventCon Instance { get; } = new UIDMapFAEventCon();


        public BaseModel<List<UIDMapFAEventModel>> GetUIDMapFAEvent(string uid, string eventCode)
        {
            var result = new BaseModel<List<UIDMapFAEventModel>>();
            try
            {
                var buffer = new UIDMapFAEventRepo();
                var bufferResult = buffer.GetUIDMapFAEvent(uid, eventCode).ToListof<UIDMapFAEventModel>();
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

        public BaseModel<string> InsertUIDMapFAEvent(UIDMapFAEventModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new UIDMapFAEventRepo();
                var bufferResult = buffer.InsertUIDMapFAEvent(obj);
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