using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.NDID;
using log4net;

namespace DAL.Repos.NDIDInfo
{
    public class NDIDStepRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public string InsertNDIDMasterStatus(UIDMapNDIDStatusModel obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@TransactionID", SqlDbType.NVarChar, 100) { Value = obj.TransactionID },
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = obj.UID },
                new SqlParameter("@Step1Status", SqlDbType.NVarChar, 5) { Value = obj.Step1Status },
                new SqlParameter("@Step1Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step1Remark },
                new SqlParameter("@Step2Status", SqlDbType.NVarChar, 5) { Value = obj.Step2Status },
                new SqlParameter("@Step2Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step2Remark },
                new SqlParameter("@Step3Status", SqlDbType.NVarChar, 5) { Value = obj.Step3Status },
                new SqlParameter("@Step3Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step3Remark },
                new SqlParameter("@Step4Status", SqlDbType.NVarChar, 5) { Value = obj.Step4Status },
                new SqlParameter("@Step4Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step4Remark },
                new SqlParameter("@Step5Status", SqlDbType.NVarChar, 5) { Value = obj.Step5Status },
                new SqlParameter("@Step5Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step5Remark },
                new SqlParameter("@Status", SqlDbType.Bit) { Value = obj.Status },
                new SqlParameter("@CurrentStausCode", SqlDbType.NVarChar, 5) { Value = obj.CurrentStausCode },
                new SqlParameter("@CurrentStatusRemark", SqlDbType.NVarChar, 4000) { Value = obj.CurrentStatusRemark },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy },
                new SqlParameter("@UpdatedBy", SqlDbType.NVarChar, 100) { Value = obj.UpdatedBy },
                new SqlParameter("@NDIDRequestID", SqlDbType.NVarChar, 100) { Value = obj.NDIDRequestID },
                new SqlParameter("@NDIDInitialSalt", SqlDbType.NVarChar, 100) { Value = obj.NDIDInitialSalt }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnStatus("proc_InsertUidMapNDID", parameters);
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUidMapNDID Error : " + ex, ref log4);
            }

            return dt;
        }

        public string UpdateNDIDMasterStatus(UIDMapNDIDStatusModel obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@TransactionID", SqlDbType.NVarChar, 100) { Value = obj.TransactionID },
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = obj.UID },
                new SqlParameter("@Step1Status", SqlDbType.NVarChar, 5) { Value = obj.Step1Status },
                new SqlParameter("@Step1Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step1Remark },
                new SqlParameter("@Step2Status", SqlDbType.NVarChar, 5) { Value = obj.Step2Status },
                new SqlParameter("@Step2Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step2Remark },
                new SqlParameter("@Step3Status", SqlDbType.NVarChar, 5) { Value = obj.Step3Status },
                new SqlParameter("@Step3Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step3Remark },
                new SqlParameter("@Step4Status", SqlDbType.NVarChar, 5) { Value = obj.Step4Status },
                new SqlParameter("@Step4Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step4Remark },
                new SqlParameter("@Step5Status", SqlDbType.NVarChar, 5) { Value = obj.Step5Status },
                new SqlParameter("@Step5Remark", SqlDbType.NVarChar, 4000) { Value = obj.Step5Remark },
                new SqlParameter("@Status", SqlDbType.Bit) { Value = obj.Status },
                new SqlParameter("@CurrentStausCode", SqlDbType.NVarChar, 5) { Value = obj.CurrentStausCode },
                new SqlParameter("@CurrentStatusRemark", SqlDbType.NVarChar, 4000) { Value = obj.CurrentStatusRemark },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy },
                new SqlParameter("@UpdatedBy", SqlDbType.NVarChar, 100) { Value = obj.UpdatedBy },
                new SqlParameter("@NDIDRequestID", SqlDbType.NVarChar, 100) { Value = obj.NDIDRequestID },
                new SqlParameter("@NDIDInitialSalt", SqlDbType.NVarChar, 100) { Value = obj.NDIDInitialSalt }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnStatus("proc_InsertUidMapNDID", parameters);
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUidMapNDID Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertCustomerChooseIDP(CustomerChooseIDPModel obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@TransactionID", SqlDbType.NVarChar, 100) { Value = obj.TransactionID },
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = obj.UID },
                new SqlParameter("@IDPVerifyStatus", SqlDbType.NVarChar, 5) { Value = obj.IDPVerifyStatus },
                new SqlParameter("@IDPVerifyRemark", SqlDbType.NVarChar, 4000) { Value = obj.IDPVerifyRemark },
                new SqlParameter("@IDPCode", SqlDbType.NVarChar, 10) { Value = obj.IDPCode },
                new SqlParameter("@IDPName", SqlDbType.NVarChar, 4000) { Value = obj.IDPName },
                new SqlParameter("@Status", SqlDbType.Bit) { Value = obj.Status },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy },
                new SqlParameter("@UpdatedBy", SqlDbType.NVarChar, 100) { Value = obj.UpdatedBy }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnStatus("proc_InsertCustomerChooseIDP", parameters);
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertCustomerChooseIDP Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertCustomerConsentNCB(CustomerConsentNCBModel obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@TransactionID", SqlDbType.NVarChar, 100) { Value = obj.TransactionID },
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = obj.UID },
                new SqlParameter("@NCBConsent1Status", SqlDbType.NVarChar, 5) { Value = obj.NCBConsent1Status },
                new SqlParameter("@NCBConsent1Remark", SqlDbType.NVarChar, 4000) { Value = obj.NCBConsent1Remark },
                new SqlParameter("@Status", SqlDbType.Bit) { Value = obj.Status },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy },
                new SqlParameter("@UpdatedBy", SqlDbType.NVarChar, 100) { Value = obj.UpdatedBy }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnStatus("proc_InsertCustomerConsentNCB", parameters);
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertCustomerConsentNCB Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertCustomerConsentNDID(CustomerConsentNDIDModel obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@TransactionID", SqlDbType.NVarChar, 100) { Value = obj.TransactionID },
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = obj.UID },
                new SqlParameter("@NDIDConsent1Status", SqlDbType.NVarChar, 5) { Value = obj.NDIDConsent1Status },
                new SqlParameter("@NDIDConsent1Remark", SqlDbType.NVarChar, 4000) { Value = obj.NDIDConsent1Remark },
                new SqlParameter("@Status", SqlDbType.Bit) { Value = obj.Status },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy },
                new SqlParameter("@UpdatedBy", SqlDbType.NVarChar, 100) { Value = obj.UpdatedBy }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnStatus("proc_InsertCustomerConsentNDID", parameters);
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertCustomerConsentNDID Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable InsertNDIDRequest(NDIDRequestModel obj)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@TransactionID", SqlDbType.NVarChar, 100) { Value = obj.TransactionID },
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = obj.UID },
                new SqlParameter("@RequestURL", SqlDbType.NVarChar, 5) { Value = obj.RequestURL },
                new SqlParameter("@RequestHeader", SqlDbType.NVarChar, 4000) { Value = obj.RequestHeader },
                new SqlParameter("@RequestBody", SqlDbType.NVarChar, 5) { Value = obj.RequestBody },
                new SqlParameter("@RawParameterInput", SqlDbType.NVarChar, 4000) { Value = obj.RawParameterInput },
                new SqlParameter("@ResponseStatus", SqlDbType.NVarChar, 5) { Value = obj.ResponseStatus },
                new SqlParameter("@ResponseBody", SqlDbType.NVarChar, 4000) { Value = obj.ResponseBody },
                new SqlParameter("@NDIDRequestID", SqlDbType.NVarChar, 5) { Value = obj.NDIDRequestID },
                new SqlParameter("@NDIDInitialSalt", SqlDbType.NVarChar, 4000) { Value = obj.NDIDInitialSalt },
                new SqlParameter("@Status", SqlDbType.NVarChar, 5) { Value = obj.Status },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 4000) { Value = obj.CreatedBy },
                new SqlParameter("@UpdatedBy", SqlDbType.NVarChar, 1) { Value = obj.UpdatedBy },
                new SqlParameter("@ResponseCode", SqlDbType.NVarChar, 5) { Value = obj.ResponseCode }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_InsertNDIDRequest", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertNDIDRequest Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}