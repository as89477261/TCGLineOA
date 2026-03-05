using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL.Repos.MasterData
{
    public class ProductRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetProductAll()
        {
            DataTable dt = null;

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetProduct").Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
                LogUtility.writeLog("GetProduct Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetProductByID(string ID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@ID", SqlDbType.VarChar, 100) { Value = ID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetProduct", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetProduct Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}