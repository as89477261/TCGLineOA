using System;
using System.Collections.Generic;
using DAL.Repos.NDIDInfo;
using DataModel.Models.NDID.Callback;
using DataModel.Models.NDID.Personal;

namespace BLL.Controller.NDID
{
    public class NDIDPersonalCon
    {
        private NDIDPersonalCon()
        {
        }

        public static NDIDPersonalCon Instance { get; } = new NDIDPersonalCon();

        public BaseModel<List<NDIDPersonalModel>> GetNDIDPersonalAll()
        {
            var result = new BaseModel<List<NDIDPersonalModel>>();
            try
            {
                var buffer = new NDIDPersonalRepo();
                var bufferResult = buffer.GetNDIDPersonalAll().ToListof<NDIDPersonalModel>();
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

        public BaseModel<List<NDIDPersonalModel>> GetNDIDPersonalByID(string id)
        {
            var result = new BaseModel<List<NDIDPersonalModel>>();
            try
            {
                var buffer = new NDIDPersonalRepo();
                var bufferResult = buffer.GetNDIDPersonalByID(id).ToListof<NDIDPersonalModel>();
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

        public BaseModel<NDIDRawPersonalModel> GetNDIDPersonalByRequestID(string reqID)
        {
            var result = new BaseModel<NDIDRawPersonalModel>();
            try
            {
                var buffer = new NDIDPersonalRepo();
                var bufferResult = buffer.GetNDIDPersonalByRequestID(reqID).To<NDIDRawPersonalModel>();
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

        public BaseModel<NDIDEFormRawPersonalModel> GetNDIDEFormPersonalByReferenceID(string refID)
        {
            var result = new BaseModel<NDIDEFormRawPersonalModel>();
            try
            {
                var buffer = new NDIDPersonalRepo();
                var bufferResult = buffer.GetNDIDEFormPersonalByReferenceID(refID).To<NDIDEFormRawPersonalModel>();
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