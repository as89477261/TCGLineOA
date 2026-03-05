using System;
using System.Data;
using System.Reflection;
using log4net;

namespace DAL.Repos.CustomerHealthCheck
{
    public class DashboardFARegisterRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private readonly Database DB_FACenter = new Database(Database.DBName.DB_FACenter);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetDashboardFARegisterMonthly()
        {
            DataTable dt = null;

            try
            {
                dt = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetDashboardFARegisterMonthly").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetDashboardFARegisterMonthly Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetDashboardFARegisterSummary()
        {
            DataTable dt = null;

            try
            {
                dt = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetDashboardFARegisterSummary").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetDashboardFARegisterSummary Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}