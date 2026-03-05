using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;


namespace DataModel.Models.FACenter
{
    public class UIDMapDIPROMModel
    {
        [AlphaFormatValidateField] public Guid Id { get; set; }

        [Required][AlphaFormatValidateField] public string Uid { get; set; }

        [AlphaFormatValidateField] public string EventCode { get; set; }

        [AlphaFormatValidateField] public string EventName { get; set; }

        [Required][AlphaFormatValidateField] public string IdentityCard { get; set; }

        public bool Status { get; set; }

        [AlphaFormatValidateField] public DateTime CreatedDate { get; set; }

        [AlphaFormatValidateField] public string CreatedBy { get; set; }

        [AlphaFormatValidateField] public DateTime UpdatedDate { get; set; }

        [AlphaFormatValidateField] public string UpdateBy { get; set; }

        public bool IsAcceptConsent { get; set; }

        [AlphaFormatValidateField] public string IsPartnerData { get; set; }

        [AlphaFormatValidateField] public string IsPartnerKey { get; set; }

        public string OtpDummyId { get; set; }

        public bool IsRegisterSuccess { get; set; }

        public string ContactTitleName { get; set; }

        public string ContactName { get; set; }

        public string ContactSurname { get; set; }

        public string ContactCompanyName { get; set; }

        public string MobileSentOTP { get; set; }
        public int ID { get; set; }
        public string BankID { get; set; }
        public int PersonType { get; set; }
        public int EstablishmentType { get; set; }
        public int YearIncorporate { get; set; }
        public int IndustryCode { get; set; }
        public string ProvinceCode { get; set; }
        public int OwnerAge { get; set; }
        public int MaritalStatus { get; set; }
        public int YearExperience { get; set; }
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
        public decimal LoanAmount { get; set; }
        public string CustomerName { get; set; }
        public string Card_ID { get; set; }
        public string SpouseName { get; set; }
        public string Card_ID_Spouse { get; set; }
        public string MDName { get; set; }
        public string Card_ID_MD { get; set; }
        public string ShareHolderName { get; set; }
        public string Card_ID_ShareHolder { get; set; }
        public string BusinessType { get; set; }
        public string MobileNo { get; set; }
        public string importFileID { get; set; }
        public int CreditStatus { get; set; }
        public int HealthCheckStatus { get; set; }
        public int AMLStatus { get; set; }
        public int GradeClaimStatus { get; set; }
        public int Req_IsRegisterSuccess { get; set; }
        public int SendEmailStatus { get; set; }
        public int IsApprove { get; set; }
        public int Req_CreditStatus { get; set; }
        public string Req_CreditStatus_Des { get; set; }
        public int Req_HealthCheckStatus { get; set; }
        public string Req_HealthCheckStatus_Des { get; set; }
        public int Req_AMLStatus { get; set; }
        public string Req_AMLStatus_Des { get; set; }
        public int Req_GradeClaimStatus { get; set; }
        public int Req_IsRegisterSuccessJoin { get; set; }
        public string Req_IsRegisterSuccess_Desc { get; set; }
        public int Req_SendEmailStatus { get; set; }
        public string Req_SendEmailStatus_Des { get; set; }
        public int Req_IsApprove { get; set; }
        public string Req_IsApprove_Desc { get; set; }
        public string Req_Bank_1_Send_Email { get; set; }

    }

    public class Request_UIDMapDIPROMModel
    {
        public Guid Id { get; set; }

        public string Uid { get; set; }

        public string IdentityCard { get; set; }

        public bool Status { get; set; }

        public string OtpDummyID { get; set; }

        public bool IsRegisterSuccess { get; set; }

        public string MobileSentOTP { get; set; }

    }

    public class Request_ImportRequest
    {
        public Guid Id { get; set; }
        public int IsRegisterSuccess { get; set; }
        public int Req_Id { get; set; }
        public int Req_CreditStatus { get; set; }
        public string Req_CreditStatus_Des { get; set; }
        public int Req_HealthCheckStatus { get; set; }
        public string Req_HealthCheckStatus_Des { get; set; }
        public int Req_AMLStatus { get; set; }
        public string Req_AMLStatus_Des { get; set; }
        public int Req_GradeClaimStatus { get; set; }
        public int Req_IsRegisterSuccess { get; set; }
        public string Req_IsRegisterSuccess_Desc { get; set; }
        public int Req_SendEmailStatus { get; set; }
        public string Req_SendEmailStatus_Des { get; set; }
        public int Req_IsApprove { get; set; }
        public string Req_IsApprove_Desc { get; set; }

    }

