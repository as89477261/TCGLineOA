using DataModel.Models.FACenter;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using DataModels.FACenter;
using System.Web.UI.WebControls.WebParts;

namespace DAL.Repos.FACenter
{
    public class UidMapDIPROMRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_FACenter = new Database(Database.DBName.DB_FACenter);

        public DataSet InsertUIDMapDIPROM(UIDMapDIPROMModel obj)
        {
            var result = new DataSet();
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@Uid", obj.Uid));
                list.Add(new SqlParameter("@EventCode", obj.EventCode));
                list.Add(new SqlParameter("@EventName", obj.EventName));
                list.Add(new SqlParameter("@IdentityCard", obj.IdentityCard));
                list.Add(new SqlParameter("@Status", obj.Status));
                list.Add(new SqlParameter("@IsAcceptConsent", obj.IsAcceptConsent));
                list.Add(new SqlParameter("@IsPartnerData", obj.IsPartnerData));
                list.Add(new SqlParameter("@IsPartnerKey", obj.IsPartnerKey));
                list.Add(new SqlParameter("@OtpDummyID", obj.OtpDummyId));
                list.Add(new SqlParameter("@IsRegisterSuccess", obj.IsRegisterSuccess));

                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_InsertUIDMapDIPROM ", list.ToArray());
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUIDMapDIPROM Error : " + ex, ref log4);
            }
            return result;
        }

        public string UpdateUIDMapDIPROM(Request_UIDMapDIPROMModel obj)
        {
            var result = string.Empty;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", SqlDbType.NVarChar, 100) { Value = obj.Id.ToString() },
                new SqlParameter("@Uid", SqlDbType.NVarChar, 100) { Value = obj.Uid },
                new SqlParameter("@OtpDummyID", obj.OtpDummyID) { Value = obj.OtpDummyID },
                new SqlParameter("@IsRegisterSuccess", obj.IsRegisterSuccess) { Value = obj.IsRegisterSuccess}
            };
            try
            {

                result = DB_FACenter
                    .ExecuteCommandTextReturnDataSet("proc_UpdateUIDMapDIPROM", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_UpdateUIDMapDept Error : " + ex, ref log4);
            }

            return result;
        }

        public DataSet UpdateReturnDataSetUIDMapDIPROM (Request_UIDMapDIPROMModel obj)
        {
            var result = new DataSet();
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@Id", obj.Id.ToString()));
                list.Add(new SqlParameter("Uid", obj.Uid));
                list.Add(new SqlParameter("@OtpDummyID", obj.OtpDummyID));
                list.Add(new SqlParameter("@IsRegisterSuccess", obj.IsRegisterSuccess));

                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_UpdateUIDMapDIPROM ", list.ToArray());
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_UpdateUIDMapDIPROM Error : " + ex, ref log4);
            }
            return result;
        }

        public DataTable GetUIDMapDIPROM(string uid, string eventCode , string identityId)
        {
            DataTable result = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 50){ Value = uid },
                new SqlParameter("@EventCode", SqlDbType.VarChar,10){Value = eventCode},
                new SqlParameter("@IdentityId", SqlDbType.VarChar,100){Value = identityId}
            };

            try
            {
                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapDIRPOM", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetUIDMapDept Error : " + ex, ref log4);
            }
            return result;
        }

        public DataTable GetProfileDiprom(string uid)
        {
            DataTable result = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 50){ Value = uid }
            };
            try
            {
                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetProfileDiprom", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetProfileDiprom Error : " + ex, ref log4);
            }
            return result;
        }
        public DataTable GetCheckUIDMapDIPROM(string identityId)
        {
            DataTable result = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@IdentityId", SqlDbType.VarChar,100){Value = identityId}
            };

            try
            {
                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetUIDMapDIRPOM", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetUIDMapDept Error : " + ex, ref log4);
            }
            return result;
        }
        public DataTable UpdateReturnDataSetLineScreeningImportRequest(int ID)
        {
            DataTable result = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@ID", SqlDbType.Int){Value = ID}
            };

            try
            {
                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_UpdateLineScreeningImportRequest", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetUIDMapDept Error : " + ex, ref log4);
            }
            return result;
        }

        public string InsertDipromTransaction(FormRegisterFAInfo obj, int ConsultantId)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("ApplicationId", obj.ApplicationId < 0 ? 1 : obj.ApplicationId));
                list.Add(new SqlParameter("CustomerProfileId", obj.CustomerProfileId));
                list.Add(new SqlParameter("ConsultantId", ConsultantId));
                list.Add(new SqlParameter("RequestTitle_Id", obj.RequestTitle_Id));
                list.Add(new SqlParameter("RequestTitle_Another", obj.RequestTitle_Another));
                list.Add(new SqlParameter("FA_Ref", obj.FA_Ref));
                list.Add(new SqlParameter("ChannelId", 2));
                list.Add(new SqlParameter("InputChannel", 5)); //FA ต้องการแยก Channal แหล่งที่มาให้ชัดเจน พี่รันแจ้งปรับเป็น InputChannel = 5 
                list.Add(new SqlParameter("CurrentStatusId", obj.CurrentStatusId));
                result = DB_FACenter.executeStoredProcedureScalar("proc_InsertFA_Transections", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertFA_Transections Error : " + ex, ref log4);
            }

            return result;
        }

        public string InsertDipromFormRegister(FormRegisterFAInfo reg)
        {
            var result = string.Empty;
            try
            {

                var list = new List<SqlParameter>();

                list.Add(new SqlParameter("@FA_TransectionsId", reg.FA_TransectionsId));
                //list.Add(new SqlParameter("IsDept_Recon", true));
                list.Add(new SqlParameter("@RequestRemark", reg.RequestRemark));
                //list.Add(new SqlParameter("Dept_Recon_ObjectId", reg.Dept_Recon_ObjectId));
                //list.Add(new SqlParameter("Dept_Recon_Money", reg.Dept_Recon_Money));
                //list.Add(new SqlParameter("Dept_Recon_LG", reg.Dept_Recon_LG));
                list.Add(new SqlParameter("@CreateBy", reg.CreateBy));
                list.Add(new SqlParameter("@IsActive", true));
                //New Parameter
                list.Add(new SqlParameter("@IsLoanMoney", reg.IsLoanMoney));
                list.Add(new SqlParameter("@LoanMoney", reg.LoanMoney));
                list.Add(new SqlParameter("@ObjectiveId", reg.ObjectiveId));
                list.Add(new SqlParameter("@Objective_Remark", reg.Objective_Remark));
                list.Add(new SqlParameter("@InterestLoanOfBank", reg.InterestLoanOfBank));

                result = DB_FACenter.executeStoredProcedureScalar("proc_InsertForm_Register_Diprom", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertForm_Register_Dept Error : " + ex, ref log4);
            }

            return result;
        }

        public DataSet UpdateTransConsultFA(UpdateTransConsultFA obj)
        {
            var result = new DataSet();

            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@Id", obj.Id.ToString()));
                list.Add(new SqlParameter("Uid", obj.Uid));
                list.Add(new SqlParameter("@IsContactClinic", obj.IsContactClinic));
                list.Add(new SqlParameter("@TransContactClinic", obj.TransContactClinic));
                list.Add(new SqlParameter("@IsContactFA", obj.IsContactFA));
                list.Add(new SqlParameter("@TransContactFA", obj.TransContactFA));

                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_UpdateUIDMapDiprom_Consult", list.ToArray());
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_UpdateUIDMapDept Error : " + ex, ref log4);
            }
            return result;
        }

        public DataTable GetImport(string uid , string identityId)
        {
            DataTable result = null;

            // identityId = "3740238002347";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar, 100){ Value = uid },
                new SqlParameter("@identityId", SqlDbType.VarChar, 100){ Value = identityId}
            };

            try
            {
                result = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetDipromImportRequest", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetUIDMapDept Error : " + ex, ref log4);
            }
            return result;
        }

    }
}
