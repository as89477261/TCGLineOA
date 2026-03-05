using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.FACenter;
using log4net;

namespace DAL.FACenter
{
    public class UIDMapFAEventRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_FACenter = new Database(Database.DBName.DB_FACenter);

        public DataTable GetUIDMapFAEvent(string UID, string eventCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@EventCode", SqlDbType.VarChar, 100) { Value = eventCode }
            };

            try
            {
                dt = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapFAEvent", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetUIDMapFAEvent Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertUIDMapFAEvent(UIDMapFAEventModel obj)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@UID", obj.UID));
                list.Add(new SqlParameter("@EventCode", obj.EventCode));
                list.Add(new SqlParameter("@IDCard", obj.IDCard));
                list.Add(new SqlParameter("@CreateBy", obj.CreatedBy));

                result = DB_FACenter.executeStoredProcedureScalar("proc_InsertUIDMapFAEvent", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUIDMapFAEvent Error : " + ex, ref log4);
            }

            return result;
        }
    }
}