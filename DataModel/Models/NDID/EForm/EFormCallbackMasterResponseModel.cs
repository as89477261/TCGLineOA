namespace DataModel.Models.NDID.EForm
{
    public class EFormCallbackMasterResponseModel
    {
        public RequestData request_data { get; set; }
        public Request request { get; set; }
        public string identity { get; set; }
        public string reference_id { get; set; }
        public string uid { get; set; }
    }
}