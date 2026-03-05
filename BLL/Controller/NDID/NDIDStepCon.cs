using System;
using DAL.Repos.NDIDInfo;
using DataModel.Models.NDID;

namespace BLL.Controller.NDID
{
    public class NDIDStepCon
    {
        private NDIDStepCon()
        {
        }

        public static NDIDStepCon Instance { get; } = new NDIDStepCon();


        public BaseModel<string> InsertNDIDMasterStatus(UIDMapNDIDStatusModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NDIDStepRepo();
                var bufferResult = buffer.InsertNDIDMasterStatus(obj);
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

        public BaseModel<string> UpdateNDIDMasterStatus(UIDMapNDIDStatusModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NDIDStepRepo();
                var bufferResult = buffer.UpdateNDIDMasterStatus(obj);
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

        public BaseModel<string> InsertCustomerChooseIDP(CustomerChooseIDPModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NDIDStepRepo();
                var bufferResult = buffer.InsertCustomerChooseIDP(obj);
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

        public BaseModel<string> InsertCustomerConsentNCB(CustomerConsentNCBModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NDIDStepRepo();
                var bufferResult = buffer.InsertCustomerConsentNCB(obj);
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

        public BaseModel<string> InsertCustomerConsentNDID(CustomerConsentNDIDModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NDIDStepRepo();
                var bufferResult = buffer.InsertCustomerConsentNDID(obj);
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

        public BaseModel<string> InsertNDIDRequest(NDIDRequestModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new NDIDStepRepo();
                var bufferResult = buffer.InsertNDIDRequest(obj).To<string>();
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