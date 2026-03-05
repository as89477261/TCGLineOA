using System;
using System.ComponentModel.DataAnnotations;

namespace DataModels.FACenter
{
    public class FormRegisterFAInfo
    {
        [Required] [AlphaFormatValidateField] public string UID { get; set; }

        [AlphaFormatValidateField] [Required] public int ApplicationId { get; set; }

        [AlphaFormatValidateField] public int Id { get; set; }

        [AlphaFormatValidateField] public int CustomerProfileId { get; set; }

        [AlphaFormatValidateField] [Required] public int ChannelId { get; set; }

        [AlphaFormatValidateField] public int InputChannel { get; set; }

        [AlphaFormatValidateField] public int CurrentStatusId { get; set; }

        [AlphaFormatValidateField] public string FA_Ref { get; set; }

        [AlphaFormatValidateField] public int FA_TransectionsId { get; set; }

        [AlphaFormatValidateField] public bool IsLoanMoney { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal LoanMoney { get; set; }

        [AlphaFormatValidateField] public int ObjectiveId { get; set; }

        [AlphaFormatValidateField] public string Objective_Remark { get; set; }

        [AlphaFormatValidateField] public int IsGuarantee { get; set; }

        [AlphaFormatValidateField] public string InterestLoanOfBank { get; set; }

        [AlphaFormatValidateField] public string InterestLoanOfBank_Remark { get; set; }

        [AlphaFormatValidateField] public bool IsReDebt { get; set; }

        [AlphaFormatValidateField] public int ReDebt { get; set; }

        [AlphaFormatValidateField] public string ReDebt_Remark { get; set; }

        [AlphaFormatValidateField] public string RequestRemark { get; set; }

        [AlphaFormatValidateField] public bool IsGuideBusiness { get; set; }

        [AlphaFormatValidateField] public int GuideBusiness { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Reg_Capital { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Property_MoneyTotal { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Stock_MoneyTotal { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Debtor_MoneyTotal { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Main_IncomeOfYear { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Main_IncomeOfNewYear { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Main_ExtraOfYear { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Main_ExtraOfNewYear { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Total_EexpensesOfYear { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Total_EexpensesOfNewYear { get; set; }

        [AlphaFormatValidateField] public int IsCurrentBusiness { get; set; }

        [AlphaFormatValidateField] public string IsCurrentBusiness_Remark { get; set; }

        [AlphaFormatValidateField] public int IsCredit_Bulo { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Debt_Month { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Debt_CurrentPay_Month { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal DebtOfBank_Month { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal DebtOfBank_CurrentPay_Month { get; set; }

        [AlphaFormatValidateField("decimal")] public decimal Summary_Debt { get; set; }

        [AlphaFormatValidateField] public string CreateBy { get; set; }

        [AlphaFormatValidateField] public string CreateByName { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime CreateDate { get; set; }

        [AlphaFormatValidateField] public string ModifyBy { get; set; }

        [AlphaFormatValidateField] public string ModifyByName { get; set; }

        [AlphaFormatValidateField] public string Remark { get; set; }

        [AlphaFormatValidateField("datetime")] public DateTime ModifyDate { get; set; }

        [AlphaFormatValidateField] public bool IsActive { get; set; }

        [AlphaFormatValidateField] public string Str_Form_Register_Details1 { get; set; }

        [AlphaFormatValidateField] public string Str_Form_Register_Details2 { get; set; }

        [AlphaFormatValidateField] public bool IsDept_Recon { get; set; }

        [AlphaFormatValidateField] public int Dept_Recon_ObjectId { get; set; }

        [AlphaFormatValidateField("decimal")] public string Dept_Recon_Money { get; set; }

        [AlphaFormatValidateField] public string Dept_Recon_LG { get; set; }

        [AlphaFormatValidateField] public int RequestTitle_Id { get; set; }

        [AlphaFormatValidateField] public string RequestTitle_Another { get; set; }

        //public List<Form_Register_DetailsInfo> Form_Register_Details1 { get; set; }
        //public List<Form_Register_DetailsInfo> Form_Register_Details2 { get; set; }
    }
}