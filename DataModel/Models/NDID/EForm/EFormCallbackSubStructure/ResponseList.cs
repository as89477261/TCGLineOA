namespace DataModel.Models.NDID.EForm
{
    public class ResponseList
    {
        public string as_id { get; set; }
        public bool signed { get; set; }
        public bool received_data { get; set; }
        public double ial { get; set; }
        public double aal { get; set; }
        public string status { get; set; }
        public string signature { get; set; }
        public string idp_id { get; set; }
        public bool valid_ial { get; set; }
        public bool valid_signature { get; set; }
    }
}