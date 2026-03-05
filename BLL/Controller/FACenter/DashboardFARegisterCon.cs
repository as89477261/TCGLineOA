using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.FACenter;

namespace BLL.Controller
{
    public class DashboardFARegisterCon
    {
        private DashboardFARegisterCon()
        {
        }

        public static DashboardFARegisterCon Instance { get; } = new DashboardFARegisterCon();

        public BaseModel<List<DashboardFARegisterInfo>> GetDashboardFARegisterMonthly()
        {
            var result = new BaseModel<List<DashboardFARegisterInfo>>();
            try
            {
                var buffer = new DashboardFARegisterRepo();
                var bufferResult = buffer.GetDashboardFARegisterMonthly().ToListof<DashboardFARegisterInfo>();
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

        public BaseModel<DashboardFARegisterInfo> GetDashboardFARegisterSummary()
        {
            var result = new BaseModel<DashboardFARegisterInfo>();
            try
            {
                var buffer = new DashboardFARegisterRepo();
                var bufferResult = buffer.GetDashboardFARegisterSummary().ToListof<DashboardFARegisterInfo>()
                    .FirstOrDefault();
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