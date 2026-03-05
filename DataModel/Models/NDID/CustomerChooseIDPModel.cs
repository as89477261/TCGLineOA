using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.NDID
{
    public class CustomerChooseIDPModel
    {
        [AlphaFormatValidateField] public string ID { get; set; }

        [Required] [AlphaFormatValidateField] public string UID { get; set; }

        [AlphaFormatValidateField] public string IDPVerifyStatus { get; set; }

        [AlphaFormatValidateField] public string IDPVerifyRemark { get; set; }

        [AlphaFormatValidateField] public string IDPCode { get; set; }

        [AlphaFormatValidateField] public string IDPName { get; set; }

        [AlphaFormatValidateField] public bool Status { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreatedDate { get; set; }

        [AlphaFormatValidateField] public string CreatedBy { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime UpdatedDate { get; set; }

        [AlphaFormatValidateField] public string UpdatedBy { get; set; }

        [AlphaFormatValidateField] public string TransactionID { get; set; }
    }
}