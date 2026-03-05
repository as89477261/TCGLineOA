using System;

namespace DataModel.Models.CustomerHealthModel.AppModel
{
    public class ActivityItem
    {
        public string LeveL { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int ReduceLevel { get; set; }
        public string Remark1 { get; set; }
    }
}