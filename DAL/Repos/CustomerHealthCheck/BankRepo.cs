using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL.Repos.CustomerHealthCheck
{
    public class BankRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetBankProfile(string bankCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@BankCode", SqlDbType.NVarChar, 100) { Value = bankCode }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetBankProfile", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBankProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetAllBank()
        {
            DataTable dt = null;

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetBucketBank").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBucketBank Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetAllBankByID(string bankCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@ID", SqlDbType.NVarChar, 100) { Value = bankCode }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetBucketBank", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBucketBank Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetAllBankByListID(string listBankCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@LID", SqlDbType.NVarChar, 200) { Value = listBankCode }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetBucketBank", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBucketBank Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}