using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DAL.Repos.ID
{
    public class VerifyRepo
    {
        Database DB_TCGID = new Database(Database.DBName.DB_TCGID);

        public DataTable GetVerfyPersonal(string dummyID, string refNumber = null, string verifyType = null)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 100) { Value = dummyID  },
                  new SqlParameter("@RefNumber", SqlDbType.NVarChar, 50) { Value = refNumber  },
                  new SqlParameter("@VerifyType", SqlDbType.NVarChar, 50) { Value = verifyType  }
            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnDataSet("GetVerifyPersonal", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
                throw ex;
            }

            return dt;
        }
    }
}
