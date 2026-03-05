using System;

namespace CustomerHealthModel.Model
{
    public class UIDMapCustomerProfileModel
    {
        public long Code { get; set; }
        public int IdCardType { get; set; }
        public string IdCard { get; set; }
        public string TitleName { get; set; }
        public string TitleCode { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsActive { get; set; }
        public string ID { get; set; }
        public string CreateBy { get; set; }
        public string Uid { get; set; }
        public string lineName { get; set; }
        public string Picture { get; set; }
        public string Uid_Channel { get; set; }
        public string Email { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
    }
}