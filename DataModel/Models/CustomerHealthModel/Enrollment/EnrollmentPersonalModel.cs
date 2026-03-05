using System;

namespace DataModel.Models.CustomerHealthModel.Enrollment
{
    public class EnrollmentPersonalModel
    {
        public string UID { get; set; }
        public string registerDummyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityID { get; set; }
        public string IdentityType { get; set; }
        public string TitleName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
    }
}