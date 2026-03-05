using System;

namespace DataModel.Models.LG
{
    public partial class LGModel
    {
        public DateTime lgStartDate { get; set; }
        public DateTime lgEndDate { get; set; }
        public decimal outstanding { get; set; }
        public string projectTypeName { get; set; }
        public string subProjectTypeName { get; set; }
        public string bankName { get; set; }
        public string customerName { get; set; }
        public decimal requestAmount { get; set; }
        public int port_Time { get; set; }
        public string isHaveCustomerJoin { get; set; }

    }
}