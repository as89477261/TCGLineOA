using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.CustomerHealthModel.EventsModel
{
    public class FormEventRegisterInputModel
    {
        [Required] [AlphaFormatValidateField] public string UID { get; set; }

        [Required] [AlphaFormatValidateField] public string EventCode { get; set; }

        //Step 1
        [Required] [AlphaFormatValidateField] public string BusinessType { get; set; }

        [Required] [AlphaFormatValidateField] public string BusinessName { get; set; }

        [Required] [AlphaFormatValidateField] public string FirstName { get; set; }

        [Required] [AlphaFormatValidateField] public string LastName { get; set; }

        [Required] [AlphaFormatValidateField] public string Position { get; set; }

        [Required]
        [AlphaFormatValidateField("phone")]
        public string Phone { get; set; }

        [Required]
        [AlphaFormatValidateField("email")]
        public string Email { get; set; }

        // Step 2
        [AlphaFormatValidateField] public string BusinessNature { get; set; }

        [AlphaFormatValidateField] public string BusinessProvince { get; set; }

        [AlphaFormatValidateField] public int CompanyAge { get; set; }

        [AlphaFormatValidateField] public decimal IncomePerYear { get; set; }

        [AlphaFormatValidateField] public string StatementBank { get; set; }

        [AlphaFormatValidateField] public string Branch { get; set; }

        [AlphaFormatValidateField] public string Purpose { get; set; }

        [AlphaFormatValidateField] public decimal LoanMoney { get; set; }

        [AlphaFormatValidateField] public string HaveMainBank { get; set; }

        [AlphaFormatValidateField] public string HaveMainBankSelectBank { get; set; }

        [AlphaFormatValidateField] public string HaveAssetGarantee { get; set; }

        [AlphaFormatValidateField] public string HaveAssetGaranteeValue { get; set; }

        [AlphaFormatValidateField] public string PurpostFromBank { get; set; }

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

        public QuestionaireAnswer GenerateQuestionAnswer()
        {
            var buffer = new QuestionaireAnswer();
            buffer.EventCode = EventCode;
            buffer.Q1 = BusinessNature;
            buffer.Q2 = BusinessProvince;
            buffer.Q3 = CompanyAge.ToString();
            buffer.Q4 = IncomePerYear.ToStringWithEmpty();
            buffer.Q5 = StatementBank;
            buffer.Q6 = Branch;
            buffer.Q7 = Purpose;
            buffer.Q8 = LoanMoney.ToStringWithEmpty();
            buffer.Q9 = HaveMainBank;
            buffer.Q10 = HaveMainBankSelectBank;
            buffer.Q11 = HaveAssetGarantee;
            buffer.Q12 = HaveAssetGaranteeValue;
            buffer.Q13 = PurpostFromBank;
            return buffer;
        }
    }
}