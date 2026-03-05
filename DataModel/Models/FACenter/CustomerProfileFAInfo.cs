using System;
using System.ComponentModel.DataAnnotations;

namespace DataModels.FACenter
{
    public class CustomerProfileFAInfo
    {
        public CustomerProfileFAInfo()
        {
            EN_Id = string.Empty;
            CustomerTCGCode = string.Empty;
            UserFirstName = string.Empty;
            UserLastName = string.Empty;
            IdCard = string.Empty;
            EmailAddress = string.Empty;
            Address = string.Empty;
            TitleName = "001";
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

        [AlphaFormatValidateField] public int Id { get; set; }

        [AlphaFormatValidateField] public string EN_Id { get; set; }

        [AlphaFormatValidateField] public bool IsCustomerTCG { get; set; }

        [AlphaFormatValidateField] public string CustomerTCGCode { get; set; }

        [Required] [AlphaFormatValidateField] public string IdCard { get; set; }

        [Required] [AlphaFormatValidateField] public string TitleName { get; set; }

        [Required] [AlphaFormatValidateField] public string UserFirstName { get; set; }

        [Required] [AlphaFormatValidateField] public string UserLastName { get; set; }

        [Required] [AlphaFormatValidateField] public string CompanyName { get; set; }

        [AlphaFormatValidateField] public string TypeProductOrService { get; set; }

        [AlphaFormatValidateField] public string Address { get; set; }

        [AlphaFormatValidateField] public string Tumbon { get; set; }

        [AlphaFormatValidateField] public string Amphur { get; set; }

        [AlphaFormatValidateField] public string Province { get; set; }

        [AlphaFormatValidateField("phone")] public string Tel { get; set; }

        [AlphaFormatValidateField] public string ZipCode { get; set; }

        [AlphaFormatValidateField] public int FormatService { get; set; }

        [AlphaFormatValidateField] public int TypeCompany { get; set; }

        [AlphaFormatValidateField] public bool IsMember { get; set; }

        [AlphaFormatValidateField] public string IsMember_Remark { get; set; }

        [AlphaFormatValidateField] public int Status_CustomerTCG { get; set; }

        [AlphaFormatValidateField] public int Business_CountAge { get; set; }

        [AlphaFormatValidateField] public int Business_CountEmployee { get; set; }

        [AlphaFormatValidateField] public int Business_Location { get; set; }

        [AlphaFormatValidateField] public string Business_Location_Remark { get; set; }

        [AlphaFormatValidateField] public int PositionInCompany { get; set; }

        [AlphaFormatValidateField] public string Fax { get; set; }

        [AlphaFormatValidateField("email")] public string EmailAddress { get; set; }

        [AlphaFormatValidateField("phone")] public string Mobile { get; set; }

        [AlphaFormatValidateField] public string LineId { get; set; }

        [AlphaFormatValidateField] public string Line_UserId { get; set; }

        [AlphaFormatValidateField] public string Remark { get; set; }

        [AlphaFormatValidateField] public string CreateBy { get; set; }

        [AlphaFormatValidateField] public string CreateByName { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreateDate { get; set; }

        [AlphaFormatValidateField] public string ModifyBy { get; set; }

        [AlphaFormatValidateField] public string ModifyByName { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime ModifyDate { get; set; }
    }
}