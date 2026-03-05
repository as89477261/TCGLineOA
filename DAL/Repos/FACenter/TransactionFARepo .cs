using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL.FACenter
{
    public class TransactionFARepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_FACenter = new Database(Database.DBName.DB_FACenter);


        public DataTable GetFATransections(string transID)
        {
            DataTable dt = null;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("Id", transID));

                dt = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetFA_Transections", list.ToArray())
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetFA_Transections Error : " + ex, ref log4);
            }

            return dt;
        }

        public string UpdateFA_Transections_Dept(int FA_Id, int ConsultantId, string FA_Ref, string LG,
            int SystemStatusId)
        {
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("FA_Id", FA_Id));
                list.Add(new SqlParameter("ConsultantId", ConsultantId));
                list.Add(new SqlParameter("FA_Ref", FA_Ref));
                list.Add(new SqlParameter("LG", LG));
                list.Add(new SqlParameter("SystemStatusId", SystemStatusId));
                var result =
                    DB_FACenter.executeStoredProcedureScalar("proc_UpdateFA_Transections_Dept", list.ToArray());
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_UpdateFA_Transections_Dept Error : " + ex, ref log4);
            }

            return null;
        }
    }
}