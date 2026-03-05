using System;
using System.Data;
using System.Reflection;
using log4net;

namespace DAL.Repos.MasterData
{
    public class IndustryRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetIndustryAll()
        {
            DataTable dt = null;

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetIndustry").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetIndustry Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}