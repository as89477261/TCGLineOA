using DataModel.Models.ID;
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
    public class EnrollmentReportRepo : BaseRepository
    {
        Database DB_CustomerHealthCheck = new Database(Database.DBName.DB_CustomerHealthCheck);

        public DataTable GetEnrollmentPersonalByUID(string UID, string IdentityID = "", string ParamOrderbyField = "", string ParamOrderbyType = "")
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = UID  },
                  new SqlParameter("@IdentityID", SqlDbType.NVarChar, 20) { Value = IdentityID  },
                  new SqlParameter("@ParamOrderbyField", SqlDbType.NVarChar, 100) { Value = ParamOrderbyField  },
                  new SqlParameter("@ParamOrderbyType", SqlDbType.NVarChar, 100) { Value = ParamOrderbyType  }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetReportEnrollmentPersonal", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
                throw ex;
            }

            return dt;
        }

        public DataTable GetFinishedEnrollmentPersonal(string UID, string IdentityID = "", string ParamOrderbyField = "", string ParamOrderbyType = "")
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                new SqlParameter("@UID", SqlDbType.NVarChar, 100) { Value = UID  },
                  new SqlParameter("@IdentityID", SqlDbType.NVarChar, 20) { Value = IdentityID  },
                  new SqlParameter("@ParamOrderbyField", SqlDbType.NVarChar, 100) { Value = ParamOrderbyField  },
                  new SqlParameter("@ParamOrderbyType", SqlDbType.NVarChar, 100) { Value = ParamOrderbyType  }
            };

            try
            {
                dt = DB_CustomerHealthCheck.ExecuteStoredProcedureReturnDataSet("GetReportFinishedEnrollmentPersonal", parameters).Tables[0];
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
