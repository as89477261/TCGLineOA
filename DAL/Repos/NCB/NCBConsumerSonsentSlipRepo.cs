using System;
using System.Data;
using System.Data.SqlClient;
using DataModel.Models.NCB;
using DataModel.Models.NDID.EForm;

namespace DAL.Repos.NDIDInfo
{
    public class NCBConsumerSonsentSlipRepo
    {

        private readonly Database DB_NCB = new Database(Database.DBName.DB_NCB);

        public DataTable GETCheckNCBHistory(string idCard)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@IdentityID", SqlDbType.NVarChar, 200) { Value = idCard },


            };

            try
            {
                dt = DB_NCB.ExecuteStoredProcedureReturnDataSet("proc_GETCheckNCBHistory", parameters).Tables[0];
            }
            catch (Exception ex)
            {

            }

            return dt;
        }
        public string InsertENCBConsentSlipData(NCBConsumerConsentSlipModel obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UIDReferenceID", SqlDbType.NVarChar, 200) { Value = obj.UIDReferenceID },
                new SqlParameter("@FirstName", SqlDbType.NVarChar, 500) { Value = obj.FirstName },
                new SqlParameter("@LastName", SqlDbType.NVarChar, 500) { Value = obj.LastName },
                new SqlParameter("@BirthDate", SqlDbType.DateTime) { Value = obj.BirthDate },
                new SqlParameter("@IDCard", SqlDbType.NVarChar, 100) { Value = obj.IDCard },
                new SqlParameter("@MobilePhone", SqlDbType.NVarChar, 20) { Value = obj.MobilePhone },
                new SqlParameter("@ProductType", SqlDbType.NVarChar, 100) { Value = obj.ProductType },
                new SqlParameter("@Email", SqlDbType.NVarChar, 200) { Value = obj.Email },
                new SqlParameter("@IsRequestEConsentSlip", SqlDbType.Bit) { Value = obj.IsRequestEConsentSlip },
                new SqlParameter("@RequestEConsentSlipDate", SqlDbType.DateTime) { Value = obj.RequestEConsentSlipDate }

            };

            try
            {
                dt = DB_NCB.ExecuteStoredProcedureReturnStatus("proc_INSERTENCBConsentSlipData", parameters);
            }
            catch (Exception ex)
            {

            }

            return dt;
        }
        public string UpdateENCBConsentSlipData(NCBConsumerConsentSlipModel obj)
        {
            string dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UIDReferenceID", SqlDbType.NVarChar, 200) { Value = obj.UIDReferenceID },
                new SqlParameter("@TransID", SqlDbType.NVarChar, 500) { Value = obj.TransID },
                new SqlParameter("@NCBToken", SqlDbType.NVarChar, 500) { Value = obj.NCBToken }
            };

            try
            {
                dt = DB_NCB.ExecuteStoredProcedureReturnStatus("proc_UPDATEENCBConsentSlipData", parameters);
            }
            catch (Exception ex)
            {
            }

            return dt;
        }
    }
}