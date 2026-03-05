using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using DataModel.Models.Line;
using log4net;

namespace DAL.Repos
{
    public class UIDRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetUID()
        {
            DataTable dt = null;

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetProvince").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetProvince Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetUIDByUID(string uid)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = string.IsNullOrEmpty(uid) }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetUIDLineProfile", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetProvince Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetExistingUID()
        {
            DataTable dt = null;

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetProvince").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetProvince Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertUIDAndDummyConsent(LineRawTokenModel obj)
        {
            var UID = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@Uid", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.sub) ? "" : obj.sub },
                new SqlParameter("@Amr", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.amr) ? "" : obj.amr },
                new SqlParameter("@Aud", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.aud) ? "" : obj.aud },
                new SqlParameter("@Email", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.email) ? "" : obj.email },
                new SqlParameter("@Exp", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.exp) ? "" : obj.exp },
                new SqlParameter("@Iat", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.iat) ? "" : obj.iat },
                new SqlParameter("@Iss", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.iss) ? "" : obj.iss },
                new SqlParameter("@Name", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.name) ? "" : obj.name },
                new SqlParameter("@Nonce", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.nonce) ? "" : obj.nonce },
                new SqlParameter("@Picture", SqlDbType.VarChar, -1)
                    { Value = string.IsNullOrEmpty(obj.picture) ? "" : obj.picture },

                new SqlParameter("@Uid_Channel", SqlDbType.VarChar, 100) { Value = "LINEOA" }
            };

            try
            {
                UID = DB_SMEClinic.executeStoredProcedureScalar("proc_InsertUid", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertUID() Error : " + ex, ref log4);
            }

            return UID;
        }

        public string DeleteDataByUID(string uid)
        {
            var UID = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = uid }
            };

            try
            {
                UID = DB_CustomerHealthCheck.executeStoredProcedureScalar("UpdateResetData", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertUID() Error : " + ex, ref log4);
            }

            return UID;
        }
    }
}