using System;
using System.Collections.Generic;
using DAL.Repos.Dashboard;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller.Dashboard
{
    public class DashbordUIDMapRegisterCon
    {
        private DashbordUIDMapRegisterCon()
        {
        }

        public static DashbordUIDMapRegisterCon Instance { get; } = new DashbordUIDMapRegisterCon();

        public BaseModel<List<DashboardUIDMapRegister>> GetDashboardUIDMapRegister(string infoType, string subInfoType)
        {
            var result = new BaseModel<List<DashboardUIDMapRegister>>();
            try
            {
                var repo = new DashboardUIDMapRegisterRepo();
                var bufferResult = repo.GetDashboardUIDMapRegister(infoType, subInfoType)
                    .ToListof<DashboardUIDMapRegister>();
                if (bufferResult != null)
                {
                    result.RESULT_OBJ = bufferResult;
                    result.SetSuccess();
                }
                else
                {
                    result.SetNotfound();
                }

                return result;
            }
            catch (Exception ex)
            {
                result.SetException(ex);
                return result;
            }
        }
    }
}