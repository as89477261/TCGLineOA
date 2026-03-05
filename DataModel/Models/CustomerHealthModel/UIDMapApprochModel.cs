using System;

namespace DataModel.Models.CustomerHealthModel
{
    public class UIDMapApprochModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ApprochBody { get; set; }
        public bool Status { get; set; }
        public DateTime Createdate { get; set; }
        public string Createby { get; set; }
        public string RegisterYear { get; set; }
        public bool IsConfirmSendMail { get; set; }
        public string ID { get; set; }
        public string UID { get; set; }
        public string RegisterInfoID { get; set; }
        public string ProductDetail { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}