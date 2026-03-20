using System;
using System.Web.UI;

namespace CustomerHealthCheck.views.hora
{
    public partial class index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //public void Start()
        //{
        //    string[] result;


        //}


        //private void CheckPurpleProgram(
        //     decimal MonthlyDebtPayment,     // ภาระหนี้ต่อเดือน
        //     decimal MonthlyRepaymentCapacity, // ความสามารถในการชำระหนี้ต่อเดือน
        //     decimal UpFrontAmount,            // เงินดาวน์/Up Front (จำนวนเงิน)
        //     decimal LoanAmount,
        //     out string[] result)
        //{
           
        //    // 1. เงินต้นเกิน 200,000
        //    if (LoanAmount <= 200000)
        //    {
        //        result.Reason = "เงินต้นต้องเกิน 200,000 บาท";
        //        return result;
        //    }

        //    // 2. ไม่มีชำระเงินต่อเดือน
        //    if (upFrontPercent > 0)
        //    {
        //        result.Reason = "ต้องไม่มีการชำระเงินดาวน์ (Up Front = 0%)";
        //        return result;
        //    }

        //    // 3. ตรวจสอบอัตราส่วนหนี้
        //    decimal totalRepayment = applicant.MonthlyRepaymentCapacity * 84;
        //    decimal totalDebt = applicant.MonthlyDebtPayment * 84;

        //    if (totalDebt == 0)
        //    {
        //        result.IsEligible = true;
        //        result.Reason = "ผ่านเงื่อนไข (ไม่มีภาระหนี้)";
        //        return result;
        //    }

        //    decimal debtRatio = (totalRepayment / totalDebt) * 100;

        //    if (debtRatio <= 30)
        //    {
        //        result.Reason = $"อัตราส่วนหนี้ {debtRatio:F2}% ต้องมากกว่า 30%";
        //        return result;
        //    }

        //    result.IsEligible = true;
        //    result.Reason = $"ผ่านเงื่อนไข (อัตราส่วนหนี้ {debtRatio:F2}%)";
        //    return result;
        //}
    }
}
