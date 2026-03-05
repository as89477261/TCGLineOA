using System;

namespace DataModel.Models.CustomerHealthModel
{
    public class CustomerProfileMapApprochModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ApprochBody { get; set; }
        public bool IsConfirmSendMail { get; set; }
        public string UID { get; set; }
        public string RegisterInfoID { get; set; }
        public string CustomerProfileCode { get; set; }
        public string ApprochID { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}