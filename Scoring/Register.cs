using System;
using System.Data;
using System.Data.SqlClient;
using log4net.Config;
using System.Collections.Generic;

namespace Scoring
{
    public class Register
    {
        Database db = new Database(Database.DBName.DB_CustomerHealthCheck);

        private static log4net.ILog log4 = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Register()
        {
            XmlConfigurator.Configure();
        }

        public DataTable GetBucketProvince()
        {
            DataTable dt = null;

            try
            {
                dt = db.ExecuteStoredProcedureReturnDataSet("GetBucketProvince").Tables[0];
            }
            catch (Exception ex)
            {
                Utility.writeLog("GetBucketProvince Error : " + ex.Message, ref log4);
            }

            return dt;
        }

        public DataTable GetBucketIndustry()
        {
            DataTable dt = null;

            try
            {
                dt = db.ExecuteStoredProcedureReturnDataSet("GetBucketIndustry").Tables[0];
            }
            catch (Exception ex)
            {
                Utility.writeLog("GetBucketIndustry Error : " + ex.Message, ref log4);
            }

            return dt;
        }

        public DataTable GetHealthCheckScore(int score, string type)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                  new SqlParameter("@Score", SqlDbType.Int) { Value = score },
                  new SqlParameter("@Type", SqlDbType.VarChar, 1) { Value = type }
            };

            try
            {
                dt = db.ExecuteStoredProcedureReturnDataSet("GetHealthCheckScore").Tables[0];
            }
            catch (Exception ex)
            {
                Utility.writeLog("GetHealthCheckScore Error : " + ex.Message, ref log4);
            }

            return dt;
        }
    }
}
