using System;

namespace DataModel.Models.CustomerHealthModel.EventsModel
{
    public class PersonalInfoModel
    {
        public string ID { get; set; }
        public string BusinessType { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string EventCode { get; set; }

        public string IdentityID { get; set; }
        public string IdentityType { get; set; }
        public string TitleCode { get; set; }
        public string TitleName { get; set; }
    }
}