    //New Mobdel Phase2
    public class UidDataProfile
    {
        public Guid Diprom_Id { get; set; }

        public string Uid { get; set; }

        public string EventCode { get; set; }

        public bool Status { get; set; }

        public bool Diprom_IsRegisterSuccess { get; set; }

        public string ContactTitleName { get; set; }

        public string ContactName { get; set; }

        public string ContactSurname { get; set; }

        public string ContactCompanyName { get; set; }

        public bool IsContactClinic { get; set; }

        public bool IsContactFA { get; set; }

        public int? Req_ID { get; set; }

        public int? RowNo { get; set; }

        public int? PersonType { get; set; }

        public int? EstablishmentType { get; set; }

        public int? YearIncorporate { get; set; }

        public int? IndustryCode { get; set; }

        public string ProvinceCode { get; set; }

        public int? OwnerAge { get; set; }

        public int? MaritalStatus { get; set; }

        public int? YearExperience { get; set; }

        public string Card_ID { get; set; } = null;

        public string BusinessType { get; set; } = null;

        public string MobileNo { get; set; }

        public string BankID1 { get; set; } = null;

        public decimal LoanAmount { get; set; } = 0;

    }

    public class CustomerProfileFAInfoDiprom
        {
            public CustomerProfileFAInfoDiprom()
            {
                EN_Id = string.Empty;
                CustomerTCGCode = string.Empty;
                UserFirstName = string.Empty;
                UserLastName = string.Empty;
                IdCard = string.Empty;
                EmailAddress = string.Empty;
                Address = string.Empty;
                TitleName = "007";
                Fax = string.Empty;
                Amphur = string.Empty;
                Tumbon = string.Empty;
                Province = string.Empty;
                CompanyName = string.Empty;
                TypeProductOrService = string.Empty;
                Tel = string.Empty;
                ZipCode = string.Empty;
                CompanyName = string.Empty;
                CompanyName = string.Empty;
                LineId = string.Empty;
                FormatService = -1;
                TypeCompany = -1;
                IsMember_Remark = string.Empty;
                PositionInCompany = -1;
                Status_CustomerTCG = -1;
            }

            public int Id { get; set; }

            public string EN_Id { get; set; }

            public bool IsCustomerTCG { get; set; }

            public string CustomerTCGCode { get; set; }

            [Required][AlphaFormatValidateField] public string IdCard { get; set; }

            [Required][AlphaFormatValidateField] public string TitleName { get; set; }

            [Required][AlphaFormatValidateField] public string UserFirstName { get; set; }

            [Required][AlphaFormatValidateField] public string UserLastName { get; set; }

            [Required][AlphaFormatValidateField] public string CompanyName { get; set; }

            public string TypeProductOrService { get; set; }

            public string Address { get; set; }

            public string Tumbon { get; set; }

            public string Amphur { get; set; }

            public string Province { get; set; }

            public string Tel { get; set; }

            public string ZipCode { get; set; }

            public int FormatService { get; set; }

            public int TypeCompany { get; set; }

            public bool IsMember { get; set; }

            public string IsMember_Remark { get; set; }

            public int Status_CustomerTCG { get; set; }

            public int Business_CountAge { get; set; }

            public int Business_CountEmployee { get; set; }

            public int Business_Location { get; set; }

            public string Business_Location_Remark { get; set; }

            public int PositionInCompany { get; set; }

            [AlphaFormatValidateField] public string Fax { get; set; }

            public string EmailAddress { get; set; }

            public string Mobile { get; set; }

            public string LineId { get; set; }

            public string Line_UserId { get; set; }

            public string Remark { get; set; }

            public string CreateBy { get; set; }

            public string CreateByName { get; set; }

            public DateTime CreateDate { get; set; }

            public string ModifyBy { get; set; }

            public string ModifyByName { get; set; }

            public DateTime ModifyDate { get; set; }
        }

    public class UpdateTransConsultFA
    {
        public Guid Id { get ; set; }

        public string Uid { get; set; }

        public bool? IsContactClinic { get; set; }

        public int? TransContactClinic { get; set; }

        public bool? IsContactFA { get; set; }

        public int? TransContactFA { get; set;

        }
    }

    public class DipromImportRequest
    {
        public int ID { get; set; }

        public int Req_IsRegisterSuccess { get; set; }

        public int Req_IsApprove { get; set; }

        public string ID_Check { get; set; }
    }

}
