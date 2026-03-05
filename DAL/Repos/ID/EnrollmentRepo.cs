
using DataModel.Models.ID;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repos.ID
{
    public class EnrollmentRepo : BaseRepository
    {
        Database DB_TCGID = new Database(Database.DBName.DB_TCGID);

        public DataTable GetAllEnrollmentPersonal()
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {               
            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnDataSet("GetEnrolmentPersonal", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
                throw ex;
            }

            return dt;
        }
        public DataTable GetEnrolmentPersonal(string IdentityID,string IdentityType)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {                
                  new SqlParameter("@IdentityID", SqlDbType.NVarChar, 50) { Value = IdentityID  },
                  new SqlParameter("@IdentityType", SqlDbType.NVarChar, 50) { Value = IdentityType  }                 
            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnDataSet("GetEnrolmentPersonal", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
                throw ex;
            }

            return dt;
        }
        public DataTable GetEnrolmentPersonal(string dummyID)
        {
            DataTable dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 100) { Value = dummyID  }
            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnDataSet("GetEnrolmentPersonal", parameters).Tables[0];
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger(ex.GetBaseException().Message);
                throw ex;
            }

            return dt;
        }

        public string InsertRegisterPersonal(EnrolmentPersonalModel obj)
        {
            string dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@DummyID", SqlDbType.NVarChar, 50) { Value = obj.DummyID  },
                  new SqlParameter("@TitleName", SqlDbType.NVarChar, 500) { Value = obj.TitleName  },
                  new SqlParameter("@FirstName", SqlDbType.NVarChar, 500) { Value = obj.FirstName  },
                  new SqlParameter("@LastName", SqlDbType.NVarChar, 500) { Value = obj.LastName  },
                  new SqlParameter("@IdentityID", SqlDbType.NVarChar, 100) { Value = obj.IdentityID  },
                  new SqlParameter("@IdentityType", SqlDbType.NVarChar, 10) { Value = obj.IdentityType  },
                  new SqlParameter("@MobilePhone", SqlDbType.NVarChar, 15) { Value = obj.MobilePhone  },
                  new SqlParameter("@Email", SqlDbType.NVarChar, 500) { Value = obj.Email  },
                  new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = obj.CreatedBy  }
            };

            try
            {
                dt = DB_TCGID.ExecuteStoredProcedureReturnStatus("InsertEnrolmentPersonal", parameters);
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
