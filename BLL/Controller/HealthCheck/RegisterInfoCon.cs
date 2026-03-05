using System;
using System.Collections.Generic;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller
{
    public class RegisterInfoCon
    {
        private RegisterInfoCon()
        {
        }

        public static RegisterInfoCon Instance { get; } = new RegisterInfoCon();

        public BaseModel<List<RegisterInfoModel>> GetRegisInfoByUID(string uid)
        {
            var result = new BaseModel<List<RegisterInfoModel>>();
            try
            {
                var buffer = new RegisterInfoRepo();
                var bufferResult = buffer.GetRegisInfoByUID(uid, "100").ToListof<RegisterInfoModel>();
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

        public BaseModel<List<RegisterInfoModel>> GetRegisInfoByUIDWithType(string uid, string infoType,
            string subInfoType)
        {
            var result = new BaseModel<List<RegisterInfoModel>>();
            try
            {
                var buffer = new RegisterInfoRepo();
                var bufferResult = buffer.GetRegisInfoByUIDWithType(uid, "100", infoType, subInfoType)
                    .ToListof<RegisterInfoModel>();
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

        public BaseModel<List<RegisterInfoModel>> GetRegisInfoStatusByUIDWithType(string uid, string RegisterInfoID,
            string clinicRequestNo, string infoType, string subInfoType)
        {
            var result = new BaseModel<List<RegisterInfoModel>>();
            try
            {
                var buffer = new RegisterInfoRepo();
                var bufferResult = buffer
                    .GetRegisInfoStatusByUIDWithType(uid, "100", RegisterInfoID, clinicRequestNo, infoType, subInfoType)
                    .ToListof<RegisterInfoModel>();
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

        public BaseModel<List<RegisterInfoModel>> GetTop5RegisInfoByUID(string uid)
        {
            var result = new BaseModel<List<RegisterInfoModel>>();
            try
            {
                var buffer = new RegisterInfoRepo();
                var bufferResult = buffer.GetRegisInfoByUID(uid, "5").ToListof<RegisterInfoModel>();
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

        public BaseModel<List<RegisterInfoModel>> GetRegisInfoByType(string uid, string type,
            string isHasCustomerProfile = "")
        {
            var result = new BaseModel<List<RegisterInfoModel>>();
            try
            {
                var buffer = new RegisterInfoRepo();
                var bufferResult = buffer.GetRegisInfoByType(uid, type, isHasCustomerProfile, "5")
                    .ToListof<RegisterInfoModel>();
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

        public BaseModel<List<RegisterInfoModel>> GetRegisInfoByRegisID(string registerInfoID)
        {
            var result = new BaseModel<List<RegisterInfoModel>>();
            try
            {
                var buffer = new RegisterInfoRepo();
                var bufferResult = buffer.GetRegisInfoByRegisID(registerInfoID).ToListof<RegisterInfoModel>();
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

        public BaseModel<List<RegisterInfoModel>> GetRegisInfoStatusByIDCardWithType(string uid, string infoType, string subInfoType)
        {
            var result = new BaseModel<List<RegisterInfoModel>>();
            try
            {
                var buffer = new RegisterInfoRepo();
                var bufferResult = buffer
                    .GetRegisInfoStatusByIDCardWithType(uid, infoType, subInfoType)
                    .ToListof<RegisterInfoModel>();
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