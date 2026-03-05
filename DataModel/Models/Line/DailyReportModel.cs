
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Line
{
    public class DailyReportModel
    {
        public string UIDLastYearSummary { get; set; }
        public string UIDSummary { get; set; }
        public string UIDHaveLGLastYearSummary { get; set; }
        public string UIDHaveLGSummary { get; set; }
        public string UIDHaveDeptLastYearSummary { get; set; }
        public string UIDHaveDeptSummary { get; set; }
        public string KPICurrentlyUIDHaveLGinPercentage { get; set; }
        public string KPICuurentlyUIDHaveActiveUserinPercentage { get; set; }
        public string UIDKYCSummary { get; set; }
        public string UIDKYCLastYearSummary { get; set; }
        public string UIDKYCFixDateSummary { get; set; }
    }
}
