namespace DataModel.Models.NDID
{
    public class NDIDWrapPersonalModel
    {
        public string source_node_id { get; set; }
        public string service_id { get; set; }
        public string source_signature { get; set; }
        public string signature_sign_method { get; set; }
        public string data_salt { get; set; }
        public string data { get; set; }
    }
}