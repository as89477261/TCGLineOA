using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.FACenter
{
    public class UIDMapFAEventModel
    {
        [Required] [AlphaFormatValidateField] public string UID { get; set; }

        [Required] [AlphaFormatValidateField] public string EventCode { get; set; }

        [Required] [AlphaFormatValidateField] public string IDCard { get; set; }

        [AlphaFormatValidateField] public bool Status { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreatedDate { get; set; }

        [AlphaFormatValidateField] public string CreatedBy { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime UpdatedDate { get; set; }

        [AlphaFormatValidateField] public string UpdatedBy { get; set; }
    }
}