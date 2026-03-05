using System;

namespace DataModel.Models.SignUp
{
    public class EnrollmentProfileModel
    {
        public int customerType { get; set; }
        public string idCard { get; set; }
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public DateTime customerOfDate { get; set; }
        public DateTime birthDate { get; set; }
        public object address { get; set; }
        public object tumbonName { get; set; }
        public object amphureName { get; set; }
        public object provinceName { get; set; }
        public int zipCode { get; set; }
        public string mobileNumber { get; set; }
        public object phoneNumber { get; set; }
        public object lineID { get; set; }
        public object bankName { get; set; }
        public object isMoveToCustomerCode { get; set; }
        public string dummyID { get; set; }
    }

    public class EnrollmentProfileModel_Min
    {
       
        public string idCard { get; set; }       
        public string mobileNumber { get; set; }      
       
        public string dummyID { get; set; }
    }
}