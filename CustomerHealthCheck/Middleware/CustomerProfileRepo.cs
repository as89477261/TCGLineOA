using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL.Repos
{
    public class CustomerProfileRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetCustomerProfileByUID(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapCustomerProfile", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
            }

            return dt;
        }

        public DataTable GetUIDMapRegisterHealthCheck(string Uid , int registerInfoId)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = Uid },
                new SqlParameter("@RegisterInfo", SqlDbType.Int) { Value = registerInfoId }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRegisterHealthCheck",parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
            }

            return dt;
        }
    }


}