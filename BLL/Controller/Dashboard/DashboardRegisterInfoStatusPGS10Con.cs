using System;
using System.Collections.Generic;
using DAL.Repos.Dashboard;
using DataModel.Models.Dashboard;

namespace BLL.Controller.Dashboard
{
    public class DashboardRegisterInfoStatusPGS10Con
    {
        private DashboardRegisterInfoStatusPGS10Con()
        {
        }

        public static DashboardRegisterInfoStatusPGS10Con Instance { get; } = new DashboardRegisterInfoStatusPGS10Con();

        public BaseModel<List<DashboardRegisterInfoStatusPGS10Model>> GetDashboardRegisterInfoStatusPGS10()
        {
            var result = new BaseModel<List<DashboardRegisterInfoStatusPGS10Model>>();
            try
            {
                var repo = new DashboardRegisterInfoStatusPGS10Repo();
                var bufferResult = repo.GetDashboardRegisterInfoStatusPGS10()
                    .ToListof<DashboardRegisterInfoStatusPGS10Model>();
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