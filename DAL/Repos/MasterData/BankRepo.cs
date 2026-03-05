using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL.Repos.MasterData
{
    public class BankRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetBankAll()
        {
            DataTable dt = null;

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetBank").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBank Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetBankByID(string ID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", SqlDbType.VarChar, 100) { Value = ID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetBank", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBank Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetBankByProductID(string pcode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@PCODE", SqlDbType.VarChar, 100) { Value = pcode }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetBankByProductID", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetBank Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}