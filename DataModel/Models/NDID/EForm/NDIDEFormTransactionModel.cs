using System;

namespace DataModel.Models.NDID.EForm
{
    public class NDIDEFormTransactionModel
    {
        public string TransactionID { get; set; }
        public string UID { get; set; }
        public bool Status { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CurrentStatusCode { get; set; }
        public string CurrentStatusRemark { get; set; }
        public string IDCard { get; set; }
    }
}