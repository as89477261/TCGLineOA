using System;

namespace DataModel.Models.MasterData
{
    public class ProductModel
    {
        public Guid ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; }
        public string Year { get; set; }
        public string ProductShortDetail { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string ProductNameHtml { get; set; }
        public string ProductDetailHtml { get; set; }
        public string ProductShortDetailHtml { get; set; }
    }
}