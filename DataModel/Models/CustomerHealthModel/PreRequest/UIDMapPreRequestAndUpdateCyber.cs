using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.CustomerHealthModel.PreRequest
{
    public class UIDMapPreRequestAndUpdateCyber
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
        public string NCBGrade { get; set; }
        public int NCBScore { get; set; }
        public string T01OnlineID { get; set; }
        public bool IsSuccessNDID { get; set; }
        public string T01OnlineIDStep { get; set; }
        public bool IsSuccessNCB { get; set; }
        public string NCBTransactionID { get; set; }

    }
}