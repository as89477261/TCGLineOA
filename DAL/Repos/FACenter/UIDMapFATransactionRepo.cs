using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.FACenter;
using log4net;

namespace DAL.FACenter
{
    public class UIDMapFATransactionRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_FACenter = new Database(Database.DBName.DB_FACenter);

        public DataTable GetUIDMapTransAndFormByID(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapTransAndForm", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetUIDMapTransAndForm Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertUIDMapTransaction(UIDMapTransactionModel obj)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@UID", obj.UID));
                list.Add(new SqlParameter("@TransactionID", obj.TransactionID));

                result = DB_FACenter.executeStoredProcedureScalar("proc_InsertUIDMapTransaction", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertFA_Transections Error : " + ex, ref log4);
            }

            return result;
        }
    }
}