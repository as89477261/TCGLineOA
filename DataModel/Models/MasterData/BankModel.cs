using System;

namespace DataModel.Models.MasterData
{
    public class BankModel
    {
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string BankEmail { get; set; }
        public string BankLogo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool Status { get; set; }
        public string BankActiveStatus { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Guid ID { get; set; }
        public bool IsAllowSendMail { get; set; }
        public string BankGroup { get; set; }
        public string BankNickName { get; set; }
    }
}