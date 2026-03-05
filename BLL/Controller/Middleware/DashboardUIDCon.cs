using System;
using System.Collections.Generic;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller
{
    public class DashboardUIDCon
    {
        private DashboardUIDCon()
        {
        }

        public static DashboardUIDCon Instance { get; } = new DashboardUIDCon();

        public BaseModel<List<DashboardUIDMonthly>> GetDashboardUID()
        {
            var result = new BaseModel<List<DashboardUIDMonthly>>();
            try
            {
                var buffer = new DashboardUIDRepo();
                var bufferResult = buffer.GetDashboardUID().ToListof<DashboardUIDMonthly>();
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

        public BaseModel<List<DashboardUIDMonthly>> GetDashboardUIDMonthly()
        {
            var result = new BaseModel<List<DashboardUIDMonthly>>();
            try
            {
                var buffer = new DashboardUIDRepo();
                var bufferResult = buffer.GetDashboardUIDMonthly().ToListof<DashboardUIDMonthly>();
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