using System;
using System.Collections.Generic;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller.HealthCheck
{
    public class ApprochCon
    {
        private ApprochCon()
        {
        }

        public static ApprochCon Instance { get; } = new ApprochCon();

        public BaseModel<List<UIDMapApprochModel>> GetUIDMapApproch(string uid)
        {
            var result = new BaseModel<List<UIDMapApprochModel>>();
            try
            {
                var buffer = new ApprochRepo();
                var bufferResult = buffer.GetUIDMapApproch(uid).ToListof<UIDMapApprochModel>();
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

        public BaseModel<List<UIDMapApprochModel>> GetUIDMapApprochWithApprochID(string approchID)
        {
            var result = new BaseModel<List<UIDMapApprochModel>>();
            try
            {
                var buffer = new ApprochRepo();
                var bufferResult = buffer.GetUIDMapApprochByApprochID(approchID).ToListof<UIDMapApprochModel>();
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

        public BaseModel<List<UIDMapApprochModel>> GetUIDMapApproch(string uid, string pcode)
        {
            var result = new BaseModel<List<UIDMapApprochModel>>();
            try
            {
                var buffer = new ApprochRepo();
                var bufferResult = buffer.GetUIDMapApprochByUIDAndPCode(uid, pcode).ToListof<UIDMapApprochModel>();
                if (bufferResult != null && bufferResult.Count > 0)
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

        public BaseModel<List<UIDMapApprochModel>> GetUIDMapApproch(string uid, string pid, string hcid)
        {
            var result = new BaseModel<List<UIDMapApprochModel>>();
            try
            {
                var buffer = new ApprochRepo();
                var bufferResult = buffer.GetUIDMapApprochByUIDAndPCode(uid, pid, hcid).ToListof<UIDMapApprochModel>();
                if (bufferResult != null && bufferResult.Count > 0)
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

        public BaseModel<List<UIDMapApprochModel>> InsertUIDMapApproch(UIDMapApprochModel obj)
        {
            var result = new BaseModel<List<UIDMapApprochModel>>();
            try
            {
                var buffer = new ApprochRepo();
                var bufferResult = buffer.InsertUIDMapApproch(obj).ToListof<UIDMapApprochModel>();
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

        public BaseModel<List<ApprochMapBankModel>> InsertApprochMapBank(List<ApprochMapBankModel> obj)
        {
            var result = new BaseModel<List<ApprochMapBankModel>>();
            try
            {
                var buffer = new ApprochRepo();
                if (obj != null && obj.Count > 0)
                {
                    var itemCount = obj.Count;
                    var successCount = 0;
                    foreach (var item in obj)
                    {
                        var bufferResult = buffer.InsertApprochMapBank(item).ToListof<ApprochMapBankModel>();
                        successCount++;
                    }

                    if (successCount == itemCount)
                        result.SetSuccess();
                    else
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

        public BaseModel<List<ApprochMapBankModel>> InsertApprochMapBankWithSendMail(List<ApprochMapBankModel> obj)
        {
            var result = new BaseModel<List<ApprochMapBankModel>>();
            try
            {
                var buffer = new ApprochRepo();


                if (obj != null && obj.Count > 0)
                {
                    var itemCount = obj.Count;
                    var successCount = 0;
                    foreach (var item in obj)
                    {
                        var bufferResult = buffer.InsertApprochMapBank(item).ToListof<ApprochMapBankModel>();
                        successCount++;
                    }

                    if (successCount == itemCount)
                        result.SetSuccess();
                    else
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