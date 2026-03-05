using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL.Repos.Dashboard
{
    public class DashboardUIDMapRegisterRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);


        public DataTable GetDashboardUIDMapRegister(string infoType, string subInfoType)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                new SqlParameter("@InfoType", SqlDbType.NVarChar, 100) { Value = infoType },
                new SqlParameter("@SubInfoType", SqlDbType.NVarChar, 100) { Value = subInfoType }
            };

            try
            {
                dt = DB_CustomerHealthCheck
                    .ExecuteStoredProcedureReturnDataSet("GetDashboardUIDMapRegister", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetDashboardUIDMapRegister Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}