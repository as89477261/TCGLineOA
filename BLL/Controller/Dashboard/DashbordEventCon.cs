using System;
using System.Collections.Generic;
using DAL.Repos.Dashboard;
using DataModel.Models.Dashboard;

namespace BLL.Controller.Dashboard
{
    public class DashbordEventCon
    {
        private DashbordEventCon()
        {
        }

        public static DashbordEventCon Instance { get; } = new DashbordEventCon();

        public BaseModel<List<DashboardEventModel>> GetDashboardEvent()
        {
            var result = new BaseModel<List<DashboardEventModel>>();
            try
            {
                var repo = new DashboardEventRepo();
                var bufferResult = repo.GetDashboardEvent().ToListof<DashboardEventModel>();
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

        public BaseModel<List<DashboardEventModel>> GetDashboardEventMonthly()
        {
            var result = new BaseModel<List<DashboardEventModel>>();
            try
            {
                var repo = new DashboardEventRepo();
                var bufferResult = repo.GetDashboardEventMonthly().ToListof<DashboardEventModel>();
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