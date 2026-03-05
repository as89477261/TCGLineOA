using System;

namespace DataModel.Models.NDID
{
    public class NDIDRequestModel
    {
        public string ID { get; set; }
        public string UID { get; set; }
        public string RequestURL { get; set; }
        public string RequestHeader { get; set; }
        public string RequestBody { get; set; }
        public string RawParameterInput { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseBody { get; set; }
        public string NDIDRequestID { get; set; }
        public string NDIDInitialSalt { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string ResponseCode { get; set; }
        public string TransactionID { get; set; }
    }
}