using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.CustomerHealthModel.PreRequest
{
    public class UIDMapNDIDPreRequestHistory
    {
        [AlphaFormatValidateField] public string ID { get; set; }

        [Required] [AlphaFormatValidateField] public string UID { get; set; }

        [AlphaFormatValidateField] public string NCBResultID { get; set; }

        [AlphaFormatValidateField] public bool Status { get; set; }

        [AlphaFormatValidateField] public string StepName { get; set; }

        [AlphaFormatValidateField] public string StepNumber { get; set; }

        [AlphaFormatValidateField] public string PreRequestID { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreatedDate { get; set; }

        [AlphaFormatValidateField] public string CreatedBy { get; set; }

        [AlphaFormatValidateField] public string NDIDReferenceID { get; set; }
    }
}