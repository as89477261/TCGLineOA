using Newtonsoft.Json;

namespace DataModel.Models.NDID.RP
{
    public class RPRequestNCBParamModel
    {
        public string uuid { get; set; }
        public string member_shortname { get; set; }
        public string citizen_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string dob { get; set; }
        public string mobile_no { get; set; }

        [JsonProperty(" email")] public string email { get; set; }

        public string product_code { get; set; }
        public string trn_type { get; set; }
        public int version { get; set; }

        public RPRequestNCBParamModel GenerateInitialObj(string uuid)
        {
            var obj = new RPRequestNCBParamModel();
            obj.uuid = uuid;
            obj.member_shortname = "";
            obj.citizen_id = "";
            obj.firstname = "";
            obj.lastname = "";
            obj.dob = "";
            obj.mobile_no = "";
            obj.email = "";
            obj.product_code = "";
            obj.trn_type = "";
            obj.version = 2;
            return obj;
        }
    }
}