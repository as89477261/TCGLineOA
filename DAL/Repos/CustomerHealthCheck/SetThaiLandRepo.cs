using DataModel.Models.SetThailand;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Reflection;
using System;

namespace DAL.Repos.CustomerHealthCheck
{

    public class SetThaiLandRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);
        private Database DB_SMEClinic = new Database(Database.DBName.DB_SMEClinic);

        public string InsertUIDMapSetThailandLog(SetThailandLogModel obj)
        {
            var result = string.Empty;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.VarChar, 50) { Value = obj.Uid },
                new SqlParameter("@LogSetUrl", SqlDbType.VarChar) { Value = obj.LogSetUrl },
                new SqlParameter("@CreateDate", SqlDbType.DateTime ) { Value = DBNull.Value},
                new SqlParameter("@StatusValid", SqlDbType.Bit) {Value = obj.StatusValid}
            };
            try
            {
                result = DB_CustomerHealthCheck.executeStoredProcedureScalar("InsertUIDMapSetThailandLog", parameters)
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
