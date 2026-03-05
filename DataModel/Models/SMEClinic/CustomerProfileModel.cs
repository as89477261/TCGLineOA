namespace DataModel.Models.SMEClinic
{
    public class CustomerProfileModel
    {
        public long Code { get; set; }
        public int CustomerType { get; set; }
        public int CustomerCodeOfMagic { get; set; }
        public int IdCardType { get; set; }
        public string IdCard { get; set; }
        public string TitleName { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType_Id { get; set; }
        public string CompanyProvince_Code { get; set; }
        public string CompanyType_OfName { get; set; }
        public string ContactCustomerName { get; set; }
        public bool IsCurrentAddressOfHouse { get; set; }
        public bool IsActive { get; set; }
        public string IdCardSpouse { get; set; }
        public string TitleNameSpouse { get; set; }
        public string NameSpouse { get; set; }
        public string SureNameSpouse { get; set; }
        public int SpouseType { get; set; }
        public bool Is_Consent { get; set; }
        public string Uid { get; set; }
        public string lineName { get; set; }
        public string MobileNumber { get; set; }
        public string Picture { get; set; }
        public string Uid_Channel { get; set; }
        public string Email { get; set; }

        public string TitleCode { get; set; }
    }
}