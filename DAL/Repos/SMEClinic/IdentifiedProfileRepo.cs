using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.SMEClinic;
using log4net;

namespace DAL.Repos.SMEClinic
{
    public class IdentifiedProfileRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private readonly Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public DataTable GetIdentifiedProfileAll()
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                //new SqlParameter("@Uid", SqlDbType.VarChar, 100) { Value = UID  }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetIdentifiedProfile", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetIdentifiedProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetIdentifiedProfileByUID(string uid)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 100) { Value = uid }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetIdentifiedProfile", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetIdentifiedProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public DataTable GetIdentifiedProfileByID(string id)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@ID", SqlDbType.VarChar, 100) { Value = id }
            };

            try
            {
                dt = DB_SMEClinic.ExecuteStoredProcedureReturnDataSet("proc_GetIdentifiedProfile", parameters)
                    .Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("GetIdentifiedProfile Error : " + ex, ref log4);
            }

            return dt;
        }

        public string InsertIdentifiedProfile(IdentifiedProfileModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@UID", SqlDbType.NVarChar, 200)
                    { Value = string.IsNullOrEmpty(obj.UID) ? "" : obj.UID },
                new SqlParameter("@BinaryImg1", SqlDbType.NVarChar) { Value = obj.BinaryImg1 },
                new SqlParameter("@BinaryImg2", SqlDbType.NVarChar) { Value = obj.BinaryImg2 },
                new SqlParameter("@BinaryImg3", SqlDbType.NVarChar) { Value = obj.BinaryImg3 }
            };

            try
            {
                customerCode = DB_SMEClinic
                    .executeStoredProcedureScalar("proc_InsertIdentifiedProfileStep1", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertIdentifiedProfileStep1() Error : " + ex, ref log4);
            }

            return customerCode;
        }

        public string UpdateIdentifiedProfileStep1(IdentifiedProfileModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@ID", SqlDbType.VarChar, 100) { Value = string.IsNullOrEmpty(obj.ID) ? "" : obj.ID }
            };

            try
            {
                customerCode = DB_SMEClinic
                    .executeStoredProcedureScalar("proc_UpdateIdentifiedProfileStep1", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("UpdateIdentifiedProfileStep1() Error : " + ex, ref log4);
            }

            return customerCode;
        }

        public string UpdateIdentifiedProfileStep2(IdentifiedProfileModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@ID", SqlDbType.VarChar, 100) { Value = string.IsNullOrEmpty(obj.ID) ? "" : obj.ID },

                new SqlParameter("@PIDCard", SqlDbType.NVarChar) { Value = obj.PIDCard },
                new SqlParameter("@PFirstNameThai", SqlDbType.NVarChar) { Value = obj.PFirstNameThai },
                new SqlParameter("@PFirstNameEng", SqlDbType.NVarChar) { Value = obj.PFirstNameEng },
                new SqlParameter("@PLastNameThai", SqlDbType.NVarChar) { Value = obj.PLastNameThai },
                new SqlParameter("@PLastNameEng", SqlDbType.NVarChar) { Value = obj.PLastNameEng },
                new SqlParameter("@PFullNameThai", SqlDbType.NVarChar) { Value = obj.PFullNameThai },
                new SqlParameter("@PFullNameEng", SqlDbType.NVarChar) { Value = obj.PFullNameEng },
                new SqlParameter("@PBirthDate", SqlDbType.NVarChar) { Value = obj.PBirthDate },
                new SqlParameter("@PRegion", SqlDbType.NVarChar) { Value = obj.PRegion },
                new SqlParameter("@PAddress", SqlDbType.NVarChar) { Value = obj.PAddress },
                new SqlParameter("@PStartDateThai", SqlDbType.NVarChar) { Value = obj.PStartDateThai },
                new SqlParameter("@PEndDateThai", SqlDbType.NVarChar) { Value = obj.PEndDateThai },
                new SqlParameter("@PStartDateEng", SqlDbType.NVarChar) { Value = obj.PStartDateEng },
                new SqlParameter("@PEndDateEng", SqlDbType.NVarChar) { Value = obj.PEndDateEng },
                new SqlParameter("@PRawData", SqlDbType.NVarChar) { Value = obj.PRawData }
            };

            try
            {
                customerCode = DB_SMEClinic
                    .executeStoredProcedureScalar("proc_UpdateIdentifiedProfileStep2", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("UpdateIdentifiedProfileStep2() Error : " + ex, ref log4);
            }

            return customerCode;
        }

        public string UpdateIdentifiedProfileStep3_SendOTP(IdentifiedProfileModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@ID", SqlDbType.VarChar, 100) { Value = string.IsNullOrEmpty(obj.ID) ? "" : obj.ID },
                new SqlParameter("@OTPSend", SqlDbType.NVarChar) { Value = obj.OTPSend }
            };

            try
            {
                customerCode = DB_SMEClinic
                    .executeStoredProcedureScalar("proc_UpdateIdentifiedProfileStep3_SendOTP", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("UpdateIdentifiedProfileStep3_SendOTP() Error : " + ex, ref log4);
            }

            return customerCode;
        }

        public string UpdateIdentifiedProfileStep3_ReceiveOTP(IdentifiedProfileModel obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                /* from user input */
                new SqlParameter("@ID", SqlDbType.VarChar, 100) { Value = string.IsNullOrEmpty(obj.ID) ? "" : obj.ID },
                new SqlParameter("@OTPReceive", SqlDbType.NVarChar) { Value = obj.OTPSend }
            };

            try
            {
                customerCode = DB_SMEClinic
                    .executeStoredProcedureScalar("proc_UpdateIdentifiedProfileStep3_ReceiveOTP", parameters)
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("UpdateIdentifiedProfileStep3_ReceiveOTP() Error : " + ex, ref log4);
            }

            return customerCode;
        }
    }
}