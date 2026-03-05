using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.FACenter
{
    public class UIDMapDeptModel
    {
        [AlphaFormatValidateField] public Guid Id { get; set; }

        [Required] [AlphaFormatValidateField] public string Uid { get; set; }

        [AlphaFormatValidateField] public string EventCode { get; set; }

        [AlphaFormatValidateField] public string EventName { get; set; }

        [Required][AlphaFormatValidateField] public string IdentityCard { get; set; }

        public bool Status { get; set; }

        [AlphaFormatValidateField] public DateTime CreatedDate { get; set; }

        [AlphaFormatValidateField] public string CreatedBy { get; set; }

        [AlphaFormatValidateField] public DateTime UpdateDate { get; set; }

        [AlphaFormatValidateField] public string UpdatedBy { get; set; }

        public bool IsAcceptConsent { get; set; }

        [AlphaFormatValidateField] public string IsDebtDCSEvent {  get; set; }

        [AlphaFormatValidateField] public string IsDebtDCS_Id { get; set; }

        public string DummyID { get; set; }

        public bool IsRegisterSuccess { get; set; }

        public string TransIDCompromise { get; set; }

        public string TransIDConsult { get; set; }

    }
}
