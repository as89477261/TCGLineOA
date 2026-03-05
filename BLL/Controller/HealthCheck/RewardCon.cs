using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.CustomerHealthModel.EventsModel;
using DAL.Repos;
using DataModel.Models.SMEClinic;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel.Reward;
using DataModel.Models.Line;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller.HealthCheck
{
    public class RewardCon
    {
        private RewardCon()
        {
        }

        public static RewardCon Instance { get; } = new RewardCon();

        public BaseModel<List<RewardMapUIDModel>> GetReward()
        {
            var result = new BaseModel<List<RewardMapUIDModel>>();
            try
            {
                var repo = new RewardRepo();
                var bufferResult = repo.GetReward().ToListof<RewardMapUIDModel>();

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
        public BaseModel<RewardMapUIDModel> GetRewardByOwner(string ownerCode, string programCode)
        {
            var result = new BaseModel<RewardMapUIDModel>();
            try
            {
                var repo = new RewardRepo();
                var bufferResult = repo.GetRewardByOwner(ownerCode, programCode).ToListof<RewardMapUIDModel>().FirstOrDefault();

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
        public BaseModel<RewardMapUIDModel> GetRewardByRewardCode(string rewardid)
        {
            var result = new BaseModel<RewardMapUIDModel>();
            try
            {
                var repo = new RewardRepo();
                var bufferResult = repo.GetRewardByRewardID(rewardid).ToListof<RewardMapUIDModel>().FirstOrDefault();

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
        public BaseModel<List<RewardMapUIDModel>> GetUIDMapReward(string UID, string rewardOwner = null, string rewardProgram = null)
        {
            var result = new BaseModel<List<RewardMapUIDModel>>();
            try
            {
                var repo = new RewardRepo();
                var bufferResult = repo.GetUIDMapReward(UID, rewardOwner, rewardProgram).ToListof<RewardMapUIDModel>();

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
        public BaseModel<List<RewardMapUIDModel>> GetUIDMapRewardByRange(string UID, string rewardOwnerCode = null, string rewardProgramCode = null)
        {
            var result = new BaseModel<List<RewardMapUIDModel>>();
            try
            {
                var repo = new RewardRepo();
                var bufferResult = repo.GetUIDMapRewardByRange(UID, rewardOwnerCode, rewardProgramCode).ToListof<RewardMapUIDModel>();

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
        public BaseModel<RewardMapUIDModel> GetUIDMapRewardDuplicate(string UID, string rewardOwnerCode = null, string rewardProgramCode = null, string phoneNumber = null, string Token = null, string Mac = null, string IP = null)
        {
            var result = new BaseModel<RewardMapUIDModel>();
            try
            {
                var repo = new RewardRepo();
                var bufferResult = repo.GetUIDMapRewardDuplicate(UID, rewardOwnerCode, rewardProgramCode, phoneNumber, Token, Mac, IP).To<RewardMapUIDModel>();

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
        public BaseModel<RewardMapUIDModel> GetUIDMapRewardDummy(string UID, string OTP = null, string rewardOwnerCode = null, string rewardProgram = null,
            string phoneNumber = null, string Token = null, string Mac = null, string IP = null, string OTPRef = null)
        {
            var result = new BaseModel<RewardMapUIDModel>();
            try
            {
                var repo = new RewardRepo();
                var bufferResult = repo.GetUIDMapRewardDummy(UID, OTP, rewardOwnerCode, rewardProgram, phoneNumber, Token, Mac, IP, OTPRef).To<RewardMapUIDModel>();

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


        public BaseModel<RewardConditionModel> GetUIDPassRewardCondition(string UID, string subInfoType)
        {
            var result = new BaseModel<RewardConditionModel>();
            try
            {
                var buffer = new RewardRepo();
                var bufferResult = buffer.GetUIDPassRewardCondition(UID, subInfoType).ToListof<RewardConditionModel>().FirstOrDefault();

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

        public BaseModel<RewardConditionModel> GetUIDPassRewardConditionConfig(string UID, string ownerCode, string programCode,string campaingCode)
        {
            var result = new BaseModel<RewardConditionModel>();
            try
            {
                var buffer = new RewardRepo();
                var bufferResult = buffer.GetUIDPassRewardConditionConfig(UID, ownerCode, programCode, campaingCode).ToListof<RewardConditionModel>().FirstOrDefault();

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

        public BaseModel<string> InsertUIDMapReward(RewardMapUIDModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new RewardRepo();
                var bufferResult = buffer.InsertUIDMapReward(obj);
                if (bufferResult != "")
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
        public BaseModel<string> InsertBulkRewardList(DataTable dt)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new RewardRepo();
                var bufferResult = buffer.InsertBulkRewardList(dt);
                if (bufferResult != "")
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
        public BaseModel<string> InsertRewardList(DataTable dt)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new RewardRepo();
                var bufferResult = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bufferResult = buffer.InsertRewardList(dt.Rows[i]);
                }





                if (bufferResult != "")
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


        public BaseModel<string> UpdateUIDMapReward(RewardMapUIDModel obj)
        {
            var result = new BaseModel<string>();
            try
            {
                var buffer = new RewardRepo();
                var bufferResult = buffer.UpdateUIDMapReward(obj);
                if (bufferResult != "")
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
        public BaseModel<DataTable> GetRewardDashboard()
        {
            var result = new BaseModel<DataTable>();
            try
            {
                var repo = new RewardRepo();
                var bufferResult = repo.GetRewardDashboard();

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
