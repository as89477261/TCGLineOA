namespace DataModel.Models.NDID.Personal
{
    public class NDIDWrapPersonalGroupModel
    {
        public CustomerInfoTh customer_info_th { get; set; }
        public CustomerInfoEn customer_info_en { get; set; }
        public string birth_date { get; set; }
        public Identifier identifier { get; set; }
        public CustomerAddressIdCard customer_address_id_card { get; set; }
        public CustomerAddressContact customer_address_contact { get; set; }
        public CustomerOccupation customer_occupation { get; set; }
        public OfficeAddress office_address { get; set; }
        public CustomerContact customer_contact { get; set; }
        public CustomerBiometric customer_biometric { get; set; }
        public string cust_created_date { get; set; }
    }

    public class CustomerAddressContact
    {
        public string contact_street_address1 { get; set; }
        public string contact_street_address2 { get; set; }
        public string contact_address_subdistrict { get; set; }
        public string contact_address_district { get; set; }
        public string contact_address_province { get; set; }
        public string contact_address_zipcode { get; set; }
        public string contact_address_country { get; set; }
        public string contact_address_full { get; set; }
    }

    public class CustomerAddressIdCard
    {
        public string id_card_street_address1 { get; set; }
        public string id_card_street_address2 { get; set; }
        public string id_card_address_subdistrict { get; set; }
        public string id_card_address_district { get; set; }
        public string id_card_address_province { get; set; }
        public string id_card_address_zipcode { get; set; }
        public string id_card_address_country { get; set; }
        public string id_card_address_full { get; set; }
    }

    public class CustomerBiometric
    {
        public string biometric_data { get; set; }
        public string biometric_type { get; set; }
        public string biometric_format { get; set; }
    }

    public class CustomerContact
    {
        public string home_tel_no { get; set; }
        public string home_tel_no_ext { get; set; }
        public string mobile_tel_no { get; set; }
        public string email_addr { get; set; }
        public string nationality { get; set; }
        public string non_iso_nationality_description { get; set; }
        public string income { get; set; }
        public string marital_status { get; set; }
        public string gender { get; set; }
    }

    public class CustomerInfoEn
    {
        public string en_title { get; set; }
        public string en_first_name { get; set; }
        public string en_middle_name { get; set; }
        public string en_last_name { get; set; }
        public string en_full_name { get; set; }
    }

    public class CustomerInfoTh
    {
        public string thai_title { get; set; }
        public string thai_first_name { get; set; }
        public string thai_middle_name { get; set; }
        public string thai_last_name { get; set; }
        public string thai_full_name { get; set; }
    }

    public class CustomerOccupation
    {
        public string occupation_code { get; set; }
        public string idp_specific_occupation_desc { get; set; }
        public string office_name { get; set; }
    }

    public class Identifier
    {
        public string card_number { get; set; }
        public string card_type { get; set; }
        public string card_issuing_country { get; set; }
        public string card_issue_date { get; set; }
        public string card_expiry_date { get; set; }
    }

    public class OfficeAddress
    {
        public string office_street_address1 { get; set; }
        public string office_street_address2 { get; set; }
        public string office_address_subdistrict { get; set; }
        public string office_address_district { get; set; }
        public string office_address_province { get; set; }
        public string office_address_zipcode { get; set; }
        public string office_address_country { get; set; }
        public string office_full_address { get; set; }
    }
}