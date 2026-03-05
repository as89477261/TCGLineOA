using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.SMEClinic;
using log4net;

namespace DAL.Repos.SMEClinic
{
    public class ConsentRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetConsentByUID(string UID)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetConsentByUID", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetTitleName Error : " + ex, ref log4);
            }

            return dt;
        }


        public string UpdateUIDConsentWiteConsentStatus(UIDConsentModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@Uid", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.Uid) ? "" : obj.Uid },
                new SqlParameter("@Consent1", SqlDbType.VarChar, 1) { Value = obj.Consent1 },
                new SqlParameter("@Consent2", SqlDbType.VarChar, 1) { Value = obj.Consent2 },
                new SqlParameter("@Consent3", SqlDbType.VarChar, 1) { Value = obj.Consent3 }
            };

            try
            {
                customerCode = DB_SMEClinic.executeStoredProcedureScalar("proc_UpdateConsent_ConsentStatus", parameters)
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("UpdateUIDConsentWiteConsentStatus() Error : " + ex, ref log4);
            }

            return customerCode;
        }

        public string UpdateConsentPdpaStatus (UIDConsentModel obj)
        {
            var result = string.Empty;

			SqlParameter[] parameters =
{
                /* from user input */
                new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = string.IsNullOrEmpty(obj.Uid) ? "" : obj.Uid},
                new SqlParameter("@IsPdpa", SqlDbType.VarChar, 1) {Value = obj.IsPdpa}
			};
            try
            {
                result = DB_SMEClinic.executeStoredProcedureScalar("proc_UpdateConsent_PdpaStatus", parameters).ToString();
			}
			catch (Exception ex)
			{
				LogUtility.writeLog("proc_UpdateConsent_PdpaStatus() Error : " + ex, ref log4);
			}

            return result.Trim();
		}


		public string UpdateUIDConsentWiteCustomerProfile(UIDConsentModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@Uid", SqlDbType.VarChar, 100)
                    { Value = string.IsNullOrEmpty(obj.Uid) ? "" : obj.Uid },
                new SqlParameter("@CustomerProfile_Code", SqlDbType.VarChar, 1) { Value = obj.CustomerProfile_Code }
            };
            try
            {
                customerCode = DB_SMEClinic
                    .executeStoredProcedureScalar("proc_UpdateConsent_CustomerProfile", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("UpdateUIDConsentWiteCustomerProfile() Error : " + ex, ref log4);
            }

            return customerCode;
        }
    }
}