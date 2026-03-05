namespace DataModel.Models.NDID.EForm
{
    public class RequestData
    {
        public CustomerInfoTh customer_info_th { get; set; }
        public CustomerInfoEn customer_info_en { get; set; }
        public Identifier identifier { get; set; }
        public CustomerAddressIdCard customer_address_id_card { get; set; }
        public CustomerAddressContact customer_address_contact { get; set; }
        public CustomerOccupation customer_occupation { get; set; }
        public OfficeAddress office_address { get; set; }
        public CustomerContact customer_contact { get; set; }
        public CustomerBiometric customer_biometric { get; set; }
        public string birth_date { get; set; }
        public string _id { get; set; }
    }
}