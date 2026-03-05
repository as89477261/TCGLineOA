using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repos.CustomerHealthCheck
{
    public class UIDMapEnrollmentRepo
    {
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);

        public DataTable GetUIDMapEnrollment(string ID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = ID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapEnrollment", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("[DAL] GetUIDMapEnrollment error message is : " + ex.Message);
            }

            return dt;
        }
        public DataTable GetUIDMapEnrollmentWithCustomerProfile(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapEnrollmentWithCustomerProfile", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("[DAL] GetUIDMapEnrollmentWithCustomerProfile error message is : " + ex.Message);
            }

            return dt;
        }
        public string InsertUIDMapEnrollment(string uid, string dummyID)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = uid },
                new SqlParameter("@RegisterID", SqlDbType.NVarChar, 100) { Value = dummyID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnStatus("InsertUIDMapEnrollment", parameters);
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("[DAL] InsertUIDMapEnrollment error message is : " + ex.Message);
            }

            return dt;
        }
    }
}