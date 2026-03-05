using System;

namespace DataModels.FACenter
{
    public class MainTransectionInfo
    {
        public MainTransectionInfo()
        {
            TCGRequestDate = default;
            ResultOfBank_Date = default;
        }

        public int ApplicationId { get; set; }
        public int Id { get; set; }
        public int CustomerProfileId { get; set; }
        public int No { get; set; }
        public string FA_Ref { get; set; }
        public int Line_FA_Id { get; set; }
        public int ChannelId { get; set; }
        public int ConsultantId { get; set; }
        public string Consultant_Email { get; set; }
        public string AConsultantId { get; set; }

        public string Employee_Owner { get; set; }
        public int CurrentStatusId_MainLevel { get; set; }
        public int CurrentStatusId { get; set; }
        public DateTime StatusDateTime { get; set; }
        public string ForwardToBank { get; set; }
        public int ForwardMethod { get; set; }
        public decimal TotalMoneyOfBank { get; set; }
        public int ResultOfBank { get; set; }
        public DateTime ResultOfBank_Date { get; set; }
        public decimal LoanRequest { get; set; }
        public decimal LoadOfTCG { get; set; }
        public decimal LoanApprove { get; set; }

        public decimal LoanRequest_Another { get; set; }
        public decimal LoanRequest_DebtStructure { get; set; }
        public string TCG_OnlineID { get; set; }
        public string TCG_LGNumber { get; set; }
        public string ManualIDCard { get; set; }
        public DateTime TCGRequestDate { get; set; }
        public string Remark { get; set; }
        public string StatusName { get; set; }
        public string ReasonName { get; set; }
        public string ConsultantName { get; set; }
        public string AConsultantName { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public int RequestTitle_Id { get; set; }
        public string RequestTitle_Another { get; set; }
        public string Request_Body { get; set; }
        public string Remark_Consult { get; set; }
        public string Remark_Employee { get; set; }
        public bool IsOK_RequestLoan { get; set; }
        public string ResultToBank { get; set; }
        public decimal ResultOfBank_Money { get; set; }
        public bool IsOK_DebtStructure { get; set; }
        public bool IsOK_Recommend { get; set; }
        public int IsOK_Recommend_Id { get; set; }
        public bool IsOK_Another { get; set; }
        public string IsOK_Another_Remark { get; set; }
        public int Status_Consult { get; set; }
        public string CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string IdCard { get; set; }
        public string Mobile { get; set; }
    }
}