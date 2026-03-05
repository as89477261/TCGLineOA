namespace DataModel.Models.NDID.EFormv2
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class NDIDEformPostData
    {
        [AlphaFormatValidateField("partial")] public string uuid { get; set; }

        [AlphaFormatValidateField] public string member_shortname { get; set; }

        [AlphaFormatValidateField] public string citizen_id { get; set; }

        [AlphaFormatValidateField] public string firstname { get; set; }

        [AlphaFormatValidateField] public string lastname { get; set; }

        [AlphaFormatValidateField] public string dob { get; set; }

        [AlphaFormatValidateField("phone")] public string mobile_no { get; set; }

        [AlphaFormatValidateField("email")] public string email { get; set; }

        [AlphaFormatValidateField] public string product_code { get; set; }
        [AlphaFormatValidateField] public string product_code_description { get; set; }        

        [AlphaFormatValidateField] public string trn_type { get; set; }

        [AlphaFormatValidateField] public string version { get; set; }
    }

    public class EFormV2PostModel
    {
        [AlphaFormatValidateField("partial")] public string uid { get; set; }

        [AlphaFormatValidateField] public string idp { get; set; }

        [AlphaFormatValidateField] public string request_option { get; set; }

        public NDIDEformPostData request_params { get; set; }
    }
}