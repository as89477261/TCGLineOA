using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repos.CustomerHealthCheck;
using DataModel.Models.CustomerHealthModel;

namespace BLL.Controller
{
    public class DashboardCon
    {
        private DashboardCon()
        {
        }

        public static DashboardCon Instance { get; } = new DashboardCon();

        public BaseModel<DashboardPersonalType> GetDashboardPersonalType()
        {
            var result = new BaseModel<DashboardPersonalType>();
            try
            {
                var buffer = new DashboardPersonalTypeRepo();
                var bufferResult = buffer.GetDashboardPersonalType().ToListof<DashboardPersonalType>().FirstOrDefault();
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

        public BaseModel<List<DashboardPersonalMonthly>> GetDashboardPersonalMonthly()
        {
            var result = new BaseModel<List<DashboardPersonalMonthly>>();
            try
            {
                var buffer = new DashboardPersonalTypeRepo();
                var bufferResult = buffer.GetDashboardPersonalMonthly().ToListof<DashboardPersonalMonthly>();
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