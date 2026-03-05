using System;

public class RegisterInfo
{
    public double assetValue; /* มูลค่าสินทรัพย์รวมของกิจการ (ล้านบาท) */
    public string businessName; /* ชื่อกิจการ */
    public int consent; /* เก็บหน้าสุดท้ายว่าลูกค้ายินยอมเปิดเผยข้อมูลส่วนบุคคลหรือเปล่า */
    public double CostSale; /* ต้นทุนขาย */
    public int? CreditBureauLevel;
    public DebtStatusType debtStatus; /* สถานะหนี้ของกิจการ */
    public double debtValue; /* หนี้สินรวมของกิจการ (ล้านบาท) */
    public double DSCR; // DSCR

    public string email;

    //public EventType eventType;               /* ที่มาของการติดต่อ */
    public int eventType; /* ที่มาของการติดต่อ */
    public double expense; /* กิจการคุณมีค่าใช้จ่าย (ต่อเดือน) */
    public int id; /* ID ที่ insert เข้าระบบ */
    public string idCard; /* เลขประชาชน เลขนิติบุคคล */
    public double income; /* รายได้รวมของกิจการ (ต่อเดือน) */
    public string industryCode; /* ประเภทกิจการของคุณ คือ */
    public double installmentAmount; /* ภาระหนี้ที่ต้องผ่อนชําระ (ต่อเดือน) */
    public IsGetProfit isGetProfit; /* 3 ปีที่ผ่านมา กิจการคุณมีรายได้เพิ่มขึ้น */


    public int? IsPassCreditBureau;

    public bool IsPassProductCriteria;

    public double LandAsset;
    public double loanAmount; /* วงเงินสินเชื่อครั้งนี้ที่คุณต้องการ (บาท) */

    public double LoanLCTR;
    public double LoanLG;
    public double LoanOD;
    public double LoanOther;
    public double LoanPN;
    public double LoanTL;
    public string LoanType; /* ประเภทของวงเงินสินเชื่อที่ต้องการ */
    public MaritalType maritalStatus; /* สถานะภาพการสมรสของผู้บริหารหลัก */

    public string name; /* ชื่อ */

    //public ObjectiveTerm objectiveTerm;       /* วัตถุประสงค์ในการขอสินเชื่อ */
    public int objectiveTerm; /* วัตถุประสงค์ในการขอสินเชื่อ */
    public EstablishmentType officeType; /* กรรมสิทธิ์ของสถานที่ประกอบกิจการ */
    public int ownerAge; /* ผู้บริหารหลักอายุ (กี่ปี) */
    public PersonType personType; /* กิจการคุณจดทะเบียนรูปแบบใด */
    public string phone; /* เบอร์โทร */
    public string provinceCode; /* กิจการของคุณตั้งอยู่ที่จังหวัด */
    public string regionCode; /* กิจการของคุณตั้งอยู่ที่ภาค */
    public string remark; /* หมายเหตุ */
    public string requestNo; /* เลขใบคำขอใน clinic online */
    public double SumAsset;
    public string surname; /* นามสกุล */
    public string TCGScoreBand;
    public int TCGScoreBandLevel;

    public double TCGScoreRBP;
    public int TCGScoreTotalScore;
    public int TdrAmount; /* จำนวน (ครั้งที่ปรับโครงสร้างหนี้) */
    public int TdrYear; /* ล่าสุดปีพ.ศ.(ที่ปรับโครงสร้างหนี้) */

    /* ข้อมูลเพิ่มเติมเพื่อลงทะเบียน */
    public string title; /* คำนำหน้า */
    public string uid; /* Line UID */
    public int yearExperience; /* ประสบการณ์โดยตรงในการทําธุรกิจนี้ */
    public int yearIncorporate; /* ก่อตั้งกิจการมาแล้ว (กี่ปี) */
    public int yearInstallment; /* ระยะเวลาในการผ่อนชําระที่คุณต้องการ (ปี) */

    public TCGScoreModel ConvertToTCGScorePersonalModel()
    {
        var obj = new TCGScoreModel
        {
            management_age = ownerAge,
            experience_Direc = yearExperience,
            credit_Buro_Approved = IsPassCreditBureau ?? 1,
            region_code = regionCode,
            industry_Group_code = industryCode,
            loan_Amount = loanAmount,
            asset_Amount = assetValue - LandAsset,
            annual_NetincomeScore = income * 12,
            dscr = DSCR
        };
        return obj;
    }

    public TCGScoreModel ConvertToTcgScoreCorporateModel()
    {
        var obj = new TCGScoreModel
        {
            year_commencement = (DateTime.Now.Year - yearIncorporate).ToString(),
            industry_Group_code = industryCode,
            experience_Direc = yearExperience,
            loan_Amount = loanAmount,
            loan_term = yearInstallment,
            dscr = DSCR
        };

        return obj;
    }

    public void BindTcgScoreModel(TCGScoreResponseModel obj)
    {
        TCGScoreRBP = obj.data.riskBasePricing;
        TCGScoreTotalScore = obj.data.total_Score;
        TCGScoreBand = obj.data.score_Band;
        TCGScoreBandLevel = obj.data.score_Band != null ? int.Parse(obj.data.score_Band.Replace("B", "")) : 0;
    }
}