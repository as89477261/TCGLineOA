using DataModels.FACenter;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.FACenter
{
    public class DebtCompromiseRegisterFARepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_FACenter = new Database(Database.DBName.DB_FACenter);

        public string InsertFATransections(FormRegisterFAInfo obj, int ConsultantId)
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
                list.Add(new SqlParameter("InputChannel",5)); //FA ต้องการแยก Channal แหล่งที่มาให้ชัดเจน พี่รันแจ้งปรับเป็น InputChannel = 5 
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

        public string InsertFormRegister(FormRegisterFAInfo reg)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("FA_TransectionsId", reg.FA_TransectionsId));
                list.Add(new SqlParameter("IsDept_Recon", true));
                list.Add(new SqlParameter("RequestRemark", reg.RequestRemark));
                list.Add(new SqlParameter("Dept_Recon_ObjectId", reg.Dept_Recon_ObjectId));
                list.Add(new SqlParameter("Dept_Recon_Money", reg.Dept_Recon_Money));
                list.Add(new SqlParameter("Dept_Recon_LG", reg.Dept_Recon_LG));
                list.Add(new SqlParameter("CreateBy", reg.CreateBy));
                list.Add(new SqlParameter("IsActive", true));
                result = DB_FACenter.executeStoredProcedureScalar("proc_InsertForm_Register_Dept", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertForm_Register_Dept Error : " + ex, ref log4);
            }

            return result;
        }

        public string InsertDebtTransections(FormRegisterFAInfo obj, int ConsultantId)
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

        public string InsertDebtFormRegister(FormRegisterFAInfo reg)
        {
            var result = string.Empty;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("FA_TransectionsId", reg.FA_TransectionsId));
                list.Add(new SqlParameter("IsDept_Recon", true));
                list.Add(new SqlParameter("RequestRemark", reg.RequestRemark));
                list.Add(new SqlParameter("Dept_Recon_ObjectId", reg.Dept_Recon_ObjectId));
                list.Add(new SqlParameter("Dept_Recon_Money", reg.Dept_Recon_Money));
                list.Add(new SqlParameter("Dept_Recon_LG", reg.Dept_Recon_LG));
                list.Add(new SqlParameter("CreateBy", reg.CreateBy));
                list.Add(new SqlParameter("IsActive", true));
                result = DB_FACenter.executeStoredProcedureScalar("proc_InsertForm_Register_Dept", list.ToArray())
                    .ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertForm_Register_Dept Error : " + ex, ref log4);
            }

            return result;
        }
    }
}
