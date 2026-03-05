namespace DataModel.Models.NDID.Callback
{
    public class NDIDEFormRawPersonalModel
    {
        public string ID { get; set; }
        public string RawData { get; set; }
        public string Request_ID { get; set; }
        public bool? ClosedStatus { get; set; }
        public bool? IsTimeout { get; set; }
        public int? Mode { get; set; }
        public string RequestStatus { get; set; }
        public string RequestNode { get; set; }
        public string Reference_ID { get; set; }
    }
}