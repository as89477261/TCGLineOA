using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.ID;

namespace DAL.Repos.ID
{
    public class ConsentRepo : BaseRepository
    {
        Database DB_TCGID = new Database(Database.DBName.DB_TCGID);


        public DataTable GetConsentByDummyID(string dummyID)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 100) { Value = dummyID  }
            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnDataSet("GetConsentByDummyID", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
                throw ex;
            }

            return dt;
        }

        public string InsertConsent(ConsentModel obj)
        {
            string dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 100) { Value = obj.DummyID  },
                  new SqlParameter("@IsConsent1", SqlDbType.Bit) { Value = obj.IsConsent1  },
                  new SqlParameter("@Status", SqlDbType.Bit) { Value = obj.Status  },
                  new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy  }

            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnStatus("InsertConsent", parameters);
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
