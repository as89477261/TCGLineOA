using System;
using System.Collections.Generic;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel.EventsModel;

namespace BLL.Controller.HealthCheck
{
    public class UIDMapEventRegisterCon
    {
        private UIDMapEventRegisterCon()
        {
        }

        public static UIDMapEventRegisterCon Instance { get; } = new UIDMapEventRegisterCon();

        public BaseModel<List<FormEventRegisterOutputModel>> GetFormRegisterWithGroupAndUID(string uid)
        {
            var result = new BaseModel<List<FormEventRegisterOutputModel>>();
            try
            {
                var buffer = new EventRepo();
                var bufferResult = buffer.GetFormRegisterWithGroupAndUID(uid).ToListof<FormEventRegisterOutputModel>();
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

        public BaseModel<List<FormEventRegisterOutputModel>> GetFormRegisterWithEventCodeAndUID(string eventCode,
            string uid)
        {
            var result = new BaseModel<List<FormEventRegisterOutputModel>>();
            try
            {
                var buffer = new EventRepo();
                var bufferResult = buffer.GetFormRegisterWithGroupAndUID(eventCode, uid)
                    .ToListof<FormEventRegisterOutputModel>();
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