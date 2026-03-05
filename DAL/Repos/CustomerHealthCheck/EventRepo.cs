using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.CustomerHealthModel.EventsModel;
using log4net;

namespace DAL.Repos.CustomerHealthCheck
{
    public class EventRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetUIDRegisterPartner(string UID, string Status)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@Status", SqlDbType.VarChar, 100) { Value = Status }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDRegisterPartner", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetEvents()
        {
            DataTable dt = null;
            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetEvents").Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetEvents Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetEventByID(string EventCode)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@EventCode", SqlDbType.VarChar, 100) { Value = EventCode }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetEvents", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetEvents Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetEventByType(string EventType)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Type", SqlDbType.VarChar, 100) { Value = EventType }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetEvents", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetEvents Error : " + ex, ref log4);
            }

            return dt;
        }

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
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapRegister", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetFormRegisterWithGroupAndUID(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapEventRegister", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDMapEventRegister Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetFormRegisterWithGroupAndUID(string eventCode, string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = UID },
                new SqlParameter("@EventCode", SqlDbType.VarChar, 100) { Value = eventCode }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetUIDMapEventRegister", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDMapEventRegister Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertFormEventRegister(FormEventRegisterInputModel reg)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@UID", reg.UID));
                list.Add(new SqlParameter("@BusinessType", reg.BusinessType));
                list.Add(new SqlParameter("@CompanyName", reg.BusinessName));
                list.Add(new SqlParameter("@FirstName", reg.FirstName));
                list.Add(new SqlParameter("@LastName", reg.LastName));
                list.Add(new SqlParameter("@Position", reg.Position));
                list.Add(new SqlParameter("@Phone", reg.Phone));
                list.Add(new SqlParameter("@Email", reg.Email));
                list.Add(new SqlParameter("@Q1", reg.BusinessNature));
                list.Add(new SqlParameter("@Q2", reg.BusinessProvince));
                list.Add(new SqlParameter("@Q3", reg.CompanyAge));
                list.Add(new SqlParameter("@Q4", reg.IncomePerYear));
                list.Add(new SqlParameter("@Q5", reg.StatementBank));
                list.Add(new SqlParameter("@Q6", reg.Branch));
                list.Add(new SqlParameter("@Q7", reg.Purpose));
                list.Add(new SqlParameter("@Q8", reg.LoanMoney));
                list.Add(new SqlParameter("@Q9", reg.HaveMainBank));
                list.Add(new SqlParameter("@Q10", reg.HaveMainBankSelectBank));
                list.Add(new SqlParameter("@Q11", reg.HaveAssetGarantee));
                list.Add(new SqlParameter("@Q12", reg.HaveAssetGaranteeValue));
                list.Add(new SqlParameter("@Q13", reg.PurpostFromBank));
                list.Add(new SqlParameter("@EventCode", reg.EventCode));

                result = DB_CustomerHealthCheck.executeStoredProcedureScalar("InsertFormRegisterEvent", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertFormRegisterEvent Error : " + ex, ref log4);
            }

            return result;
        }

        public string InsertFormEventRegisterDynamic(FormEventRegisterDynamicInputModel reg)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@UID", reg.UID));
                list.Add(new SqlParameter("@BusinessType", reg.BusinessType));
                list.Add(new SqlParameter("@CompanyName", reg.BusinessName));
                list.Add(new SqlParameter("@FirstName", reg.FirstName));
                list.Add(new SqlParameter("@LastName", reg.LastName));
                list.Add(new SqlParameter("@Position", reg.Position));
                list.Add(new SqlParameter("@Phone", reg.Phone));
                list.Add(new SqlParameter("@Email", reg.Email));
                list.Add(new SqlParameter("@Q1", reg.Q1));
                list.Add(new SqlParameter("@Q2", reg.Q2));
                list.Add(new SqlParameter("@Q3", reg.Q3));
                list.Add(new SqlParameter("@Q4", reg.Q4));
                list.Add(new SqlParameter("@Q5", reg.Q5));
                list.Add(new SqlParameter("@Q6", reg.Q6));
                list.Add(new SqlParameter("@Q7", reg.Q7));
                list.Add(new SqlParameter("@Q8", reg.Q8));
                list.Add(new SqlParameter("@Q9", reg.Q9));
                list.Add(new SqlParameter("@Q10", reg.Q10));
                list.Add(new SqlParameter("@Q11", reg.Q11));
                list.Add(new SqlParameter("@Q12", reg.Q12));
                list.Add(new SqlParameter("@Q13", reg.Q13));
                list.Add(new SqlParameter("@Q14", reg.Q14));
                list.Add(new SqlParameter("@Q15", reg.Q15));
                list.Add(new SqlParameter("@Q16", reg.Q16));
                list.Add(new SqlParameter("@Q17", reg.Q17));
                list.Add(new SqlParameter("@Q18", reg.Q18));
                list.Add(new SqlParameter("@Q19", reg.Q19));
                list.Add(new SqlParameter("@Q20", reg.Q20));
                list.Add(new SqlParameter("@EventCode", reg.EventCode));

                result = DB_CustomerHealthCheck.executeStoredProcedureScalar("InsertFormRegisterEvent", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertFormRegisterEvent Error : " + ex, ref log4);
            }

            return result;
        }
    }
}