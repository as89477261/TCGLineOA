using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repos.Dashboard;
using DAL.Repos.FACenter;
using DataModel.Models.DCS;

namespace BLL.Controller.FACenter
{
    public class EmployeeDCSCon
    {
        private EmployeeDCSCon()
        {
        }

        public static EmployeeDCSCon Instance { get; } = new EmployeeDCSCon();

        public BaseModel<List<ExployeeDCSModel>> GetEmployeeWithDept_In_DCS(string idCard)
        {
            var result = new BaseModel<List<ExployeeDCSModel>>();
            try
            {
                var buffer = new EmployeeDCSRepo();
                var bufferResult = buffer.GetEmployeeWithDept_In_DCS(idCard).ToList<ExployeeDCSModel>();
                 if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult;
                    result.SetSuccess(); 

                }else
                {
                    result.SetNotfound();
                }
                return result ;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
    }
}