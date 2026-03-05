using DataModel.Models.CustomerHealthModel.EventsModel;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.CustomerHealthModel.Reward;
using System.Configuration;
using System.Globalization;

namespace DAL.Repos.CustomerHealthCheck
{
    public class RewardHeaderRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);

        public DataTable GetRewardByHeader(string rewardOwnerCode, string rewardProgramCode, string isUseCurrentDate)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                new SqlParameter("@RewardOwnerCode", SqlDbType.VarChar, 200) { Value = rewardOwnerCode },
                new SqlParameter("@RewardProgramCode", SqlDbType.VarChar, 200) { Value = rewardProgramCode },
                new SqlParameter("@IsUseCurrentDate", SqlDbType.VarChar, 200) { Value = isUseCurrentDate }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetRewardProgram", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetRewardStock Error : " + ex, ref log4);
            }

            return dt;
        }

    }
}
