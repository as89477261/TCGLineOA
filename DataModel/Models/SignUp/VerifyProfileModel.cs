using System;

namespace DataModel.Models.SignUp
{
    public class VerifyProfileModel
    {
        public string id { get; set; }
        public string dummyId { get; set; }
        public string verifyType { get; set; }
        public string verifyValue { get; set; }
        public string refNumber { get; set; }
        public bool? isSuccess { get; set; }
        public DateTime? sendRefDate { get; set; }
        public string verifiedTimeStamp { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? keyInDate { get; set; }
        public string keyInValue { get; set; }
        public string createdBy { get; set; }
        public bool? status { get; set; }
    }
}