using System;
using System.Data;
using System.Data.SqlClient;
using DataModel.Models.NDID.EForm;

namespace DAL.Repos.NDIDInfo
{
    public class NDIDEFormRepo
    {
        private Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);


        public string GetNDIDEFormCountAll()
        {
            var dt = "";

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnValue("proc_GetUIDMapEFormLastNumber");
            }
            catch (Exception ex)
            {
            }

            return dt;
        }

        public string InsertNDIDEFormTransaction(NDIDEFormTransactionModel obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@TransactionID", SqlDbType.NVarChar, 50) { Value = obj.TransactionID },
                new SqlParameter("@UID", SqlDbType.NVarChar, 500) { Value = obj.UID },
                new SqlParameter("@CurrentStatusCode", SqlDbType.NVarChar, 500) { Value = obj.CurrentStatusCode },
                new SqlParameter("@CurrentStatusRemark", SqlDbType.NVarChar, 4000) { Value = obj.CurrentStatusRemark }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnStatus("proc_InsertUidMapNDIDEForm", parameters);
            }
            catch (Exception ex)
            {
            }

            return dt;
        }
    }
}