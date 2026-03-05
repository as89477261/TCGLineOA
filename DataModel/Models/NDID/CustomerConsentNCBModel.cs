using System;

namespace DataModel.Models.NDID
{
    public class CustomerConsentNCBModel
    {
        public string ID { get; set; }
        public string UID { get; set; }
        public bool NCBConsent1Status { get; set; }
        public string NCBConsent1Remark { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string TransactionID { get; set; }
    }
}