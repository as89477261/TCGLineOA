using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.SMEClinic;
using log4net;

namespace DAL.Repos
{
    public class CustomerProfileRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetCustomerProfileMapApproch(string CID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@CID", SqlDbType.VarChar, 100) { Value = CID }
            };

            try
            {
                dt = DB_CustomerHealthCheck
                    .ExecuteStoredProcedureReturnDataSet("GetCustomerProfileMapApproch", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetCustomerProfileMapApproch Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetCustomerProfileByUID(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapCustomerProfile", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetCustomerProfileByUID Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetUIDLineProfile(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetUIDLineProfile", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetUIDLineProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetCustomerProfileByCID(string CID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@CustomerCode", SqlDbType.VarChar, 100) { Value = CID }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetCustomerProfile", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetCustomerProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetCustomerProfileByCardID(string cardID, string cardType)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@IdCard", SqlDbType.VarChar, 100) { Value = cardID },
                new SqlParameter("@IdCardType", SqlDbType.VarChar, 100) { Value = cardType }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetCustomerProfile", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetCustomerProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetCustomerProfileHistoryByUID(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_SMEClinic
                    .ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapCustomerProfileHistory", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("GetCustomerProfileByUID : " + ex.GetBaseException().Message);
                LogUtility.writeLog("GetCustomerProfileByUID Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertCustomerProfile(CustomerProfileHistoryModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Code", SqlDbType.Int) { Value = obj.Code },
                new SqlParameter("@User_Create", SqlDbType.VarChar, 100) { Value = obj.CreateBy },
                new SqlParameter("@IdCardType", SqlDbType.VarChar, 5) { Value = obj.IdCardType },
                new SqlParameter("@IdCard", SqlDbType.VarChar, 20) { Value = obj.IdCard },
                new SqlParameter("@TitleName", SqlDbType.VarChar, 50) { Value = obj.TitleName },
                new SqlParameter("@TitleCode", SqlDbType.VarChar, 50) { Value = obj.TitleCode },
                new SqlParameter("@Name", SqlDbType.VarChar, 1000) { Value = obj.Name },
                new SqlParameter("@SureName", SqlDbType.VarChar, 1000) { Value = obj.SureName },
                new SqlParameter("@CompanyName", SqlDbType.VarChar, 1000) { Value = obj.CompanyName },
                new SqlParameter("@EmailAddress", SqlDbType.VarChar, 1000) { Value = obj.EmailAddress },
                new SqlParameter("@MobileNumber", SqlDbType.VarChar, 1000) { Value = obj.MobileNumber }
            };

            try
            {
                customerCode = DB_SMEClinic
                    .executeStoredProcedureScalar("proc_UpdateCustomerProfileHistory", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("UpdateCustomerProfileHistory() Error : " + ex, ref log4);
            }

            return customerCode;
        }

        public string UpdateCustomerProfileHistory(CustomerProfileHistoryModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Code", SqlDbType.Int) { Value = obj.Code },
                new SqlParameter("@User_Create", SqlDbType.VarChar, 100) { Value = obj.CreateBy },
                new SqlParameter("@IdCardType", SqlDbType.VarChar, 5) { Value = obj.IdCardType },
                new SqlParameter("@IdCard", SqlDbType.VarChar, 20) { Value = obj.IdCard },
                new SqlParameter("@TitleName", SqlDbType.VarChar, 50) { Value = obj.TitleName },
                new SqlParameter("@TitleCode", SqlDbType.VarChar, 50) { Value = obj.TitleCode },
                new SqlParameter("@Name", SqlDbType.VarChar, 1000) { Value = obj.Name },
                new SqlParameter("@SureName", SqlDbType.VarChar, 1000) { Value = obj.SureName },
                new SqlParameter("@CompanyName", SqlDbType.VarChar, 1000) { Value = obj.CompanyName },
                new SqlParameter("@EmailAddress", SqlDbType.VarChar, 1000) { Value = obj.EmailAddress },
                new SqlParameter("@MobileNumber", SqlDbType.VarChar, 1000) { Value = obj.MobileNumber }
            };

            try
            {
                customerCode = DB_SMEClinic
                    .executeStoredProcedureScalar("proc_UpdateCustomerProfileHistory", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("UpdateCustomerProfileHistory() Error : " + ex, ref log4);
            }

            return customerCode;
        }
    }
}