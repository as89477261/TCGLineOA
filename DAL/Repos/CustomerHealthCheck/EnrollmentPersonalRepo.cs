using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repos.CustomerHealthCheck
{
    public class EnrollmentPersonalRepo
    {
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetUIDMapEnrollmentPersonal(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_CustomerHealthCheck
                    .ExecuteStoredProcedureReturnDataSet("GetUIDMapEnrollmentPersonal", parameters).Tables[0];
            }
            catch (Exception ex)
            {
            }

            return dt;
        }
        public string UpdateEnrollmentByRegisterID(string registerID,string email)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@RegisterID", SqlDbType.VarChar, 100) { Value = registerID },
                new SqlParameter("@Email", SqlDbType.VarChar, 100) { Value = email }
            };

            try
            {
                dt = DB_CustomerHealthCheck
                    .ExecuteStoredProcedureReturnStatus("UpdateEnrollmentByRegisterID", parameters);
            }
            catch (Exception ex)
            {

            }

            return dt;
        }
    }
}