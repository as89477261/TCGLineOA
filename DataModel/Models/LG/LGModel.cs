using System;

namespace DataModel.Models.LG
{
    public partial class LGModel
    {
        public string LGNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GuaranteePrice { get; set; }
        public string IDCard { get; set; }

        public string ProjectName { get; set; }
        public string BankName { get; set; }
        public string CreateDate { get; set; }
        public string RequestName { get; set; }
        public string Objective { get; set; }
    }
}