using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.FACenter
{
    public class UIDMapTransactionModel
    {
        [AlphaFormatValidateField] public string ID { get; set; }

        [Required] [AlphaFormatValidateField] public string UID { get; set; }

        [Required] [AlphaFormatValidateField] public string TransactionID { get; set; }

        [AlphaFormatValidateField] public string Status { get; set; }

        [AlphaFormatValidateField("datetime")] public string CreateDate { get; set; }

        [AlphaFormatValidateField] public string CreateBy { get; set; }
    }
}