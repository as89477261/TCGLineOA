using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.SMEClinic;
using log4net;

namespace DAL.Repos
{
    public class UIDMapCustomerProfileRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetUIDMapCustomerProfile(string UID, string customerProfileCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@CustomerProfileCode", SqlDbType.VarChar, 100) { Value = customerProfileCode }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapCustomerProfileNoData", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetUIDMapCustomerProfileNoData Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertUIDMapCustomerProfile(UIDMapCustomerProfileModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerProfileCode", SqlDbType.VarChar, 100) { Value = obj.CustomerProfileCode },
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = obj.Uid },
                new SqlParameter("@PersonalType", SqlDbType.VarChar, 50) { Value = obj.PersonalType },
                new SqlParameter("@IsActive", SqlDbType.VarChar, 5) { Value = obj.IsActive }
            };

            try
            {
                customerCode = DB_SMEClinic.executeStoredProcedureScalar("proc_InsertUidMapCustomerProfile", parameters)
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUidMapCustomerProfile() Error : " + ex, ref log4);
            }

            return customerCode;
        }
    }
}