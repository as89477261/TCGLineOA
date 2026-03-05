using System;
using System.Data;
using System.Reflection;
using log4net;

namespace DAL.Repos.CustomerHealthCheck
{
    public class DashboardPersonalTypeRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetDashboardPersonalType()
        {
            DataTable dt = null;

            //SqlParameter[] parameters =
            //{
            //      new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID  }
            //};

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetDashboardPersonalType").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetDashboardPersonalType Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetDashboardPersonalMonthly()
        {
            DataTable dt = null;

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetDashboardPersonalMonthly")
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetDashboardPersonalMonthly Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}