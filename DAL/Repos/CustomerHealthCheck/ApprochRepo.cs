using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.CustomerHealthModel;
using log4net;

namespace DAL.Repos.CustomerHealthCheck
{
    public class ApprochRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetUIDMapApproch(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapApproch", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDMapApproch Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetUIDMapApprochByApprochID(string approchID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@ApprochID", SqlDbType.VarChar, 100) { Value = approchID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapApprochAll", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDMapApproch Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetUIDMapApprochByUIDAndPCode(string UID, string PCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@PCODE", SqlDbType.VarChar, 100) { Value = PCode }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapApproch", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDMapApproch Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetUIDMapApprochByUIDAndPCode(string UID, string pid, string hcid)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@PCODE", SqlDbType.VarChar, 100) { Value = pid },
                new SqlParameter("@REGISTERINFOID", SqlDbType.VarChar, 100) { Value = hcid }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapApproch", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDMapApproch Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable InsertUIDMapApproch(UIDMapApprochModel obj)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = obj.UID },
                new SqlParameter("@ApprochBody", SqlDbType.NVarChar) { Value = obj.ApprochBody },
                new SqlParameter("@ProductCode", SqlDbType.VarChar, 10) { Value = obj.ProductCode },
                new SqlParameter("@RegisterInfoID", SqlDbType.VarChar, 10) { Value = obj.RegisterInfoID },
                new SqlParameter("@RegisterYear", SqlDbType.VarChar, 10) { Value = obj.RegisterYear },
                new SqlParameter("@CreatedBy", SqlDbType.VarChar, 10) { Value = obj.Createby }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("InsertUIDMapApproch", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable InsertApprochMapBank(ApprochMapBankModel obj)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@ApprochID", SqlDbType.VarChar, 50) { Value = obj.ApprochID },
                new SqlParameter("@BankCode", SqlDbType.VarChar, 10) { Value = obj.BankCode },
                new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50) { Value = obj.CreatedBy },
                new SqlParameter("@ApprochBody", SqlDbType.NVarChar) { Value = obj.ApprochBody }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("InsertApprochMapBank", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}