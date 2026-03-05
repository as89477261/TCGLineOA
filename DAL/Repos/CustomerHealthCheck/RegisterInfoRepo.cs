using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL.Repos.CustomerHealthCheck
{
    public class RegisterInfoRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetRegisInfoByUID(string UID, string count)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@Count", SqlDbType.VarChar, 10) { Value = count },
                new SqlParameter("@RegisterInfoID", SqlDbType.VarChar, 10) { Value = "" },
                new SqlParameter("@Type", SqlDbType.VarChar, 10) { Value = "" }
            };

            try
            {
                LocalLogManager.Logger("Prepare insert uidmap register Call : GetUIDMapRegister");
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRegister", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.Message);
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetRegisInfoByUIDWithType(string UID, string count, string infoType, string subInfoType)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@Count", SqlDbType.VarChar, 10) { Value = count },
                new SqlParameter("@RegisterInfoID", SqlDbType.VarChar, 10) { Value = "" },
                new SqlParameter("@InfoType", SqlDbType.NVarChar, 50) { Value = infoType },
                new SqlParameter("@SubInfoType", SqlDbType.NVarChar, 50) { Value = subInfoType },
                new SqlParameter("@IsHasCustomerProfile", SqlDbType.NVarChar,50){ Value = "Y"}
            };

            try
            {
                LocalLogManager.Logger("Prepare insert uidmap register Call : GetUIDMapRegister");
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRegister", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.Message);
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetRegisInfoStatusByUIDWithType(string UID, string count, string RegisterInfoID,
            string clinicRequestNo, string infoType, string subInfoType)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@Count", SqlDbType.VarChar, 10) { Value = count },
                new SqlParameter("@RegisterInfoID", SqlDbType.VarChar, 10) { Value = RegisterInfoID },
                new SqlParameter("@ClinicRequestNo", SqlDbType.VarChar, 10) { Value = clinicRequestNo },
                new SqlParameter("@InfoType", SqlDbType.NVarChar, 50) { Value = infoType },
                new SqlParameter("@SubInfoType", SqlDbType.NVarChar, 50) { Value = subInfoType }
            };

            try
            {
                LocalLogManager.Logger("Prepare insert uidmap register Call : GetUIDMapRegisterStatus");
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRegisterStatus", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.Message);
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetTop5RegisInfoByUID(string UID, string count)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@Count", SqlDbType.VarChar, 10) { Value = count },
                new SqlParameter("@RegisterInfoID", SqlDbType.VarChar, 10) { Value = "" },
                new SqlParameter("@Type", SqlDbType.VarChar, 10) { Value = "" }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRegister", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetRegisInfoByType(string uid, string type, string isHasCustomerProfile = "",
            string count = "0")
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = uid },
                new SqlParameter("@Count", SqlDbType.VarChar, 10) { Value = count },
                new SqlParameter("@IsHasCustomerProfile", SqlDbType.VarChar, 10) { Value = isHasCustomerProfile },
                new SqlParameter("@RegisterInfoID", SqlDbType.VarChar, 10) { Value = "" },
                new SqlParameter("@Type", SqlDbType.VarChar, 10) { Value = type }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRegister", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetRegisInfoByRegisID(string regisInfoID, string count = "1")
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = "" },
                new SqlParameter("@Count", SqlDbType.VarChar, 10) { Value = count },
                new SqlParameter("@RegisterInfoID", SqlDbType.VarChar, 10) { Value = regisInfoID },
                new SqlParameter("@Type", SqlDbType.VarChar, 10) { Value = "" }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRegister", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetRegisInfoStatusByIDCardWithType(string IDCard, string infoType, string subInfoType)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@IDCard", SqlDbType.VarChar, 100) { Value = IDCard },
                new SqlParameter("@Count", SqlDbType.VarChar, 10) { Value = 1000 },
                new SqlParameter("@InfoType", SqlDbType.NVarChar, 50) { Value = infoType },
                new SqlParameter("@SubInfoType", SqlDbType.NVarChar, 50) { Value = subInfoType }
            };

            try
            {
                LocalLogManager.Logger("Prepare insert uidmap register Call : GetUIDMapRegisterStatus");
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRegisterStatus", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.Message);
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}