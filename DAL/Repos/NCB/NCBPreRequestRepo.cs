using System;
using System.Data;
using System.Data.SqlClient;
using DataModel.Models.CustomerHealthModel.PreRequest;
using DataModel.Models.NCB;
using DataModel.Models.NDID.EForm;

namespace DAL.Repos.NDIDInfo
{
    public class NCBPreRequestRepo
    {

        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);

        public string UpdateUIDMapNCBPreRequestViaOldNCB(UIDMapPreRequestAndUpdateCyber obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {

                new SqlParameter("@NDIDReferenceID", SqlDbType.NVarChar, 500) { Value = obj.NDIDReferenceID },
                new SqlParameter("@StepName", SqlDbType.NVarChar, 500) { Value = obj.StepName },
                new SqlParameter("@StepNumber", SqlDbType.NVarChar, 500) { Value = obj.StepNumber },
                new SqlParameter("@IsSuccessNCB", SqlDbType.Bit) { Value = obj.IsSuccessNCB },
                new SqlParameter("@T01OnlineIDStep", SqlDbType.NVarChar, 500) { Value = obj.T01OnlineIDStep },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 500) { Value = obj.CreatedBy },
                new SqlParameter("@NCBTransactionID", SqlDbType.NVarChar, 500) { Value = obj.NCBTransactionID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnStatus("UpdateUIDMapNCBPreRequestViaOldNCB", parameters);
            }
            catch (Exception ex)
            {
            }

            return dt;
        }
    }
}