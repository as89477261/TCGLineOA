using System;
using System.Data;
using System.Reflection;
using log4net;

namespace DAL.Repos.CustomerHealthCheck
{
    public class DashboardUIDRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetDashboardUID()
        {
            DataTable dt = null;

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetDashboardUID").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetDashboardUID Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetDashboardUIDMonthly()
        {
            DataTable dt = null;

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetDashboardUIDMonthly").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetDashboardUIDMonthly Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}