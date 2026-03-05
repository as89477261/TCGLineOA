using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DataModel.Models.LOG;
using DataModel.Models.SMEClinic;
using log4net;

namespace DAL.Repos.MasterData
{
    public class LogActivityRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public string InsertLogActivity(LogActivity obj)
        {
            var customerCode = string.Empty;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar) { Value = obj.UID },
                new SqlParameter("@ApplicationCode", SqlDbType.VarChar, 10) { Value = obj.ApplicationCode },
                new SqlParameter("@SubApplicationCode", SqlDbType.VarChar, 10) { Value = obj.SubApplicationCode },
                new SqlParameter("@ActivityCode", SqlDbType.VarChar, 10) { Value = obj.ActivityCode },
                new SqlParameter("@Remark", SqlDbType.VarChar) { Value = obj.Remark },
                new SqlParameter("@CreateBy", SqlDbType.VarChar, 50) { Value = obj.CreateBy }

            };

            try
            {
                customerCode = DB_CustomerHealthCheck
                    .executeStoredProcedureScalar("InsertLogActivity", parameters).ToString();
            }
            catch (Exception ex)
            {
                LogUtility.writeLog("InsertLogActivity() Error : " + ex, ref log4);
            }

            return customerCode;
        }
    }
}