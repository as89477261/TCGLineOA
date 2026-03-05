using System;

namespace DataModel.Models.SMEClinic
{
    public class UIDMapCustomerProfileModel
    {
        public int ID { get; set; }
        public string CustomerProfileCode { get; set; }
        public string Uid { get; set; }
        public string IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string PersonalType { get; set; }
    }
}