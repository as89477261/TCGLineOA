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
    public class ConfirmRepo : BaseRepository
    {
        Database DB_TCGID = new Database(Database.DBName.DB_TCGID);

        public DataTable GetVerifyPersonal(string dummyID, string refNumber, string verifyType)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 50) { Value = dummyID  },
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
        public DataTable GetVerifyPersonalStep(string dummyID)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 50) { Value = dummyID  }
                
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

        public string InsertVerify(ConfirmModel_BK obj)
        {
            string dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 50) { Value = obj.DummyID  },
                  new SqlParameter("@VerifyType", SqlDbType.NVarChar, 50) { Value = obj.VerifyType  },
                  new SqlParameter("@VerifyValue", SqlDbType.NVarChar, 50) { Value = obj.VerifyValue  },
                  new SqlParameter("@RefNumber", SqlDbType.NVarChar, 50) { Value = obj.RefNumber  },
                  new SqlParameter("@IsSuccess", SqlDbType.Bit) { Value = obj.IsSuccess  },
                  new SqlParameter("@SendRefDate", SqlDbType.DateTime) { Value = obj.SendRefDate  },
                  new SqlParameter("@KeyInDate", SqlDbType.DateTime) { Value = obj.KeyInDate  },
                  new SqlParameter("@KeyInValue", SqlDbType.NVarChar, 2000) { Value = obj.KeyInValue  },
                  new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy  }
            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnStatus("InsertConfirmPersonal", parameters);
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
                throw ex;
            }

            return dt;
        }
        public string UpdateVerify(ConfirmModel_BK obj)
        {
            string dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 50) { Value = obj.DummyID  },
                  new SqlParameter("@RefNumber", SqlDbType.NVarChar, 50) { Value = obj.RefNumber  },
                  new SqlParameter("@IsSuccess", SqlDbType.Bit) { Value = obj.IsSuccess  },
                  new SqlParameter("@KeyInValue", SqlDbType.NVarChar, 2000) { Value = obj.KeyInValue  },
                  new SqlParameter("@VerifyType", SqlDbType.NVarChar, 50) { Value = obj.VerifyType  }                 

            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnStatus("UpdateConfirmPersonal", parameters);
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
