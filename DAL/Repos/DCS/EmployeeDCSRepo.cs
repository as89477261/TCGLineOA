using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace DAL.Repos.FACenter
{
    public class EmployeeDCSRepo
    {
        private static ILog log4 = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Database DB_FACenter = new Database(Database.DBName.DB_FACenter);


        public DataTable GetEmployeeWithDept_In_DCS(string IdCard)
        {
            DataTable dt = null;
            try
            {
                var list = new List<SqlParameter>();
                list.Add(new SqlParameter("IdCard", IdCard));

                dt = DB_FACenter.ExecuteStoredProcedureReturnDataSet("proc_GetEmployeeWithDept_In_DCS", list.ToArray())
                    .Tables[0];
            }
            catch (Exception err)
            {
                LogUtility.writeLog("proc_GetEmployeeWithDept_In_DCS Error : " + err, ref log4);
            }

            return dt;
        }
    }
}