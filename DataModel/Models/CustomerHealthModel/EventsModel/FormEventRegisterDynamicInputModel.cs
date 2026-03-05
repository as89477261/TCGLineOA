using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.CustomerHealthModel.EventsModel
{
    public class FormEventRegisterDynamicInputModel
    {
        [Required] [AlphaFormatValidateField] public string UID { get; set; }

        [Required] [AlphaFormatValidateField] public string EventCode { get; set; }

        //Step 1

        [Required] [AlphaFormatValidateField] public string BusinessType { get; set; }

        [Required] [AlphaFormatValidateField] public string BusinessName { get; set; }

        [Required] [AlphaFormatValidateField] public string FirstName { get; set; }

        [Required] [AlphaFormatValidateField] public string LastName { get; set; }

        [AlphaFormatValidateField] public string Position { get; set; }

        [Required]
        [AlphaFormatValidateField("phone")]
        public string Phone { get; set; }

        [Required]
        [AlphaFormatValidateField("email")]
        public string Email { get; set; }

        // Step 2       
        [AlphaFormatValidateField("partial")] public string Q1 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q2 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q3 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q4 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q5 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q6 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q7 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q8 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q9 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q10 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q11 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q12 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q13 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q14 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q15 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q16 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q17 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q18 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q19 { get; set; }

        [AlphaFormatValidateField("partial")] public string Q20 { get; set; }

        public PersonalInfoModel GeneratePersonalInfo()
        {
            var buffer = new PersonalInfoModel();
            buffer.BusinessType = BusinessType;
            buffer.CompanyName = BusinessName;
            buffer.FirstName = FirstName;
            buffer.LastName = LastName;
            buffer.Email = Email;
            buffer.Position = Position;
            buffer.Phone = Phone;
            buffer.EventCode = EventCode;

            return buffer;
        }
    }
}