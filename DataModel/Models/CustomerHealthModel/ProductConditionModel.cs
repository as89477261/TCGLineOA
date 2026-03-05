using System;

namespace DataModel.Models.CustomerHealthModel
{
    public class ProductConditionModel
    {
        public string ID { get; set; }
        public string ProductCode { get; set; }
        public string CriteriaCode { get; set; }
        public string CriteriaCondition { get; set; }
        public string CriteriaValue { get; set; }
        public string CriteriaRemark { get; set; }
        public string CriteriaResult { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CriteriaCustomerType { get; set; }
        public string CriteriaSourceField { get; set; }
        public string CriteriaValueType { get; set; }
    }
}