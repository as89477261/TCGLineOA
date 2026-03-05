using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL.Repos.NDIDInfo
{
    public class NDIDPersonalRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetNDIDPersonalAll()
        {
            DataTable dt = null;

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetNDIDPersonal").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetProduct Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetNDIDPersonalByID(string ID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = ID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetNDIDPersonal", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetProduct Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetNDIDPersonalByRequestID(string reqID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@RequestID", SqlDbType.NVarChar, 100) { Value = reqID }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetNDIDRawData", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetNDIDRawData Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetNDIDEFormPersonalByReferenceID(string refID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@RequestID", SqlDbType.NVarChar, 100) { Value = refID }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetNDIDRawData", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetNDIDRawData Error : " + ex, ref log4);
            }

            return dt;
        }
    }
}