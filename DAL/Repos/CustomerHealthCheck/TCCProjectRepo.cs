using DataModel.Models.TCCProject;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;

namespace DAL.Repos.CustomerHealthCheck
{
    public class TCCProjectRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
    
        public DataSet InsertUIDMapTCC(UIDMapTCCModel obj)
        {
            var result = new DataSet();
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@Uid", obj.Uid));
                list.Add(new SqlParameter("@IdentityId", obj.IdentityId));
                list.Add(new SqlParameter("@Status", obj.Status));
                list.Add(new SqlParameter("@IsAcceptConsent", obj.IsAcceptConsent));
                list.Add(new SqlParameter("@InformationId", obj.InformationId));
                list.Add(new SqlParameter("@OtpDummyId", obj.OtpDummyId));
                list.Add(new SqlParameter("@IsRegisterSuccess", obj.IsRegisterSuccess));

                result = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("proc_InsertUIDMapTCC", list.ToArray());
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUIDMapDIPROM Error : " + ex, ref log4);
            }
            return result;
        }
        public DataSet InsertInformationTCC(InformationTCCModel obj)
        {
            var result = new DataSet();
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@TranID", obj.TransID));
                list.Add(new SqlParameter("@TypeForm", obj.TypeFrom));

                result = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("proc_InsertInformationTCC", list.ToArray());
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUIDMapDIPROM Error : " + ex, ref log4);
            }
            return result;
        }
        public DataSet UpdateInformationTCCPerson(InformationTCCModel obj)
        {
            var result = new DataSet();
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@TransID", obj.TransID));
                list.Add(new SqlParameter("@ID", obj.ID));
                //list.Add(new SqlParameter("@Status", obj.Status));
                list.Add(new SqlParameter("@firstName", obj.firstName));
                list.Add(new SqlParameter("@lastName", obj.lastName));
                list.Add(new SqlParameter("@registerNo", obj.registerNo));
                list.Add(new SqlParameter("@email", obj.email));
                list.Add(new SqlParameter("@mobile", obj.mobile));
                list.Add(new SqlParameter("@occupation", obj.occupation));
                list.Add(new SqlParameter("@productName", obj.productName));
                list.Add(new SqlParameter("@productExportcountry", obj.productExportcountry));
                list.Add(new SqlParameter("@bussinessType", obj.bussinessType));
                list.Add(new SqlParameter("@productNameExport", obj.productNameExport));
                list.Add(new SqlParameter("@addressNoTH", obj.addressNoTH));
                list.Add(new SqlParameter("@mooTH", obj.mooTH));
                list.Add(new SqlParameter("@buildingTH", obj.buildingTH));
                list.Add(new SqlParameter("@villageTH", obj.villageTH));
                list.Add(new SqlParameter("@floorTH", obj.floorTH));
                list.Add(new SqlParameter("@roomTH", obj.roomTH));
                list.Add(new SqlParameter("@soiTH", obj.soiTH));
                list.Add(new SqlParameter("@laneTH", obj.laneTH));
                list.Add(new SqlParameter("@roadTH", obj.roadTH));
                list.Add(new SqlParameter("@tambolTH", obj.tambolTH));
                list.Add(new SqlParameter("@ampherTH", obj.ampherTH));
                list.Add(new SqlParameter("@provinceTH", obj.provinceTH));
                list.Add(new SqlParameter("@countryTH", obj.countryTH));
                list.Add(new SqlParameter("@zipcode", obj.zipcode));
                list.Add(new SqlParameter("@fullAddressTH", obj.fullAddressTH));
                list.Add(new SqlParameter("@doc_DC", obj.doc_DC ?? "DC"));
                list.Add(new SqlParameter("@filePath_DC", obj.filePath_DC ?? ""));
                list.Add(new SqlParameter("@doc_DB", obj.doc_DB ?? "DB"));
                list.Add(new SqlParameter("@filePath_DB", obj.filePath_DB ?? ""));
                list.Add(new SqlParameter("@doc_CH", obj.doc_DB ?? "CH"));
                list.Add(new SqlParameter("@filePath_CH", obj.filePath_CH ?? ""));
                list.Add(new SqlParameter("@doc_PL", obj.doc_DB ?? "PL"));
                list.Add(new SqlParameter("@filePath_PL", obj.filePath_PL ?? ""));

                result = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("proc_UpdateInformationTCC", list.ToArray());
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUIDMapDIPROM Error : " + ex, ref log4);
            }
            return result;
        }


        public DataSet UpdateInformationTCCJurustic(InformationTCCModel obj)
        {
            var result = new DataSet();
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@TransID", obj.TransID));
                list.Add(new SqlParameter("@ID", obj.ID));
                //list.Add(new SqlParameter("@Status", obj.Status));
                list.Add(new SqlParameter("@companyName", obj.companyName));
                list.Add(new SqlParameter("@registerNo", obj.registerNo));
                list.Add(new SqlParameter("@issueDate", obj.issueDate));
                list.Add(new SqlParameter("@email", obj.email));
                list.Add(new SqlParameter("@mobile", obj.mobile));
                list.Add(new SqlParameter("@companyType", obj.companyType));
                list.Add(new SqlParameter("@productName", obj.productName));
                list.Add(new SqlParameter("@bussinessType", obj.bussinessType));
                list.Add(new SqlParameter("@numberEmployee", obj.numberEmployee));
                list.Add(new SqlParameter("@productExportcountry", obj.productExportcountry));
                list.Add(new SqlParameter("@productNameExport", obj.productNameExport));
                list.Add(new SqlParameter("@contactFirstName",obj.contactFirstName));
                list.Add(new SqlParameter("@contactLastName", obj.contactLastName));
                list.Add(new SqlParameter("@contactIDCard", obj.contactIDCard));
                list.Add(new SqlParameter("@contactPosition", obj.contactPosition));
                list.Add(new SqlParameter("@contactMobile", obj.contactMobile));
                list.Add(new SqlParameter("@contactEmail", obj.contactEmail));
                list.Add(new SqlParameter("@directorFirstName", obj.directorFirstName));
                list.Add(new SqlParameter("@directorLastName", obj.directorLastName));
                list.Add(new SqlParameter("@directorIDCard", obj.directorIDCard));
                list.Add(new SqlParameter("@directorMobile", obj.directorMobile));
                list.Add(new SqlParameter("@directorEmail", obj.directorEmail));
                list.Add(new SqlParameter("@directorIDCopyDoc", obj.directorIDCopyDoc ?? "IDcopy"));
                list.Add(new SqlParameter("@filePath_directorIDCopyDoc", obj.filePath_directorIDCopyDoc));
                list.Add(new SqlParameter("@totalAsset", obj.totalAsset));
                list.Add(new SqlParameter("@addressNoTH", obj.addressNoTH));
                list.Add(new SqlParameter("@mooTH", obj.mooTH));
                list.Add(new SqlParameter("@buildingTH", obj.buildingTH));
                list.Add(new SqlParameter("@villageTH", obj.villageTH));
                list.Add(new SqlParameter("@floorTH", obj.floorTH));
                list.Add(new SqlParameter("@roomTH", obj.roomTH));
                list.Add(new SqlParameter("@soiTH", obj.soiTH));
                list.Add(new SqlParameter("@laneTH", obj.laneTH));
                list.Add(new SqlParameter("@roadTH", obj.roadTH));
                list.Add(new SqlParameter("@tambolTH", obj.tambolTH));
                list.Add(new SqlParameter("@ampherTH", obj.ampherTH));
                list.Add(new SqlParameter("@provinceTH", obj.provinceTH));
                list.Add(new SqlParameter("@countryTH", obj.countryTH));
                list.Add(new SqlParameter("@zipcode", obj.zipcode));
                list.Add(new SqlParameter("@fullAddressTH", obj.fullAddressTH));
                list.Add(new SqlParameter("@doc_OJ", obj.doc_OJ ?? "OJ"));
                list.Add(new SqlParameter("@filePath_OJ", obj.filePath_OJ));
                list.Add(new SqlParameter("@doc_PP", obj.doc_DB ?? "PP"));
                list.Add(new SqlParameter("@filePath_PP", obj.filePath_PP ?? ""));
                list.Add(new SqlParameter("@doc_IS", obj.doc_DB ?? "IS"));
                list.Add(new SqlParameter("@filePath_IS", obj.filePath_IS ?? ""));
          

                result = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("proc_UpdateInformationTCC", list.ToArray());
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_InsertUIDMapDIPROM Error : " + ex, ref log4);
            }
            return result;
        }
        public DataTable GetUidDataTCC(string uid)
        {
            DataTable result = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Uid", SqlDbType.VarChar,100){Value = uid}
            };

            try
            {
                result = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("proc_GetUidDataTCC", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_GetUidDataTCC Error : " + ex, ref log4);
            }
            return result;
        }

        public DataSet UpdateUIDMapTCC(UIDMapTCCModel obj)
        {
            var result = new DataSet();
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("@ID", obj.Id));
                list.Add(new SqlParameter("@IsMemberTCC", obj.IsMemberTCC));
                list.Add(new SqlParameter("@MemberTCCStatus",obj.MemberTCCStatus));
                list.Add(new SqlParameter("@TransactionId", obj.TransactionId));
                list.Add(new SqlParameter("@IsSave", obj.IsRegisterSuccess));

                result = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("proc_UpdateUIDMapTCC", list.ToArray());
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("proc_UpdateUIDMapTCC Error : " + ex, ref log4);
            }

            return result;

        }
    }
    
}
