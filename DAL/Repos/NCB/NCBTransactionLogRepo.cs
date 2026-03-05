using System;
using System.Data;
using System.Data.SqlClient;
using DataModel.Models.NCB;
using DataModel.Models.NDID.EForm;

namespace DAL.Repos.NDIDInfo
{
    public class NCBTransactionLogRepo
    {

        private readonly Database DB_NCB = new Database(Database.DBName.DB_NCB);

        public DataTable GETNCBScoreHistroyByIDCard(string idCard, bool isHaveScore, string limitDate)
        {
            DataTable dt = null;

            SqlParameter[] parameters =
            {
                new SqlParameter("@REFER_ID", SqlDbType.NVarChar, 200) { Value = idCard },
                new SqlParameter("@IS_HAVESCORE", SqlDbType.NVarChar, 10) { Value = (isHaveScore == true ? "TRUE":"FALSE") },
                new SqlParameter("@LIMIT_DATE", SqlDbType.NVarChar,10) { Value = limitDate },



            };

            try
            {
                dt = DB_NCB.ExecuteStoredProcedureReturnDataSet("proc_GETNCBScoreHistroyByIDCard", parameters).Tables[0];
            }
            catch (Exception ex)
            {

            }

            return dt;
        }

    }
}