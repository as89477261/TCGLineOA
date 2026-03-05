using DataModel.Models.FACenter;
using DataModel.Models.SMEClinic;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;


namespace DAL.Repos.FACenter
{
    public class UidMapFADeptRepo
    {

        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_FACenter = new Database(Database.DBName.DB_FACenter);


        public DataTable GetUIDMapDept(string uid , string eventCode)
        {
            DataTable result = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 50){ Value = uid },
                new SqlParameter("EventCode", SqlDbType.VarChar,10){Value = eventCode}
            }; 

            try
            {
                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapDept", parameters).Tables[0]; 
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetUIDMapDept Error : " + ex, ref log4);
            }
            return result;
        }

        public DataSet InsertUIDMapDept(UIDMapDeptModel obj)
        {
            var result = new DataSet();
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@Uid" , obj.Uid));
                list.Add(new SqlParameter("@EventCode", obj.EventCode));
                list.Add(new SqlParameter("@EventName", obj.EventName));
                list.Add(new SqlParameter("@IdentityCard", obj.IdentityCard));
                list.Add(new SqlParameter("@Status", obj.Status));
                list.Add(new SqlParameter("@IsAcceptConsent", obj.IsAcceptConsent));
                list.Add(new SqlParameter("@IsDebtDCSEvent", obj.IsDebtDCSEvent));
                list.Add(new SqlParameter("@IsDebtDCS_Id", obj.IsDebtDCS_Id));
                list.Add(new SqlParameter("@DummyID", obj.DummyID));
                list.Add(new SqlParameter("@IsRegisterSuccess", obj.IsRegisterSuccess));

                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_InsertUIDMapDept", list.ToArray());
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUIDMapDept Error : " + ex, ref log4);
            }
            return result;
        }
        public string UpdateUidMapDebtTrans(UIDMapDeptModel obj)
        {
            var result = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */               
                new SqlParameter("@ID", SqlDbType.NVarChar, 100) { Value = obj.Id.ToString() } , 
                new SqlParameter("@Uid", SqlDbType.VarChar, 50) { Value = obj.Uid},
                new SqlParameter("@DummyID", SqlDbType.VarChar, 50) { Value = obj.DummyID},
                new SqlParameter("@IsRegisterSuccess", SqlDbType.Bit) { Value = true},
                new SqlParameter("@TransIDCompromise", SqlDbType.NVarChar, 100) { Value = obj.TransIDCompromise },
                new SqlParameter("@TransIDConsult", SqlDbType.NVarChar, 100) {Value = obj.TransIDConsult} 
        };

            try
            {
                result = DB_FACenter
                    .executeStoredProcedureScalar("proc_UpdateUIDMapDept", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_UpdateUIDMapDept Error : " + ex, ref log4);
            }

            return result;
        }
    }
}
