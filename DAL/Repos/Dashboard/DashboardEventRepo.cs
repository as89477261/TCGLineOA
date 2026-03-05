using System;
using System.Data;
using System.Reflection;
using log4net;

namespace DAL.Repos.Dashboard
{
    public class DashboardEventRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);


        public DataTable GetDashboardEvent()
        {
            DataTable dt = null;
            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetDashboardEvent").Tables[0];
            }
            catch (Exception err)
            {
                LogUtility.writeLog("GetDashboardEvent Error : " + err, ref log4);
            }

            return dt;
        }

        public DataTable GetDashboardEventMonthly()
        {
            DataTable dt = null;
            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetDashboardEventMonthly").Tables[0];
            }
            catch (Exception err)
            {
                LogUtility.writeLog("GetDashboardEventMonthly Error : " + err, ref log4);
            }

            return dt;
        }
    }
}