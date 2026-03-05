using System;

namespace DataModel.Models.NDID
{
    public class UIDMapNDIDStatusModel
    {
        public string TransactionID { get; set; }
        public string UID { get; set; }
        public string Step1Status { get; set; }
        public string Step1Remark { get; set; }
        public string Step2Status { get; set; }
        public string Step2Remark { get; set; }
        public string Step3Status { get; set; }
        public string Step3Remark { get; set; }
        public string Step4Status { get; set; }
        public string Step4Remark { get; set; }
        public string Step5Status { get; set; }
        public string Step5Remark { get; set; }
        public bool Status { get; set; }
        public string CurrentStausCode { get; set; }
        public string CurrentStatusRemark { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string NDIDRequestID { get; set; }
        public string NDIDInitialSalt { get; set; }
        public string Reference_ID { get; set; }
    }
}