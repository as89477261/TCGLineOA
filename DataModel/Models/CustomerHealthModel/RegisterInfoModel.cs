using System;

namespace DataModel.Models.CustomerHealthModel
{
    public class RegisterInfoModel
    {
        public string Uid { get; set; }
        public int RegisterInfoID { get; set; }
        public string Channel { get; set; }
        public int ID { get; set; }
        public int PersonType { get; set; }
        public string personTypeName { get; set; }
        public int EstablishmentType { get; set; }
        public int YearIncorporate { get; set; }
        public int IndustryCode { get; set; }
        public string ProvinceCode { get; set; }
        public string RegionCode { get; set; }
        public int OwnerAge { get; set; }
        public int MaritalStatus { get; set; }
        public int YearExperience { get; set; }
        public int DebtStatus { get; set; }
        public int TdrAmount { get; set; }
        public int TdrYear { get; set; }
        public decimal AssetValue { get; set; }
        public decimal DebtValue { get; set; }
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
        public decimal InstallmentAmount { get; set; }
        public int IsGetProfit { get; set; }
        public int ObjectiveTerm { get; set; }
        public decimal LoanAmount { get; set; }
        public int YearInstallment { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BusinessName { get; set; }
        public string Phone { get; set; }
        public string IdCard { get; set; }
        public string Remark { get; set; }
        public int Score { get; set; }
        public int ScoreGroup { get; set; }
        public string GroupShortDesc { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ClinicCustomerCode { get; set; }
        public string ClinicRequestNo { get; set; }
        public int IsActive { get; set; }
        public int IsAcceptConsent { get; set; }
        public string Event { get; set; }
        public string ImageScore { get; set; }
        public string GroupDesc { get; set; }
        public string DebtStatusName { get; set; }
        public string FieldName { get; set; }
        public string TitleName { get; set; }

        public decimal CostSale { get; set; } /* ต้นทุนขาย */
        public string LoanType { get; set; } /* ประเภทของวงเงินสินเชื่อที่ต้องการ */
        public decimal DSCR { get; set; } // DSCR

        public decimal LoanLCTR { get; set; }
        public decimal LoanLG { get; set; }
        public decimal LoanPN { get; set; }
        public decimal LoanOD { get; set; }
        public decimal LoanTL { get; set; }
        public decimal LoanOther { get; set; }

        public decimal LandAsset { get; set; }

        public decimal TCGScoreRBP { get; set; }
        public int TCGScoreTotalScore { get; set; }
        public string TCGScoreBand { get; set; }
        public int TCGScoreBandLevel { get; set; }


        public int? IsPassCreditBureau { get; set; }
        public int? CreditBureauLevel { get; set; }

        public bool IsPassProductCriteria { get; set; }
        public decimal SumAsset { get; set; }


        public int StatusID { get; set; }
        public DateTime StatusCreated { get; set; }
        public string StatusName { get; set; }
        public int StatusCategoryID { get; set; }
        public int StatusLevelID { get; set; }
        public bool StatusEndLevel { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BranchEmail { get; set; }
        public string BranchPhone { get; set; }
    }
}