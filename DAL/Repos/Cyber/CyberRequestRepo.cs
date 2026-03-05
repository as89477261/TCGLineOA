
using DataModel.Models.CustomerHealthModel.PreRequest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repos
{
    public class CyberRequestRepo
    {

        Database DB_CYBER = new Database(Database.DBName.DB_CYBER);
        
        public string UpdateNCBScoreToRequest(UIDMapPreRequestAndUpdateCyber obj)
        {
            string dt = null;
            SqlParameter[] parameters =
            {
                  new SqlParameter("@T01NCB_CreditScore", SqlDbType.Int) { Value = obj.NCBScore  },
                  new SqlParameter("@T01NCB_Level_CreditScore", SqlDbType.NVarChar, 5) { Value = obj.NCBGrade  },
                  new SqlParameter("@T01NCB_CreateDate", SqlDbType.NVarChar, 10) { Value = DateTime.Now.ToString("yyyyMMdd",new CultureInfo("th-TH"))  },
                  new SqlParameter("@T01NCB_CreateTime", SqlDbType.NVarChar, 10) { Value = DateTime.Now.ToString("HHmmss",new CultureInfo("th-TH"))  },

                  //new SqlParameter("@T02NCB_CreditScore", SqlDbType.Int) { Value = obj.T02NCB_CreditScore  },
                  //new SqlParameter("@T02NCB_Level_CreditScore", SqlDbType.NVarChar, 5) { Value = obj.T02NCB_Level_CreditScore  },
                  //new SqlParameter("@T02NCB_CreateDate", SqlDbType.NVarChar, 10) { Value = obj.T02NCB_CreateDate  },

                  //new SqlParameter("@T03NCB_CreditScore", SqlDbType.Int) { Value =  obj.T03NCB_CreditScore  },
                  //new SqlParameter("@T03NCB_Level_CreditScore", SqlDbType.NVarChar, 5) { Value = obj.T03NCB_Level_CreditScore  },
                  //new SqlParameter("@T03NCB_CreateDate", SqlDbType.NVarChar, 10) { Value = obj.T03NCB_CreateDate  },

                  //new SqlParameter("@T04NCB_CreditScore", SqlDbType.Int) { Value =  obj.T04NCB_CreditScore  },
                  //new SqlParameter("@T04NCB_Level_CreditScore", SqlDbType.NVarChar, 5) { Value = obj.T04NCB_Level_CreditScore  },
                  //new SqlParameter("@T04NCB_CreateDate", SqlDbType.NVarChar, 10) { Value = obj.T04NCB_CreateDate  },

                  //new SqlParameter("@T05NCB_CreditScore", SqlDbType.Int) { Value =  obj.T05NCB_CreditScore  },
                  //new SqlParameter("@T05NCB_Level_CreditScore", SqlDbType.NVarChar, 5) { Value = obj.T05NCB_Level_CreditScore  },
                  //new SqlParameter("@T05NCB_CreateDate", SqlDbType.NVarChar, 10) { Value = obj.T05NCB_CreateDate  },

                  //new SqlParameter("@T06NCB_CreditScore", SqlDbType.Int) { Value =  obj.T06NCB_CreditScore  },
                  //new SqlParameter("@T06NCB_Level_CreditScore", SqlDbType.NVarChar, 5) { Value = obj.T06NCB_Level_CreditScore  },
                  //new SqlParameter("@T06NCB_CreateDate", SqlDbType.NVarChar, 10) { Value = obj.T06NCB_CreateDate  },

                  //new SqlParameter("@T07NCB_CreditScore", SqlDbType.Int) { Value =  obj.T07NCB_CreditScore  },
                  //new SqlParameter("@T07NCB_Level_CreditScore", SqlDbType.NVarChar, 5) { Value = obj.T07NCB_Level_CreditScore  },
                  //new SqlParameter("@T07NCB_CreateDate", SqlDbType.NVarChar, 10) { Value = obj.T07NCB_CreateDate  },

                  new SqlParameter("@T01Online_ID", SqlDbType.NVarChar, 100) { Value = obj.T01OnlineID  },

            };
            try
            {
                dt = DB_CYBER.ExecuteStoredProcedureReturnStatus("proc_UPDATENCBScoreToRequest", parameters);
            }
            catch (Exception ex)
            {

            }

            return dt;
        }
    }
}
