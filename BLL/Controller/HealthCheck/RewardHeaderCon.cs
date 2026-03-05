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
    public class RewardHeaderCon
    {
        private RewardHeaderCon()
        {
        }

        public static RewardHeaderCon Instance { get; } = new RewardHeaderCon();

        public BaseModel<List<RewardProgramModel>> GetRewardByHeader(string rewardOwnerCode, string rewardProgramCode, string isUseCurrentDate)
        {
            var result = new BaseModel<List<RewardProgramModel>>();
            try
            {
                var repo = new RewardHeaderRepo();
                var bufferResult = repo.GetRewardByHeader(rewardOwnerCode, rewardProgramCode, isUseCurrentDate).ToListof<RewardProgramModel>();

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
