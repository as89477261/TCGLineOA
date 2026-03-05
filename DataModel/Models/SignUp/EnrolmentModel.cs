using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.SignUp
{
    public class EnrolmentModel
    {
        [AlphaFormatValidateField] public string ID { get; set; }

        [AlphaFormatValidateField] public string BusinessType { get; set; }

        [AlphaFormatValidateField] public string CompanyName { get; set; }

        [Required] [AlphaFormatValidateField] public string FirstName { get; set; }

        [Required] [AlphaFormatValidateField] public string LastName { get; set; }

        [AlphaFormatValidateField] public string Position { get; set; }

        [AlphaFormatValidateField("phone")] public string Phone { get; set; }

        [Required]
        [AlphaFormatValidateField("phone")]
        public string MobilePhone { get; set; }

        [AlphaFormatValidateField("email")] public string Email { get; set; }

        [AlphaFormatValidateField] public bool Status { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreatedDate { get; set; }

        [AlphaFormatValidateField] public string CreatedBy { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime UpdatedDate { get; set; }

        [AlphaFormatValidateField] public string UpdatedBy { get; set; }

        [AlphaFormatValidateField] public string EventCode { get; set; }

        [Required] [AlphaFormatValidateField] public string IdentityID { get; set; }

        [Required] [AlphaFormatValidateField] public string IdentityType { get; set; }

        [Required]
        [AlphaFormatValidateField("laserid")]
        public string LaserID { get; set; }

        [AlphaFormatValidateField] public string TitleCode { get; set; }

        [AlphaFormatValidateField] public string TitleName { get; set; }

        [AlphaFormatValidateField] public string DummyID { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime? BirthDay { get; set; }
    }
}