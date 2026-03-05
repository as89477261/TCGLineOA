using CustomerHealthModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerHealthModel
{
    public class RegisterInfo
    {
        public PersonType personType;               /* กิจการคุณจดทะเบียนรูปแบบใด */
        public EstablishmentType officeType;        /* กรรมสิทธิ์ของสถานที่ประกอบกิจการ */
        public int yearIncorporate;                 /* ก่อตั้งกิจการมาแล้ว (กี่ปี) */
        public string industryCode;                 /* ประเภทกิจการของคุณ คือ */
        public string provinceCode;                 /* กิจการของคุณตั้งอยู่ที่จังหวัด */
        public string regionCode;                   /* กิจการของคุณตั้งอยู่ที่ภาค */
        public int ownerAge;                        /* ผู้บริหารหลักอายุ (กี่ปี) */
        public MaritalType maritalStatus;           /* สถานะภาพการสมรสของผู้บริหารหลัก */
        public int yearExperience;                  /* ประสบการณ์โดยตรงในการทําธุรกิจนี้ */
        public DebtStatusType debtStatus;           /* สถานะหนี้ของกิจการ */
        public int TdrAmount;                       /* จำนวน (ครั้งที่ปรับโครงสร้างหนี้) */
        public int TdrYear;                         /* ล่าสุดปีพ.ศ.(ที่ปรับโครงสร้างหนี้) */
        public double assetValue;                   /* มูลค่าสินทรัพย์รวมของกิจการ (ล้านบาท) */
        public double debtValue;                    /* หนี้สินรวมของกิจการ (ล้านบาท) */
        public double income;                       /* รายได้รวมของกิจการ (ต่อเดือน) */
        public double expense;                      /* กิจการคุณมีค่าใช้จ่าย (ต่อเดือน) */
        public double installmentAmount;            /* ภาระหนี้ที่ต้องผ่อนชําระ (ต่อเดือน) */
        public IsGetProfit isGetProfit;             /* 3 ปีที่ผ่านมา กิจการคุณมีรายได้เพิ่มขึ้น */
        //public ObjectiveTerm objectiveTerm;       /* วัตถุประสงค์ในการขอสินเชื่อ */
        public int objectiveTerm;                   /* วัตถุประสงค์ในการขอสินเชื่อ */
        public double loanAmount;                   /* วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ (บาท) */
        public int yearInstallment;                 /* ระยะเวลาในการผ่อนชําระที่คุณต้องการ (ปี) */
        public int id;                              /* ID ที่ insert เข้าระบบ */
        public int consent;                         /* เก็บหน้าสุดท้ายว่าลูกค้ายินยอมเปิดเผยข้อมูลส่วนบุคคลหรือเปล่า */
        public string requestNo;                    /* เลขใบคำขอใน clinic online */
        //public EventType eventType;               /* ที่มาของการติดต่อ */
        public int eventType;                       /* ที่มาของการติดต่อ */
        public double CostSale;                     /* ต้นทุนขาย */
        public string LoanType;                     /* ประเภทของวงเงินสินเชื่อที่ต้องการ */
        public double DSCR;                         // DSCR

        public double LoanLCTR;
        public double LoanLG;
        public double LoanPN;
        public double LoanOD;
        public double LoanTL;
        public double LoanOther;

        public double LandAsset;

        public double TCGScoreRBP;
        public int TCGScoreTotalScore;
        public string TCGScoreBand;
        public int TCGScoreBandLevel;


        public int? IsPassCreditBureau;
        public int? CreditBureauLevel;

        public bool IsPassProductCriteria;
        public double SumAsset;

        /* ข้อมูลเพิ่มเติมเพื่อลงทะเบียน */
        public string title;                        /* คำนำหน้า */
        public string name;                         /* ชื่อ */
        public string surname;                      /* นามสกุล */
        public string businessName;                 /* ชื่อกิจการ */
        public string phone;                        /* เบอร์โทร */
        public string idCard;                       /* เลขประชาชน เลขนิติบุคคล */
        public string remark;                       /* หมายเหตุ */

        public string uid;                          /* Line UID */


        public TCGScoreModel ConvertToTCGScorePersonalModel()
        {
            var obj = new TCGScoreModel();
            obj.management_age = this.ownerAge;
            obj.experience_Direc = this.yearExperience;
            obj.credit_Buro_Approved = (this.IsPassCreditBureau.HasValue == true ? this.IsPassCreditBureau.Value : 1);
            obj.region_code = this.regionCode;
            obj.industry_Group_code = this.industryCode;
            obj.loan_Amount = this.loanAmount;
            obj.asset_Amount = this.SumAsset;//this.assetValue - (this.LandAsset);
            obj.annual_NetincomeScore = this.income * 12;
            obj.dscr = this.DSCR;
            return obj;
        }

        public TCGScoreModel ConvertToTCGScoreCorporateModel()
        {
            var obj = new TCGScoreModel();
            obj.year_commencement = ((DateTime.Now.Year) - this.yearIncorporate).ToString();
            obj.industry_Group_code = this.industryCode;
            obj.experience_Direc = this.yearExperience;
            obj.loan_Amount = this.loanAmount;
            obj.loan_term = this.yearInstallment;
            obj.dscr = this.DSCR;
            obj.region_code = this.regionCode;

            return obj;
        }

        public void BindingTCGScoreModel(TCGScoreResponseModel obj)
        {

            this.TCGScoreRBP = obj.data.riskBasePricing;
            this.TCGScoreTotalScore = obj.data.total_Score;
            this.TCGScoreBand = obj.data.score_Band;
            this.TCGScoreBandLevel = (obj.data.score_Band != null ? int.Parse(obj.data.score_Band.Replace("B", "")) : 0);

        }
    }


}