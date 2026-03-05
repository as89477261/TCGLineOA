using System;
using System.Data;
using System.Data.SqlClient;
using DataModel.Models.CustomerHealthModel.PreRequest;

namespace DAL.Repos.CustomerHealthCheck
{
    public class PreNDIDRepo

    {
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);

        public DataTable GetUIDMapNDIDPreRequest(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapNDIDPreRequest", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
            }

            return dt;
        }

        public string InsertUIDMapNDIDPreRequest(UIDMapNDIDPreRequest obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = obj.UID },
                new SqlParameter("@NDIDReferenceID", SqlDbType.NVarChar, 100) { Value = obj.NDIDReferenceID },
                new SqlParameter("@NCBResultID", SqlDbType.NVarChar, 100) { Value = obj.NCBResultID },
                new SqlParameter("@StepName", SqlDbType.NVarChar, 100) { Value = obj.StepName },
                new SqlParameter("@StepNumber", SqlDbType.NVarChar, 100) { Value = obj.StepNumber },
                new SqlParameter("@IsSuccessNDID", SqlDbType.Bit) { Value = obj.IsSuccessNDID },
                new SqlParameter("@Status", SqlDbType.Bit) { Value = obj.Status },
                new SqlParameter("@T01OnlineID", SqlDbType.NVarChar, 100) { Value = obj.T01OnlineID },
                new SqlParameter("@T01OnlineIDStep", SqlDbType.NVarChar, 100) { Value = obj.T01OnlineIDStep },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy },
                new SqlParameter("@PersonalChooseBank", SqlDbType.NVarChar, 100) { Value = obj.PersonalChooseBank }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnStatus("InsertUIDMapNDIDPreRequest",
                    parameters);
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("[DAL] InsertUIDMapNDIDPreRequest error message is : " + ex.Message);
            }

            return dt;
        }

        public string InsertUIDMapNDIDPreRequestHistory(UIDMapNDIDPreRequestHistory obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = obj.UID },
                new SqlParameter("@NCBResultID", SqlDbType.NVarChar, 100) { Value = obj.NCBResultID },
                new SqlParameter("@StepName", SqlDbType.NVarChar, 100) { Value = obj.StepName },
                new SqlParameter("@StepNumber", SqlDbType.NVarChar, 100) { Value = obj.StepNumber },
                new SqlParameter("@PreRequestID", SqlDbType.NVarChar, 100) { Value = obj.PreRequestID },
                new SqlParameter("@Status", SqlDbType.Bit) { Value = obj.Status },
                new SqlParameter("@NDIDReferenceID", SqlDbType.NVarChar, 100) { Value = obj.NDIDReferenceID },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnStatus("InsertUIDMapNDIDPreRequestHistory",
                    parameters);
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("[DAL] InsertUIDMapNDIDPreRequestHistory error message is : " + ex.Message);
            }

            return dt;
        }

        public string InsertUIDMapNDIDPreRequestOldNCB(UIDMapPreRequestAndUpdateCyber obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = obj.UID },
                new SqlParameter("@NDIDReferenceID", SqlDbType.NVarChar, 100) { Value = obj.NDIDReferenceID },                
                new SqlParameter("@StepName", SqlDbType.NVarChar, 100) { Value = obj.StepName },
                new SqlParameter("@StepNumber", SqlDbType.NVarChar, 100) { Value = obj.StepNumber },
                new SqlParameter("@IsSuccessNDID", SqlDbType.Bit) { Value = obj.IsSuccessNDID },
                new SqlParameter("@IsSuccessNCB", SqlDbType.Bit) { Value = obj.IsSuccessNCB },
                new SqlParameter("@T01OnlineID", SqlDbType.NVarChar, 100) { Value = obj.T01OnlineID },
                new SqlParameter("@T01OnlineIDStep", SqlDbType.NVarChar, 100) { Value = obj.T01OnlineIDStep },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy },
                new SqlParameter("@NCBTransactionID", SqlDbType.NVarChar, 100) { Value = obj.NCBTransactionID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnStatus("InsertUIDMapNDIDPreRequestViaOldNCB", parameters);
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("[DAL] InsertUIDMapNDIDPreRequestViaOldNCB error message is : " + ex.Message);
            }

            return dt;
        }
    }
}