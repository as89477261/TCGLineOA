using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repos.ID
{
    public class ProfileRepo : BaseRepository
    {
        Database DB_TCGID = new Database(Database.DBName.DB_TCGID);


        public DataTable GetProfile(
            string dummyID, string identityID, string identityType,
            string mobilePhone, string firstName, string lastName)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 50) { Value = dummyID  },
                  new SqlParameter("@IdentityID", SqlDbType.NVarChar, 50) { Value = identityID  },
                  new SqlParameter("@IdentityType", SqlDbType.NVarChar, 5) { Value = identityType  },
                  new SqlParameter("@MobilePhone", SqlDbType.NVarChar, 12) { Value = mobilePhone  },
                  new SqlParameter("@FirstName", SqlDbType.NVarChar, 100) { Value = firstName  },
                  new SqlParameter("@LastName", SqlDbType.NVarChar, 100) { Value = lastName  }

            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnDataSet("GetProfile", parameters).Tables[0];
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
