using System;
using System.Data;
using System.Reflection;
using log4net;

namespace DAL.Repos.Dashboard
{
    public class DashboardRegisterInfoStatusPGS10Repo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);


        public DataTable GetDashboardRegisterInfoStatusPGS10()
        {
            DataTable dt = null;
            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetDashboardRegisterInfoStatusPGS10")
                    .Tables[0];
            }
            catch (Exception err)
            {
                LogUtility.writeLog("GetDashboardRegisterInfoStatusPGS10 Error : " + err, ref log4);
            }

            return dt;
        }
    }
}