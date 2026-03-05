using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.CustomerHealthModel.PreRequest
{
    public class UIDMapNDIDPreRequest
    {
        [AlphaFormatValidateField("id")] public Guid ID { get; set; }

        [Required] [AlphaFormatValidateField] public string UID { get; set; }

        [AlphaFormatValidateField("ndidrefid")]
        public string NDIDReferenceID { get; set; }

        [AlphaFormatValidateField] public string NCBResultID { get; set; }

        [Required] [AlphaFormatValidateField] public string StepName { get; set; }

        [AlphaFormatValidateField] public string StepNumber { get; set; }

        [AlphaFormatValidateField] public bool IsSuccessNDID { get; set; }

        [AlphaFormatValidateField] public bool Status { get; set; }

        [AlphaFormatValidateField] public string T01OnlineID { get; set; }

        [AlphaFormatValidateField] public string T01OnlineIDStep { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreatedDate { get; set; }

        [AlphaFormatValidateField] public string CreatedBy { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime UpdatedDate { get; set; }

        [AlphaFormatValidateField] public string UpdatedBy { get; set; }

        [AlphaFormatValidateField] public string NCBTransactionID { get; set; }

        [AlphaFormatValidateField] public string PersonalChooseBank { get; set; }
    }
}