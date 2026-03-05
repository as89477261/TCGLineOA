using System;

namespace DataModel.Models.CustomerHealthModel
{
    public class ApprochMapBankModel
    {
        [AlphaFormatValidateField] public string ID { get; set; }

        [AlphaFormatValidateField] public string ApprochID { get; set; }

        [AlphaFormatValidateField] public string BankCode { get; set; }

        [AlphaFormatValidateField] public bool status { get; set; }

        [AlphaFormatValidateField] public string CreatedBy { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreatedTime { get; set; }

        [AlphaFormatValidateField] public string ApprochBody { get; set; }

        [AlphaFormatValidateField("email")] public string BankEmail { get; set; }

        [AlphaFormatValidateField] public string BankName { get; set; }
    }
}